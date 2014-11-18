//==================================================================
// AUTHOR:  Jeff Henry
// PURPOSE: This form will allow the user to change their password 
//          as long as they correctly enter their old password and 
//          the new password must follow password requirements.
// UPDATED: 11/18/2014 - Initial Creation
//==================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Forms
{
    public partial class ChangePasswordForm : Form
    {
        Control allcontrol;
        string current_user; 
        public ChangePasswordForm(Control control, string user)
        {
            InitializeComponent();
            allcontrol = control;
            current_user = user;
        }

        //===================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will enable the new password box once text
        //          is entered into the old password box.
        //===================================================================
        private void OldPasswordChange(object sender, EventArgs e)
        {
            if (old_password_box.Text != "")
                new_password_box.Enabled = true;
            else
                new_password_box.Enabled = false;
        }

        //===================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will enable the verify password box once
        //          text is entered into the new password box.
        //===================================================================
        private void NewPasswordChange(object sender, EventArgs e)
        {
            // Validate each character that comes in from user:
            foreach (char c in new_password_box.Text.ToCharArray())
            {
                // Handle if the text is whitespace or not a character or integer:
                if (char.IsWhiteSpace(c) || !char.IsLetterOrDigit(c))
                {
                    new_password_box.Text = new_password_box.Text.Remove(new_password_box.Text.Length - 1);
                    new_password_box.Select(new_password_box.Text.Length, 0);
                }
            }

            if (new_password_box.Text != "")
                verify_password_box.Enabled = true;
            else
                verify_password_box.Enabled = false;
        }
        //===================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will enable the change password button and
        //          check only allow the user to enter letters and numbers.
        //===================================================================
        private void VerifyPasswordChange(object sender, EventArgs e)
        {
            foreach (char c in verify_password_box.Text.ToCharArray())
            {
                if (char.IsWhiteSpace(c) || !char.IsLetterOrDigit(c))
                {
                    verify_password_box.Text = verify_password_box.Text.Remove(verify_password_box.Text.Length - 1);
                    verify_password_box.Select(verify_password_box.Text.Length, 0);
                }
            }

            if (verify_password_box.Text != "")
                change_pass_btn.Enabled = true;
            else
                change_pass_btn.Enabled = false;
        }

        //===================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will check the inputs for validity and if
        //          all return successful, the users password will be updated
        //          in the xml and list.
        //===================================================================
        private void ChangePasswordClick(object sender, EventArgs e)
        {
            // Clear any errors:
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            password_error_msg.Text = "";

            // Validate the old password:
            bool old_valid = allcontrol.VerifyPassword(current_user, old_password_box.Text);
            
            // Handle if the old password wasn't correct:
            if (!old_valid)
            {
                errorProvider1.SetError(old_password_box, "Old password does not match.");
                password_error_msg.Text = "Old password does not match.";
                password_error_msg.Show();
                old_password_box.Text = "";
                new_password_box.Text = "";
                verify_password_box.Text = "";
            }
            // Make sure the new password is at least 6 characters long:
            if (new_password_box.Text.Length < 6)
            {
                errorProvider2.SetError(new_password_box, "New Password must be at least 6 characters long.");
                password_error_msg.Text = "New Password must be at least 6 characters long.";
                password_error_msg.Show();
            }
            // Make sure the verify password is at least 6 characters long:
            if (verify_password_box.Text.Length < 6)
            {
                errorProvider3.SetError(verify_password_box, "New Password must be at least 6 characters long.");
                password_error_msg.Text = "New Password must be at least 6 characters long.";
                password_error_msg.Show();
            }
            // Make sure the new password isn't the same as the old password:
            if (old_password_box.Text == new_password_box.Text)
            {
                errorProvider2.SetError(new_password_box, "New password must be different from the old password.");
                password_error_msg.Text = "New password must be different from the old password.";
                password_error_msg.Show();
                new_password_box.Text = "";
                verify_password_box.Text = "";
            }


            // Check that the new password equals the verify password:
            if (new_password_box.Text != verify_password_box.Text)
            {
                errorProvider3.SetError(verify_password_box, "Passwords did not match.");
                password_error_msg.Text = "New passwords did not match.";
                password_error_msg.Show();
                verify_password_box.Text = "";
            }
           
            // Otherwise the passwords matched. Update the user's password.
            else
            {
                string encryptedPass = allcontrol.Encrypt(new_password_box.Text, "password");
                allcontrol.ChangePassword(current_user, encryptedPass);
                this.Close();
            }


        }

        
    }
}
