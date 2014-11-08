﻿//=====================================================================
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
    // AUTHOR:  Michelle Jaro
    // PURPOSE: A simple class of string and datetime variables to be 
    //          passed to the control under certain conditions
    // PARAMS:  None
    //=========================================================================
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Expense { get; set; }
    }//end transaction class
    //=========================================================================

    //=========================================================================
    // AUTHOR:  Maxwell Partington & Ranier Limpiado 
    // PURPOSE: This new class was added for detailed reports. 
    // PARAMS:  None.
    // DATE:    11/1/14
    //=========================================================================
    public class DetailedTransaction
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Expense { get; set; }
        public string User { get; set; }
        public string Comments { get; set; }
    }//end transaction class
    //=========================================================================


    //=========================================================================
    // PURPOSE: The Data class is the only class capable of reading, writing, 
    //          or even creating the XML Document. This exclusive ability of 
    //          this class makes it  a root for all information 
    //          entry and pulling. 
    // PARAMS:  None
    //=========================================================================
    class Data
    {
        int idnum = 0;//global idnum so that all functions can see it
        int lognum = 0;//global lognum so that all functions can see it

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Various lists that are used to story the values recieved from reading the XML in the
        //          load_name function. 
        // PARAMS:  None
        //=====================================================================
        List<string> names = new List<string>();
        List<DateTime> newdates = new List<DateTime>();
        List<string> newnames = new List<string>();
        List<string> newcat = new List<string>();


        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Provides a generate template with which the xml should be initially created
        // PARAMS:  None
        //=====================================================================
        public void xmlcreate()
        {
            XDocument Database =
            new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This database will store transactions under <Transaction> label"),
            new XComment("This transaction history will be stored under History_Username"),
            new XElement("App_Records",
            new XElement("All_Transactions"),
            new XElement("Change_History", new XElement("DefaultID", 1)), new XElement("Login_History", new XElement("Default_login_id", 0))));
            Database.Save(@"transactions.xml");
        }//end xmlCreate
        //=====================================================================

        //=====================================================================
        // AUTHOR: Maxwell Partington & Ranier Limpiado 
        // Date: 10/24/2014
        // PURPOSE: To create an xml only for transactions
        //=====================================================================
        public void detailed_transaction()
        {
            XDocument Database =
            new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This database will store transactions under <Detailed_Transaction> label"),
            new XComment("This transaction history will be stored under History_Username"),
            //new XElement("App_Records",
            new XElement("All_Transactions"));
            Database.Save(@"detailed_transaction.xml");
        }//end detailed_Transaction
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This creates the default categories.xml
        // DATE:    10/24/14
        //=====================================================================
        public void categoriesXml()
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
        // PURPOSE: Added a default admin account for the first creation of the xml. 
        //=====================================================================
        public void userXml()
        {
            XDocument Database =
            new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This database will all users under <User> label"),
            new XComment("This user information will be stored under Username"),
            new XElement("Users"));
            Database.Save(@"users.xml");
        }//end userXml
        //=====================================================================

        //=====================================================================
        // AUTHOR: Maxwell Partington & Ranier Limpiado 
        // DATE:   10/24/14
        // EDIT:   Added a default admin account for the first creation of the xml. 
        //=====================================================================
        public void userAdminXml()
        {
            XDocument Database =
            new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This database will store transactions under <User> label"),
            new XComment("This user information will be stored under Username"),
            new XElement("Users", new XElement("User",
                                         new XElement("Username", "admin"),
                                         new XElement("password", "admin"),
                                         new XElement("firstName", "admin"),
                                         new XElement("lastName", "admin"),
                                         new XElement("email", "admin@vbm.com"),
                                         new XElement("admin", true),
                                         new XElement("locked", false),
                                         new XElement("lastLogin", DateTime.Now.ToString()))));
            Database.Save(@"user_admin");
        }//end userAmdminXml
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Goes to the location of the xml file to check if it exists. Boolean.
        // OUTPUT:  true : if the file exists
        // PARAMS:  None
        //=====================================================================
        public bool xmlcheck()
        {
            //edited 10/24/14
            if (File.Exists(@"transactions.xml") && File.Exists(@"users.xml") && File.Exists(@"categories.xml") && File.Exists(@"detailed_transaction.xml") && File.Exists(@"user_admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end xmlCheck
        //=====================================================================

        //=====================================================================
        // By:      Karan Singh
        // PURPOSE: Add transaction locates the defaultid in the initialized xml and uses it to create a 
        //          new transaction with the values passed to it from the forms by the Control Class. It increments 
        //          default id afterwards for future use.
        // PARAMS:  Expense, category, date, name
        //=====================================================================
        public void add_transaction(decimal expenditure, string category, DateTime date, string name, string comments)
        {
            int id = 1;
            //Load the xml and get the default id
            XDocument get_id = XDocument.Load("transactions.xml");
            var ids = from id1 in get_id.Descendants("Change_History")
                      select new { id = id1.Element("DefaultID").Value };

            foreach (var id1 in ids)
            { 
                id = Convert.ToInt32(id1.id); 
            }

            idnum = id;//set it to the global int so that add history can use the same read number.

            var doc = XDocument.Load("transactions.xml");
            doc.Element("App_Records").Element("All_Transactions").Add(new XElement("Transaction",
                                      new XElement("Added_by", name),
                                      new XAttribute("Id", id),
                                      new XElement("Expenditure", expenditure),
                                      new XElement("Comments", comments), // added this to accept comments on expenditures.  Added By: Ranier
                                      new XElement("Category", category),
                                      new XElement("Date", date)));
            id++;
            doc.Element("App_Records").Element("Change_History").Element("DefaultID").SetValue(id);
            doc.Save(@"transactions.xml");

        }//end add_transaction
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado  10/24/2014
        // PURPOSE: To make populate the transaction xml
        // PARAMS: expenditure, category, date, name of user, and comments
        //=====================================================================
        public void add_detailed(decimal expenditure, string category, DateTime date, string name, string comments)
        {
            var doc = XDocument.Load("detailed_transaction.xml");
            doc.Element("All_Transactions").Add(new XElement("Transaction",
                                     new XElement("Added_by", name),
                                     // new XAttribute("Id", id),
                                      new XElement("Expenditure", expenditure),
                                      new XElement("Comments", comments), // added this to accept comments on expenditures.  Added By: Ranier
                                      new XElement("Category", category),
                                      new XElement("Date", date)));
            doc.Save(@"detailed_transaction.xml");
        }//end add_detailed
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Add history of the transaction made to keep track of all changes made to the "database". 
        // PARAMS:  Date, name
        //=====================================================================
        public void add_history(DateTime date, string user)
        {
            //add the record
            var doc = XDocument.Load("transactions.xml");
            doc.Element("App_Records").Element("Change_History").Add(new XElement("Record", new XAttribute("ChangeID", idnum),
                                     new XElement("Transaction_Date", date), new XElement("Adding_user", user)));
            doc.Save(@"transactions.xml");//save the changes
        }//end add_history
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Add login history as called by the control so that the last date is easier to access 
        // PARAMS:  Date, username
        //=====================================================================
        public void add_login_history(string username, DateTime date)
        {
            int id = 1;
            XDocument get_id = XDocument.Load("transactions.xml");
            var ids = from id1 in get_id.Descendants("Login_History")
                      select new
                      {
                          id = id1.Element("Default_login_id").Value
                      };
            foreach (var id1 in ids)
            { 
                id = Convert.ToInt32(id1.id); 
            }//end foreach

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
                      select new
                      {
                          id = id1.Element("DefaultID").Value
                      };
            foreach (var id1 in ids)
            { 
                id = Convert.ToInt32(id1.id); 
            }//end foreach

            //update idnum according to read value
            idnum = id;
        }//end getdefaultid
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Public variables for use of the loadname method. To be used to store one read value read
        //          from the xml at a time while it is parsed into lists.
        // PARAMS:  None
        //=====================================================================
        public DateTime datedata;
        public string namedata;
        public string catdata;
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: It uses the default id to parse through the entire xml and get all the information in the form 
        //          of lists that are then set to public string functions that the Control class can access as long as 
        //          its in the same instance in which they calle dthis function.
        // PARAMS:  Start and end dates, username, category
        //=====================================================================
        public void load_name(DateTime start, DateTime end, string category, string name)
        {
            this.getdefaultid();
            for (int i = 1; i < idnum; i++)//go through the entire file
            {
                XDocument get_id = XDocument.Load("transactions.xml");
                var ids = from id1 in get_id.Descendants("Transaction")//Go to all transaction nodes
                          where ((int)id1.Attribute("Id") == i)//parse with i
                          select new
                          {
                              //get these values
                              expense = id1.Element("Expenditure").Value,
                              date = id1.Element("Date").Value,
                              name = id1.Element("Added_by").Value,
                              category = id1.Element("Category").Value
                          };

                foreach (var id1 in ids)
                {
                    //convert the values appropriately and pass them onto a list for storage (using add--aka to the end)
                    namedata = Convert.ToString(id1.name);
                    newnames.Add(namedata);
                    catdata = Convert.ToString(id1.category);
                    newcat.Add(catdata);

                    name = Convert.ToString(id1.expense);
                    names.Add(name);
                    datedata = Convert.ToDateTime(id1.date);
                    newdates.Add(datedata);
                }//end foreach
            }// end for
            //Now that the lists are filled, assign them to public strings to let Control reference them
            this.trans = newdates;
            this.lists = names;
            this.trans1 = newnames;
            this.trans2 = newcat;
        }//end load_name
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Public list functions, meant to transfer data between Data class and Control class. 
        // PARAMS:  None
        //=====================================================================
        public List<string> trans1 { get; set; }
        public List<string> trans2 { get; set; }
        public List<DateTime> trans { get; set; }
        public List<string> lists { get; set; }

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Simply gets the default_login_id of the login_history for the use of a function or another method. 
        // PARAMS:  None
        //=====================================================================
        public void getDefaultLoginId()
        {
            int id = 1;
            XDocument get_id = XDocument.Load("transactions.xml");
            var ids = from id1 in get_id.Descendants("Login_History")//go to this node
                      select new
                      {
                          id = id1.Element("Default_login_id").Value//get the element
                      };
            foreach (var id1 in ids)
            { 
                id = Convert.ToInt32(id1.id); 
            }
            lognum = id;//update lognum accordingly
        }//end getDefaultLoginId
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: List and list function of datetime that allows for the login
        //          history to be read and transfered
        //          to the Control class.
        // PARAMS:  Name
        //=====================================================================
        List<DateTime> dates = new List<DateTime>();
        public List<DateTime> login { get; set; }

        //=====================================================================
        // AUTHOR:  Karan Singh 
        // PURPOSE: This function finds the login history of the user.  
        // PARAMS:  The username of the person whos login history you request. 
        // This is deprecated and needs to be removed in cycle 3. 11/3/14
        //=====================================================================
        public void login_history(string name)
        {
            this.getDefaultLoginId();
            for (int i = 1; i <= lognum; i++)
            {
                XDocument get_id = XDocument.Load("transactions.xml");
                var ids = from id1 in get_id.Descendants("Log")//go to the node
                          where (int)id1.Attribute("id") == i && (string)id1.Element("User").Value == name//parse through...whereever the name is equal, get that value
                          select new
                          {
                              date = id1.Element("last_login").Value,
                              name = id1.Element("User").Value
                          };

                foreach (var id1 in ids)
                {
                    DateTime date = Convert.ToDateTime(id1.date).AddDays(1);//a day is lost while conversion
                    dates.Add(date);//get all dates
                }
            }//end for loop
            login = dates; //dump entire List into login List function for transfer to Control
        }//end login_history
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Michelle Jaro
        // PURPOSE: Opens the XML file to look for and display the transactions that match the 
        //          time frame and category specified by the user. It also calculates the total 
        //          expenses in that time frame and category and displays it.
        // UPDATED: 11/7/2014   - Jeff Henry (Refactoring)
        //=====================================================================
        public void loadExpenses(DateTime start, DateTime end, string category, ref List<Transaction> expenseReport, ref decimal total, ref decimal totalMil, string addedBy)
        {
            XDocument xmlDoc = XDocument.Load(@"transactions.xml");
            // Search through XML files to retrieve the necessary information based on user input
            // Transactions for all  in specified time frame (ADMIN)
            if (category == "All Categories" && checkAdmin(addedBy))  
            {
                var all = from exp in xmlDoc.Descendants("Transaction")
                          where ((DateTime)exp.Element("Date") >= start && (DateTime)exp.Element("Date") <= end)
                          select new Transaction
                          {
                              Date = (DateTime)exp.Element("Date"),
                              Category = exp.Element("Category").Value,
                              Expense = exp.Element("Expenditure").Value                            
                          };
                expenseReport = all.ToList();
            }
            // Transactions for all  in specified time frame (Employee)
            else if(category == "All Categories" && !checkAdmin(addedBy))
            {
                var all = from exp in xmlDoc.Descendants("Transaction")
                          where ((DateTime)exp.Element("Date") >= start && (DateTime)exp.Element("Date") <= end && exp.Element("Added_by").Value == addedBy)
                          select new Transaction
                          {
                              Date = (DateTime)exp.Element("Date"),
                              Category = exp.Element("Category").Value,
                              Expense = exp.Element("Expenditure").Value
                          };
                expenseReport = all.ToList();
            }
            //Transactions with one specific category in specified time frame (ADMIN)
            else if(category != "All Categories" && checkAdmin(addedBy))
            {
                var one = from e in xmlDoc.Descendants("Transaction")
                          where ((e.Element("Category").Value == category) && (((DateTime)e.Element("Date") >= start) && (DateTime)e.Element("Date") <= end))
                          select new Transaction
                          {
                              Date = (DateTime)e.Element("Date"),
                              Category = e.Element("Category").Value,
                              Expense = e.Element("Expenditure").Value
                          };
                expenseReport = one.ToList();
            }
            //Transactions with one specific category in specified time frame (Employee)
            else
            {
                var one = from e in xmlDoc.Descendants("Transaction")
                          where ((e.Element("Category").Value == category) && (((DateTime)e.Element("Date") >= start) && (DateTime)e.Element("Date") <= end))
                          select new Transaction
                          {
                              Date = (DateTime)e.Element("Date"),
                              Category = e.Element("Category").Value,
                              Expense = e.Element("Expenditure").Value
                          };
                expenseReport = one.ToList();
            }

            // Prints out the list of the results with the total expense
            for (int i = 0; i < expenseReport.Count; i++)   
            {
                if (expenseReport[i].Category != "Mileage")
                {
                    total += Convert.ToDecimal(expenseReport[i].Expense);
                }
                else
                {
                    totalMil += Convert.ToDecimal(expenseReport[i].Expense);
                }
            }//end for 
        }//end loadExpenses
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Opens the XML file to look for and display the detailed transactions that match the 
        //          time frame and category specified by the user. It also calculates the total 
        //          expenses in that time frame and category and displays it.
        // UPDATED: 11/7/2014 - Jeff Henry - Fixed misprint of reports
        //=====================================================================
        public void loadDetailedExpenses(DateTime start, DateTime end, string category, ref List<DetailedTransaction> expenseReport, ref decimal total, ref decimal totalMil, string addedBy)
        {
           
            XDocument xmlDoc = XDocument.Load(@"transactions.xml");
            // Search through XML files to retrieve the necessary information based on user input
            // Transactions fr all categories in a specified time frame. (ADMIN)
            if (category == "All Categories" && checkAdmin(addedBy)) 
            {
                var all = from exp in xmlDoc.Descendants("Transaction")
                          where ((DateTime)exp.Element("Date") >= start && (DateTime)exp.Element("Date") <= end)
                          select new DetailedTransaction
                          {
                              Date = (DateTime)exp.Element("Date"),
                              Category = exp.Element("Category").Value,
                              Expense = exp.Element("Expenditure").Value,
                              User = exp.Element("Added_by").Value,
                              Comments = exp.Element("Comments").Value
                          };
                expenseReport = all.ToList();
            }
            // Transactions fr all categories in a specified time frame.
            else if (category == "All Categories" && !checkAdmin(addedBy))
            {
                var all = from exp in xmlDoc.Descendants("Transaction")
                          where ((DateTime)exp.Element("Date") >= start && (DateTime)exp.Element("Date") <= end && exp.Element("Added_by").Value == addedBy)
                          select new DetailedTransaction
                          {
                              Date = (DateTime)exp.Element("Date"),
                              Category = exp.Element("Category").Value,
                              Expense = exp.Element("Expenditure").Value,
                              User = exp.Element("Added_by").Value,
                              Comments = exp.Element("Comments").Value
                          };
                expenseReport = all.ToList();
            }
            //Transactions with one specific category in specified time frame (ADMIN)
            else if (category != "All Categories" && checkAdmin(addedBy))
            {
                var one = from e in xmlDoc.Descendants("Transaction")
                          where ((e.Element("Category").Value == category) && (((DateTime)e.Element("Date") >= start) && (DateTime)e.Element("Date") <= end))
                          select new DetailedTransaction
                          {
                              Date = (DateTime)e.Element("Date"),
                              Category = e.Element("Category").Value,
                              Expense = e.Element("Expenditure").Value,
                              User = e.Element("Added_by").Value,
                              Comments = e.Element("Comments").Value
                          };

                expenseReport = one.ToList();
            }
            //Transactions with one specific category in specified time frame (Employee)
            else
            {
                var one = from e in xmlDoc.Descendants("Transaction")
                          where ((e.Element("Category").Value == category) && (((DateTime)e.Element("Date") >= start) && (DateTime)e.Element("Date") <= end) && e.Element("Added_by").Value == addedBy)
                          select new DetailedTransaction
                          {
                              Date = (DateTime)e.Element("Date"),
                              Category = e.Element("Category").Value,
                              Expense = e.Element("Expenditure").Value,
                              User = e.Element("Added_by").Value,
                              Comments = e.Element("Comments").Value
                          };

                expenseReport = one.ToList();
            }

            //Prints out the list of the results with the total expense
            for (int i = 0; i < expenseReport.Count; i++)
            {
                if (expenseReport[i].Category != "Mileage")
                {                
                    total += System.Convert.ToDecimal(expenseReport[i].Expense);
                }
                else
                {
                    totalMil += Convert.ToDecimal(expenseReport[i].Expense);
                }
            }//end for 
        }//end loadExpenses
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Jeff Henry
        // PURPOSE:     If an administrator chooses to change a user to admin 
        //              or vice versa, this function transfers the user to the
        //              appropriate xml file and removes them from the original.
        // PARAMETERS:  User to transfer and if the change is to the admin xml,
        //              Otherwise it will be moving an admin to the users.xml.
        // UPDATED:     11/7/2014 - Added by Jeff Henry
        //=====================================================================
        public void changeStatus(string user, bool toAdmin)
        {
            string username = user;
            string password = "";
            string first_name = "";
            string last_name = "";
            string email = "";
            string last_login = "";
            bool locked = false;

            Data checkExists = new Data();
            if (checkExists.xmlcheck())
            {
                // If being transferred to admin.xml, open the users.xml and save
                // the info to transfer then delete the user from the users.xml
                if (toAdmin)
                {
                    XDocument users_xml = XDocument.Load(@"users.xml");

                    // Parse through the xml for the user:
                    foreach (var User in users_xml.Document.Descendants("User"))
                    {
                        if (User.Element("Username").Value == user)
                        {
                            password = User.Element("password").Value;
                            first_name = User.Element("firstName").Value;
                            last_name = User.Element("lastName").Value;
                            email = User.Element("email").Value;
                            last_login = User.Element("lastLogin").Value;
                            MessageBox.Show("User data grabbed from users.xml." +
                                            "\nPassword: " + password +
                                            "\nFirst Name: " + first_name +
                                            "\nLast Name: " + last_name +
                                            "\nEmail: " + email +
                                            "\nLast Login: " + last_login);
                            addNewUser(user, password, toAdmin, first_name, last_name, email, last_login, locked);
                            User.Remove();
                            users_xml.Save(@"users.xml");
                            return;
                        }
                    }//end foreach
                }
                else
                {
                    XDocument admins_xml = XDocument.Load(@"user_admin.xml");

                    // Parse through the xml for the user:
                    foreach (var User in admins_xml.Document.Descendants("User"))
                    {
                        if (User.Element("Username").Value == user)
                        {
                            password = User.Element("password").Value;
                            first_name = User.Element("firstName").Value;
                            last_name = User.Element("lastName").Value;
                            email = User.Element("email").Value;
                            last_login = User.Element("lastLogin").Value;
                            MessageBox.Show("User data grabbed from users.xml." +
                                            "\nPassword: " + password +
                                            "\nFirst Name: " + first_name +
                                            "\nLast Name: " + last_name +
                                            "\nEmail: " + email +
                                            "\nLast Login: " + last_login);
                            addNewUser(user, password, toAdmin, first_name, last_name, email, last_login, locked);
                            User.Remove();
                            admins_xml.Save(@"user_admin.xml");
                            return;
                        }
                    }//end foreach
                }
            }
        }

        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to add a new user to the
        //              userXml or the userAdminXml. 
        // PARAMETERS:  The usersname to add, their new passowrd, if they will
        //              be an admin or not, their first name, last name, 
        //              and email, last login date. 
        // UPDATED:     11/7/2014 - Jeff Henry - Modified parameters to allow 
        //                          more function use.
        //=====================================================================
        public void addNewUser(string userToAdd, string userPassword, bool userAdmin, string firstName, string lastName, string email, string login, bool isLocked)
        {
            string password = userPassword;
            string user = userToAdd;
            bool admin = userAdmin;
            bool locked = isLocked;
            string fname = firstName;
            string lname = lastName;
            string uEmail = email;
            string lastLogin;
            if (login == "ignore")
                lastLogin = "Hello! This is your first login!";
            else
                lastLogin = login;

            // Load the XML document
            var docu = XDocument.Load(@"users.xml");

            // This performs encryption on all name elements
            var nameElements = docu.Descendants("password").ToList();
            foreach (var nameElement in nameElements)
            {
                nameElement.Value = new string(nameElement.Value.Reverse().ToArray());
       
            }//end foreach
           
            if (!userAdmin) //add to normal users xml
            {
                var doc = XDocument.Load("users.xml");
                doc.Element("Users").Add(new XElement("User",
                                         new XElement("Username", user), 
                                         new XElement("password", password), 
                                         new XElement("firstName", fname), 
                                         new XElement("lastName", lname), 
                                         new XElement("email", uEmail), 
                                         new XElement("admin", admin), 
                                         new XElement("locked", locked),
                                         new XElement("lastLogin", lastLogin)));
                                        
                doc.Save(@"users.xml");
                MessageBox.Show("User saved.");
            }
            else if (userAdmin) //add to admin users xml
            {
                var doc = XDocument.Load("user_admin");
                doc.Element("Users").Add(new XElement("User",
                                         new XElement("Username", user), 
                                         new XElement("password", password), 
                                         new XElement("firstName", fname), 
                                         new XElement("lastName", lname), 
                                         new XElement("email", uEmail), 
                                         new XElement("admin", admin),
                                         new XElement("locked", locked),
                                         new XElement("lastLogin", lastLogin)));
                doc.Save(@"user_admin");
                MessageBox.Show("User saved.");
            }
        }//end addNewUser
        //=========================================================================

        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to edit a user to be admin, or not
        //              an admin, and to lock or unlock the user. 
        // PARAMETERS:  The username that will be edited, a boolean admin key, and a 
        //              boolean locked key. 
        // UPDATED: 11/3/2014
        //=========================================================================
        public void editUser(string userToEdit, bool admin, bool locked)
        {
            string userName;
            bool exists;
            string userLock = locked.ToString();
            string userAdmin = admin.ToString();

            Data checkExists = new Data();
            exists = checkExists.xmlcheck();

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

        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to delete a user from the appropriate
        //              XML document. 
        // PARAMETERS:  The username that will be 
        // UPDATED: 11/3/2014
        //=========================================================================
        public void deleteUser(string userToDelete)
        {
            string userName;
            bool exists;
            bool deleted = false; 
            Data checkExists = new Data();
            exists = checkExists.xmlcheck();
            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"users.xml");
                XDocument adminDoc = XDocument.Load(@"user_admin");
                
                foreach (var User in userDoc.Descendants("User"))
                {
                    userName = User.Element("Username").Value;
                    if (userName == userToDelete)
                    {
                        User.Remove();
                        userDoc.Save(@"users.xml");
                        MessageBox.Show("User deleted.");
                        deleted = true; 
                        return; 
                    }
                }//end foreach
                if (deleted == false)
                {
                    foreach (var User in adminDoc.Descendants("User"))
                    {
                        userName = User.Element("Username").Value;
                        if (userName == userToDelete)
                        {
                            User.Remove();
                            adminDoc.Save(@"user_admin");
                            MessageBox.Show("User deleted.");
                            deleted = true;
                            return;
                        }
                    }
                }
            }
        }//end deleteUser
        //=========================================================================

        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to lock or unlock a user. 
        // PARAMETERS:  The username that will be locked or unlocked, and the boolean
        //              that will say whether to lock or unlock them. 
        // UPDATED: 11/3/2014
        //=========================================================================
        public void lockUnlockUser(string userToLockUnlock, bool isLocked)
        {
            string userName;
            bool exists;
            string userLock = isLocked.ToString();
            bool finished = false; 

            Data checkExists = new Data();
            exists = checkExists.xmlcheck();

            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"users.xml");
                XDocument adminDoc = XDocument.Load(@"user_admin");

                foreach (var User in userDoc.Descendants("User"))
                {
                    userName = User.Element("Username").Value;
                    if (userName == userToLockUnlock)
                    {
                        User.Element("locked").Value = userLock;
                        userDoc.Save(@"users.xml");
                        finished = true; 
                        MessageBox.Show("User 'locked' value updated.");
                        return;
                    }
                }//end foreach
                if (finished == false)
                {
                    foreach (var User in adminDoc.Descendants("User"))
                    {
                        userName = User.Element("Username").Value;
                        if (userName == userToLockUnlock)
                        {
                            User.Element("locked").Value = userLock;
                            adminDoc.Save(@"user_admin");
                            finished = true;
                            MessageBox.Show("User 'locked' value updated.");
                            return;
                        }
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
        // UPDATED: 11/3/2014
        //=========================================================================
        public void addNewCategory(string newCategory)
        {
            string cat = newCategory;
            Data checkExists = new Data();
            bool exists = checkExists.xmlcheck();

            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"categories.xml");
                userDoc.Element("All_Categories").Add(new XElement("Category", new XElement("categoryName", newCategory)));
                userDoc.Save(@"categories.xml");
                MessageBox.Show("Category saved.");
            }
        }//end addNewCategory
        //=========================================================================


        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // LAST UPDATE: 10/24/14
        // PURPOSE:     This function is designed to delete a category from the 
        //              category XML. 
        // PARAMETERS:  The category that will be deleted.  
        // UPDATED: 11/3/2014
        //=========================================================================
        public void deleteCategory(string delCategory)
        {
            string cat = delCategory;
            string catName; 
            Data checkExists = new Data();
            bool exists = checkExists.xmlcheck();

            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in userDoc.Descendants("Category"))
                {
                    catName = Category.Element("categoryName").Value;
                    if (catName == delCategory)
                    {
                        Category.Remove();
                        userDoc.Save(@"categories.xml");
                        MessageBox.Show("Category deleted.");
                        break;
                    }
                }//end foreach
            }
        }//end deleteCategory
        //=========================================================================


        //=========================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to rename a category that already
        //              exists in the category.xml file. 
        // PARAMETERS:  The category to be renamed, and the new name for that category. 
        // UPDATED: 11/3/2014
        //=========================================================================
        public void renameCategory(string catToRename, string newName)
        {
            string cat = catToRename;
            string newCat = newName;
            string catName;
            Data checkExists = new Data();
            bool exists = checkExists.xmlcheck();

            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in userDoc.Descendants("Category"))
                {
                    if (Category.Element("categoryName").Value != null)
                    {
                        catName = Category.Element("categoryName").Value;

                        if (catName == cat)
                        {
                            Category.Element("categoryName").Value = newCat;
                            userDoc.Save(@"categories.xml");
                            MessageBox.Show("Category renamed.");
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
        // PARAMS: The name of the category to check in the category.xml
        // UPDATED: 11/3/2014
        //=====================================================================
        public bool checkDuplicateCategory(string catToCheck)
        {
            string cat = catToCheck;
            string catName;
            Data checkExists = new Data();
            bool exists = checkExists.xmlcheck();

            if (exists == true)
            {
                XDocument userDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in userDoc.Descendants("Category"))
                {
                    if (Category.Element("categoryName").Value != null)
                    {
                        catName = Category.Element("categoryName").Value;

                        if (catName == cat)
                        {
                            return true; 
                        }
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
        // UPDATED: 11/3/2014
        //=====================================================================
        public bool checkUserPassword(string username, string password)
        {
            string user = username;
            string xmlUser = ""; 
            string userPass = password;
            string xmlPassword = "";
            string deCryptedPass = "";
            bool adminUser;
            bool found = false; 
                
            adminUser = checkAdmin(user);

            if (user == "admin" && password == "admin")
            {
                updateLastLogin("admin", true); 
                return true;  
            }
            else if (user == "admin" && password != "admin")
            {
                MessageBox.Show("Incorrect login information.");
                return false;
            }
            else if (user != "admin")
            {
                if (adminUser)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load("user_admin");
                    XmlNodeList list = xml.SelectNodes("/Users/User");
                    foreach (XmlNode xn in list)
                    {
                        xmlUser = xn["Username"].InnerText;
                        if (xmlUser.Equals(user))
                        {
                            xmlPassword = xn["password"].InnerText;
                            deCryptedPass = Decrypt(xmlPassword, "password");

                            if (deCryptedPass.Equals(userPass))
                            {
                                found = true; 
                                return true;
                            }
                            else
                            {
                                found = false; 
                            }
                        }
                    }//end foreach
                    if (found == false)
                    {
                        XmlDocument userXml = new XmlDocument();
                        userXml.Load("users.xml");
                        XmlNodeList userList = userXml.SelectNodes("/Users/User");
                        foreach (XmlNode xn in userList)
                        {
                            xmlUser = xn["Username"].InnerText;
                            if (xmlUser.Equals(user))
                            {
                                xmlPassword = xn["password"].InnerText;
                                deCryptedPass = Decrypt(xmlPassword, "password");

                                if (deCryptedPass.Equals(userPass))
                                {
                                    //found = true;
                                    return true;
                                }
                            }
                        }//end foreach 
                    }
                }
                else if (!adminUser)
                {
                    XmlDocument nonAdminXml = new XmlDocument();
                    nonAdminXml.Load("users.xml");
                    XmlNodeList nonAdminList = nonAdminXml.SelectNodes("/Users/User");
                    foreach (XmlNode xn in nonAdminList)
                    {
                        xmlUser = xn["Username"].InnerText;
                        if (xmlUser.Equals(user))
                        {
                            xmlPassword = xn["password"].InnerText;
                            deCryptedPass = Decrypt(xmlPassword, "password");

                            if (deCryptedPass.Equals(userPass))
                            {
                                return true;
                            }
                        }
                    }//end foreach
                }
            }
            return false;
        }//end checkUserPassword
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function was written to check whether or not a user is 
        //          an and admin. 
        // PARAMS:  The username to be checked.  
        // UPDATED: 11/3/2014
        //=====================================================================
        public bool checkAdmin(string userName)
        { 
                XmlDocument xml = new XmlDocument();
                XmlDocument userXml = new XmlDocument();
                string user = "";
                string nonAdUser = "";
                string admin =  "";
                string adminCheck = ""; 
                bool found = false; 
                xml.Load("user_admin");
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    user = xn["Username"].InnerText;
                    if (user == userName)
                    {
                        admin = xn["admin"].InnerText;
                        if (admin == "true")
                        {
                            found = true; 
                            return true;
                        }
                    }
                }
                if (found == false)
                {
                    userXml.Load("users.xml");
                    XmlNodeList userList = userXml.SelectNodes("/Users/User");
                    foreach (XmlNode xnode in userList)
                    {
                        nonAdUser = xnode["Username"].InnerText;
                        if (nonAdUser == userName)
                        {
                            adminCheck = xnode["admin"].InnerText;
                            if (adminCheck == "True")
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
        }//end checkAdmin
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to load the users from the xml into a list
        // PARAMETERS:  none
        // UPDATED: 11/3/2014
        //=====================================================================
        public List<string> loadUsers()
        {
            List<string> listOfUsers = new List<string>();
            listOfUsers.Add(null);
            listOfUsers[0] = "All Users"; // first item should be All Users
            
            XmlDocument xml = new XmlDocument();
            xml.Load("user_admin");
            XmlNodeList list = xml.SelectNodes("/Users/User");
            foreach (XmlNode xn in list)
            {
                string user = xn["Username"].InnerText;
                listOfUsers.Add(xn["Username"].InnerText);
            }      
                XmlDocument xml2 = new XmlDocument();
                xml2.Load("users.xml");
                XmlNodeList list2 = xml2.SelectNodes("/Users/User");
                foreach (XmlNode xn in list2)
                {
                    if (xn["Username"].InnerText != "")
                    {
                        string user = xn["Username"].InnerText;
                        listOfUsers.Add(xn["Username"].InnerText);
                    }
                }
            
            //listOfUsers.Sort();
            return listOfUsers;
        }//end loadUsers
        //=====================================================================

        //=====================================================================
        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to load the users from the xml into a list
        // PARAMETERS:  none
        // UPDATED: 11/3/2014
        //=====================================================================
        public List<string> loadCat()
        {
            List<string> listOfCat = new List<string>();      
            XmlDocument xml = new XmlDocument();
            xml.Load("categories.xml");
            XmlNodeList list = xml.SelectNodes("/All_Categories/Category");
            foreach (XmlNode xn in list)
            {
                string user = xn["categoryName"].InnerText;  
                listOfCat.Add(xn["categoryName"].InnerText);
            }

                listOfCat.Sort();
                listOfCat.Insert(0, "All Categories");
                return listOfCat;
        }//end loadCat
        //=====================================================================

		//=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // PURPOSE:     This function is designed to check if a user exists already in the xml
        // PARAMETERS:  The newUser to be checked
        // UPDATED: 11/3/2014
        //=========================================================================
        public bool userExists(string newUser, bool adminUser)
        {
            bool found = true;
            if (adminUser)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("user_admin");
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    string userName = xn["Username"].InnerText;
                    if (userName.Equals(newUser))
                    {
                        return true;
                    }
                    else
                    {
                        found = false; 
                    }
                }

                if (found == false)
                {
                    XmlDocument userXml = new XmlDocument();
                    userXml.Load("users.xml");
                    XmlNodeList userList = userXml.SelectNodes("/Users/User");
                    foreach (XmlNode xn in userList)
                    {
                        string userName = xn["Username"].InnerText;
                        if (userName.Equals(newUser))
                        {
                            return true;
                        }
                    }//end foreach 
                }
            }
            else if (!adminUser)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("users.xml");
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    string userName = xn["Username"].InnerText;
                    if (userName.Equals(newUser))
                    {
                        return true;
                    }
                }//end foreach  
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
        // UPDATED: 11/3/2014
        //==========================================================================
        public string displayHelpInfo(string node)
        {
            string helpInfo;

            if (node == "Welcome!")
            {
                helpInfo = "Venture Business Management is a comprehensive tool to store, manage, and report various expenses.This help menu gives you a set of comprehensive instructions that you need to perform the operations on any particular form. Pick the form you need more information about from the menu to the left.";
                return helpInfo;
            }
            else if(node == "Login")
            {
                helpInfo = "The USERNAME and PASSWORD fields need to be filled correctly and then submitted for you to be able to log in. All fields must be filled in. If this is your first time using the program and your user is not being recognized by the application, it is probably because the administrator has not added your profile into the system. Please ask the administrator to do so and try again.";
                return helpInfo; 
            }
            else if(node == "Enter Expense")
            {
	            helpInfo = "The enter expense page allows you to add expenses for storage into your system but with these preconditions:\n\t1)	The expense value cannot be zero. In other words, free expenses cannot be stored because there is no need for them to be stored. \n\t2)	There needs to be a date and category picked for the corresponding expense to allow for well maintained system of records.\n\tOnce all fields are filled, click the button at the bottom of the page to insert and store your expense record.";
                return helpInfo;
            }
            else if(node == "View Reports")
            {
                helpInfo = "The view reports page allows you to view all the expenses that you have entered but increases the capability of reporting by adding multiple filtering options before the report is generated. The filters include a date range and category (or All categories).";
                return helpInfo; 
            }
            else if(node == "View History")
            {
	            helpInfo = "This is an Administrative Privilege only.\n\n\tThe administrator can view the history of all changes made to the system by providing a start date, end date, category, and name of the employee that added the particular expense.\n\n\tEven though all fields have to be filled, it doesn’t mean that there is no way to view all user activities as the administrator. Using the ALL CATEGORY and ALL USER options under the “Category” and “User” field respectively, the administrator can generate reports for which even given time frame they choose.";
                return helpInfo; 
            }
            else if(node == "Add User") 
            {
	            helpInfo = "This is an Administrative Capability.\n\n\tThe add user capability requires the administrator to fill the fields provided on the page to create a new user profile. Any administrator account is capable of creating a new user. All fields need to be completed in order to add the user so that the system can have comprehensive information of the user being admitted into it."; 
                return helpInfo;    
            }
            else if(node == "Edit User")
            {
	            helpInfo = "This is an Administrative Capability.\n\n\tThe edit user capabilities of the administrator allows him or her to reset an existing account in case of a lost password or even delete a user if they so wish. The administrator needs to once again provide his or her credentials for security purposes.";
                return helpInfo;
            }
            else if(node == "Add Category")
            {
                helpInfo = "This is an Administrative Capability.\n\n\tThe \"Add category\" capability requires the administrator to fill the fields provided on the page to create a new category field. Any administrator account is capable of creating a new category. All fields need to be completed in order to add the user so that the system can make the category available for Employees to use."; 
                return helpInfo;
            }
            else if(node =="Edit Category")
            {
                helpInfo = "This is an Administrative Capability.\n\n\tThe \"Edit category\" capabilities of the administrator allows him or her to edit the name of a category so that it can be updated in the system and allow the user to pick the edited version of the category when inserting a new expense.";
                return helpInfo;
            }
            else if (node == "Rename Category")
            {
                helpInfo = "More info soon.";
                return helpInfo;
            }
            else if(node == "Delete Category")
            {
                helpInfo = 	"This is an Administrative Capability.\n\n\tThe \"Delete category\" ability allows the administrator to omit any category he or she chooses from the system to disallow the Employees from entering expenses under that particular field of category.";
                return helpInfo;
            }
            else
            {
                helpInfo = "More information coming soon!";
                return helpInfo;
            }
        }//end displayHelpInfo
        //=====================================================================

        //=====================================================================
        // AUTHOR:      Maxwell Partington & Ranier Limpiado 
        // LAST UPDATE: 10/30/14
        // PURPOSE:     This function is designed to load each list with the different nodes in the transaction xml
        //              used for the view history tab
        // PARAMETERS:  datagrid, user, category, start date, end date
        // UPDATED: 11/3/2014
        //=====================================================================
        public void getTransCount(DataGridView datagrid, string user, string category, DateTime start, DateTime end)
        {
            List<string> users = new List<string>();
            List<string> expenses = new List<string>();
            List<string> cats = new List<string>();
            List<DateTime> date = new List<DateTime>();

            XmlDocument xml = new XmlDocument();
            xml.Load("transactions.xml");
            XmlNodeList list = xml.SelectNodes("/App_Records/All_Transactions/Transaction");

            foreach (XmlNode xn in list)
            {
                //string userInXml = xn["Added_by"].InnerText;
                string dates = xn["Date"].InnerText;
                DateTime listDates = Convert.ToDateTime(dates);
                date.Add(listDates);

                users.Add(xn["Added_by"].InnerText);

                expenses.Add(xn["Expenditure"].InnerText);

                cats.Add(xn["Category"].InnerText);
            }//end foreach

            var xDoc = XDocument.Load(@"transactions.xml");
            var count = xDoc.Descendants("Transaction").Count();
            if (category == "All Categories" && user == "All Users")
            {
                for (int i = 0; i < count; i++)
                {
                    if (date[i] >= start && date[i] <= end)// && users[i] == user)
                        datagrid.Rows.Add(date[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
            else if (category == "All Categories" && user != "All Users")
            {
                for (int i = 0; i < count; i++)
                {
                    if (date[i] >= start && date[i] <= end && users[i] == user)
                        datagrid.Rows.Add(date[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
            else if (category != "All Categories" && user == "All Users")
            {
                for (int i = 0; i < count; i++)
                {
                    if (date[i] >= start && date[i] <= end && cats[i] == category)
                        datagrid.Rows.Add(date[i], expenses[i], cats[i], users[i]);
                }//end for 
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (date[i] >= start && date[i] <= end && cats[i] == category && users[i] == user)
                        datagrid.Rows.Add(date[i], expenses[i], cats[i], users[i]);
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
        public int getMileage(DateTime start, DateTime end)
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

            for (int i = 0; i < count; i++)
            {            
                if (date[i] >= start && date[i] <= end && cats[i] == "Mileage")
                {
                    total += Convert.ToInt32(expenses[i]);
                }
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
        // UPDATED: 11/3/2014
        //=====================================================================
        public string fillInLoginInfo(string user, bool adminUser)
        {
            string loginInfo = "";
            bool found = true; 
            if (adminUser)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("user_admin");
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    string userName = xn["Username"].InnerText;
                    if (userName.Equals(user))
                    {
                        loginInfo = ("User: " + xn["firstName"].InnerText + " " + 
                                                xn["lastName"].InnerText + "\nLast login: "+ 
                                                xn["lastLogin"].InnerText + 
                                                "\nAuthority level: Administrator");
                        return loginInfo;
                    }
                    else
                    {
                        found = false;
                    }
                }//end foreach  
                if (found == false)
                {
                    XmlDocument newAdxml = new XmlDocument();
                    newAdxml.Load("users.xml");
                    XmlNodeList newAdlist = newAdxml.SelectNodes("/Users/User");
                    foreach (XmlNode xn in newAdlist)
                    {
                        string userName2 = xn["Username"].InnerText;
                        if (userName2.Equals(user))
                        {
                            loginInfo = ("User: " + xn["firstName"].InnerText + " " +
                                                    xn["lastName"].InnerText + "\nLast login: " +
                                                    xn["lastLogin"].InnerText +
                                                    "\nAuthority level: Administrator");
                            return loginInfo;
                        }
                    }//end foreach  
                }
            }
                    else if (!adminUser)
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load("users.xml");
                        XmlNodeList list = xml.SelectNodes("/Users/User");
                        foreach (XmlNode xn in list)
                        {
                            string userName = xn["Username"].InnerText;
                            if (userName.Equals(user))
                            {
                                loginInfo = ("User: " + xn["firstName"].InnerText + " " + 
                                                        xn["lastName"].InnerText + "\nLast login: " + 
                                                        xn["lastLogin"].InnerText + 
                                                        "\nAuthority Level: Employee"); 
                                return loginInfo;
                            }
                        }//end foreach 
                    }
            return loginInfo; 
        }//end fillInLoginInfo
        //=====================================================================

        //=====================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function updates the last login of the user. 
        // PARAMS:  The name of the user, and whether or not they are an admin.  
        // UPDATED: 11/3/2014
        //=====================================================================
        public void updateLastLogin(string user, bool adminUser)
        {
            bool found = true; 
            if (adminUser)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("user_admin");
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    string userName = xn["Username"].InnerText;
                    if (userName.Equals(user))
                    {
                        xn["lastLogin"].InnerText = DateTime.Now.ToString();
                        xml.Save(@"user_admin");
                    }
                    else
                    {
                        found = false; 
                    }
                }//end foreach 

                if (found == false)
                {
                    XmlDocument userXml = new XmlDocument();
                    userXml.Load("users.xml");
                    XmlNodeList userlist = userXml.SelectNodes("/Users/User");
                    foreach (XmlNode xn in userlist)
                    {
                        string userName = xn["Username"].InnerText;
                        if (userName.Equals(user))
                        {
                            xn["lastLogin"].InnerText = DateTime.Now.ToString();
                            userXml.Save(@"users.xml");
                        }
                    }//end foreach 
                }
            
            }
            else if (!adminUser)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("users.xml");
                XmlNodeList list = xml.SelectNodes("/Users/User");
                foreach (XmlNode xn in list)
                {
                    string userName = xn["Username"].InnerText;
                    if (userName.Equals(user))
                    {
                        xn["lastLogin"].InnerText = DateTime.Now.ToString();
                        xml.Save(@"users.xml"); 
                    }
                }//end foreach 
            }
        }//end fillInLoginInfo
        //=====================================================================

        //=======================================================
        // AUTHOR: Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Exports the report into excel. 
        // UPDATED: 11/7/2014   - Jeff Henry (Added SaveFileDialog) 
        //=======================================================
        public void exportExcel(DataGridView dataGrid, string total, string mileage)
        {
            // Prompt the User where to save the file.
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel File | *xls";
            saveFileDialog1.Title = "Save as Excel File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook ExcelBook;
                    Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;
                    int i = 0;
                    int j = 0;
                    var totalHeader = 0;// go to the very right of the columns
                    
                    // Create the Excel Object:
                    ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
                    ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet; 

                    // Create the header
                    for (i = 1; i <= dataGrid.Columns.Count; i++)
                    {
                        ExcelSheet.Cells[1, i] = dataGrid.Columns[i - 1].HeaderText;
                        totalHeader = i + 1;
                    }
                    
                    var totalRow = 0;
                    var totalCol = 0;

                    //export the data to excel
                    for (i = 1; i <= dataGrid.RowCount; i++)
                    {
                        for (j = 1; j <= dataGrid.Columns.Count; j++)
                        {
                            ExcelSheet.Cells[i + 1, j] = dataGrid.Rows[i - 1].Cells[j - 1].Value;
                            totalCol = j + 1;
                        }
                        totalRow = i + 1;
                    }
                    ExcelSheet.Cells[totalRow + 2, 1] = "Expense Total:";           // Display the expense total after all the expense
                    ExcelSheet.Cells[totalRow + 3, 1] = "Mileage Total:";           // Display the mileage total after all the expense
                    ExcelSheet.Cells[totalRow + 2, totalCol-1] = total;       //Show the total in the correct cell
                    ExcelSheet.Cells[totalRow + 3, totalCol-1] = mileage;   //Show the total mileage in the correct cell
                    ExcelApp.Visible = true;

                    //set the font detailed
                    Microsoft.Office.Interop.Excel.Range myRange = ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[dataGrid.RowCount + 1, dataGrid.Columns.Count]];
                    Microsoft.Office.Interop.Excel.Font x = myRange.Font;
                    x.Name = "Arial";
                    x.Size = 10;
                    
                    //Bold the header row
                    myRange = ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, dataGrid.Columns.Count + 2]];
                    myRange.Interior.Color = System.Drawing.Color.SlateGray;
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
        // UPDATED: 11/3/2014
        //=====================================================================
        public string[] addCategories()
        {
            string[] categories = new string[100];
            string catName;
            Data checkExists = new Data();
            bool exists = checkExists.xmlcheck();
            int x = 0; 
            //int count = 0;
            int count2 = 0;

            if (exists == true)
            {
                XDocument catDoc = XDocument.Load(@"categories.xml");

                foreach (var Category in catDoc.Descendants("Category"))
                {
                    catName = Category.Element("categoryName").Value;
                    if (catName != "All Categories")
                    {
                        categories[x++] = catName;
                        count2++;
                    }
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
                    //var source2 = new AutoCompleteStringCollection();
                    //source2.AddRange(actualCats);
                    //comboBox2.Items.AddRange(actualCats);
                    //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    
                }
                return actualCats;
            }
            return categories;
         }//end addCategories
        //=====================================================================
    }//end class: Data
    //=====================================================================

}//end
//===================================================================== 
