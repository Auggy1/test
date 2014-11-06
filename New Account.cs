//=====================================================================
// AUTHORS: 
//          Cycle 2: Maxwell Partington & Ranier Limpiado     
// PURPOSE: This is the new account form of the program that creates
//          a new user based on the administrators input. It then saves
//          the new user to either the user.xml file or the userAdminXml
//          file depending on whether or not the admin wants them to
//          be an admin. 
// PARAMS:  Proper execution of the .exe is the only parameter. 
// UPDATED:    11/3/14
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

namespace Project_Forms
{ 
    public partial class New_Account : Form
    {
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This creates the new account form and class. 
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        public New_Account()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.label9, "Username must follow these guidelines: \n 1. At least five characters in length \n 2. At least one uppercase charcter (A-Z) \n 3. At least one lowercase character (a-z) \n 4. At least one number (0-9) \n 5. _ character acceptable \n All other characters forbidden");
            toolTip1.SetToolTip(this.label10, "Password must follow these guidelines: \n 1. At least six characters in length \n 2. At least one uppercase charcter (A-Z) \n 3. At least one lowercase character (a-z) \n 4. At least one number (0-9) \n All other characters forbidden");
        }//end 
        //=====================================================================
       
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks if the inputs are correct if it is then the user is 
        //          added to the xml file
        // PARAMS:  None.
        // UPDATED: 11/3/14
        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            string error = "Incorrect Login Information"; // error meessage
            if (string.IsNullOrWhiteSpace(textBox1.Text) || checkInput(textBox1.Text) || textBox1.Text.Length < 5) // make sure format is correct for username
            {
                MessageBox.Show("Please enter a user name containing the following characters: [a-z][A-Z][0-9] or […]");
            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text) || checkInput(textBox2.Text) || textBox3.Text.Length < 6 || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text)) // make sure format is correct for password
            {
                MessageBox.Show(error);
            }
            else if (!textBox6.Text.Equals(textBox5.Text))
            {
                MessageBox.Show("Emails do not match. Try Again.");
            }
            else if (!IsValidEmail(textBox5.Text))
            {
                MessageBox.Show("Please enter a valid email address (johndoe@aol.com).");
            }
            else // if everything is filled correctly, 
            {
                Data newUser = new Data();
                
                if (newUser.userExists(textBox1.Text,checkBox1.Checked))
                {
                    MessageBox.Show("User exists already.");
                    this.Close();
                }
                else 
                    {
                       string encryptedPass = newUser.Encrypt(textBox3.Text, "password");// encrypt the password, need to decrypt it later 10/27/2014
                       newUser.addNewUser(textBox1.Text, encryptedPass, checkBox1.Checked, textBox2.Text, textBox4.Text, textBox5.Text);
                    }
                this.Refresh();
                this.Close();
            }
        }//end 
        //=====================================================================
        
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password and username
        // PARAMS:  The userName from the textboxes.
        // UPDATED: 11/3/14
        //=====================================================================
        private bool checkInput(string userName)
        {
            string regex = @"^[a-zA-Z0-9_]*$"; // for the username only letters, numbers, and underscores
            Match m = Regex.Match(userName, regex, RegexOptions.IgnoreCase);
            if (!m.Success)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < userName.Length; i++) // check for spaces between the string and return true 
                {
                    if (char.IsWhiteSpace(userName, i))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }//end checkInput
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password and username
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int stringSize = textBox1.Text.Length;
            if (stringSize < 5)
            {
                errorProvider1.SetError(textBox1, "Needs to be at least 5 characters."); //errorProvider enabled if username is < 5
            }
            else
            {
                errorProvider1.Clear();
            }
        }//end 
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: To check if the correct format is entered into the password and username
        // PARAMS:  None. 
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var stringSize = textBox3.Text.Length;
            if (stringSize < 6)
            {
                errorProvider2.SetError(textBox3, "Needs to be at least 6 characters."); //errorProvider enabled if password is < 6
            }
            else
            {
                errorProvider2.Clear();
            }
        }//end 
        //=====================================================================

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
        //=====================================================================

        string oldText = string.Empty;

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks that the first name is correct.  
        // PARAMS:  None.  
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox2.Text;
                textBox2.Text = oldText;

                textBox2.BackColor = System.Drawing.Color.White;
                textBox2.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox2.Text = oldText;
                textBox2.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please enter a first name.");
                textBox2.ForeColor = System.Drawing.Color.White;
            }
            textBox2.SelectionStart = textBox2.Text.Length;
        }//end 
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Checks that the last name is correct.  
        // PARAMS:  None.  
        // UPDATED: 11/3/14
        //=====================================================================
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox4.Text;
                textBox4.Text = oldText;

                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox4.Text = oldText;
                textBox4.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please enter a last name.");
                textBox4.ForeColor = System.Drawing.Color.White;
            }
            textBox4.SelectionStart = textBox4.Text.Length;
        }//end textBox4_TextChanged
        //=====================================================================

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
                catch (FormatException)
                {
                    return false;
                }
        }//end isValidEmail
        //=====================================================================

    }
}
