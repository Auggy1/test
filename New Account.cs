﻿//=====================================================================
// AUTHORS: 
//          Cycle 2: Maxwell Partington & Ranier Limpiado    
//          Cycle 3: Jeff Henry & Augustine Garcia 
// PURPOSE: This is the new account form of the program that creates
//          a new user based on the administrators input. It then saves
//          the new user to either the user.xml file or the userAdminXml
//          file depending on whether or not the admin wants them to
//          be an admin. 
// PARAMS:  Proper execution of the .exe is the only parameter. 
// UPDATED: 11/6/14
//=====================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Globalization;

namespace Project_Forms
{ 
    public partial class New_Account : Form
    {
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This creates the new account form and class. 
        // PARAMS:  None. 
        // UPDATED: 11/5/14     Reassigned ToolTips to boxes.
        //=====================================================================
        public New_Account()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.na_username, "Username must follow these guidelines: \n 1. At least five characters in length \n 2. At least one uppercase charcter (A-Z) \n 3. At least one lowercase character (a-z) \n 4. At least one number (0-9) \n 5. _ character acceptable \n All other characters forbidden");
            toolTip1.SetToolTip(this.na_password, "Password must follow these guidelines: \n 1. At least six characters in length \n 2. At least one uppercase charcter (A-Z) \n 3. At least one lowercase character (a-z) \n 4. At least one number (0-9) \n All other characters forbidden");
        }//end 
       
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks if the inputs are correct if it is then the user is 
        //          added to the xml file
        // PARAMS:  None.
        // UPDATED: 11/5/14     Email is no longer required. Jeff Henry
        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            // Clear the error messages and error providers:
            na_error_msg_1.Text = "";
            na_error_msg_2.Text = "";
            errorProvider1.Clear();
            errorProvider2.Clear();

            // make sure format is correct for username
            if (string.IsNullOrWhiteSpace(na_username.Text) || checkInput(na_username.Text) || na_username.Text.Length < 5) 
            {
                na_error_msg_1.Text = "Username must contain the following: [a-z][A-Z][0-9][_]";
                na_error_msg_1.Visible = true;
                //MessageBox.Show("Please enter a user name containing the following characters: [a-z][A-Z][0-9] or [_]");
            }
            else if (string.IsNullOrWhiteSpace(na_password.Text))
            {
                na_error_msg_1.Text = "Please enter a password";
                na_error_msg_1.Visible = true;
                //MessageBox.Show("Please enter a password");
            }
            else if (checkInput(na_firstname.Text))
            {
                na_error_msg_1.Text = "Username not allowed. Please try again.";
                na_error_msg_1.Visible = true;
                //MessageBox.Show("Please enter a valid username");
            }
            else if (na_password.Text.Length < 6) // make sure format is correct for password
            {
                na_error_msg_1.Text = "Password must be at least 6 characters long.";
                na_error_msg_1.Visible = true;
                //MessageBox.Show("Please enter a password that is at least 6 characters long.");
            }
            else if (!na_verifyemail.Text.Equals(na_email.Text))
            {
                na_error_msg_2.Text = "Emails do not match. Try Again.";
                na_error_msg_2.Visible = true;
                //MessageBox.Show("Emails do not match. Try Again.");
            }
            else if (!string.IsNullOrWhiteSpace(na_email.Text) && !IsValidEmail(na_email.Text))
            {
                na_error_msg_2.Text = "Please enter a valid email address. (Ex. johndoe@aol.com)";
                na_error_msg_2.Visible = true;
               //MessageBox.Show("Please enter a valid email address (johndoe@aol.com).");
            }
            else // if everything is filled correctly, 
            {
                Data newUser = new Data();
                
                if (newUser.CheckUserExistence(na_username.Text,admin_chkbox.Checked))
                {
                    na_error_msg_2.Text = "Username is taken, try again.";
                    na_error_msg_2.Visible = true;
                    na_username.Text = "";
                    return;
                    //MessageBox.Show("User exists already.");
                    //this.Close();
                }
                else 
                {
                    string encryptedPass = newUser.Encrypt(na_password.Text, "password");// encrypt the password, need to decrypt it later 10/27/2014
                    newUser.AddNewUser(na_username.Text, encryptedPass, admin_chkbox.Checked, na_firstname.Text, na_lastname.Text, na_email.Text,false);
                }
                this.Refresh();
                //this.Close();
            }
        }//end 
        //=====================================================================
        
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password 
        //          and username
        // PARAMS:  The userName from the textboxes.
        // UPDATED: 11/5/14     Refactored      Jeff Henry
        //=====================================================================
        private bool checkInput(string userName)
        {
            // For the username only letters, numbers, and underscores
            Match match = Regex.Match(userName,@"^[a-zA-Z0-9_]*$", RegexOptions.IgnoreCase);
            if (!match.Success){return true;}
            else
            {
                // check for spaces between the string and return true
                for (int i = 0; i < userName.Length; i++)  
                {
                    if (char.IsWhiteSpace(userName, i)){return true;}
                    //else{return false;}
                }
                return false;
            }
        }//end checkInput

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password 
        //          and username
        // PARAMS:  None. 
        // UPDATED: 11/10/14    Jeff Henry  -   Refactored
        //=====================================================================
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (na_username.Text.Length < 5)
                errorProvider1.SetError(na_username, "Needs to be at least 5 characters."); 
            else
                errorProvider1.Clear();
        }//end

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password
        //          and username
        // PARAMS:  None. 
        // UPDATED: 11/10/14    Jeff Henry  - Refactored
        //=====================================================================
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (na_password.Text.Length < 6)
                errorProvider2.SetError(na_password, "Needs to be at least 6 characters."); 
            else
                errorProvider2.Clear();
        }//end

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Closes the form if the admin doesn't want to make a new account. 
        // PARAMS:  The userName from the textboxes.
        // UPDATED: 11/3/14
        //=====================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end

        string oldText = string.Empty;

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks that the first name is correct.  
        // PARAMS:  None.  
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (na_firstname.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = na_firstname.Text;
                na_firstname.Text = oldText;

                na_firstname.BackColor = System.Drawing.Color.White;
                na_firstname.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                na_firstname.Text = oldText;
                na_firstname.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please enter a first name.");
                na_firstname.ForeColor = System.Drawing.Color.White;
            }
            na_firstname.SelectionStart = na_firstname.Text.Length;
        }//end

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks that the last name is correct.  
        // PARAMS:  None.  
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (na_lastname.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = na_lastname.Text;
                na_lastname.Text = oldText;

                na_lastname.BackColor = System.Drawing.Color.White;
                na_lastname.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                na_lastname.Text = oldText;
                na_lastname.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please enter a last name.");
                na_lastname.ForeColor = System.Drawing.Color.White;
            }
            na_lastname.SelectionStart = na_lastname.Text.Length;
        }//end

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks that the email is correct.  
        // PARAMS:  None.  
        // UPDATED: 11/3/14
        //=====================================================================
        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException){return false;}
        }


        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will autocapitalize the first letter entered.
        // UPDATED: 11/9/2014   Jeff Henry - Initial Creation
        //=====================================================================
        private void na_firstname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(na_firstname.Text))
            {
                // Converts to character array then updates the first char.
                char[] letters = na_firstname.Text.ToCharArray();
                string name = letters[0].ToString().ToUpper();
                for (int i = 1; i < letters.Length; i++)
                    name += letters[i].ToString().ToLower();
                na_firstname.Text = name;
                // Need to move to next character otherwise only one char can be entered.
                na_firstname.Select(na_firstname.Text.Length, 0);
            }
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will autocapitalize the first letter entered.
        // UPDATED: 11/9/2014   Jeff Henry - Initial Creation
        //=====================================================================
        private void na_lastname_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(na_lastname.Text))
            {
                // Converts to character array then updates the first char.
                char[] letters = na_lastname.Text.ToCharArray();
                string name = letters[0].ToString().ToUpper();
                for (int i = 1; i < letters.Length; i++)
                    name += letters[i].ToString().ToLower();
                na_lastname.Text = name;
                // Need to move to next character otherwise only one char can be entered.
                na_lastname.Select(na_lastname.Text.Length, 0);
            }
        }//end 
    }
}
