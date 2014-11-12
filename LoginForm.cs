//=====================================================================
// AUTHORS: Jeff Henry
// PURPOSE: This form will handle login for the user when the application
//          is executed. It will verify the user exists in the system,
//          the password is correct, and will launch the main application.
//          Otherwise it will display error messages to the user.
// REVISION HISTORY:
//          11/12/2014 - Initial Creation.
//=====================================================================
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function handles a user attempting to login. It checks
        //          against the possible errors in username, password, or both. 
        //          Upon successful login, it will open the main form and set
        //          which tabs should be shown, as well as update the home info.
        // UPDATES: 11/12/2014 - Jeff Henry - Initial Creation.
        //=====================================================================
        private void LoginBtnClick(object sender, EventArgs e)
        {
            Control login = new Control();
            Data user_checks = new Data();

            errorProvider1.Clear();
            errorProvider2.Clear();
            login_error_msg.Visible = false;

            if (username_box.Text == "" && password_box.Text == "")
            {
                errorProvider1.SetError(username_box, "Username must be provided.");
                errorProvider2.SetError(password_box, "Password must be provided.");
                login_error_msg.Text = " Username and Password must be provided.";
                login_error_msg.Show();
            }
            else if (username_box.TextLength < 5 && username_box.Text != "admin")
            {
                errorProvider1.SetError(username_box, "Username is too short.");
                login_error_msg.Text = "Username is too short.";
                login_error_msg.Show();
            }
            else if (password_box.TextLength < 6)
            {
                errorProvider1.SetError(password_box, "Password is too short.");
                login_error_msg.Text = "Password is too short.";
                login_error_msg.Show();
            }
            else
            {
                bool admin = user_checks.CheckIfAdmin(username_box.Text);
                bool exists = user_checks.CheckUserExistence(username_box.Text, admin);
                bool validPass = user_checks.VerifyPassword(username_box.Text, password_box.Text);

                // If the user entered correct login information, we need to call the main 
                // form and pass information such as who logged in, and if they are an
                // administrator so we can determine what tabs and information should be shown.
                if (exists && validPass)
                {
                    Home main_app = new Home(username_box.Text, admin);
                    this.Hide();
                    main_app.ShowDialog();
                    reset();
                    this.Show();
                }
                else if (!exists)
                {
                    login_error_msg.Text = "User does not exist.";
                    login_error_msg.Show();
                    username_box.Clear();
                    password_box.Clear();
                }
                else if (!validPass)
                {
                    login_error_msg.Text = "Invalid Password. Try Again.";
                    login_error_msg.Show();
                    password_box.Clear();
                }
            }

        }

        //===================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function resets the login form.
        //===================================================================
        private void reset()
        {
            username_box.Text = "";
            password_box.Text = "";
        }
    }
}
