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
        string current_user = "";

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
            Data initialization = new Data();
            
            
            //The already initialized logout button under file is not visible to the user initially
            logOutToolStripMenuItem.Visible = false;
            ee_category_list.SelectedIndex = -1;
            vr_category_list.SelectedIndex = -1;
            vh_category_list.SelectedIndex = -1;

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
            login_error_msg.Hide();                                 // Hide the login error message
            expense_error_msg.Hide();                               // Hide the expense error message.
            administrationToolStripMenuItem.Visible = false;        // Hide the administration menu
            tab_control.Controls.Remove(vh_tab);                    // Remove the view history tab
            vr_report_label.Hide();                                 // Hides the view report label
            this.vh_grid.RowHeadersWidth = 4;                       // Hides the arrow on the data grid.
            this.vr_grid.RowHeadersWidth = 4;                       // Hides the arrow on the data grid.
            this.vh_grid.Rows.Clear();                              // Clears the vh grid
            this.vr_grid.Rows.Clear();                              // Clears the vr grid

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
            login_error_msg.Text = "";  
                      
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
                    // Update all the drop-down lists:
                    refresh_dropdowns(); 

                    current_user = username_box.Text;
                    
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

            // Hide all tabs:
            tab_control.Appearance = TabAppearance.FlatButtons;
            tab_control.ItemSize = new Size(0, 1);
            tab_control.SizeMode = TabSizeMode.Fixed;
            
            // Reset the user details box:
            home_user_details.Text = "Venture Business Management";

            // Reset all the data grids:
            vr_grid.DataSource = null;
            vr_grid.Rows.Clear();
            vh_grid.DataSource = null;
            vh_grid.Rows.Clear();

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
            CultureInfo ci = new CultureInfo("en-us");  // Used to display the totals in the correct format added 11/2/2014
            errorProvider1.Clear();
            if (ee_category_list.Text == "")           //Is a Cateogory chosen?
            {
                errorProvider1.SetError(ee_category_list, "Please select a category.");
                expense_error_msg.Text = "Please select a category.";
                expense_error_msg.Show();
            }
            else if (ee_expense_input.Text == "")      //Is an Expense entered?
            {
                errorProvider1.SetError(ee_expense_input, "Please enter an expense.");
                expense_error_msg.Text = "Please enter an expense.";
                expense_error_msg.Show();
            }
            else if (!decimal.TryParse(ee_expense_input.Text, NumberStyles.Currency | NumberStyles.AllowCurrencySymbol, ci, out d))
            {
                errorProvider1.SetError(ee_expense_input, "Please enter a valid expense. (Ex. $100.00)");
                expense_error_msg.Text = "Please enter a valid expense (Ex. $100.00)";
                expense_error_msg.Show();
                ee_expense_input.Clear();
                return;
            }
            else if (ee_category_list.Text == "Mileage" && !decimal.TryParse(ee_expense_input.Text, out d))
            {
                errorProvider1.SetError(ee_category_list, "Please enter a valid mileage. (Ex. 25)");
                expense_error_msg.Text = "Please enter a valid mileage. (Ex. 25)";
                expense_error_msg.Show();
            }
            else if (Convert.ToDecimal(ee_expense_input.Text) == 0)//no 0 values allowed for expense
            {
                errorProvider1.SetError(ee_expense_input, "Entries of $0.00 are not allowed.");
                expense_error_msg.Text = "Entries of $0.00 are not allowed.";
                expense_error_msg.Show();
            }
            else// convert the contents of the input to the correct formats and pass them to an add transaction function in Control
            {
                if (!checkExpenseInput(ee_expense_input.Text) && ee_category_list.Text != "Mileage")//added 10/30/2014 checks for decimal and correct formatting if it's not mileage
                {
                    errorProvider1.SetError(ee_expense_input, "Please enter a valid expense. (Ex. $10.00)");
                    expense_error_msg.Text = "Please enter a valid expense. (Ex. $100.00)";
                    expense_error_msg.Show();
                }
                else if (ee_category_list.Text == "Mileage" && ee_expense_input.Text.Contains("."))
                {
                    errorProvider1.SetError(ee_expense_input, "Please enter a valid mileage (Ex. 125)");
                    expense_error_msg.Text = "Please enter a valid mileage (Ex. 125)";
                    expense_error_msg.Show();
                }
                else if (ee_category_list.Text == "Mileage" && ee_expense_input.TextLength > 5)
                {
                    errorProvider1.SetError(ee_expense_input, "Expense is too large for a mileage.");
                    expense_error_msg.Text = "Expense is too large for a mileage.";
                    expense_error_msg.Show();
                }
                else
                {
                    decimal expense = Convert.ToDecimal(ee_expense_input.Text);
                    DateTime date = Convert.ToDateTime(ee_date_picker.Value.ToShortDateString());
                    Control newdata = new Control();

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
        //          the xml data file. (Summary)
        // PARAMS:  None. 
        // UPDATED: 11/7/14 - Refactoring Jeff Henry
        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the Data Grid in the case of refreshing:
            this.vr_grid.DataSource = null;
            this.vr_grid.Rows.Clear();

            CultureInfo ci = new CultureInfo("en-us");  // Used to display the totals in the correct format added 11/2/2014
            vr_mon_total.Text = "$0.00";                // Clear text so it doesn't show old values
            vr_mileage_total.Text = "0 mi";             // Clear text so it doesn't show old values
            errorProvider1.Clear();                     // Clears the errorProvider1
            vr_error_msg.Visible = false;               // Hide the error message
            if (vr_category_list.Text == "")
            {
                errorProvider1.SetError(vr_category_list, "Please select a category.");
                vr_error_msg.Text = "Please select a category.";
                vr_error_msg.Visible = true;
            }
            else
            {
                decimal exp_total = 0;                                          // Total expenses
                decimal mil_total = 0;                                          // Total mileage
                DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());    // Grab the start date
                DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());        // Grab the end date
                Data reports = new Data();
                Control loadData = new Control();

                // Fill the grid view with summary report:
                reports.fillGridSummary(this.vr_grid, vr_category_list.Text, ref exp_total, ref mil_total, startDate, endDate, current_user);
                
                vr_report_label.Text = vr_category_list.Text + " Report";       // Display the appropriate title for the report.
                vr_report_label.Show();                                         // Show the new title.

                if (vr_category_list.Text == "Mileage")
                {
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString() + " mi"; //display total for mileage only
                }
                else if (vr_category_list.Text == "All Categories")
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString("N0", ci) + " mi"; //display total for mileage only
                }
                else
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
                }
                //this.vr_grid.Columns["Expense"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
             }
        }//end button2_Click 

        //=====================================================================
        // AUfTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function is used to for the admin to view the entire
        //          history of data entries from their employees. 
        // PARAMS:  None. 
        // UPDATED: 11/7/14     - Jeff Henry (Refactoring)
        //=====================================================================
        private void button6_Click(object sender, EventArgs e)
        {
            vh_grid.DataSource = null;
            vh_grid.Rows.Clear();
            
            vh_error_msg.Visible = false;   // Hide the error messages

            errorProvider1.Clear();         // Clear all errorProvider notifications
            errorProvider2.Clear();         // Clear all errorPrvoider notifications

            // Grab Date information from the form:
            DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());

            Data history = new Data();

            //make sure that ALL the fields are filled in and also that the user does not pick an end date earlier than the start date
            if (vh_user_list.Text == "" || vh_category_list.Text == "") 
            {
                errorProvider1.SetError(vh_user_list, "Select a user or category.");
                errorProvider2.SetError(vh_category_list, "Select a user or category.");
                vh_error_msg.Text = "Select a user or category.";
                vh_error_msg.Visible = true;
            }
            else if (vh_user_list.Text == "") 
            {
                errorProvider1.SetError(vh_user_list, "Please select a user.");
                vh_error_msg.Text = "Please select a user.";
                vh_error_msg.Visible = true;
            }
            else if (vh_category_list.Text == "") 
            {
                errorProvider1.SetError(vh_category_list, "Please select a category.");
                vh_error_msg.Text = "Please select a category.";
                vh_error_msg.Visible = true;
            }
            else
            {
                history.getTransCount(this.vh_grid, vh_user_list.Text, vh_category_list.Text, startDate, endDate);
            }

            
        }//end button6_Click

        //=======================================================
        //Author: Maxwell Partington & Ranier Limpiado 
        //Purpose: Exports the report into excel.
        //Updated: 11/2/2014 //brandnew
        //=======================================================
        private void export_Click_1(object sender, EventArgs e)
        {
            if (vr_grid.Rows.Count == 0)
                MessageBox.Show("Cannot export an empty report. Please generate a report first.");
            else
            {
                string start = this.vr_grid.Rows[0].Cells[0].Value.ToString();
                string end = this.vr_grid.Rows[vr_grid.Rows.Count - 1].Cells[0].Value.ToString();
                string user = current_user;

                Control excel = new Control();
                excel.export(this.vr_grid, vr_mon_total.Text, vr_mileage_total.Text,start,end,user);
            }
        }//end 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function is called when the user wants to view more
        //          detailed data from their xml data file. 
        // PARAMS:  None. 
        // UPDATED: 11/8/14 Jeff Henry (Refactoring)
        //=====================================================================
        private void detailedRe_Click(object sender, EventArgs e)
        {
            this.vr_grid.DataSource = null;
            this.vr_grid.Rows.Clear();
            
            CultureInfo ci = new CultureInfo("en-us");  // Display the totals in the correct format
            vr_mon_total.Text = "$0.00";        // Clear text so it doesn't show old values
            vr_mileage_total.Text = "0 mi";    // Clear text so it doesn't show old values
            errorProvider1.Clear();
            vr_error_msg.Visible = false;

            if (vr_category_list.Text == "")
            {
                errorProvider1.SetError(vr_category_list, "Please select a category.");
                vr_error_msg.Text = "Please select a categoy.";
                vr_error_msg.Visible = true;
            }
            else
            {
                decimal exp_total = 0;
                decimal mil_total = 0;
                DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());

                Data reports = new Data();
                Control loadData = new Control();

                // Fill the data grid with detailed info:
                reports.fillGridDetailed(this.vr_grid, vr_category_list.Text, ref exp_total, ref mil_total, startDate, endDate, current_user);

                if (vr_category_list.Text == "Mileage")
                {
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString(); //display total for mileage only
                }
                else if (vr_category_list.Text == "All Categories")
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
                    vr_mileage_total.Text = loadData.mileage(startDate, endDate).ToString("N0", ci) + " mi"; //display total for mileage only
                }
                else
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
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
        }

        //========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will update the minimum date on the second calendar so 
        //          the user can't select an end date that comes before the start
        //          date.
        // UPDATED: 11/7/2014
        //========================================================================
        private void vh_start_date_picker_ValueChanged(object sender, EventArgs e)
        {
            vh_end_date_picker.MinDate = vh_start_date_picker.Value;
        }

        //========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will update the minimum date on the second calendar so 
        //          the user can't select an end date that comes before the start
        //          date.
        // UPDATED: 11/7/2014
        //========================================================================
        private void vr_end_date_picker_ValueChanged(object sender, EventArgs e)
        {
            vr_end_date_picker.MinDate = vr_start_date_picker.Value;
        }

        //========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will "refresh" or basically reload all the drop down lists
        //          so that the user always has an updated list of users and 
        //          categories.
        // UPDATED: 11/9/2014   Jeff Henry -    Initial creation
        //========================================================================
        private void refresh_dropdowns()
        {
            Data updates = new Data();
            // Clear all the lists first:
            ee_category_list.DataSource = null;
            vr_category_list.DataSource = null;
            vh_category_list.DataSource = null;
            vh_user_list.DataSource = null;

            // Update the lists:
            ee_category_list.DataSource = updates.addCategories();
            vr_category_list.DataSource = updates.addAllCategories();
            vh_category_list.DataSource = updates.addAllCategories();
            vh_user_list.DataSource = updates.loadUsers();
            
            // Reset the indices:
            ee_category_list.SelectedIndex = -1;
            vr_category_list.SelectedIndex = -1;
            vh_category_list.SelectedIndex = -1;
            vh_user_list.SelectedIndex = -1;
        }
    }
}