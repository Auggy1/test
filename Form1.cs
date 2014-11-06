//=====================================================================
// AUTHORS: 
//              Cycle 1: Karan Singh & Michelle Jaro
//              Cycle 2: Maxwell Partington & Ranier Limpiado     
//              Cycle 3: Jeff Henry & Augustine Garcia
// PURPOSE:     This is the main form of the program that runs all of the
//              functionality that the user requires, be it regular user
//              or admin. 
// PARAMS:      Proper execution of the .exe is the only parameter. 
// LAST UPDATE: 11/6/14
//=====================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Timers;

namespace Project_Forms
{
    public partial class Home : Form
    {
        DateTime date;// public datetime variable to transfer date between functions

        //==========================================================
        // PURPOSE: This is the main function of the program. It
        //          is what holds the intialization of the application
        //          and shows/hides all of the appropriate functions
        //          upon login/logout of both types of users. 
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //==========================================================
        public Home()
        {
            InitializeComponent();
            vr_report_label.Hide();
            //get rid of the * on the history table
            dataGridView2.AllowUserToAddRows = false;
            //comboBox2.Items.AddRange(types);//removed because getting information from XML after user logs in 10/29/2014
            ee_category_list.DropDownStyle = ComboBoxStyle.DropDownList;//set the format to dropdownlist 
            //comboBox3.Items.AddRange(types); //removed because getting information from XML after user logs in 10/29/2014
            vr_category_list.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox5.Items.AddRange(types);//removed because getting information from XML after user logs in 10/29/2014
            vh_category_list.DropDownStyle = ComboBoxStyle.DropDownList;

            //The already initialized logout button under file is not visible to the user initially
            logOutToolStripMenuItem.Visible = false;

            //ee_expense_input.MaxLength = 6;                         // Max length for an expense to be when entered

            /*************************************** Date and Time Displays *******************************************/
            ee_date_picker.MaxDate = DateTime.Now;                  // Enter Expense date picker
            vr_end_date_picker.MaxDate = DateTime.Now;              // View Reports start date picker
            vr_start_date_picker.MaxDate = DateTime.Now;            // View Reports end date picker
            vh_end_date_picker.MaxDate = DateTime.Now;              // View History start date picker
            vh_start_date_picker.MaxDate = DateTime.Now;            // View History end date picker
            date_label.Text = DateTime.Now.ToString("MM/dd/yyyy");  // Month/date/year format for program date display
            time_stamp.Text = DateTime.Now.ToString("HH:mm:ss tt"); // Time stamp
            date = DateTime.UtcNow.Date;

            System.Timers.Timer clk_timer = new System.Timers.Timer(1);     // Create a new timer
            clk_timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);     // Call OnTimedEvent with each tick
            clk_timer.Enabled = true;
            clk_timer.Start();

            /****************************************** Hidden labels/tabs ********************************************/
            welcome_msg.Hide();                                     // Hide the welcome message
            login_error_msg.Hide();
            expense_error_msg.Hide();
            label13.Hide();   
            administrationToolStripMenuItem.Visible = false;        // Hide the administration menu
            tab_control.Controls.Remove(vh_tab);                    // Remove the view history tab
            // Hide the tabs so that only the home tab is useable:
            tab_control.Appearance = TabAppearance.FlatButtons;
            tab_control.ItemSize = new Size(0, 1); 
            tab_control.SizeMode = TabSizeMode.Fixed;
            var source0 = new AutoCompleteStringCollection();

        }// end home

