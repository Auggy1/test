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
        public Adminstration()
        {
            InitializeComponent();

            // These are our local variables that will hold
            // our list of users, categories, usernames,
            // categories, as well as various counts that will
            // check to make sure we are only adding valid
            // users and categories to our lists. 
            string[] users = new string[100];
            string[] categories = new string[100];
            string userName;
            string adminName; 
            string catName;
            int i = 0;
            int x = 0;
            int count = 0;
            int count2 = 0; 
            bool exists;

            // These buttons will be hidden until the user
            // requests to enter a new name for a category,
            // and then we will show them for them to enter
            // /submit/validate their change.
            textBox1.Hide();
            label9.Hide();
            button5.Hide();

            // We check that the appropriate XML's exist. 
            Data checkExists = new Data();
            exists = checkExists.xmlcheck();

            if (exists == true)
            {
                // Load in all XML documents to edit. 
                XDocument userDoc = XDocument.Load(@"users.xml");
                XDocument adminDoc = XDocument.Load(@"userAdminXml.xml");
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
                    userName = User.Element("Username").Value;
                    if (userName != "admin")
                    {
                        users[i++] = userName;
                        count++;
                    }
                }
                foreach (var User in adminDoc.Descendants("User"))
                {
                    adminName = User.Element("Username").Value;
                    if (adminName != "admin")
                    {
                        users[i++] = adminName;
                        count++;
                    }
                }

                // We declare a new array based on the actual number of users in the xml. 
                string[] actual = new string[count];

                // Save the non-null users to the new array. 
                for (int j = 0; j < 100; j++)
                {
                    if (users[j] != null )
                        actual[j] = users[j];
                }

                // If the array isn't empty, we add it to comboBox1 as a dropdown. 
                if (actual != null)
                {
                    Array.Sort<string>(actual);
                    var source = new AutoCompleteStringCollection();
                    source.AddRange(actual);
                    comboBox1.Items.AddRange(actual);
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                //==========================================================

                //=====================================================================
                // AUTHOR:  Maxwell Partington & Ranier Limpiado 
                // PURPOSE: This segment does the same as above, but for the category 
                //          dropdown. 
                // UPDATED: 11/3/2014 
                //=====================================================================
                foreach (var Category in catDoc.Descendants("Category"))
                {
                    catName = Category.Element("categoryName").Value;
                    categories[x++] = catName;
                    count2++;
                }

                string[] actualCats = new string[count2];

                for (int k = 0; k < 100; k++)
                {
                    if (categories[k] != null)
                    {
                        actualCats[k] = categories[k];
                    }
                }

                if (actualCats != null)
                {
                    Array.Sort<string>(actualCats);
                    var source2 = new AutoCompleteStringCollection();
                    source2.AddRange(actualCats);
                    comboBox2.Items.AddRange(actualCats);
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                }
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

            string userToBeEdited = comboBox1.Text;
            bool admin = checkBox2.Checked; 
            bool locked = checkBox1.Checked;
                    
            // This is a check to make sure they selected a user to edit. 
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a user.");
                return;
            }
            
            // This is to check that the user selected one of the options. 
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                MessageBox.Show("No changes were made.");
                return;
            }

            // A user cannot lock an admin, so this is a check if both the 
            // "make admin" and "lock" boxes are not checked at the same time. 
            else if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                MessageBox.Show("An administrator account cannot be locked.");
                checkBox1.Checked = false;
                checkBox2.Checked = false; 
                return;
            }

            // This check is for when the adminstrator wants to make the
            // the select user an admin. It prompts the user for a yes or no
            // and then proceeds. 
            else if ((comboBox1.Text != "")  && (checkBox2.Checked == true))
            {

                DialogResult dialog = MessageBox.Show("Are you sure you want to make '" + userToBeEdited + "' an admin?", "Confirm", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    functionCaller.editUser(userToBeEdited, admin, locked);
                    checkBox2.Checked = false; 
                    return;
                }
            }
            
            // This is a check to see if the administrator wants to delete a user. 
            else if((comboBox1.Text != "") && (checkBox3.Checked == true))
            {
                functionCaller.deleteUser(userToBeEdited);
                checkBox3.Checked = false;
            }   

            // This is a check to see if the administrator wants to lock/unlock
            // a user. 
            else if ((comboBox1.Text != "") && (checkBox1.Checked == true))
            {
                functionCaller.lockUnlockUser(userToBeEdited, locked);
                checkBox1.Checked = false;  
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
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a category name.", "ERROR");
            }
            else
            {
                exists = checkCat.checkDuplicateCategory(textBox2.Text);
                if (exists == false)
                {
                    Data functionCall = new Data();
                    string catToAdd = textBox2.Text;
                    functionCall.addNewCategory(catToAdd);
                    this.Refresh();
                }
                else if (exists == true)
                {
                    MessageBox.Show("The category '" + textBox2.Text + "' already exists.");
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
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please select a category to delete from the list.", "ERROR");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Confirm delete:", "Confirm", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Data functionCall = new Data();
                    string catToDelete = comboBox2.Text;
                    functionCall.deleteCategory(catToDelete);
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
            if (comboBox2.Text == "")
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
                string catToRename = comboBox2.Text;
                functionCall.renameCategory(catToRename, textBox1.Text);
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
        }// end 
        //=====================================================================
    }
}
