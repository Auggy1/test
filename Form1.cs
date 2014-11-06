//=====================================================================
// AUTHORS: 
//          Cycle 1: Karan Singh & Michelle Jaro
//          Cycle 2: Maxwell Partington & Ranier Limpiado     
// PURPOSE: This is the main form of the program that runs all of the
//          functionality that the user requires, be it regular user
//          or admin. 
// PARAMS:  Proper execution of the .exe is the only parameter. 
// DATE:    11/3/14
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

            
            
            
            ee_expense_input.MaxLength = 6;                         // Max length for an expense to be when entered

            /*************************************** Date and Time Displays *******************************************/
            ee_date_picker.MaxDate = DateTime.Now;                  // Enter Expense date picker
            vr_end_date_picker.MaxDate = DateTime.Now;              // View Reports start date picker
            vr_start_date_picker.MaxDate = DateTime.Now;            // View Reports end date picker
            vh_end_date_picker.MaxDate = DateTime.Now;              // View History start date picker
            vh_start_date_picker.MaxDate = DateTime.Now;            // View History end date picker
            date_label.Text = DateTime.Now.ToString("MM/dd/yyyy");  // Month/date/year format for program date display
            date = DateTime.UtcNow.Date;

            System.Timers.Timer clk_timer = new System.Timers.Timer(1000);
            clk_timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            clk_timer.Enabled = true;
            clk_timer.Start();

            //time_stamp.Text = DateTime.Now.ToString("hh:mm tt");    //Time format

            /****************************************** Hidden labels/tabs ********************************************/
            welcome_msg.Hide();                                     // Hide the welcome message
            label13.Hide();

            home_tab.Hide();
            administrationToolStripMenuItem.Visible = false; 
            tab_control.Appearance = TabAppearance.FlatButtons;
            tab_control.ItemSize = new Size(0, 1); 
            tab_control.SizeMode = TabSizeMode.Fixed;
            var source0 = new AutoCompleteStringCollection();

        }// end home

        //=====================================================================
        // Purpose: These functions were required because the OnTimeEvent 
        //          function comes from another thread context than the UI 
        //          thread, so we have to use a dispatcher to make it work.
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
        //=====================================================================
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string txt = DateTime.Now.ToString("HH:mm:ss tt");
            SetText(txt);
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
            login.createxmlfile();
        
            string user;
            string password;
            bool exists;
            bool validPassword; 
            bool isAdmin = false;
            Data userChecks = new Data(); 
            var source = new AutoCompleteStringCollection();

            // The following if/else statements perform the proper
            // checks of the user's input to make sure they actually exist
            // in the system, they have the proper username and password,
            // and if they are an admin or not. 
            if ((username_box.Text== "") || (username_box.TextLength < 5))
            {
                MessageBox.Show("Incorrect login information.");
                username_box.Clear();
            }
            else if  ((pass_box.Text=="") || (pass_box.TextLength <5))
            {
                MessageBox.Show("Incorrect login information.");
                pass_box.Clear();
            }
            else if (username_box.Text != "" && pass_box.Text != "")
            {
                user = username_box.Text;
                password = pass_box.Text;
                    // Perform the proper checks of the user. 
                    isAdmin = userChecks.checkAdmin(user);
                    exists = userChecks.userExists(user, isAdmin);
                    validPassword = userChecks.checkUserPassword(user, password);

                    // Once everything is validated, we log the user 
                    // into the program, and show the appropriate
                    // data and buttons/labels for the specific users. 
                    if (exists == true && validPassword == true)
                    {
                        welcome_msg.Text = "Welcome " + user + "!"; 
                        welcome_msg.Show();
                        home_user_details.Text = userChecks.fillInLoginInfo(user, isAdmin);
                        userChecks.updateLastLogin(user, isAdmin); 

                        tab_control.Appearance = TabAppearance.Normal;
                        tab_control.ItemSize =  new Size(20, 20);
                        tab_control.SizeMode = TabSizeMode.Normal;
                        logOutToolStripMenuItem.Visible = true; 

                        if (isAdmin)
                        {
                            tab_control.SelectedTab = vr_tab;
                            welcome_msg.Show();
                            login_btn.Hide();
                            username_box.Hide();
                            pass_box.Hide();
                            label3.Hide();
                            label5.Hide();
                            dataGridView2.Show();
                            vh_user_list.Show();
                            vh_category_list.Show();
                            vh_end_date_picker.Show();
                            vh_start_date_picker.Show();
                            label19.Show();
                            label17.Show();
                            label20.Show();
                            label21.Show();
                            vh_search_btn.Show();
                            administrationToolStripMenuItem.Visible = true;
                        }
                        else if (!isAdmin)
                        {
                            tab_control.SelectedTab = ee_tab; 
                            //Admin information 
                            dataGridView2.Hide();
                            vh_user_list.Hide();
                            vh_category_list.Hide();
                            vh_end_date_picker.Hide();
                            vh_start_date_picker.Hide();
                            label19.Hide();
                            label17.Hide();
                            label20.Hide();
                            label21.Hide();
                            //================

                            label13.Show();
                            vh_search_btn.Hide();
                            username_box.Hide();
                            pass_box.Hide();
                            login_btn.Hide();
                            label3.Hide();
                            label5.Hide();
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
                        MessageBox.Show("Incorrect login information.", "ERROR");
                        username_box.Clear();
                        pass_box.Clear();
                    }

                    else if (validPassword == false)
                    {
                        MessageBox.Show("Incorrect login information.", "ERROR");
                        pass_box.Clear();
                    }
            }
        }//end button4_Click
        //=====================================================================

        //=====================================================================
        // AUTHOR: Karan Singh 
        // PURPOSE: Provide a  means for the user to exit at any time they so wish through FILE menu
        // PARAMS: None
        //===================================================================== 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Terminate the Application?", "Exiting...", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }//end exitToolStripMenuItem_Click
        //=====================================================================

        //=====================================================================
        // AUTHOR: Karan Singh & Maxwell Partington & Ranier Limpiado  
        // PURPOSE: Provide a  means for the user to logout at any time they so wish through FILE menu(pick new user)
        // PARAMS: None
        // UPDATED: 11/3/14
        //=====================================================================
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab_control.SelectedTab = home_tab; 
            label13.Hide();
            welcome_msg.Hide();
            home_tab.Hide();
            logOutToolStripMenuItem.Visible = false; 
            administrationToolStripMenuItem.Visible = false;
            tab_control.Appearance = TabAppearance.FlatButtons;
            tab_control.ItemSize = new Size(0, 1);
            tab_control.SizeMode = TabSizeMode.Fixed;
            login_btn.Show();
            username_box.Show();
            pass_box.Show();
            label3.Show();
            label5.Show();
            username_box.Clear();
            pass_box.Clear();
            home_user_details.Text = "Venture Business Management";
        }//end logOutToolStripMenuItem
        //=====================================================================

        //=====================================================================
        // AUTHOR: Karan Singh 
        // PURPOSE: To show the log out button only AFTER the user has logged in
        // PARAMS: None
        //=====================================================================
        private void label2_TextChanged(object sender, EventArgs e)
        {
            logOutToolStripMenuItem.Visible = true;
        }//end 
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Allows the admin to create a new account for a user. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Account form = new New_Account();
            form.ShowDialog();
        }//end 
        //=====================================================================

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

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This button is used to save expenses to the transaction
        //          xml file. In this function, we checked to make sure that the
        //          user has entered the correct information and is allowed
        //          to save their information into the xml file. 
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void button5_Click(object sender, EventArgs e)
        {
            decimal d;
            if (ee_category_list.Text == "")//Make sure a category is picked
            {
                MessageBox.Show("Please select a category.", "ERROR");
            }

            else if (ee_expense_input.Text == "")//make sure something is entered for the text box
            {
                MessageBox.Show("Error: You forgot to enter an expense", "Error!");
            }
            else if (!decimal.TryParse(ee_expense_input.Text, out d))
            {
                MessageBox.Show("Please enter a valid expense. (Ex. 1234.56)");
                ee_expense_input.Clear();
                return;
            }
            else if (ee_category_list.Text == "Mileage" && !decimal.TryParse(ee_expense_input.Text, out d))
            {
                MessageBox.Show("Please enter a valid mileage. (Ex. 1234.5)");
            }
            /* else if (richTextBox2.Text == "")  // This can be potentially used for cycle 3, making comments mandatory
            {                                     // when entering data. 
                MessageBox.Show("You must enter comments for your expense.");
            }*/
            else if (Convert.ToDecimal(ee_expense_input.Text) == 0)//no 0 values allowed for expense
            {
                MessageBox.Show("The entry you are trying to enter is Free (Does not need to be recorded).", "Error!");
            }

            else// convert the contents of the input to the correct formats and pass them to an add transaction function in Control
            {
                if (!checkExpenseInput(ee_expense_input.Text) && ee_category_list.Text != "Mileage")//added 10/30/2014 checks for decimal and correct formatting if it's not mileage
                {
                    MessageBox.Show("Incorrect format. Try again.");
                }
                else if (ee_category_list.Text == "Mileage" && ee_expense_input.Text.Contains("."))
                {
                    MessageBox.Show("Incorrect format. Try again."); //mileage should not have decimal
                }
                else if (ee_category_list.Text == "Mileage" && ee_expense_input.TextLength > 6) //mileage should not be over 6 digits added: 11/2/2014
                {
                    MessageBox.Show("Error, input too large.");
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
        // UPDATED: 11/3/14
        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-us");  //used to display the totals in the correct format added 11/2/2014
            vr_mon_total.Text = "0";                    //clear text so it doesn't show old values
            vr_mileage_total.Text = "0";                //clear text so it doesn't show old values
            if (vr_category_list.Text == "")
            {
                MessageBox.Show("Please select a category.", "ERROR");//make sure the category is not empty
            }
            else
            {
                //make appropriate conversions
                List<Transaction> expenseReport = new List<Transaction>();
                decimal totalExp = 0;
                DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());
                Control loadData = new Control();
                //call the control function to load data. Pass the values.
                loadData.loadExpenseReport(startDate, endDate, vr_category_list.Text, ref expenseReport, ref totalExp, username_box.Text);//Use start date, end date, and category
               
                dataGridView1.DataSource = expenseReport;//Display in text field (date, expense, total expense)
                
                vr_report_label.Text = vr_category_list.Text + " Report"; // to show which report is being shown
                vr_report_label.Show();
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
                this.dataGridView1.Columns["Expense"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Sort(this.dataGridView1.Columns["Category"], ListSortDirection.Ascending);
            }
        }//end button2_Click 
        //=====================================================================

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
            if (vh_user_list.Text == "" && vh_category_list.Text == "") 
            { 
                MessageBox.Show("You have not provided a USER or CATEGORY with which to process your request. Please try again after doing so.", "Error!"); 
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
        //=====================================================================

        //=======================================================
        //Author: Maxwell Partington & Ranier Limpiado 
        //Purpose: Exports the report into excel.
        //Updated: 11/2/2014 //brandnew
        //=======================================================
        private void export_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                MessageBox.Show("Cannot export an empty report. Please generate a report with values.");
            else
            {
                Control excel = new Control();
                excel.export(this.dataGridView1, vr_mon_total.Text, vr_mileage_total.Text);
            }
        }//end 
        //=====================================================================

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

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: Used to check if the proper format of the expense is used. Checks if the digits is 2 after the decimal
        //          If not then it is the wrong format.
        // UPDATED: 11/3/2014
        //=====================================================================
        private bool checkExpenseInput(string userInput)
        {
            int length = userInput.Substring(userInput.IndexOf(".") + 1).Length;
            if (length != 2)
            {
                return false;
            }
            else if (!userInput.Contains(".")) //needs to have a decimal
            {
                return false;
            }
            return true;
        }//end checkExpenseInput
        //=====================================================================
    }
}