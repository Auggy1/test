//=====================================================================
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
        Control allcontrol;
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This creates the new account form and class. 
        // PARAMS:  None. 
        // UPDATED: 11/5/14     Reassigned ToolTips to boxes.
        //=====================================================================
        public New_Account(Control control)
        {
            InitializeComponent();
            allcontrol = control;
        }//end 
       
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks if the inputs are correct if it is then the user is 
        //          added to the xml file
        // PARAMS:  None.
        // UPDATED: 11/5/14     Email is no longer required. Jeff Henry
        //          11/28/14    Fixed error message to comply with SRS - Augustin Garcia
        //=====================================================================
        private void SubmitClick(object sender, EventArgs e)
        {
            // Clear the error messages and error providers:
            na_error_msg_1.Text = "";
            na_error_msg_2.Text = "";
            errorProvider1.Clear();
            errorProvider2.Clear();

            // make sure format is correct for username
            if (string.IsNullOrWhiteSpace(na_username.Text) || !CheckInput(na_username.Text) || na_username.Text.Length < 5) 
            {
                na_error_msg_1.Text = "Please enter a (minimum 5 character) username using any of the following characters: [a-z][A-Z][0-9][_]";
                na_error_msg_1.MaximumSize = new Size(300, 0);
                na_error_msg_1.AutoSize = true;
                na_error_msg_1.Visible = true;
            }
            else if (string.IsNullOrWhiteSpace(na_password.Text))
            {
                na_error_msg_1.Text = "Please enter a password with 6 characters.";
                na_error_msg_1.Visible = true;
            }
            else if (allcontrol.CheckUserExistence(na_username.Text))
            {
                na_error_msg_1.Text = "Username is taken. Please try another.";
                na_error_msg_1.Visible = true;
                
            }
            else if (na_password.Text.Length < 6) // make sure format is correct for password
            {
                na_error_msg_1.Text = "Password must be at least 6 characters long.";
                na_error_msg_1.Visible = true;
            }
            else if (na_firstname.Text == "")
            {
                na_error_msg_2.Text = "Please enter a valid first name. [a-z][A-z][-']";
                na_error_msg_2.Visible = true;
            }
            else if (na_lastname.Text == "")
            {
                na_error_msg_2.Text = "Please enter a valid last name. [a-z][A-z][-']";
                na_error_msg_2.Visible = true;
            }
            else if (!string.IsNullOrWhiteSpace(na_email.Text) && !IsValidEmail(na_email.Text))
            {
                na_error_msg_2.Text = "Please enter a valid email address. (Ex. johndoe@aol.com)";
                na_error_msg_2.Visible = true;
            }
            else if (!na_verifyemail.Text.Equals(na_email.Text))
            {
                na_error_msg_2.Text = "Emails do not match. Please re-enter them.";
                na_error_msg_2.Visible = true;
            }
            
            else // if everything is filled correctly, 
            {
                if (allcontrol.CheckUserExistence(na_username.Text))
                {
                    na_error_msg_2.Text = "Username is taken. Try again.";
                    na_error_msg_2.Visible = true;
                    na_username.Text = "";
                    return;
                }
                else
                {
                    string encryptedPass = allcontrol.Encrypt(na_password.Text, "password");// encrypt the password, need to decrypt it later 10/27/2014
                    allcontrol.AddNewUser(na_username.Text, encryptedPass, admin_chkbox.Checked, na_firstname.Text, na_lastname.Text, na_email.Text, false);
                }
                ClearEntries();
                this.Refresh();
            }
        }//end 
        //=====================================================================
        
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password 
        //          and username
        // UPDATED: 11/5/14     Refactored  -    Jeff Henry
        //=====================================================================
        private bool CheckInput(string userName)
        {
            // For the username only letters, numbers, and underscores
            Match match = Regex.Match(userName,@"^[a-zA-Z0-9_]*$", RegexOptions.IgnoreCase);
            if (!match.Success){return false;}
            return true;
        }//end checkInput

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password 
        //          and username
        // PARAMS:  None. 
        // UPDATED: 11/13/14    Jeff Henry  - Checks for whitespace
        //          11/14/14    Jeff Henry  - Wont allow more than 9 characters
        //                                  - Enables submit button after 2 chars.
        //=====================================================================
        private void UsernameBoxTextChange(object sender, EventArgs e)
        {
            if (na_username.TextLength >= 2)
                na_submit_btn.Enabled = true;
            else
                na_submit_btn.Enabled = false;
            
            // Check for whitespaces:
            foreach (char c in na_username.Text.ToCharArray())
                if (char.IsWhiteSpace(c) || na_username.TextLength > 9 || !char.IsLetterOrDigit(c))
                {
                    na_username.Text = na_username.Text.Remove(na_username.Text.Length - 1);
                    na_username.Select(na_username.Text.Length, 0);
                }
            // Check username length:
            if (na_username.Text.Length < 5)
                errorProvider1.SetError(na_username, "Needs to be at least 5 characters."); 
            else
                errorProvider1.Clear();
        }//end

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado & Jeff Henry
        // PURPOSE: To check if the correct format is entered into the password
        //          and username
        // PARAMS:  None. 
        // UPDATED: 11/13/14    Jeff Henry  - Checks for whitespaces now.
        //          11/14/14    Jeff Henry  - Wont allow more than 9 characters.
        //=====================================================================
        private void PasswordBoxTextChange(object sender, EventArgs e)
        {
            // Check for whitespaces.
            foreach (char c in na_password.Text.ToCharArray())
                if (char.IsWhiteSpace(c) || na_password.TextLength > 9 || !char.IsLetterOrDigit(c))
                {
                    na_password.Text = na_password.Text.Remove(na_password.Text.Length - 1);
                    na_password.Select(na_password.Text.Length, 0);
                }
               
            // Check the password length:
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
        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//end

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks that the email is correct.  
        // PARAMS:  None.  
        // UPDATED: 11/3/14
        //=====================================================================
        public bool IsValidEmail(string emailaddress)
        {
            Match match = Regex.Match(emailaddress, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase);
            if (!match.Success) { return false; }
            return true;

            //try{MailAddress m = new MailAddress(emailaddress);return true;}
            //catch (FormatException){return false;}
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will autocapitalize the first letter entered.
        // UPDATED: 11/9/2014   Jeff Henry - Initial Creation
        //=====================================================================
        private void FirstNameTextChange(object sender, EventArgs e)
        {
            // Look for whitespaces first:
            foreach (char c in na_firstname.Text.ToCharArray())
                if (char.IsWhiteSpace(c) || !char.IsLetter(c))
                {
                    na_firstname.Text = na_firstname.Text.Remove(na_firstname.Text.Length - 1);
                    na_firstname.Select(na_firstname.Text.Length, 0);
                }
            // If no whitespaces, make first letter Uppercase.
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
        private void LastNameTextChange(object sender, EventArgs e)
        {
            // Look for whitespaces first:
            foreach (char c in na_lastname.Text.ToCharArray())
                if (char.IsWhiteSpace(c) || !char.IsLetter(c))
                {
                    na_lastname.Text = na_lastname.Text.Remove(na_lastname.Text.Length - 1);
                    na_lastname.Select(na_lastname.Text.Length, 0);
                }
            // If no whitespaces, make first letter Uppercase:
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
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will ignore whitespaces when a user enters an
        //          email.
        //=====================================================================
        private void EmailTextChange(object sender, EventArgs e)
        {
            foreach (char c in na_email.Text.ToCharArray()){
                if (char.IsWhiteSpace(c)){
                    na_email.Text = na_email.Text.Remove(na_email.Text.Length - 1);
                    na_email.Select(na_email.Text.Length, 0);
                }
            }
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will ignore whitespaces when a user enters a
        //          verification email.
        //=====================================================================
        private void VerifyEmailTextChange(object sender, EventArgs e)
        {
            foreach (char c in na_verifyemail.Text.ToCharArray()){
                if (char.IsWhiteSpace(c)){
                    na_verifyemail.Text = na_verifyemail.Text.Remove(na_verifyemail.Text.Length - 1);
                    na_verifyemail.Select(na_verifyemail.Text.Length, 0);
                }
            }
        }//end
         
        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will refresh all the textboxes in the form.
        //=====================================================================
        private void ClearEntries()
        {
            na_username.Text = "";
            na_password.Text = "";
            na_firstname.Text = "";
            na_lastname.Text = "";
            na_email.Text = "";
            na_verifyemail.Text = "";
            na_submit_btn.Enabled = false;
            errorProvider1.Clear();
            errorProvider2.Clear();
        }
    }
}
