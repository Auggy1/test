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
            label18.Hide();
            //get rid of the * on the history table
            dataGridView2.AllowUserToAddRows = false;
            //comboBox2.Items.AddRange(types);//removed because getting information from XML after user logs in 10/29/2014
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;//set the format to dropdownlist 
            //comboBox3.Items.AddRange(types); //removed because getting information from XML after user logs in 10/29/2014
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox5.Items.AddRange(types);//removed because getting information from XML after user logs in 10/29/2014
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;

            //The already initialized logout button under file is not visible to the user initially
            logOutToolStripMenuItem.Visible = false;

            //Shows the current time at the labels
            DateTime dateTime = DateTime.UtcNow.Date;
            textBox3.MaxLength = 6;
            dateTimePicker1.MaxDate = DateTime.Now; //added 10/27
            dateTimePicker2.MaxDate = DateTime.Now; //added 10/30
            dateTimePicker3.MaxDate = DateTime.Now; //added 10/30
            dateTimePicker4.MaxDate = DateTime.Now; //added 10/27
            dateTimePicker5.MaxDate = DateTime.Now; //added 10/27
            label1.Text = DateTime.Now.ToString("MM/dd/yyyy");//Month/date/year format
            label4.Text = DateTime.Now.ToString("hh:mm tt");  //Time format

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            date = dateTime;

            label13.Hide();
            label2.Hide();
            tabPage1.Hide();
            administrationToolStripMenuItem.Visible = false; 
            tabcontrol1.Appearance = TabAppearance.FlatButtons;
            tabcontrol1.ItemSize = new Size(0, 1); 
            tabcontrol1.SizeMode = TabSizeMode.Fixed;
            var source0 = new AutoCompleteStringCollection();

        }//end home
        //=====================================================================

        //=====================================================================
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
            if ((textBox1.Text== "") || (textBox1.TextLength < 5))
            {
                MessageBox.Show("Incorrect login information.");
                textBox1.Clear();
            }
            else if  ((textBox2.Text=="") || (textBox2.TextLength <5))
            {
                MessageBox.Show("Incorrect login information.");
                textBox2.Clear();
            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                user = textBox1.Text;
                password = textBox2.Text;
                    // Perform the proper checks of the user. 
                    isAdmin = userChecks.checkAdmin(user);
                    exists = userChecks.userExists(user, isAdmin);
                    validPassword = userChecks.checkUserPassword(user, password);

                    // Once everything is validated, we log the user 
                    // into the program, and show the appropriate
                    // data and buttons/labels for the specific users. 
                    if (exists == true && validPassword == true)
                    {
                        label2.Text = "Welcome " + user + "!"; 
                        label2.Show();
                        richTextBox1.Text = userChecks.fillInLoginInfo(user, isAdmin);
                        userChecks.updateLastLogin(user, isAdmin); 

                        tabcontrol1.Appearance = TabAppearance.Normal;
                        tabcontrol1.ItemSize =  new Size(20, 20);
                        tabcontrol1.SizeMode = TabSizeMode.Normal;
                        logOutToolStripMenuItem.Visible = true; 

                        if (isAdmin)
                        {
                            tabcontrol1.SelectedTab = tabPage3;
                            label2.Show();
                            button4.Hide();
                            textBox1.Hide();
                            textBox2.Hide();
                            label3.Hide();
                            label5.Hide();
                            dataGridView2.Show();
                            comboBox4.Show();
                            comboBox5.Show();
                            dateTimePicker4.Show();
                            dateTimePicker5.Show();
                            label19.Show();
                            label17.Show();
                            label20.Show();
                            label21.Show();
                            button6.Show();
                            administrationToolStripMenuItem.Visible = true;
                        }
                        else if (!isAdmin)
                        {
                            tabcontrol1.SelectedTab = tabPage2; 
                            //Admin information 
                            dataGridView2.Hide();
                            comboBox4.Hide();
                            comboBox5.Hide();
                            dateTimePicker4.Hide();
                            dateTimePicker5.Hide();
                            label19.Hide();
                            label17.Hide();
                            label20.Hide();
                            label21.Hide();
                            //================

                            label13.Show();
                            button6.Hide();
                            textBox1.Hide();
                            textBox2.Hide();
                            button4.Hide();
                            label3.Hide();
                            label5.Hide();
                        }
           
                      
                        // This call loads the categories after logging in so there needs to be a user logged in to do anything. 
                        // This list does not contain "All Categories". 
                        comboBox2.Items.Clear();
                        comboBox2.Items.AddRange(userChecks.addCategories().ToArray());
               
                        // This call loads the categories after logging in so there needs to be a user logged in to do anything.
                        comboBox5.Items.Clear();//no duplicates
                        comboBox5.Items.AddRange(login.loadCategoryList().ToArray());
                      
                        // This call loads the list of users into the comboBox on the view history tab.
                        comboBox4.Items.Clear();//no duplicates
                        comboBox4.Items.AddRange(login.loadUserList().ToArray());
                      
                        // This call loads the categories after logging in so there needs to be a user logged in to do anything.
                        comboBox3.Items.Clear(); //no duplicates
                        comboBox3.Items.AddRange(login.loadCategoryList().ToArray());

                        // This adds the login history of the user. 
                        login.add_history(textBox1.Text, date);
                    }
                    else if (exists == false)
                    {
                        MessageBox.Show("Incorrect login information.", "ERROR");
                        textBox1.Clear();
                        textBox2.Clear();
                    }

                    else if (validPassword == false)
                    {
                        MessageBox.Show("Incorrect login information.", "ERROR");
                        textBox2.Clear();
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
            tabcontrol1.SelectedTab = tabPage1; 
            label13.Hide();
            label2.Hide();
            tabPage1.Hide();
            logOutToolStripMenuItem.Visible = false; 
            administrationToolStripMenuItem.Visible = false;
            tabcontrol1.Appearance = TabAppearance.FlatButtons;
            tabcontrol1.ItemSize = new Size(0, 1);
            tabcontrol1.SizeMode = TabSizeMode.Fixed;
            button4.Show();
            textBox1.Show();
            textBox2.Show();
            label3.Show();
            label5.Show();
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Text = "Venture Business Management";
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
            if (comboBox2.Text == "")//Make sure a category is picked
            {
                MessageBox.Show("Please select a category.", "ERROR");
            }

            else if (textBox3.Text == "")//make sure something is entered for the text box
            {
                MessageBox.Show("Error: You forgot to enter an expense", "Error!");
            }
            else if (!decimal.TryParse(textBox3.Text, out d))
            {
                MessageBox.Show("Please enter a valid expense. (Ex. 1234.56)");
                textBox3.Clear();
                return;
            }
            else if (comboBox2.Text == "Mileage" && !decimal.TryParse(textBox3.Text, out d))
            {
                MessageBox.Show("Please enter a valid mileage. (Ex. 1234.5)");
            }
            /* else if (richTextBox2.Text == "")  // This can be potentially used for cycle 3, making comments mandatory
            {                                     // when entering data. 
                MessageBox.Show("You must enter comments for your expense.");
            }*/
            else if (Convert.ToDecimal(textBox3.Text) == 0)//no 0 values allowed for expense
            {
                MessageBox.Show("The entry you are trying to enter is Free (Does not need to be recorded).", "Error!");
            }

            else// convert the contents of the input to the correct formats and pass them to an add transaction function in Control
            {
                if (!checkExpenseInput(textBox3.Text) && comboBox2.Text != "Mileage")//added 10/30/2014 checks for decimal and correct formatting if it's not mileage
                {
                    MessageBox.Show("Incorrect format. Try again.");
                }
                else if (comboBox2.Text == "Mileage" && textBox3.Text.Contains("."))
                {
                    MessageBox.Show("Incorrect format. Try again."); //mileage should not have decimal
                }
                else if (comboBox2.Text == "Mileage" && textBox3.TextLength > 6) //mileage should not be over 6 digits added: 11/2/2014
                {
                    MessageBox.Show("Error, input too large.");
                }
                else
                {
                    decimal expense = Convert.ToDecimal(textBox3.Text);
                    DateTime date = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
                    Control newdata = new Control();
                    Data dataCaller = new Data();

                    dataCaller.add_detailed(expense, comboBox2.Text, date, textBox1.Text, richTextBox2.Text);
                    newdata.addatransaction(expense, comboBox2.Text, date, textBox1.Text, richTextBox2.Text);
                    comboBox2.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Today;
                    textBox3.Clear();
                    richTextBox2.Clear();
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
            CultureInfo ci = new CultureInfo("en-us");//used to display the totals in the correct format added 11/2/2014
            label10.Text = "0"; //clear text so it doesn't show old values
            label23.Text = "0"; //clear text so it doesn't show old values
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please select a category.", "ERROR");//make sure the category is not empty
            }
            else
            {
                //make appropriate conversions
                List<Transaction> expenseReport = new List<Transaction>();
                decimal totalExp = 0;
                DateTime startDate = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
                Control loadData = new Control();
                //call the control function to load data. Pass the values.
                loadData.loadExpenseReport(startDate, endDate, comboBox3.Text, ref expenseReport, ref totalExp, textBox1.Text);//Use start date, end date, and category
               
                dataGridView1.DataSource = expenseReport;//Display in text field (date, expense, total expense)
                
                label18.Text = comboBox3.Text; // to show which report is being shown
                label18.Show();
                if (endDate < startDate) 
                { 
                    MessageBox.Show("Your end date is higher than your start date, please correct this and try again.", "Error!");
                    return;
                }
                else if (comboBox3.Text == "Mileage")
                {                
                    label23.Text = loadData.mileage(startDate, endDate).ToString(); //display total for mileage only
                }
                else if (comboBox3.Text == "All Categories")
                {
                    label10.Text = totalExp.ToString("N02", ci);//Display the total correct format with commas
                    label23.Text =  loadData.mileage(startDate, endDate).ToString("N0", ci); //display total for mileage only
                }
                else
                {
                    label10.Text = totalExp.ToString("N02", ci);//Display the total correct format with commas
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

            string startstring = dateTimePicker1.Value.ToShortDateString();//get the start date
            DateTime start = Convert.ToDateTime(startstring);

            string endstring = dateTimePicker2.Value.ToShortDateString();//get the end date
            DateTime end = Convert.ToDateTime(endstring);
            Data history = new Data();

            List<Transaction> expenseReport = new List<Transaction>();
            decimal totalExp = 0;
            DateTime startDate = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            Control loadData = new Control();
            //call the control function to load data. Pass the values.
            loadData.loadExpenseReport(startDate, endDate, comboBox3.Text, ref expenseReport, ref totalExp, textBox1.Text);//Use start date, end date, and category

            //make sure that ALL the fields are filled in and also that the user does not pick an end date earlier than the start date
            if (comboBox4.Text == "" && comboBox5.Text == "") 
            { 
                MessageBox.Show("You have not provided a USER or CATEGORY with which to process your request. Please try again after doing so.", "Error!"); 
            }
            else if (comboBox4.Text == "") 
            {
                MessageBox.Show("Please select a user.", "ERROR"); 
            }
            else if (comboBox5.Text == "") 
            {
                MessageBox.Show("Please select a category.", "ERROR"); 
            }
            else if (end < start) 
            { 
                MessageBox.Show("Your end date is higher than your start date, please correct this and try again.", "Error!"); 
            }
            else
            {
                history.getTransCount(this.dataGridView2, comboBox4.Text, comboBox5.Text, start, end);
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
                excel.export(this.dataGridView1, label10.Text, label23.Text);
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
            label10.Text = "0"; //clear text so it doesn't show old values
            label23.Text = "0"; //clear text so it doesn't show old values
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please select a category.", "ERROR");
            }
            else
            {
                List<DetailedTransaction> expenseReports = new List<DetailedTransaction>();
                decimal totalExp = 0;
                DateTime startDate = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
                Control loadData = new Control();
                //call the control function to load data. Pass the values.
                loadData.loadDetailedExpenseReport(startDate, endDate, comboBox3.Text, ref expenseReports, ref totalExp, textBox1.Text);//Use start date, end date, and category
                dataGridView1.DataSource = expenseReports;//Display in text field (date, expense, total expense)
                if (endDate < startDate)
                {
                    MessageBox.Show("Your end date is higher than your start date, please correct this and try again.", "Error!");
                    return;
                }
                else if (comboBox3.Text == "Mileage")
                {
                    label23.Text = loadData.mileage(startDate, endDate).ToString(); //display total for mileage only
                }
                else if (comboBox3.Text == "All Categories")
                {
                    label10.Text = totalExp.ToString("N02", ci);//Display the total correct format with commas
                    label23.Text = loadData.mileage(startDate, endDate).ToString("N0", ci); //display total for mileage only
                }
                else
                {
                    label10.Text = totalExp.ToString("N02", ci);//Display the total correct format with commas
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
            textBox3.MaxLength = 6;
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