//=====================================================================
// AUTHORS: Maxwell Partington & Ranier Limpiado 
// PURPOSE: This form was designed for the adminstrators of the program
//          to add/edit/delete users and categories in the program.
// PARAMS:  There are no required parameters for this form to work, besides
//          the proper execution and running of the initial screen. 
// UPDATED: 11/3/2014
//=====================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Forms
{
    public partial class Adminstration : Form
    {
        // Used to handle if a user ticks and reticks a checkbox:
        bool original_admin_attr = false;       
        bool original_locked_attr = false;

        public Adminstration()
        {
            InitializeComponent();
            List<string> users_list = new List<string>();       // List to be used as Data Source for user dropdown
            List<string> cats_list = new List<string>();        // List to be used as Data Source for category dropdown
    
            // These buttons will be hidden until the user
            // requests to enter a new name for a category,
            // and then we will show them for them to enter
            // /submit/validate their change.
            textBox1.Hide();
            label9.Hide();
            button5.Hide();

            // We check that the appropriate XML's exist. 
            Data checkExists = new Data();
            
            if (checkExists.xmlcheck())
            {
                // Load in all XML documents to edit. 
                XDocument userDoc = XDocument.Load(@"users.xml");
                XDocument adminDoc = XDocument.Load(@"user_admin.xml");
                XDocument catDoc = XDocument.Load(@"categories.xml");

                //=============================================================
                // AUTHOR:  Maxwell Partington & Ranier Limpiado 
                // PURPOSE: This segment of code pulls the users from the
                //          users.xml document and puts them all into a 
                //          list so that we can iterate through the list,
                //          and put them all into a combobox for the user to choose. 
                // PARAMS:  This foreach requires the appropriate xml doc to 
                //          pull information from. 
                // UPDATED: 11/3/2014
                //=============================================================
                foreach (var User in userDoc.Descendants("User"))
                {
                    users_list.Add(User.Element("Username").Value);
                }
                foreach (var User in adminDoc.Descendants("User"))
                {
                    users_list.Add(User.Element("Username").Value);
                }

                // Sort the list and make it the data source of the dropdown:
                users_list.Sort();
                admin_user_dropdown.DataSource = users_list;
                admin_user_dropdown.SelectedIndex = 0;

                //==========================================================

                //=====================================================================
                // AUTHOR:  Maxwell Partington & Ranier Limpiado 
                // PURPOSE: This segment does the same as above, but for the category 
                //          dropdown. 
                // UPDATED: 11/3/2014 
                //=====================================================================
                foreach (var Category in catDoc.Descendants("Category"))
                {
                    cats_list.Add(Category.Element("categoryName").Value);
                }
                
                // Sort the category list and make it the data source of the dropdown:
                cats_list.Sort();
                admin_cat_dropdown.DataSource = cats_list;
                admin_cat_dropdown.SelectedIndex = 0;

            }//end category dropdown 
            //=====================================================================
        }

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function is used when the user clicks "Submit Changes"
        //          to update a users information. 
        // PARAMS:  A proper execution of administration form.  
        // UPDATED: 11/3/2014
        //=====================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            Data functionCaller = new Data();

            string userToBeEdited = admin_user_dropdown.Text;
            user_admin_err_msg.Visible = false;
            MessageBox.Show("Original lock value " + original_locked_attr + "\nCheckbox valud " + lock_unlock_chkbox);
            // This is a check to make sure they selected a user to edit. 
            if (admin_user_dropdown.Text == "")
            {
                user_admin_err_msg.Text = "Please select a user.";
                user_admin_err_msg.Visible = true;
                return;
            }

            // This is to check that the user selected one of the options. 
            else if (lock_unlock_chkbox.Checked == false && make_admin_chkbox.Checked == false && delete_chkbox.Checked == false)
            {
                user_admin_err_msg.Text = "No changes were made.";
                user_admin_err_msg.Visible = true;
                return;
            }

            // A user cannot lock an admin, so this is a check if both the 
            // "make admin" and "lock" boxes are not checked at the same time. 
            else if ((lock_unlock_chkbox.Checked) && (make_admin_chkbox.Checked))
            {
                user_admin_err_msg.Text = "An administrator account can't be locked.";
                user_admin_err_msg.Visible = true;
                lock_unlock_chkbox.Checked = original_locked_attr;
                make_admin_chkbox.Checked = original_admin_attr;
                return;
            }

            // This check is for when the adminstrator wants to make the
            // the select user an admin. It prompts the user for a yes or no
            // and then proceeds. 
            else if ((admin_user_dropdown.Text != "") && (make_admin_chkbox.Checked) && (!original_admin_attr))
            {

                DialogResult dialog = MessageBox.Show("Are you sure you want to make '" + userToBeEdited + "' an admin?", "Confirm", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    functionCaller.changeStatus(userToBeEdited, true);
                    make_admin_chkbox.Checked = false;
                    return;
                }
            }

            // This is a check to see if the administrator wants to delete a user. 
            else if ((admin_user_dropdown.Text != "") && (delete_chkbox.Checked))
            {
                functionCaller.deleteUser(userToBeEdited);
                delete_chkbox.Checked = false;
                user_admin_err_msg.Text = userToBeEdited + " has been deleted.";
                user_admin_err_msg.Show();
            }

            // This is a check to see if the administrator wants to lock a user:
            else if ((admin_user_dropdown.Text != "") && (lock_unlock_chkbox.Checked) && (!original_locked_attr))
            {
                functionCaller.lockUnlockUser(userToBeEdited, original_locked_attr);
                lock_unlock_chkbox.Checked = true;
                user_admin_err_msg.Text = userToBeEdited + " has been locked.";
                user_admin_err_msg.Visible = true;
            }

            // This is a check to see if the administrator wants to unlock a user:
            else if ((admin_user_dropdown.Text != "") && (!lock_unlock_chkbox.Checked) && (original_locked_attr))
            {
                MessageBox.Show("Attempting to unlock User");
                functionCaller.lockUnlockUser(userToBeEdited, original_locked_attr);
                lock_unlock_chkbox.Checked = false;
                user_admin_err_msg.Text = userToBeEdited + " has been unlocked.";
                user_admin_err_msg.Visible = true;
            }
            else
            {
                user_admin_err_msg.Text = "No changes were made.";
                user_admin_err_msg.Visible = true;
            }
        }//end button1_Click 
        //=====================================================================


        //=====================================================================
        // AUTHOR:  Maxwell Partington
        // PURPOSE: Used to add a new category. It will first check to see if the
        //          category already exists, and if not, it will add it to the
        //          category.xml.  
        // UPDATED: 11/3/2014
        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            Data checkCat = new Data();
            bool exists = false;
            if (admin_new_cat_input.Text == "")
            {
                MessageBox.Show("Please enter a category name.", "ERROR");
            }
            else
            {
                exists = checkCat.checkDuplicateCategory(admin_new_cat_input.Text);
                if (exists == false)
                {
                    Data functionCall = new Data();
                    string catToAdd = admin_new_cat_input.Text;
                    functionCall.addNewCategory(catToAdd);
                    refresh_dropdowns();
                    this.Refresh();
                    admin_new_cat_input.Text = "";
                }
                else if (exists == true)
                {
                    MessageBox.Show("The category '" + admin_new_cat_input.Text + "' already exists.");
                    return;
                }
            }
        }//end button2_Click 
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Used to delete a category. 
        // UPDATED: 11/3/2014
        //=====================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            if (admin_cat_dropdown.Text == "")
            {
                MessageBox.Show("Please select a category to delete from the list.", "ERROR");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Confirm delete:", "Confirm", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Data functionCall = new Data();
                    string catToDelete = admin_cat_dropdown.Text;
                    functionCall.deleteCategory(catToDelete);
                    refresh_dropdowns();
                    this.Refresh();
                }
            }
        }//end button4_Click 
        //=====================================================================


        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Used to show the correct boxes/buttons for adding a category. 
        // UPDATED: 11/3/2014
        //=====================================================================
        private void button3_Click(object sender, EventArgs e)
        {
            if (admin_cat_dropdown.Text == "")
            {
                MessageBox.Show("ERROR. Please select a category name.");
            }
            else
            {
                textBox1.Show();
                label9.Show();
                button5.Show();
            }
        }//end button3_Click 
        //=====================================================================

        //=====================================================================
        // AUTHOR: Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Used to send the category to be renamed to the data.cs file. 
        // UPDATED: 11/3/2014
        //=====================================================================
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a category name.", "ERROR");
            }
            else
            {
                Data functionCall = new Data();
                string catToRename = admin_cat_dropdown.Text;
                functionCall.renameCategory(catToRename, textBox1.Text);
                refresh_dropdowns();
                this.Refresh();
                return;
            }
        }//end button5_Click 
        //=====================================================================

        //=====================================================================
        // This closes the form when the user clicks "Exit" 
        //=====================================================================
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //=====================================================================
        // If the admin selects a user from the dropdown list, we need to check
        // if that user is an admin, so we can tick the Admin box or Locked box.
        //=====================================================================
        private void admin_user_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data functionCall = new Data();
            // Update the admin checkbox.
            if (functionCall.checkAdmin(admin_user_dropdown.Text))
            {
                make_admin_chkbox.Checked = true;
                original_admin_attr = true;
            }
            else
            {
                make_admin_chkbox.Checked = false;
                original_admin_attr = false;
            }   

            // Update the locked checkbox.
            if (functionCall.checkLocked(admin_user_dropdown.Text))
            {
                lock_unlock_chkbox.Checked = true;
                original_locked_attr = true;
            }
            else
            {
                lock_unlock_chkbox.Checked = false;
                original_locked_attr = false;
            }
        }// end 
        //=====================================================================

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
            admin_cat_dropdown.DataSource = null;
            admin_user_dropdown.DataSource = null;

            // Update the dropdowns with the new data:
            admin_cat_dropdown.DataSource = updates.addCategories();
            admin_user_dropdown.DataSource = updates.loadUsers();
        }

    }
}
