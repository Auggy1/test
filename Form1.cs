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
        Control control;
        
        public Home()
        {
            InitializeComponent();

        }// end home

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This is a second constructor made to handle when the login
        //          form creates an instance of this main form. It will receive
        //          the username and administrator boolean form the login form.
        // PARAMS:  string username, bool isadmin
        //=====================================================================
        public Home(string user, bool is_admin, Control allcontrol)
        {
            InitializeComponent();
            control = allcontrol;

            ee_category_list.SelectedIndex = -1;
            vr_category_list.SelectedIndex = -1;
            vh_category_list.SelectedIndex = -1;
            vh_user_list.SelectedIndex = -1;

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
            expense_error_msg.Hide();                               // Hide the expense error message.
            administrationToolStripMenuItem.Visible = false;        // Hide the administration menu
            tab_control.Controls.Remove(vh_tab);                    // Remove the view history tab
            vr_report_label.Hide();                                 // Hides the view report label
            this.vh_grid.Rows.Clear();                              // Clears the vh grid
            this.vr_grid.Rows.Clear();                              // Clears the vr grid

            // Update all the drop-down lists:
            RefreshDropdowns();
            current_user = user;

            // Update the Home tab and save users Login History:
            home_user_details.Text = control.FillLoginInfo(user, is_admin);
            control.UpdateUserLogin(user, is_admin);

            // Make the tab controls visible:
            tab_control.Appearance = TabAppearance.Normal;
            tab_control.ItemSize = new Size(20, 20);
            tab_control.SizeMode = TabSizeMode.Normal;
            logOutToolStripMenuItem.Visible = true;

            if (System.DateTime.Now.Hour > 12)
                welcome_msg.Text = "Good Afternoon " + user + "!";
            else
                welcome_msg.Text = "Good Morning " + user + "!";
            //==================================================================
            // Since we are passing information from the login form, we need to 
            // adjust the main form before we show it to the user:
            //==================================================================
            if (is_admin)
            {
                tab_control.Controls.Add(vh_tab);   // Addd the View History Tab to the form
                tab_control.SelectedTab = vr_tab;   // Change the tab to View History
                administrationToolStripMenuItem.Visible = true;
            }
            else if (!is_admin)
            {
                tab_control.SelectedTab = ee_tab;   // Change the tab to Enter Expense 
                tab_control.Controls.Remove(vh_tab); // Remove the View History tab
            }
        }


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
        // AUTHOR:  Karan Singh 
        // PURPOSE: This function confirms that the user wants to exit the 
        //          software after clicking the 'Exit' menu option.
        // PARAMS:  None
        //===================================================================== 
        private void ExitProgramClick(object sender, EventArgs e)
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
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }//end logOutToolStripMenuItem


        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Allows the admin to create a new account for a user. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void AddUserClick(object sender, EventArgs e)
        { 
            New_Account form = new New_Account(control);
            form.ShowDialog();
        }

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: Allows an admin to open the edit dialogue to change a user 
        //          and or category as they choose. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void EditUserCategoryClick(object sender, EventArgs e)
        {
            Adminstration administration = new Adminstration(control);
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
        private void EnterExpenseClick(object sender, EventArgs e)
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
                if (!CheckExpenseInput(ee_expense_input.Text) && ee_category_list.Text != "Mileage")//added 10/30/2014 checks for decimal and correct formatting if it's not mileage
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
                    
                    control.AddTransaction(expense, ee_category_list.Text, date, current_user, ee_comment_box.Text);
                    ee_category_list.SelectedIndex = -1;
                    ee_date_picker.Value = DateTime.Today;
                    ee_expense_input.Clear();
                    ee_comment_box.Clear();
                    ee_success_message.Text = "The expense was successfully saved.";
                    ee_success_message.Visible = true;
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
        private void ViewSummaryClick(object sender, EventArgs e)
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
               
                // Fill the grid view with summary report:
                control.FillGridSummary(this.vr_grid, vr_category_list.Text, ref exp_total, ref mil_total, startDate, endDate, current_user);
                
                vr_report_label.Text = vr_category_list.Text + " Report";       // Display the appropriate title for the report.
                vr_report_label.Show();                                         // Show the new title.

                if (vr_category_list.Text == "Mileage")
                {
                    vr_mileage_total.Text = control.GetTotalMileage(startDate, endDate).ToString() + " mi"; 
                }
                else if (vr_category_list.Text == "All Categories")
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);
                    vr_mileage_total.Text = control.GetTotalMileage(startDate, endDate).ToString("N0", ci) + " mi"; 
                }
                else
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
                }
             }
        }//end button2_Click 

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function is called when the user wants to view more
        //          detailed data from their xml data file. 
        // PARAMS:  None. 
        // UPDATED: 11/8/14 Jeff Henry (Refactoring)
        //=====================================================================
        private void ViewDetailedClick(object sender, EventArgs e)
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

                // Fill the data grid with detailed info:
                control.FillGridDetailed(this.vr_grid, vr_category_list.Text, ref exp_total, ref mil_total, startDate, endDate, current_user);

                if (vr_category_list.Text == "Mileage")
                {
                    vr_mileage_total.Text = control.GetTotalMileage(startDate, endDate).ToString(); //display total for mileage only
                }
                else if (vr_category_list.Text == "All Categories")
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
                    vr_mileage_total.Text = control.GetTotalMileage(startDate, endDate).ToString("N0", ci) + " mi"; //display total for mileage only
                }
                else
                {
                    vr_mon_total.Text = "$" + exp_total.ToString("N02", ci);//Display the total correct format with commas
                }
            }
        } 

        //=====================================================================
        // AUfTHOR: Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function is used to for the admin to view the entire
        //          history of data entries from their employees. 
        // PARAMS:  None. 
        // UPDATED: 11/7/14     - Jeff Henry (Refactoring)
        //=====================================================================
        private void ViewHistoryClick(object sender, EventArgs e)
        {
            vh_grid.DataSource = null;
            vh_grid.Rows.Clear();
            
            vh_error_msg.Visible = false;   // Hide the error messages

            errorProvider1.Clear();         // Clear all errorProvider notifications
            errorProvider2.Clear();         // Clear all errorPrvoider notifications

            // Grab Date information from the form:
            DateTime startDate = Convert.ToDateTime(vr_start_date_picker.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(vr_end_date_picker.Value.ToShortDateString());

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
                control.GetTransactionHistory(this.vh_grid, vh_user_list.Text, vh_category_list.Text, startDate, endDate);
            }

            
        }//end button6_Click

        //=======================================================
        //Author: Maxwell Partington & Ranier Limpiado 
        //Purpose: Exports the report into excel.
        //Updated: 11/2/2014 //brandnew
        //=======================================================
        private void ExportClick(object sender, EventArgs e)
        {
            if (vr_grid.Rows.Count == 0)
                MessageBox.Show("Cannot export an empty report. Please generate a report first.");
            else
            {
                string start = this.vr_grid.Rows[0].Cells[0].Value.ToString();
                string end = this.vr_grid.Rows[vr_grid.Rows.Count - 1].Cells[0].Value.ToString();
                string user = current_user;

                control.export(this.vr_grid, vr_mon_total.Text, vr_mileage_total.Text,start,end,user);
            }
        }//end 

        
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function is used to call the about window forward that 
        //          will display all relevant information about the program. 
        // PARAMS:  None
        // UPDATED: 11/3/14
        //=====================================================================
        private void AboutClick(object sender, EventArgs e)
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
        private void HelpClick(object sender, EventArgs e)
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
        private void ExpenseEntryKeyPress(object sender, KeyPressEventArgs e)
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
        private bool CheckExpenseInput(string userInput)
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
        private void VHStartDateChange(object sender, EventArgs e)
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
        private void VRStartDateChange(object sender, EventArgs e)
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
        private void RefreshDropdowns()
        {
            // Clear all the lists first:
            ee_category_list.DataSource = null;
            vr_category_list.DataSource = null;
            vh_category_list.DataSource = null;
            vh_user_list.DataSource = null;

            // Update the lists:
            ee_category_list.DataSource = control.GetCategories();
            vr_category_list.DataSource = control.GetAllCategories();
            vh_category_list.DataSource = control.GetAllCategories();
            vh_user_list.DataSource = control.GetAllUsers();
            
            // Reset the indices:
            ee_category_list.SelectedIndex = -1;
            vr_category_list.SelectedIndex = -1;
            vh_category_list.SelectedIndex = -1;
            vh_user_list.SelectedIndex = -1;
        }

        //========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will hide the message as soon as a user starts 
        //          entering text. 
        //========================================================================
        private void ExpenseEntryTextChanged(object sender, EventArgs e)
        {
            ee_success_message.Visible = false;
        }

        //========================================================================
        //                      !! DEPRECATED FUNCTIONS !!
        //========================================================================
        /*
        
        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: Hide the login page and displays a welcome message
        // UPDATED: 11/12/2014 Deprecated since separate login form added.
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
        // AUTHOR:  Jeff Henry
        // PURPOSE: Shows the login form and hides the welcome message
        // UPDATED: 11/12/2014 - Deprecated since separate login form was added.
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
        // Updates: 11/12/2014 Deprecated upon adding separate login form. 
        //=====================================================================
        private void LoginClick(object sender, EventArgs e)
        {
            Control login = new Control();
            Data userChecks = new Data();
            var source = new AutoCompleteStringCollection();
            login.CreateXMLs();
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
                isAdmin = userChecks.CheckIfAdmin(username_box.Text);
                exists = userChecks.CheckUserExistence(username_box.Text, isAdmin);
                validPassword = userChecks.VerifyPassword(username_box.Text, pass_box.Text);

                // Once everything is validated, we log the user 
                // into the program, and show the appropriate
                // data and buttons/labels for the specific users. 
                if (exists && validPassword)
                {
                    // Update all the drop-down lists:
                    RefreshDropdowns(); 
                    current_user = username_box.Text;
                    
                    // Update the Home tab and save users Login History:
                    home_user_details.Text = userChecks.FillInLoginInfo(username_box.Text, isAdmin);
                    userChecks.UpdateLastLogin(username_box.Text, isAdmin); 
                    
                    // Make the tab controls visible:
                    tab_control.Appearance = TabAppearance.Normal;
                    tab_control.ItemSize =  new Size(20, 20);
                    tab_control.SizeMode = TabSizeMode.Normal;
                    logOutToolStripMenuItem.Visible = true;
                    HideLogin(username_box.Text);
                    
                    // Handle if the user is an admin:
                    if (isAdmin)
                    {
                        tab_control.Controls.Add(vh_tab);
                        tab_control.SelectedTab = vr_tab;           // Change the tab to View History
                        administrationToolStripMenuItem.Visible = true;
                    }
                    // Handle if an employee:
                    else if (!isAdmin)
                    {
                        tab_control.SelectedTab = ee_tab;
                        tab_control.Controls.Remove(vh_tab);
                    } 
                    
                    // This adds the login history of the user. 
                    login.SetLoginHistory(username_box.Text, date);
                }
                else if (!exists)
                {
                    login_error_msg.Text = "User does not exist.";
                    login_error_msg.Show();
                    username_box.Clear();
                    pass_box.Clear();
                }
                else if (!validPassword)
                {
                    login_error_msg.Text = "Invalid Password. Try Again.";
                    login_error_msg.Show();
                    pass_box.Clear();
                }
            }
        }//end button4_Click
        
        //=====================================================================
        // AUTHOR:  Karan Singh 
        // PURPOSE: To show the log out button only AFTER the user has logged in
        // PARAMS:  None
        //=====================================================================
        private void label2_TextChanged(object sender, EventArgs e)
        {
            logOutToolStripMenuItem.Visible = true;             // Deprecated!
        }
        
        */

    }
}