        //=====================================================================
        // Purpose: These functions were required because the OnTimeEvent 
        //          function comes from another thread context than the UI 
        //          thread, so we have to use a dispatcher to make it work.
        // Author:  Jeff Henry
        //=====================================================================
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.time_stamp.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else{this.time_stamp.Text = text;}
        }

        //=====================================================================
        // Purpose: Provides a dynamic clock on the UI.
        // Author:  Jeff Henry
        //=====================================================================
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string txt = DateTime.Now.ToString("HH:mm:ss tt");
            SetText(txt);
        }

        //=====================================================================
        // Purpose: Hide the login page and displays a welcome message
        // Author:  Jeff Henry
        //=====================================================================
        private void HideLogin(string user)
        {
            username_label.Hide();
            pass_label.Hide();
            login_btn.Hide();
            username_box.Hide();
            pass_box.Hide();
            welcome_msg.Text = "Welcome " + user + "!";
            welcome_msg.Show();
        }

        //=====================================================================
        // Purpose: Shows the login form and hides the welcome message
        // Author:  Jeff Henry
        //=====================================================================
        private void ShowLogin()
        {
            username_label.Show();
            pass_label.Show();
            login_btn.Show();
            username_box.Show();
            pass_box.Show();
            welcome_msg.Hide();
            username_box.Clear();
            pass_box.Clear();
        }


        //===================================================================== 
        // Purpose: Button4 is the Select button. The event is meant to confirm 
        //          the users identity by showing the users name in a text box 
        //          and taking away the ability to change it using the dropdownlist.
        //          The code also checks if the xml file exists or not by passing 
        //          a call to the Control file.
        // Inputs:  Label2.text/the selected username by the user or admin, as 
        //          well as current date:date. 
        //=====================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            Control login = new Control();
            Data userChecks = new Data();
            var source = new AutoCompleteStringCollection();
            login.createxmlfile();              
                      
            bool exists;                                // Check if user exists
            bool validPassword;                         // Check if the password is valid
            bool isAdmin = false;                       // Check if user is admin

            errorProvider1.Clear();                     // Reset errorProvider1
            errorProvider2.Clear();                     // Reset errorProvider2

            // The following if/else statements perform the proper
            // checks of the user's input to make sure they actually exist
            // in the system, they have the proper username and password,
            // and if they are an admin or not. 
            if ((username_box.Text=="") && (pass_box.Text==""))
            {
                errorProvider1.SetError(username_box, "Username must be provided.");
                errorProvider2.SetError(pass_box, "Password must be provided.");
            }
            else if ((username_box.Text== "") || (username_box.TextLength < 5))
            {
                errorProvider1.SetError(username_box, "Username must be provided.");
            }
            else if  ((pass_box.Text=="") || (pass_box.TextLength < 5))
            {
                errorProvider1.SetError(pass_box, "Password must be provided.");
            }
            else if (username_box.Text != "" && pass_box.Text != "")
            {                 
                // Perform the proper checks of the user. 
                isAdmin = userChecks.checkAdmin(username_box.Text);
                exists = userChecks.userExists(username_box.Text, isAdmin);
                validPassword = userChecks.checkUserPassword(username_box.Text, pass_box.Text);

                // Once everything is validated, we log the user 
                // into the program, and show the appropriate
                // data and buttons/labels for the specific users. 
                if (exists && validPassword)
                {
                    //welcome_msg.Text = "Welcome " + user + "!"; 
                    //welcome_msg.Show();
                    home_user_details.Text = userChecks.fillInLoginInfo(username_box.Text, isAdmin);
                    userChecks.updateLastLogin(username_box.Text, isAdmin); 
                    
                    // Make the tab controls visible:
                    tab_control.Appearance = TabAppearance.Normal;
                    tab_control.ItemSize =  new Size(20, 20);
                    tab_control.SizeMode = TabSizeMode.Normal;
                    logOutToolStripMenuItem.Visible = true;
 
                    // Handle if the user is an admin
                    if (isAdmin)
                    {
                        tab_control.SelectedTab = vr_tab;           // Change the tab to View History
                        HideLogin(username_box.Text);
                        tab_control.Controls.Add(vh_tab);
                        administrationToolStripMenuItem.Visible = true;
                    }
                    else if (!isAdmin)
                    {
                        tab_control.SelectedTab = ee_tab;
                        HideLogin(username_box.Text);
                        tab_control.Controls.Remove(vh_tab);
                    }
           
                      
                    // This call loads the categories after logging in so there needs to be a user logged in to do anything. 
                    // This list does not contain "All Categories". 
                    ee_category_list.Items.Clear();
                    ee_category_list.Items.AddRange(userChecks.addCategories().ToArray());
            
                    // This call loads the categories after logging in so there needs to be a user logged in to do anything.
                    vh_category_list.Items.Clear();//no duplicates
                    vh_category_list.Items.AddRange(login.loadCategoryList().ToArray());
                      
                    // This call loads the list of users into the comboBox on the view history tab.
                    vh_user_list.Items.Clear();//no duplicates
                    vh_user_list.Items.AddRange(login.loadUserList().ToArray());
                      
                    // This call loads the categories after logging in so there needs to be a user logged in to do anything.
                    vr_category_list.Items.Clear(); //no duplicates
                    vr_category_list.Items.AddRange(login.loadCategoryList().ToArray());
                    
                    // This adds the login history of the user. 
                    login.add_history(username_box.Text, date);
                }
                else if (exists == false)
                {
                    //MessageBox.Show("Invalid User.", "ERROR");
                    login_error_msg.Text = "User does not exist.";
                    login_error_msg.Show();
                    username_box.Clear();
                    pass_box.Clear();
                }
                else if (validPassword == false)
                {
                    //MessageBox.Show("Invalid Password.", "ERROR");
                    login_error_msg.Text = "Invalid Password. Try Again.";
                    login_error_msg.Show();
                    pass_box.Clear();
                }
            }
        }//end button4_Click

        //=====================================================================
        // AUTHOR:  Karan Singh 
        // PURPOSE: This function confirms that the user wants to exit the 
        //          software after clicking the 'Exit' menu option.
        // PARAMS:  None
        //===================================================================== 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exiting...", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes){Application.Exit();}
        }//end exitToolStripMenuItem_Click

        //=====================================================================
        // AUTHOR:  Karan Singh & Maxwell Partington & Ranier Limpiado  
        // PURPOSE: This function simulates a logout be resetting all forms and 
        //          data associated with the last logged in user.
        // PARAMS:  None
        // UPDATED: 11/6/14 By Jeff Henry (Refactoring)
        //=====================================================================
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLogin();                                        // Show the login page
            tab_control.SelectedTab = home_tab;                 // Return program to home 
            logOutToolStripMenuItem.Visible = false;            // Hide 'Logout' Option
            administrationToolStripMenuItem.Visible = false;    // Hide 'Administration'

            // Clear our the view reports data grid:
            

            // Hide all tabs:
            tab_control.Appearance = TabAppearance.FlatButtons;
            tab_control.ItemSize = new Size(0, 1);
            tab_control.SizeMode = TabSizeMode.Fixed;
            
            // Reset the user details box:
            home_user_details.Text = "Venture Business Management";
        }//end logOutToolStripMenuItem

        //=====================================================================
        // AUTHOR:  Karan Singh 
        // PURPOSE: To show the log out button only AFTER the user has logged in
        // PARAMS:  None
        //=====================================================================
        private void label2_TextChanged(object sender, EventArgs e)
        {
            logOutToolStripMenuItem.Visible = true;             // Deprecated!
        }
        

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Allows the admin to create a new account for a user. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Account form = new New_Account();
            form.ShowDialog();
        }

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: Allows an admin to open the edit dialogue to change a user 
        //          and or category as they choose. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adminstration administration = new Adminstration();
            administration.ShowDialog(); 
        }

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This button is used to save expenses to the transaction
        //          xml file. In this function, we checked to make sure that the
        //          user has entered the correct information and is allowed
        //          to save their information into the xml file. 
        // PARAMS:  None. 
        // UPDATED: 11/6/14 - errorProviders instead of pop-up errors Jeff Henry
        //=====================================================================
        private void button5_Click(object sender, EventArgs e)
        {
            decimal d;
            errorProvider1.Clear();
            if (ee_category_list.Text == "")                            //Is a Cateogory chosen?
            {
                errorProvider1.SetError(ee_category_list, "Please select a category.");
                expense_error_msg.Text = "Please select a category.";
                expense_error_msg.Show();
                //MessageBox.Show("Please select a category.", "ERROR");
            }
            else if (ee_expense_input.Text == "")                       //Is an Expense entered?
            {
                errorProvider1.SetError(ee_expense_input, "Please enter an expense.");
                expense_error_msg.Text = "Please enter an expense.";
                expense_error_msg.Show();
                //MessageBox.Show("Error: You forgot to enter an expense", "Error!");
            }
            else if (!decimal.TryParse(ee_expense_input.Text, out d))
            {
                errorProvider1.SetError(ee_expense_input, "Please enter a valid expense. (Ex. $100.00)");
                expense_error_msg.Text = "Please enter a valid expense (Ex. $100.00)";
                expense_error_msg.Show();
                //MessageBox.Show("Please enter a valid expense. (Ex. 1234.56)");
                ee_expense_input.Clear();
                return;
            }
            else if (ee_category_list.Text == "Mileage" && !decimal.TryParse(ee_expense_input.Text, out d))
            {
                errorProvider1.SetError(ee_category_list, "Please enter a valid mileage. (Ex. 25.5)");
                expense_error_msg.Text = "Please enter a valid mileage. (Ex. 1234.5)";
                expense_error_msg.Show();
                //MessageBox.Show("Please enter a valid mileage. (Ex. 1234.5)");
            }
            else if (Convert.ToDecimal(ee_expense_input.Text) == 0)//no 0 values allowed for expense
            {
                errorProvider1.SetError(ee_expense_input, "Entries of $0.00 are not allowed.");
                expense_error_msg.Text = "Entries of $0.00 are not allowed.";
                expense_error_msg.Show();
                //MessageBox.Show("The entry you are trying to enter is Free (Does not need to be recorded).", "Error!");
            }
            else// convert the contents of the input to the correct formats and pass them to an add transaction function in Control
            {
                if (!checkExpenseInput(ee_expense_input.Text) && ee_category_list.Text != "Mileage")//added 10/30/2014 checks for decimal and correct formatting if it's not mileage
                {
                    errorProvider1.SetError(ee_expense_input, "Please enter a valid expense. (Ex. $10.00)");
                    expense_error_msg.Text = "Please enter a valid expense. (Ex. $100.00)";
                    expense_error_msg.Show();
                    //MessageBox.Show("Please enter a valid expense (ex. 10.00)");
                }
                else if (ee_category_list.Text == "Mileage" && ee_expense_input.Text.Contains("."))
                {
                    errorProvider1.SetError(ee_expense_input, "Please enter a valid mileage. (Ex. 25.5)");
                    expense_error_msg.Text = "Please enter a valid mileage. (Ex. 25.5)";
                    expense_error_msg.Show();
                    //MessageBox.Show("Incorrect format. Try again."); //mileage should not have decimal
                }
                else if (ee_category_list.Text == "Mileage" && ee_expense_input.TextLength > 5) //mileage should not be over 5 digits added: 11/2/2014
                {
                    errorProvider1.SetError(ee_expense_input, "Expense is too large for a mileage.");
                    expense_error_msg.Text = "Expense is too large for a mileage.";
                    expense_error_msg.Show();
                    //MessageBox.Show("Error, expense is too large for a mileage.");
                }
                else
                {
                    decimal expense = Convert.ToDecimal(ee_expense_input.Text);
                    DateTime date = Convert.ToDateTime(ee_date_picker.Value.ToShortDateString());
                    Control newdata = new Control();
                    Data dataCaller = new Data();

                    dataCaller.add_detailed(expense, ee_category_list.Text, date, username_box.Text, ee_comment_box.Text);
                    newdata.addatransaction(expense, ee_category_list.Text, date, username_box.Text, ee_comment_box.Text);
                    ee_category_list.SelectedIndex = -1;
                    ee_date_picker.Value = DateTime.Today;
                    ee_expense_input.Clear();
                    ee_comment_box.Clear();
                    MessageBox.Show("The record has been saved.");
                }
            }
        }//end button5_click
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function is the button click event when a user wants to
        //          view their own reports that they have previous entered into
        //          the xml data file. 
        // PARAMS:  None. 
        // UPDATED: 11/5/14 - Refactoring Jeff Henry
        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-us");  // Used to display the totals in the correct format added 11/2/2014
            vr_mon_total.Text = "$0.00";                // Clear text so it doesn't show old values
            vr_mileage_total.Text = "0 mi";             // Clear text so it doesn't show old values
            errorProvider1.Clear();                     // Clears the errorProvider1
            errorProvider2.Clear();                     // Clears the errorProvider2


            if (vr_category_list.Text == ""){errorProvider1.SetError(vr_category_list, "Please select a category.");}
            else
            {
                List<Transaction> expenseReport = new List<Transaction>();      // List to be used for the transactions.
                decimal totalExp = 0;                                           // Total expenses
                DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());    // Grab the start date
                DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());        // Grab the end date
                Control loadData = new Control();

                // Call the control function to load data. Pass the values.
                loadData.loadExpenseReport(startDate, endDate, vr_category_list.Text, ref expenseReport, ref totalExp, username_box.Text);
               
                dataGridView1.DataSource = expenseReport;                       //Display in text field (date, expense, total expense)
                vr_report_label.Text = vr_category_list.Text + " Report";       // Display the appropriate title for the report.
                vr_report_label.Show();                                         // Show the new title.

                // Verify the user entered an appropriate date range.
                if (endDate < startDate) 
                {
                    errorProvider1.SetError(vr_start_date_picker, "Start date must be before end date.");
                    errorProvider2.SetError(vr_end_date_picker, "End date must be after start date.");
                    return;
                }
                else if (vr_category_list.Text == "Mileage")
                {                
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString() + " mi"; //display total for mileage only
                }
                else if (vr_category_list.Text == "All Categories")
                {
                    vr_mon_total.Text = "$" + totalExp.ToString("N02", ci);//Display the total correct format with commas
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString("N0", ci) + " mi"; //display total for mileage only
                }
                else
                {
                    vr_mon_total.Text = "$" + totalExp.ToString("N02", ci);//Display the total correct format with commas
                }

                this.dataGridView1.Columns["Expense"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.RowHeadersWidth = 5;         // Hides the arrow.
             }
        }//end button2_Click 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function is used to for the admin to view the entire
        //          history of data entries from their employees. 
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();//clear the rows when ever the button is clicked so the entries stay fresh

            string startstring = ee_date_picker.Value.ToShortDateString();//get the start date
            DateTime start = Convert.ToDateTime(startstring);

            string endstring = vr_end_date_picker.Value.ToShortDateString();//get the end date
            DateTime end = Convert.ToDateTime(endstring);
            Data history = new Data();

            List<Transaction> expenseReport = new List<Transaction>();
            decimal totalExp = 0;
            DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());
            Control loadData = new Control();
            //call the control function to load data. Pass the values.
            loadData.loadExpenseReport(startDate, endDate, vr_category_list.Text, ref expenseReport, ref totalExp, username_box.Text);//Use start date, end date, and category

            //make sure that ALL the fields are filled in and also that the user does not pick an end date earlier than the start date
            if (vh_user_list.Text == "" || vh_category_list.Text == "") 
            { 
                MessageBox.Show("You have not provided a USER or CATEGORY with which to process your request. Please try again.", "Error!"); 
            }
            else if (vh_user_list.Text == "") 
            {
                MessageBox.Show("Please select a user.", "ERROR"); 
            }
            else if (vh_category_list.Text == "") 
            {
                MessageBox.Show("Please select a category.", "ERROR"); 
            }
            else if (end < start) 
            { 
                MessageBox.Show("Your end date is higher than your start date, please correct this and try again.", "Error!"); 
            }
            else
            {
                history.getTransCount(this.dataGridView2, vh_user_list.Text, vh_category_list.Text, start, end);
            }
        }//end button6_Click

        //=======================================================
        //Author: Maxwell Partington & Ranier Limpiado 
        //Purpose: Exports the report into excel.
        //Updated: 11/2/2014 //brandnew
        //=======================================================
        private void export_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                MessageBox.Show("Cannot export an empty report. Please generate a report first.");
            else
            {
                Control excel = new Control();
                excel.export(this.dataGridView1, vr_mon_total.Text, vr_mileage_total.Text);
            }
        }//end 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function is called when the user wants to view more
        //          detailed data from their xml data file. 
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void detailedRe_Click(object sender, EventArgs e)
        {       
            CultureInfo ci = new CultureInfo("en-us");//used to display the totals in the correct format added 11/2/2014
            vr_mon_total.Text = "0"; //clear text so it doesn't show old values
            vr_mileage_total.Text = "0"; //clear text so it doesn't show old values
            if (vr_category_list.Text == "")
            {
                MessageBox.Show("Please select a category.", "ERROR");
            }
            else
            {
                List<DetailedTransaction> expenseReports = new List<DetailedTransaction>();
                decimal totalExp = 0;
                DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());
                Control loadData = new Control();
                //call the control function to load data. Pass the values.
                loadData.loadDetailedExpenseReport(startDate, endDate, vr_category_list.Text, ref expenseReports, ref totalExp, username_box.Text);//Use start date, end date, and category
                dataGridView1.DataSource = expenseReports;//Display in text field (date, expense, total expense)
                if (endDate < startDate)
                {
                    MessageBox.Show("Your end date is higher than your start date, please correct this and try again.", "Error!");
                    return;
                }
                else if (vr_category_list.Text == "Mileage")
                {
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString(); //display total for mileage only
                }
                else if (vr_category_list.Text == "All Categories")
                {
                    vr_mon_total.Text = "$" + totalExp.ToString("N02", ci);//Display the total correct format with commas
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString("N0", ci) + " mi"; //display total for mileage only
                }
                else
                {
                    vr_mon_total.Text = totalExp.ToString("N02", ci);//Display the total correct format with commas
                }
            }
        }//end detailedRe_Click 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function is used to call the about window forward that 
        //          will display all relevant information about the program. 
        // PARAMS:  None
        // UPDATED: 11/3/14
        //=====================================================================
        private void applicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }//end 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: The purpose of this function is show the help form for the
        //          user when they need direction in the program. 
        // PARAMS:  None
        // UPDATED: 11/3/14
        //=====================================================================
        private void applicationHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 helpForm = new Form2();
            helpForm.Show();
        }//end 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function is used to check the entry of the expense field
        //          to make sure it is the correct format of data. 
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ee_expense_input.MaxLength = 6;
            TextBox textBox = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (textBox.TextLength >= 5 && textBox.TextLength < 9)
            {
                bool backspace = false;
                if (!backspace)
                {
                    textBox.MaxLength = 9;//need to make the length of the textbox longer to add the remaining digits after the decimal
                }
            }

            if (!char.IsControl(e.KeyChar))
            {
                if (textBox.Text.IndexOf('.') > -1 &&
                         textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }//end textBox3_keyPress_1

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: Used to check if the proper format of the expense is used. 
        //          Checks if the digits is 2 after the decimal.
        //          If not then it is the wrong format.
        // UPDATED: 11/3/2014
        //=====================================================================
        private bool checkExpenseInput(string userInput)
        {
            int length = userInput.Substring(userInput.IndexOf(".") + 1).Length;
            if (length != 2){return false;}
            else if (!userInput.Contains(".")){return false;}
            else return true;
        }//end checkExpenseInput
        //=====================================================================
    }
}