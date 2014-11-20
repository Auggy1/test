//=====================================================================
// AUTHORS: 
//          Cycle 1: Karan Singh & Michelle Jaro
//          Cycle 2: Maxwell Partington & Ranier Limpiado 
//          Cycle 3: Jeff Henry & Augustin Garcia
// PURPOSE: This .cs file holds most of the functions that do the 
//          heavy lifting for the forms. It produces unique user data,
//          data checks, data processing and general information fetching.  
// PARAMS:  This file does not require parameters, but a working app. 
// UPDATED: 11/3/2014
//=====================================================================
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;

namespace Project_Forms
{
    //=========================================================================
    // AUTHOR:  Michelle Jaro & Jeff Henry
    // PURPOSE: This is a class declaration for transactions. All information 
    //          relevant to a transaction will be saved into a Transaction object
    //          and added to a list, to be used with other functions.
    // PARAMS:  None
    //=========================================================================
    public class Transaction
    {
        public string username { get; set; }
        public decimal expenditure { get; set; }
        public string comments { get; set; }
        public string category { get; set; }
        public DateTime dateEntered { get; set; }

        public Transaction()
        {
            username = comments = category = null;
            expenditure = 0.00m;
            dateEntered = DateTime.Now;
        }

        public Transaction(string user, decimal exp, string cmmt, string cat, DateTime date)
        {
            username = user;
            expenditure = exp;
            comments = cmmt;
            category = cat;
            dateEntered = date;
        }
    }//end transaction class
    //=========================================================================

    //=========================================================================
    // AUTHOR:  Jeff Henry
    // PURPOSE: This class will hold all information on a particular user.
    //=========================================================================
    public class User
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool admin { get; set; }
        public bool locked { get; set; }
        public DateTime lastLogin { get; set; }

        public User()
        {
            username = firstname = lastname = password = email = null;
            admin = locked = false;
            lastLogin = DateTime.Now;
        }

        public User(string user, string fname, string lname, string pass, string mail, bool isAdmin, bool isLocked, DateTime login)
        {
            username = user;
            firstname = fname;
            lastname = lname;
            password = pass;
            email = mail;
            admin = isAdmin;
            locked = isLocked;
            lastLogin = login;
        }
    }//end user class
    //=========================================================================

    //=========================================================================
    // PURPOSE: The Data class is the only class capable of reading, writing, 
    //          or even creating the XML Document. This exclusive ability of 
    //          this class makes it  a root for all information 
    //          entry and pulling. 
    // PARAMS:  None
    //=========================================================================
    public class Data
    {
        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: These are the lists that will hold all information for the 
        //          control funtions to interact with, modify, or return to the
        //          main program.
        //=====================================================================
        List<Transaction> transactions = new List<Transaction>();
        List<User> users = new List<User>();

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will return a list of all users to be used for 
        //          dropdown lists in the main program.
        //=====================================================================
        public List<string> GetAllUsers()
        {
            List<string> userlist = new List<string>();
            foreach (var user in users)
                userlist.Add(user.username);
            userlist.Sort();
            return userlist;
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will return a list of only employees to be 
        //          used for dropdown lists in the main program.
        //=====================================================================
        public List<string> GetEmployees()
        {
            List<string> userlist = new List<string>();
            foreach (var user in users)
                if (!user.admin)
                    userlist.Add(user.username);
            userlist.Sort();
            return userlist;
        }


        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will return a list of regular employees to be
        //          used for dropdown lists in the main program.
        //=====================================================================
        public List<string> GetEmployeesOnly()
        {
            List<string> userlist = new List<string>();
            foreach (var user in users)
                if (!user.admin)
                    userlist.Add(user.username);
            return userlist;
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will grab all users from the xml and will save
        //          them to the users list.
        // UPDATED: 11/18/2014  - Jeff Henry    - No need for admin.xml
        //=====================================================================
        public void LoadUsersFromXML()
        {
            if (CheckXMLExistence())
            {
                XmlDocument user_xml = new XmlDocument();
                user_xml.Load("users.xml");
                XmlNodeList user_list = user_xml.SelectNodes("/Users/User");
                foreach (XmlNode node in user_list)
                {
                    User new_user = new User();
                    new_user.username = node["username"].InnerText;
                    new_user.firstname = node["firstName"].InnerText;
                    new_user.lastname = node["lastName"].InnerText;
                    new_user.password = node["password"].InnerText;
                    new_user.email = node["email"].InnerText;
                    new_user.admin = Convert.ToBoolean(node["admin"].InnerText);
                    new_user.locked = Convert.ToBoolean(node["locked"].InnerText);
                    new_user.lastLogin = Convert.ToDateTime(node["lastLogin"].InnerText);
                    users.Add(new_user);
                }
            }
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will create Activities XML to be used to keep
        //          track of all new expenses and user activities while the
        //          admin is logged of.
        // PARAMETERS:  None
        // UPDATES:     11/18/2014 - Jeff Henry - Initial Creation
        //=====================================================================
        public void CreateActivitiesXML()
        {
            XDocument Database =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("This database will store transactions under <Activity> label"),
                    new XElement("App_Records",
                    new XElement("All_Activities",
                    new XElement("First_Run","True"))));
            Database.Save(@"activities.xml");
        }
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Provides a generate template with which the xml should be 
        //          initially created
        // PARAMS:  None
        //=====================================================================
        public void CreateTransactionXML()
        {
            XDocument Database =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("This database will store transactions under <Transaction> label"),
                    new XElement("App_Records",
                    new XElement("All_Transactions")));
                Database.Save(@"transactions.xml");
        }//end xmlCreate
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This creates the default categories.xml
        // DATE:    10/24/14
        //=====================================================================
        public void CreateCategoriesXML()
        {
            XDocument Database =
            new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This database will store categories under <Categories> label"),
            new XElement("All_Categories",
                          new XElement("Category", new XElement("categoryName", "Mileage")),
                          new XElement("Category", new XElement("categoryName", "Rent (other)")), 
                          new XElement("Category", new XElement("categoryName", "Advertising")),
                          new XElement("Category", new XElement("categoryName", "Insurance (health)")),
                          new XElement("Category", new XElement("categoryName", "Repairs and maintenance")),
                          new XElement("Category", new XElement("categoryName", "Automobile")),
                          new XElement("Category", new XElement("categoryName", "Interest (mortgage)")),
                          new XElement("Category", new XElement("categoryName", "Supplies")),
                          new XElement("Category", new XElement("categoryName", "Commissions & Fees")), 
                          new XElement("Category", new XElement("categoryName", "Interest (other)")), 
                          new XElement("Category", new XElement("categoryName", "Taxes and licenses")),
                          new XElement("Category", new XElement("categoryName", "Contract labor")), 
                          new XElement("Category", new XElement("categoryName", "Legal & professional fees")),
                          new XElement("Category", new XElement("categoryName", "Travel")), 
                          new XElement("Category", new XElement("categoryName", "Depletion")), 
                          new XElement("Category", new XElement("categoryName", "Office Expenses")),
                          new XElement("Category", new XElement("categoryName", "Travel (Meals & Entertainment)")), 
                          new XElement("Category", new XElement("categoryName", "Employee benefits")),
                          new XElement("Category", new XElement("categoryName", "Pension & profit sharing plans")), 
                          new XElement("Category", new XElement("categoryName", "Utilities")),
                          new XElement("Category", new XElement("categoryName", "Rent (vehicles & equipment)")), 
                          new XElement("Category", new XElement("categoryName", "Wages"))));
            Database.Save(@"categories.xml");
        }//end categoriesXml
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // DATE:    10/24/14
        // PURPOSE: This creates the User xml that will hold all data on each
        //          user created by the software.
        // UPDATED: 11/18/2014 - Jeff Henry - Only one user file will be used.
        //=====================================================================
        public void CreateUserXML()
        {
            XDocument Database =
           new XDocument(
           new XDeclaration("1.0", "utf-8", "yes"),
           new XComment("This database will store transactions under <User> label"),
           new XComment("This user information will be stored under Username"),
           new XElement("Users", new XElement("User",
                                 new XElement("username", "admin"),
                                 new XElement("password", "admin"),
                                 new XElement("firstName", "Default"),
                                 new XElement("lastName", "Administrator"),
                                 new XElement("email", "admin@vbm.com"),
                                 new XElement("admin", true),
                                 new XElement("locked", false),
                                 new XElement("lastLogin", DateTime.Now.ToString()))));
            Database.Save(@"users.xml");
        }//end userXml
        //=====================================================================

        

        //=====================================================================
        // AUTHOR:  Karan Singh & Jeff Henry (Refactored)
        // PURPOSE: Goes to the location of the xml file to check if it exists. 
        // OUTPUT:  true : if the file exists
        // PARAMS:  None
        //=====================================================================
        public bool CheckXMLExistence()
        {
            return File.Exists(@"transactions.xml") 
                && File.Exists(@"users.xml")
                && File.Exists(@"categories.xml")
                && File.Exists(@"activities.xml");
                
        }//end xmlCheck
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will check whether it is the first time 
        //          running the software. If so, it will suggest to the admin
        //          to create a new administrator account and to lock the 
        //          default administrator account.
        // UPDATED: 11/18/2014 - Jeff Henry - Initial Creation
        //=====================================================================
        public void CheckFirstRun()
        {            
            XmlDocument xml = new XmlDocument();
            xml.Load(@"activities.xml");
            XmlNode node = xml.DocumentElement.GetElementsByTagName("First_Run")[0];
            if (node.InnerText == "True")
            {
                MessageBox.Show("We have determined that this is your first time running the"
                            + " Venture Business Management Software. We suggest that you"
                            + " create a unique Administrator account under the Administration"
                            + " tab and lock the default 'admin' account that you used to login"
                            + " with. If you require a more detailed explanation of how to edit"
                            + " users, click on the help button at the top of the application.","Welcome");
                node.InnerText = "False";
            }
            xml.Save(@"activities.xml");
            
        }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will load all the transactions from the xml
        //          file and save them to the transactions list to be used in
        //          other functions.
        // UPDATED: 11/12/2014 - Jeff Henry - Initial Creation
        //=====================================================================
        public void LoadTransactionsFromXML()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"transactions.xml");
            XmlNodeList list = xml.SelectNodes("/App_Records/All_Transactions/Transaction");

            foreach (XmlNode node in list)
            {
                Transaction new_trans = new Transaction();
                new_trans.username = node["Added_By"].InnerText;
                new_trans.expenditure = Convert.ToDecimal(node["Expenditure"].InnerText);
                new_trans.comments = node["Comments"].InnerText;
                new_trans.category = node["Category"].InnerText;
                new_trans.dateEntered = Convert.ToDateTime(node["Date"].InnerText);
                transactions.Add(new_trans);
            }
        }

        //=====================================================================
        // By:      Karan Singh
        // PURPOSE: Add transaction locates the defaultid in the initialized xml 
        //          and uses it to create a new transaction with the values 
        //          passed to it from the forms by the Control Class. It increments 
        //          default id afterwards for future use.
        // PARAMS:  Expense, category, date, name
        // UPDATED: Ranier Limpiado - Added comments for transactions
        //          Jeff Henry - Removed Unused id values, saves transaction to list.
        //=====================================================================
        public void AddTransaction(decimal expenditure, string category, DateTime date, string name, string comments)
        {
            // Update the transactions xml
            var doc = XDocument.Load("transactions.xml");
            doc.Element("App_Records").Element("All_Transactions").Add(new XElement("Transaction",
                                      new XElement("Added_By", name),
                                      new XElement("Expenditure", expenditure),
                                      new XElement("Comments", comments), 
                                      new XElement("Category", category),
                                      new XElement("Date", date)));
            doc.Save(@"transactions.xml");
            
            // Update the list:
            Transaction new_trans = new Transaction(name, expenditure, comments, category, date);
            transactions.Add(new_trans);

            // Update the activity xml:
            AddActivity(DateTime.Now.ToShortTimeString() + " " + name + " entered an expense for " + category + ".");

        }//end add_transaction
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     If an administrator chooses to change a user to admin 
        //              or vice versa, this function transfers the user to the
        //              appropriate xml file and removes them from the original.
        // PARAMETERS:  User to transfer and if the change is to the admin xml,
        //              Otherwise it will be moving an admin to the users.xml.
        // UPDATED:     11/14/2014 - Jeff Henry - Initial Creation
        //=====================================================================
        public void ChangeAuthorizationInList(string userToChange, bool toAdmin)
        {
            foreach (var user in users)
                if (user.username == userToChange)
                    user.admin = toAdmin;
        }


        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     If an administrator chooses to change a user to admin 
        //              or vice versa, this function transfers the user to the
        //              appropriate xml file and removes them from the original.
        // PARAMETERS:  User to transfer and if the change is to the admin xml,
        //              Otherwise it will be moving an admin to the users.xml.
        // UPDATED:     11/7/2014   - Jeff Henry - Initial Creation
        //              11/18/2014  - Jeff Henry - No need for admin.xml
        //=====================================================================
        public void ChangeAuthorizationInXML(string user, bool toAdmin)
        {
            if (CheckXMLExistence())
            {
                XDocument users_xml = XDocument.Load(@"users.xml");

                // Parse through the xml for the user:
                foreach (var User in users_xml.Document.Descendants("User"))
                {
                    if (User.Element("username").Value == user)
                    {
                        User.Element("admin").Value = toAdmin.ToString();
                        users_xml.Save(@"users.xml");
                        return;
                    }
                }//end foreach

                // Change Authorization in List:
                foreach (var User in users)
                    if (User.username == user)
                        User.admin = toAdmin;

            }
        }

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     This function will change the users password in the XML
        //              file.
        // PARAMETERS:  The username, the new password
        // UPDATED:     11/18/2014 - Jeff Henry - Initial creation
        //=====================================================================
        public void ChangePasswordInXML(string userName, string newPass)
        {
            if (CheckXMLExistence())
            {
                XDocument users = XDocument.Load(@"users.xml");
                foreach (var user in users.Document.Descendants("User"))
                    if (user.Element("username").Value == userName)
                        user.Element("password").Value = newPass;
                users.Save(@"users.xml");
            }

            // Update the activity xml:
            AddActivity(DateTime.Now.ToShortTimeString() + " " + userName + " changed their password.");
        }

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     This function will change the users password in the Lists
        // PARAMETERS:  The username, the new password
        // UPDATED:     11/18/2014 - Jeff Henry - Initial Creation
        //=====================================================================
        public void ChangePasswordInList(string userName, string newPass)
        {
            foreach (var user in users)
                if (user.username == userName)
                    user.password = newPass;
        }

        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to add a new user to the
        //              users.xml
        // PARAMETERS:  The usersname to add, their new passowrd, if they will
        //              be an admin or not, their first name, last name, 
        //              and email, last login date. 
        // UPDATED:     11/7/2014   - Jeff Henry -  Modified parameters to allow 
        //                                          more function use.
        //              11/18/2014  - Jeff Henry -  No need for admin.xml
        //=====================================================================
        public void AddNewUser(string userToAdd, string userPassword, bool userAdmin, string firstName, string lastName, string email, bool isLocked)
        {
            // Load the XML document
            var docu = XDocument.Load(@"users.xml");

            // This performs encryption on all name elements
            var nameElements = docu.Descendants("password").ToList();
            foreach (var nameElement in nameElements)
                nameElement.Value = new string(nameElement.Value.Reverse().ToArray());
            var userXML = XDocument.Load("users.xml");
            userXML.Element("Users").Add(new XElement("User",
                                        new XElement("username", userToAdd), 
                                        new XElement("password", userPassword), 
                                        new XElement("firstName", firstName), 
                                        new XElement("lastName", lastName), 
                                        new XElement("email", email), 
                                        new XElement("admin", userAdmin), 
                                        new XElement("locked", isLocked),
                                        new XElement("lastLogin", DateTime.Now.ToString())));
                                        
            userXML.Save(@"users.xml");
            MessageBox.Show("New Employee: " + userToAdd + " has been saved.");
            
            // Save the user to the list:
            User new_user = new User(userToAdd, firstName, lastName, userPassword, email, userAdmin, isLocked, DateTime.Now);
            users.Add(new_user);

            // Update the activity xml:
            AddActivity(DateTime.Now.ToShortTimeString() + " " + userToAdd + "'s account was created.");

        }//end addNewUser
        //=========================================================================

        //=========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function deletes the user from the list of users.
        //=========================================================================
        public void DeleteUserFromList(string userToDelete)
        {
            var user = users.Single(x => x.username == userToDelete);
            users.Remove(user);
        }

        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to delete a user from the appropriate
        //              XML document. 
        // PARAMETERS:  The username that will be 
        // UPDATED:     11/12/2014  Jeff Henry - Refactoring
        //=========================================================================
        public void DeleteUserFromXML(string userToDelete)
        {
            if (CheckXMLExistence())
            {
                XDocument userDoc = XDocument.Load(@"users.xml");
                
                foreach (var User in userDoc.Descendants("User"))
                {
                    if (userToDelete == User.Element("username").Value)
                    {
                        User.Remove();
                        userDoc.Save(@"users.xml");
                        MessageBox.Show(userToDelete + " has been deleted.");
                        break; 
                    }
                }//end foreach
             }
            // Delete user from the lists:
            var userInList = users.Single(user => user.username == userToDelete);
            users.Remove(userInList);

            // Update the activity xml:
            AddActivity(DateTime.Now.ToShortTimeString() + " " + userToDelete + " was deleted.");

        }//end deleteUser
        //=========================================================================

        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to lock or unlock a user. 
        // PARAMETERS:  The username that will be locked or unlocked, and the boolean
        //              that will say whether to lock or unlock them. 
        // UPDATED:     11/7/2014   Jeff Henry - Refactoring
        //=========================================================================
        public void LockUnlockUser(string userToLockUnlock, bool toBeLocked)
        {
            if (CheckXMLExistence()){
                XDocument userDoc = XDocument.Load(@"users.xml");
                // Handle if the user is being locked:
                if (toBeLocked){
                    users.First(user => user.username == userToLockUnlock).locked = true;
                    foreach (var User in userDoc.Descendants("User")){
                        if (User.Element("username").Value == userToLockUnlock)
                        {
                            User.Element("locked").Value = "true";
                            userDoc.Save(@"users.xml");
                            return;
                        }
                        // Update the activity xml:
                        AddActivity(DateTime.Now.ToShortTimeString() + " " + userToLockUnlock + " was locked.");

                    }//end foreach
                }
                
                // Handle if the user to be unlocked:
                if (!toBeLocked){
                    users.First(user => user.username == userToLockUnlock).locked = false;
                    foreach (var User in userDoc.Descendants("User")){
                        if (User.Element("username").Value == userToLockUnlock)
                        {
                            User.Element("locked").Value = "false";
                            userDoc.Save(@"users.xml");
                            return;
                        }
                        // Update the activity xml:
                        AddActivity(DateTime.Now.ToShortTimeString() + " " + userToLockUnlock + " was unlocked.");
                    }
                }
            }
        }//end lockUnlockUser
        //=========================================================================

        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to add a new category to the category
        //              xml. It first checks that the category doesn't exist, and if
        //              not, it adds it. 
        // PARAMETERS:  The category name that will be added to the XML. 
        // UPDATED:     11/10/2014  Jeff Henry  -   Refactoring
        //=========================================================================
        public void AddCategory(string newCategory)
        {
            if (CheckXMLExistence())
            {
                XDocument userDoc = XDocument.Load(@"categories.xml");
                userDoc.Element("All_Categories").Add(new XElement("Category", new XElement("categoryName", newCategory)));
                userDoc.Save(@"categories.xml");
                MessageBox.Show("Category saved.");

                // Update the activity xml:
                AddActivity(DateTime.Now.ToShortTimeString() + " The new category " + newCategory + " was created.");
            }
        }//end addCategory
        //=========================================================================


        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // LAST UPDATE: 10/24/14
        // PURPOSE:     This function is designed to delete a category from the 
        //              category XML. 
        // PARAMETERS:  The category that will be deleted.  
        // UPDATED:     11/10/2014  Jeff Henry - Refactoring
        //=========================================================================
        public void DeleteCategory(string delCategory)
        {
            bool succesfulDelete = false;
            if (CheckXMLExistence()){
                XDocument userDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in userDoc.Descendants("Category")){
                    if (Category.Element("categoryName").Value == delCategory)
                    {
                        Category.Remove();
                        userDoc.Save(@"categories.xml");
                        MessageBox.Show("Category '" + delCategory + "' has been deleted.");
                        succesfulDelete = true;
                        // Update the activity xml:
                        AddActivity(DateTime.Now.ToShortTimeString() + " The category " + delCategory + " was deleted.");
                        break;
                    }
                }//end foreach
            }
            if (!succesfulDelete)
            {
                MessageBox.Show("Category '" + delCategory + "' has not been delete.");
            }
        }//end deleteCategory
        //=========================================================================


        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to rename a category that already
        //              exists in the category.xml file. 
        // PARAMETERS:  The category to be renamed, and the new name for that category. 
        // UPDATED:     11/10/2014  Jeff Henry - Refactoring
        //=========================================================================
        public void RenameCategory(string catToRename, string newName)
        {
            if (CheckXMLExistence()){
                XDocument userDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in userDoc.Descendants("Category")){
                    if (Category.Element("categoryName").Value != null){
                       if (Category.Element("categoryName").Value == catToRename)
                        {
                            Category.Element("categoryName").Value = newName;
                            userDoc.Save(@"categories.xml");
                            MessageBox.Show("Category renamed.");

                            // Update the activity xml:
                            AddActivity(DateTime.Now.ToShortTimeString() + " The Category " + catToRename + " was renamed to " + newName + ".");

                            break;
                        }
                    }
                }//end foreach
            }
        }//end deleteCategory
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function will be called by addNewCategory, to determine
        //          whether or not the new desired category exists already or not. 
        //          If it doesn't it returns false, else it returns true.  
        // PARAMS:  The name of the category to check in the category.xml
        // UPDATED: 11/10/2014  Jeff Henry -    Refactoring
        //=====================================================================
        public bool CheckCategoryExistence(string catToCheck)
        {
            if (CheckXMLExistence()){
                XDocument userDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in userDoc.Descendants("Category")){
                    if (Category.Element("categoryName").Value != null){
                        if (Category.Element("categoryName").Value == catToCheck)
                            return true; 
                    }
                }//end foreach
            }
            return false; 
        }//end checkDuplicateCategory
        //=====================================================================

        
        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado. 
        // PURPOSE: This function is used to check the users login information
        //          and make sure they are using the correct password.  
        // PARAMS:  The username of the potential user, and the password of 
        //          the potential user. 
        // UPDATED: 11/10/2014   Jeff Henry - Refactoring
        //=====================================================================
        public bool VerifyPassword(string username, string password)
        {
            if (username == "admin" && password == "admin"){UpdateLastLogin("admin", true);return true;}
            else if (username == "admin" && password != "admin"){return false;}
            else if (username != "admin")
            {
                XmlDocument userXml = new XmlDocument();
                userXml.Load(@"users.xml");
                XmlNodeList nonAdminList = userXml.SelectNodes("/Users/User");
                foreach (XmlNode xn in nonAdminList){
                    if (xn["username"].InnerText == username)
                        if (Decrypt(xn["password"].InnerText, "password") == password) { return true; }
                }//end foreach
            }
            return false;
        }//end checkUserPassword
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function was written to check whether or not a user is 
        //          an and admin. 
        // PARAMS:  The username to be checked.  
        // UPDATED: 11/10/2014  Jeff Henry - Refactoring
        //=====================================================================
        public bool CheckIfAdmin(string userName)
        {
            foreach (var user in users)
                if (user.username == userName)
                    return (user.admin);
            return false;

        }//end checkAdmin
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     This function searches through the user xml to see if
        //              the user is locked.
        // PARAMETERS:  username to search for
        // UPDATED:     11/9/2014   Jeff Henry - Initial Creation
        //=====================================================================
        public bool CheckIfLocked(string username)
        {
            foreach (var user in users)
                if (user.username == username)
                    return (user.locked);
            return false;
        }
        
        //=====================================================================
        

		//=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to check if a user exists 
        //              already in the xml
        // PARAMETERS:  The newUser to be checked
        // UPDATED:     11/9/2014   Jeff Henry - Refactoring
        //=========================================================================
        public bool CheckUserExistence(string newUser)
        {
            foreach (var user in users)
            {
                if (user.username == newUser)return true;
            }
            return false;
        }//end userExists
        //==========================================================================

        //==========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function was written to show all the help information that
        //          that is required for the application to help the user utilize all
        //          of the functionality. 
        // PARAMS:  The name of the help node the user is currently looking at.
        // UPDATED: 11/7/2014   Jeff Henry - Refactoring
        //==========================================================================
        public string GrabHelpInfo(string node)
        {
            if (node == "Welcome!")
            {
                return "Venture Business Management is a comprehensive tool to store, manage, and report various expenses.This help menu gives you a set of comprehensive instructions that you need to perform the operations on any particular form. Pick the form you need more information about from the menu to the left.";
            }
            else if(node == "Login")
            {
                return "The USERNAME and PASSWORD fields need to be filled correctly and then submitted for you to be able to log in. All fields must be filled in. If this is your first time using the program and your user is not being recognized by the application, it is probably because the administrator has not added your profile into the system. Please ask the administrator to do so and try again.";
            }
            else if(node == "Enter Expense")
            {
	            return "The enter expense page allows you to add expenses for storage into your system but with these preconditions:\n\t1)	The expense value cannot be zero. In other words, free expenses cannot be stored because there is no need for them to be stored. \n\t2)	There needs to be a date and category picked for the corresponding expense to allow for well maintained system of records.\n\tOnce all fields are filled, click the button at the bottom of the page to insert and store your expense record.";
            }
            else if(node == "View Reports")
            {
                return "The view reports page allows you to view all the expenses that you have entered but increases the capability of reporting by adding multiple filtering options before the report is generated. The filters include a date range and category (or All categories).";
            }
            else if(node == "View History")
            {
	            return "This is an Administrative Privilege only.\n\n\tThe administrator can view the history of all changes made to the system by providing a start date, end date, category, and name of the employee that added the particular expense.\n\n\tEven though all fields have to be filled, it doesn’t mean that there is no way to view all user activities as the administrator. Using the ALL CATEGORY and ALL USER options under the “Category” and “User” field respectively, the administrator can generate reports for which even given time frame they choose.";
            }
            else if(node == "Add User") 
            {
	            return "This is an Administrative Capability.\n\n\tThe add user capability requires the administrator to fill the fields provided on the page to create a new user profile. Any administrator account is capable of creating a new user. All fields need to be completed in order to add the user so that the system can have comprehensive information of the user being admitted into it."; 
            }
            else if(node == "Edit User")
            {
	            return "This is an Administrative Capability.\n\n\tThe edit user capabilities of the administrator allows him or her to reset an existing account in case of a lost password or even delete a user if they so wish. The administrator needs to once again provide his or her credentials for security purposes.";
            }
            else if(node == "Add Category")
            {
                return "This is an Administrative Capability.\n\n\tThe \"Add category\" capability requires the administrator to fill the fields provided on the page to create a new category field. Any administrator account is capable of creating a new category. All fields need to be completed in order to add the user so that the system can make the category available for Employees to use."; 
            }
            else if(node =="Edit Category")
            {
                return "This is an Administrative Capability.\n\n\tThe \"Edit category\" capabilities of the administrator allows him or her to edit the name of a category so that it can be updated in the system and allow the user to pick the edited version of the category when inserting a new expense.";
            }
            else if (node == "Rename Category")
            {
                return "More info soon.";
            }
            else if(node == "Delete Category")
            {
                return "This is an Administrative Capability.\n\n\tThe \"Delete category\" ability allows the administrator to omit any category he or she chooses from the system to disallow the Employees from entering expenses under that particular field of category.";
            }
            else
            {
                return "More information coming soon!";
            }
        }//end displayHelpInfo
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     This functions fills the data grid in the view reports
        //              form. (Summary View)
        // PARAMETERS:  datagrid, category, start date, end date
        // UPDATED:     11/9/2014 Jeff Henry - Users can only see their reports.
        //=====================================================================
        public void FillGridSummaryView(DataGridView datagrid, string category, ref decimal exp_total, ref decimal mil_total, DateTime start, DateTime end, string user)
        {
            // Administrator:
            if (CheckIfAdmin(user)){
                // All Categories:
                if (category == "All Categories"){
                    // Update data grid from the lists:
                    foreach (var trans in transactions){
                        if (trans.dateEntered >= start && trans.dateEntered <= end){
                            datagrid.Rows.Add(trans.dateEntered, trans.expenditure, trans.category);
                            if (trans.category == "Mileage")
                                mil_total += Convert.ToDecimal(trans.expenditure);
                            else
                                exp_total += Convert.ToDecimal(trans.expenditure);
                        }
                    }
                }
                // One Category:
                else if (category != "All Categories"){
                    foreach (var trans in transactions){
                        if (trans.dateEntered >= start && trans.dateEntered <= end && trans.category == category){
                            datagrid.Rows.Add(trans.dateEntered, trans.expenditure);
                            if (trans.category == "Mileage")
                                mil_total += Convert.ToDecimal(trans.expenditure);
                            else
                                exp_total += Convert.ToDecimal(trans.expenditure);

                        }
                    }
                }
            }
            // Employee:
            else if (!CheckIfAdmin(user)){
                // All Categories:
                if (category == "All Categories"){
                    foreach (var trans in transactions){
                        if (trans.username == user){
                            if (trans.dateEntered >= start && trans.dateEntered <= end){
                                datagrid.Rows.Add(trans.dateEntered, trans.expenditure, trans.category);
                                if (trans.category == "Mileage")
                                    mil_total += Convert.ToDecimal(trans.expenditure);
                                else
                                    exp_total += Convert.ToDecimal(trans.expenditure);
                            }
                        }
                    }
                }
                // One Category:
                else if (category != "All Categories"){
                    foreach (var trans in transactions){
                        if (trans.username == user){
                            if (trans.dateEntered >= start && trans.dateEntered <= end && trans.category == category){
                                datagrid.Rows.Add(trans.dateEntered, trans.expenditure);
                                if (trans.category == "Mileage")
                                    mil_total += Convert.ToDecimal(trans.expenditure);
                                else
                                    exp_total += Convert.ToDecimal(trans.expenditure);

                            }
                        }
                    }
                }
            }
        }

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     This functions fills the data grid in the view reports
        //              form. (Detail View)
        // PARAMETERS:  datagrid, category, start date, end date
        //=====================================================================
        public void FillGridDetailView(DataGridView datagrid, string category, ref decimal exp_total, ref decimal mil_total, DateTime start, DateTime end, string user)
        {
            // Administrator:
            if (CheckIfAdmin(user)){
                // All Categories:
                if (category == "All Categories"){
                    // Update data grid from the lists:
                    foreach (var trans in transactions){
                        if (trans.dateEntered >= start && trans.dateEntered <= end){
                            datagrid.Rows.Add(trans.dateEntered, trans.expenditure, trans.category, trans.username, trans.comments);
                            if (trans.category == "Mileage")
                                mil_total += Convert.ToDecimal(trans.expenditure);
                            else
                                exp_total += Convert.ToDecimal(trans.expenditure);
                        }
                    }
                }
                // One Category:
                else if (category != "All Categories"){
                    foreach (var trans in transactions){
                        if (trans.dateEntered >= start && trans.dateEntered <= end && trans.category == category)
                        {
                            datagrid.Rows.Add(trans.dateEntered, trans.expenditure, " ", trans.username, trans.comments);
                            if (trans.category == "Mileage")
                                mil_total += Convert.ToDecimal(trans.expenditure);
                            else
                                exp_total += Convert.ToDecimal(trans.expenditure);

                        }
                    }
                }
            }
            // Employee:
            else if (!CheckIfAdmin(user)){
                // All Categories:
                if (category == "All Categories"){
                    foreach (var trans in transactions){
                        if (trans.username == user){
                            if (trans.dateEntered >= start && trans.dateEntered <= end){
                                datagrid.Rows.Add(trans.dateEntered, trans.expenditure, trans.category, trans.username, trans.comments);
                                if (trans.category == "Mileage")
                                    mil_total += Convert.ToDecimal(trans.expenditure);
                                else
                                    exp_total += Convert.ToDecimal(trans.expenditure);
                            }
                        }
                    }
                }
                // One Category:
                else if (category != "All Categories"){
                    foreach (var trans in transactions){
                        if (trans.username == user){
                            if (trans.dateEntered >= start && trans.dateEntered <= end && trans.category == category){
                                datagrid.Rows.Add(trans.dateEntered, trans.expenditure, " ", trans.username, trans.comments);
                                if (trans.category == "Mileage")
                                    mil_total += Convert.ToDecimal(trans.expenditure);
                                else
                                    exp_total += Convert.ToDecimal(trans.expenditure);

                            }
                        }
                    }
                }
            }
        }

        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // LAST UPDATE: 10/30/14
        // PURPOSE:     This function is designed to load each list with the 
        //              different nodes in the transaction xml
        //              used for the view history tab
        // PARAMETERS:  datagrid, user, category, start date, end date
        // UPDATED:     11/3/2014   Jeff Henry - Refactoring
        //=====================================================================
        public void GetTransactionHistory(DataGridView datagrid, string user, string category, DateTime start, DateTime end)
        {
            List<string> users = new List<string>();
            List<string> expenses = new List<string>();
            List<string> cats = new List<string>();
            List<DateTime> dates = new List<DateTime>();

            XmlDocument xml = new XmlDocument();
            xml.Load("transactions.xml");
            XmlNodeList list = xml.SelectNodes("/App_Records/All_Transactions/Transaction");

            foreach (XmlNode xn in list)
            {
                dates.Add(Convert.ToDateTime(xn["Date"].InnerText));
                users.Add(xn["Added_By"].InnerText);
                expenses.Add(xn["Expenditure"].InnerText);
                cats.Add(xn["Category"].InnerText);
            }//end foreach

            var xDoc = XDocument.Load(@"transactions.xml");
            var count = xDoc.Descendants("Transaction").Count();
            if (category == "All Categories" && user == "All Users")
            {
                for (int i = 0; i < count; i++)
                {
                    if (dates[i] >= start && dates[i] <= end)// && users[i] == user)
                        datagrid.Rows.Add(dates[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
            else if (category == "All Categories" && user != "All Users")
            {
                for (int i = 0; i < count; i++)
                {
                    if (dates[i] >= start && dates[i] <= end && users[i] == user)
                        datagrid.Rows.Add(dates[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
            else if (category != "All Categories" && user == "All Users")
            {
                for (int i = 0; i < count; i++)
                {
                    if (dates[i] >= start && dates[i] <= end && cats[i] == category)
                        datagrid.Rows.Add(dates[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (dates[i] >= start && dates[i] <= end && cats[i] == category && users[i] == user)
                        datagrid.Rows.Add(dates[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
        }//end getTransCount
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function finds and returns the mileage of the transactions
        //          xml file. 
        // PARAMS:  The start and end date that the user specified. 
        // UPDATED: 11/3/2014
        //=====================================================================
        public int GetMileage(DateTime start, DateTime end)
        {
            List<string> expenses = new List<string>();
            List<string> cats = new List<string>();
            List<DateTime> date = new List<DateTime>();
            int total = 0; 

            var xDoc = XDocument.Load(@"transactions.xml");
            var count = xDoc.Descendants("Transaction").Count();
          
            XmlDocument xml = new XmlDocument();
            xml.Load("transactions.xml");
            XmlNodeList list = xml.SelectNodes("/App_Records/All_Transactions/Transaction");

            foreach (XmlNode xn in list)
            {
                string dates = xn["Date"].InnerText;
                DateTime listDates = Convert.ToDateTime(dates);
                date.Add(listDates);
                expenses.Add(xn["Expenditure"].InnerText);
                cats.Add(xn["Category"].InnerText);             
            }//end foreach

            for (int i = 0; i < count; i++){            
                if (date[i] >= start && date[i] <= end && cats[i] == "Mileage")
                    total += Convert.ToInt32(expenses[i]);
            }//end for
            return total;
        }//end getMileage
        //==========================================================================


        //=====================================================================
        // AUTHOR:  RijndaelManaged 
        // PURPOSE: Used to encrypt passwords.This constant string is used as 
        // a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        // UPDATED: 11/3/2014
        //=====================================================================
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        
        //=====================================================================
        // AUTHOR: RijndaelManaged 
        // PURPOSE: Class taken from internet to encrypt strings
        // PARAMS: The password to be encrypted and the passPhrase to encrypt with. 
        // UPDATED: 11/3/2014
        //=====================================================================
        public string Encrypt(string plainText, string passPhrase)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }//end Encrypt
        //=====================================================================

        //=====================================================================
        // AUTHOR:  RijndaelManaged
        // PURPOSE: Class taken from internet to decrpyt strings
        // Params: The password to decrypt, and the passphrase to decrypt with.
        // UPDATED: 11/3/2014
        //=====================================================================
        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }//end Decrypt
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: The purpose of this function is to return all of the proper
        //          login information for each user for form1 to print out on 
        //          the first screen.  
        // PARAMS:  The name of the user, and whether or not they are an admin
        //          user.  
        // UPDATED: 11/10/2014   Jeff Henry  - Refactoring
        //=====================================================================
        public string FillInLoginInfo(string user, bool adminUser)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("users.xml");
            // Administrator:
            if (adminUser){
                
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    if (xn["username"].InnerText == user)
                    {
                        return ("User: " + xn["firstName"].InnerText + " " + 
                                           xn["lastName"].InnerText + "\nLast login: "+ 
                                           xn["lastLogin"].InnerText + 
                                           "\nAuthority level: Administrator");
                    }              
                }//end foreach    
            }
            // Employee:
            else if (!adminUser)
            {
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list){
                    if (xn["username"].InnerText == user){
                        return ("User: " + xn["firstName"].InnerText + " " + 
                                           xn["lastName"].InnerText + "\nLast login: " + 
                                           xn["lastLogin"].InnerText + 
                                           "\nAuthority Level: Employee"); 
                    }
                }//end foreach 
            }
            return "Venture Business Management";
        }//end fillInLoginInfo
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function updates the last login of the user. 
        // PARAMS:  The name of the user, and whether or not they are an admin.  
        // UPDATED: 11/10/2014 Jeff Henry - Refactoring
        //=====================================================================
        public void UpdateLastLogin(string user, bool adminUser)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("users.xml");
            XmlNodeList list = xml.SelectNodes("/Users/User");
            foreach (XmlNode xn in list){
                if (xn["username"].InnerText == user){
                    xn["lastLogin"].InnerText = DateTime.Now.ToString();
                    xml.Save(@"users.xml"); 
                }
            }//end foreach 

        }//end fillInLoginInfo
        //=====================================================================

        //=======================================================
        // AUTHOR: Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Exports the report into excel. 
        // UPDATED: 11/7/2014   - Jeff Henry (Added SaveFileDialog) 
        //=======================================================
        public void ExportToExcel(DataGridView dataGrid, string total, string mileage, string start_date, string end_date, string user)
        {
            // Prompt the User where to save the file.
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel File | *xls";
            saveFileDialog1.Title = "Save as Excel File";

            // If the user choose a directory and gave the file a name, save the excel:
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    var current_date = DateTime.Now.ToShortDateString();

                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook ExcelBook;
                    Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;
                    int i = 0;
                    int j = 0;
                    var totalHeader = 0;// go to the very right of the columns
                    
                    // Create the Excel Object:
                    ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
                    ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;
                    
                    // Create the header:
                    ExcelSheet.Cells[1, 1] = "Business Name Here." +
                                            "\nDate Processed:\t" + current_date +
                                            "\nProcessed by:\t" + user +
                                            "\nDate Range:\t" + start_date +
                                            " - " + end_date;
                    Microsoft.Office.Interop.Excel.Range Title = ExcelSheet.get_Range("A1:G1", Type.Missing);
                    Title.Merge(Type.Missing);
                    Title.RowHeight = 80;

                    for (i = 1; i <= dataGrid.Columns.Count; i++)
                    {
                        ExcelSheet.Cells[2, i] = dataGrid.Columns[i - 1].HeaderText;
                        totalHeader = i + 1;
                    }
                    
                    var totalRow = 0;
                    var totalCol = 0;

                    //export the data to excel
                    for (i = 1; i <= dataGrid.RowCount; i++)
                    {
                        for (j = 1; j <= dataGrid.Columns.Count; j++)
                        {
                            ExcelSheet.Cells[i + 2, j] = dataGrid.Rows[i - 1].Cells[j - 1].Value;
                            totalCol = j + 1;
                        }
                        totalRow = i + 1;
                    }
                    ExcelSheet.Cells[totalRow + 5, 1] = "Expense Total:";           // Display the expense total after all the expense
                    ExcelSheet.Cells[totalRow + 6, 1] = "Mileage Total:";           // Display the mileage total after all the expense
                    ExcelSheet.Cells[totalRow + 5, totalCol-1] = total;       //Show the total in the correct cell
                    ExcelSheet.Cells[totalRow + 6, totalCol-1] = mileage;   //Show the total mileage in the correct cell
                    ExcelApp.Visible = true;

                    //set the font detailed
                    Microsoft.Office.Interop.Excel.Range myRange = ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[dataGrid.RowCount + 1, dataGrid.Columns.Count]];
                    Microsoft.Office.Interop.Excel.Font x = myRange.Font;
                    x.Name = "Arial";
                    x.Size = 10;
                    
                    //Bold the header row
                    myRange = ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, dataGrid.Columns.Count + 2]];
                    x = myRange.Font;
                    x.Bold = true;

                    //autofit everything
                    myRange.EntireColumn.AutoFit();

                    //
                    ExcelSheet = null;
                    ExcelBook = null;
                    ExcelApp = null;


                }
            }
        }//end 
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function was written to add the list of categories
        //          to the first combobox on form1. This was written because 
        //          it will not contain the "All Categories" name. 
        // PARAMS:  None.  
        // UPDATED: 11/10/2014   Jeff Henry - Refactored
        //=====================================================================
        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            Data checkExists = new Data();
            XDocument catDoc = XDocument.Load(@"categories.xml");

            if (checkExists.CheckXMLExistence()){
                foreach (var Category in catDoc.Descendants("Category")){
                   categories.Add(Category.Element("categoryName").Value);
                }
                categories.Sort();
            } 

            return categories;
         }//end GetCategories
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Jeff Henry 
        // PURPOSE: This function was written to add the list of categories
        //          to the first combobox on form1. This was written because 
        //          it will contain the "All Categories" name. 
        // PARAMS:  None.  
        // UPDATED: 11/9/2014   Jeff Henry - Initial Creation
        //=====================================================================
        public List<string> GetAllCategories()
        {
            List<string> cats = new List<string>();
            Data checkExists = new Data();
            XDocument catDoc = XDocument.Load(@"categories.xml");

            if (checkExists.CheckXMLExistence()){
                foreach (var Category in catDoc.Descendants("Category")){
                    cats.Add(Category.Element("categoryName").Value);
                }
                cats.Sort();
            }
            cats.Insert(0, "All Categories");

            return cats;
        }//end GetAllCategories
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will add a new activity to the activity.xml
        // PARAMS:  Activity to add the the xml
        // UPDATED: 11/19/2014 Jeff Henry - Initial Creation
        //=====================================================================
        public void AddActivity(string activity)
        {
            if (CheckXMLExistence())
            {
                XDocument activity_xml = XDocument.Load(@"activities.xml");
                activity_xml.Element("App_Records").Element("All_Activities").Add(new XElement("Activity", activity));
                activity_xml.Save(@"activities.xml");
            }
         }

        //=====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function wll read all the activiteis from the activity
        //          xml and send the data to the rich text box on the main form.
        // PARAMS:  The rich text box to populate.
        // UPDATED: 11/19/2014  Jeff Henry - Initial Creation  
        //=====================================================================
        public void PopulateActivityLog(RichTextBox activityLog)
        {
            activityLog.Clear();
            activityLog.AppendText("---------------------------------------------------------------------------------------------------");
            activityLog.AppendText(" TODAY'S ACTIVITY ");
            activityLog.AppendText("---------------------------------------------------------------------------------------------------\n");
            activityLog.AppendText(" Today's Date:\t" + DateTime.Now.ToShortDateString() + "\n");
            activityLog.AppendText(" Log Generated:\t" + DateTime.Now.ToShortTimeString() + "\n");
            activityLog.AppendText("--------------------------------------------------------------------------------------------------------------------");
            activityLog.AppendText("--------------------------------------------------------------------------------------------------------------------\n");
            XDocument activity_xml = XDocument.Load(@"activities.xml");
            foreach (var activity in activity_xml.Descendants("Activity"))
            {
                activityLog.AppendText(activity.Value + "\n");
            }
        }

        //=====================================================================
        // AUTHORS: Jeff Henry
        // PURPOSE: This function will clear all activities from the activity
        //          xml file.
        // UPDATED: 11/19/2014  Jeff Henry - Initial Creation
        //=====================================================================
        public void ClearActivity()
        {
            XElement root = XElement.Load(@"activities.xml");
            root.Descendants("All_Activities").Descendants("Activity").Remove();
            root.Save(@"activities.xml");
        }

    }//end class: Data
    //=====================================================================


    //=====================================================================
    //                      !! Deprecated Functions !! 
    //=====================================================================
    /*
     * 
    //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado  10/24/2014
        // PURPOSE: To make populate the transaction xml
        // PARAMS:  expenditure, category, date, name of user, and comments
        // UPDATED: Ranier Limpiado - Accepts comments on expenditures now.
        //=====================================================================
        public void add_detailed(decimal expenditure, string category, DateTime date, string name, string comments)
        {
            var doc = XDocument.Load("detailed_transaction.xml");
            doc.Element("All_Transactions").Add(new XElement("Transaction",
                                     new XElement("Added_By", name),
                                     new XElement("Expenditure", expenditure),
                                     new XElement("Comments", comments), 
                                     new XElement("Category", category),
                                     new XElement("Date", date)));
            doc.Save(@"detailed_transaction.xml");
        }//end add_detailed
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Add history of the transaction made to keep track of all 
        //          changes made to the "database". 
        // PARAMS:  Date, name
        //=====================================================================
        public void UpdateTransactionHistory(DateTime date, string user)
        {
            var doc = XDocument.Load("transactions.xml");
            doc.Element("App_Records").Element("Change_History").Add(new XElement("Record", new XAttribute("ChangeID", idnum),
                                     new XElement("Transaction_Date", date), new XElement("Adding_user", user)));
            doc.Save(@"transactions.xml");
        }//end add_history
        //=====================================================================
        
        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Add login history as called by the control so that the last
        //          date is easier to access 
        // PARAMS:  Date, username
        //=====================================================================
        public void SetLoginHistory(string username, DateTime date)
        {
            int id = 1;
            XDocument get_id = XDocument.Load("transactions.xml");
            var ids = from id1 in get_id.Descendants("Login_History")
                      select new{id = id1.Element("Default_login_id").Value};
            foreach (var id1 in ids){id = Convert.ToInt32(id1.id);}//end foreach

            id++;
            var doc = XDocument.Load(@"transactions.xml");
            doc.Element("App_Records").Element("Login_History").Add(new XElement("Log", new XAttribute("id", id), new XElement("User", username), new XElement("last_login", date)));
            doc.Element("App_Records").Element("Login_History").Element("Default_login_id").SetValue(id);
            doc.Save(@"transactions.xml");
        }//end add_login_history
        //=====================================================================
     
        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Simply gets the default id of the transaction for the use of a function or another method. 
        // PARAMS:  None
        //=====================================================================
        public void getdefaultid()
        {
            int id = 1;
            XDocument get_id = XDocument.Load("transactions.xml");
            var ids = from id1 in get_id.Descendants("Change_History")
                      select new{id = id1.Element("DefaultID").Value};
            foreach (var id1 in ids){id = Convert.ToInt32(id1.id);}

            //update global id number according to read value
            idnum = id;
        }//end getdefaultid
        //=====================================================================
      
        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to edit a user to be admin, or not
        //              an admin, and to lock or unlock the user. 
        // PARAMETERS:  The username that will be edited, a boolean admin key, and a 
        //              boolean locked key. 
        // UPDATED: 11/3/2014
        //=========================================================================
        public void EditUser(string userToEdit, bool admin, bool locked)
        {
            string userName;
            bool exists;
            string userLock = locked.ToString();
            string userAdmin = admin.ToString();

            Data checkExists = new Data();
            exists = checkExists.CheckXMLExistence();

            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"users.xml");

                foreach (var User in userDoc.Descendants("User"))
                {
                    userName = User.Element("Username").Value;
                    if (userName == userToEdit)
                    {
                       User.Element("admin").Value = userAdmin;
                       userDoc.Save(@"users.xml");
                       MessageBox.Show("User is now an administrator.");
                    }
                }//end foreach
            }
        }//end editUser5
        //=========================================================================
     
        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to load the users from the 
        //              xml into a list
        // PARAMETERS:  none
        // UPDATED: 11/9/2014   Jeff Henry  - Refactoring
        //=====================================================================
        public List<string> GetUsers()
        {
            List<string> listOfUsers = new List<string>();
            listOfUsers.Add(null);
            listOfUsers[0] = "All Users"; // first item should be All Users
            
            XmlDocument admin_xml = new XmlDocument();
            XmlDocument user_xml = new XmlDocument();
            admin_xml.Load("user_admin.xml");
            user_xml.Load("users.xml");

            XmlNodeList list = admin_xml.SelectNodes("/Users/User");
            foreach (XmlNode xn in list){listOfUsers.Add(xn["Username"].InnerText);}      
            XmlNodeList list2 = user_xml.SelectNodes("/Users/User");
            foreach (XmlNode xn in list2){
                if (xn["Username"].InnerText != ""){listOfUsers.Add(xn["Username"].InnerText);}
            }//end foreach
            return listOfUsers;
        }//end loadUsers
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to load the categories from the 
        //              xml into a list
        // PARAMETERS:  none
        // UPDATED:     11/3/2014
        //=====================================================================
        public List<string> GetCategories()
        {
            List<string> listOfCat = new List<string>();      
            XmlDocument xml = new XmlDocument();
            xml.Load("categories.xml");
            XmlNodeList list = xml.SelectNodes("/All_Categories/Category");
            foreach (XmlNode xn in list){
                listOfCat.Add(xn["categoryName"].InnerText);
            }

            listOfCat.Sort();
            listOfCat.Insert(0, "All Categories");
            return listOfCat;
        }//end loadCat
        //=====================================================================
      
        //=====================================================================
        // AUTHOR: Maxwell Partington & Ranier Limpiado 
        // DATE:   10/24/14
        // EDIT:   Added a default admin account for the first creation of the xml. 
        //=====================================================================
        public void CreateAdminXML()
        {
            XDocument Database =
            new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This database will store transactions under <User> label"),
            new XComment("This user information will be stored under Username"),
            new XElement("Users", new XElement("User",
                                  new XElement("username", "admin"),
                                  new XElement("password", "admin"),
                                  new XElement("firstName", "admin"),
                                  new XElement("lastName", "admin"),
                                  new XElement("email", "admin@vbm.com"),
                                  new XElement("admin", true),
                                  new XElement("locked", false),
                                  new XElement("lastLogin", DateTime.Now.ToString()))));
            Database.Save(@"user_admin.xml");
        }//end userAmdminXml
        //=====================================================================
    */
}//end
//===================================================================== 
