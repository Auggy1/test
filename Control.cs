using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
namespace Project_Forms
{
    //=========================================================================
    // PURPOSE: This class is meant to do a lot of the thinking in small functions. 
    //          However its main function is to act as a barrier between data and 
    //          the forms. The class contains multiple functions and methods that
    //          transfer data between class data and forms. Some methods are called
    //          in a specific order from the data class in order to give a certain effect.
    // PARAMS:  None
    // UPDATED: 11/10/2014  Jeff Henry - Refactoring and renamed functions
    // ========================================================================
    public class Control
    {
        public Data alldata = new Data();
        //=====================================================================
        // AUTHOR: Karan Singh
        // PURPOSE:Public string that gets a value and sets it so other forms can call it.
        // PARAMS: None
        // ====================================================================
        public string ReturnValue1{get;set;} 
        //========================================================================

        //========================================================================
        // AUTHORS: Karan Singh
        // PURPOSE: Public list with which the last date can be determined in multiple forms
        // PARAMS: None
        //========================================================================
        public List<DateTime> passList{get;set;}
        //========================================================================
                
        //========================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Multiple Public arrays, meant to store and transport data back to the forms
        // PARAMS:  Name, Date
        //========================================================================
        public List<string> expenses { get; set; }
        public List<DateTime> dates { get; set; }
        public List<string> nametrans { get; set; }
        public List<string> catrans { get; set; }
        //========================================================================


        //=====================================================================
        // AUTHOR: Karan Singh
        // PURPOSE: This calls the xmlcreate function in the data IF the xml 
        //          check call returns false.
        // PARAMS: None
        //=====================================================================
        public void CreateXMLs()
        {
            if (!alldata.CheckXMLExistence())
            {
                alldata.CreateTransactionXML();
                alldata.CreateUserXML();
                alldata.CreateCategoriesXML(); 
                alldata.CreateAdminXML();
            }
        }//end createxmlfile
        //========================================================================
        
        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: Retrieves all the information from the xml files and saves
        //          it into the data lists.
        //====================================================================
        public void LoadLists()
        {
            alldata.LoadTransactionsFromXML();
            alldata.LoadUsersFromXML();
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will return whether a user is an admin or not.
        //====================================================================
        public bool CheckIfAdmin(string user)
        {
            return alldata.CheckIfAdmin(user);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will return whether a user exists or not
        //====================================================================
        public bool CheckUserExistence(string user, bool isAdmin)
        {
            return alldata.CheckUserExistence(user, isAdmin);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will return whether the password was valid.
        //====================================================================
        public bool VerifyPassword(string user, string pass)
        {
            return alldata.VerifyPassword(user, pass);
        }
        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will fill in the login info upon a user 
        //          successfully logging into the program.
        //====================================================================
        public string FillLoginInfo(string user, bool isAdmin)
        {
           return alldata.FillInLoginInfo(user, isAdmin);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will update the login of the user 
        //====================================================================
        public void UpdateUserLogin(string user, bool isAdmin)
        {
            alldata.UpdateLastLogin(user, isAdmin);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will fill the gridview in the main program
        //====================================================================
        public void FillGridSummary(DataGridView grid, string cat, ref decimal exp, ref decimal mil, DateTime start, DateTime end, string user)
        {
            alldata.FillGridSummaryView(grid, cat, ref exp, ref mil, start, end, user);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will fill the gridview in the main program
        //====================================================================
        public void FillGridDetailed(DataGridView grid, string cat, ref decimal exp, ref decimal mil, DateTime start, DateTime end, string user)
        {
            alldata.FillGridDetailView(grid, cat, ref exp, ref mil, start, end, user);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This will determine the mileage total within the date 
        //          range of the calendars.
        //====================================================================
        public int GetTotalMileage(DateTime start, DateTime end)
        {
            return alldata.GetMileage(start, end);
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will populate the grid view for the history.
        //====================================================================
        public void GetTransactionHistory(DataGridView grid, string user, string cat, DateTime start, DateTime end)
        {
            alldata.GetTransactionHistory(grid, user, cat, start, end);
        }
        
        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function returns a list of all the categories.
        //====================================================================
        public List<string> GetCategories()
        {
            return alldata.GetCategories();
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function returns a list of all the categories.
        //====================================================================
        public List<string> GetAllCategories()
        {
            return alldata.GetAllCategories();
        }

        //====================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function returns a list of all the users.
        //====================================================================
        public List<string> GetAllUsers()
        {
            return alldata.GetAllUsers();
        }

        //====================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Gets the various data fields from the forms and adds a 
        //          transaction and history at the same time
        //          to work as a sort of Primary Key validation in most 
        //          Relatable Databases.
        // PARAMS:  Expense, Category, Date, Name
        //=====================================================================
        public void AddTransaction(decimal expenditure, string category, DateTime date, string name, string comments)
        {
            alldata.AddTransaction(expenditure, category, date, name, comments);
        }//end addatransaction
        //=====================================================================

        //========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This loads all of the help information from the helpinfo function
        //          and sends it back to the "help" window generated in form1. 
        // PARAMS:  The parameter for this function is the help node name that 
        //          the user is requesting information for. The displayHelpInfo
        //          function will return a string will all of the appropriate info. 
        // DATE:    10/29/14
        //========================================================================
        public string GrabHelpInfo(string nodeName)
        {
            return (alldata.GrabHelpInfo(nodeName)); 
        }//end 
        //========================================================================

        //========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE: This function is meant to get all of the mileage data from the
        //          xml.
        // PARAMS:  The parameters for this function are the start and end dates
        //          that the user specificed in when they requested their data.  
        // DATE:    10/29/14
        //========================================================================
        public int GetMileage(DateTime start, DateTime end)
        {
            return alldata.GetMileage(start, end);
        }//end 
        //========================================================================

        //========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado  
        // PURPOSE: This function is utilized to bring the data from the xml files
        //          out into excel spreadsheet form for the user to view. 
        // PARAMS:  This function requires the gridview data, the total of all 
        //          expenditures, as well as the milage.  
        // DATE:    10/29/14
        //========================================================================
        public void export(DataGridView gridview, string total, string mileage, string start, string end, string user)
        {
            alldata.ExportToExcel(gridview, total, mileage, start, end, user);
        }//end
        //========================================================================

        //========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will perform the action of adding a new user.
        // UPDATE:  11/13/2014  Jeff Henry  - Initial Creation
        //========================================================================
        public void AddNewUser(string user, string enc_pass, bool admin, string first, string last, string email, bool locked)
        {
            alldata.AddNewUser(user, enc_pass, admin, first, last, email, locked);
        }

        //========================================================================
        // AUTHOR:  Jeff Henry
        // PURPOSE: This function will perform the encryption of a users password
        //          and return the encrpyted password to the main program.
        // UPDATES: 11/13/2014  Jeff Henry  - Initial Creation
        //========================================================================
        public string Encrypt(string password, string cypher)
        {
            return alldata.Encrypt(password, cypher);
        }
    }
    //========================================================================
    // !! Deprecated Functions !!
    //========================================================================
    /*
    //========================================================================
    // AUTHOR:  Maxwell Partington & Ranier Limpiado 
    // PURPOSE: Loads all of the users from xml files, after a user logins.  
    //========================================================================
    public List<string> GetUsers()
    {
        Data users = new Data();
        return users.GetUsers();
    }//end loadUserList
    //========================================================================
    
    //========================================================================
    // AUTHOR:  Karan Singh
    // PURPOSE: Serves as a messenger to the Data class to tell it to log the 
    //          current login activity 
    // PARAMS:  Name, Date 
    //========================================================================
    public void SetLoginHistory(string name, DateTime date)
    {
        Data newtransaction = new Data();
        //newtransaction.SetLoginHistory(name, date);
    }
    //========================================================================

    
    //========================================================================
    // AUTHOR:  Maxwell Partington & Ranier Limpiado 
    // PURPOSE: THis function only load lists after a user logs into the application.
    // PARAMS:  10/29/2014
    //========================================================================
    public List<string> GetCategories()
    {
        return alldata.GetCategories();
    }//end 
    //========================================================================
     */
}//end control 
//========================================================================
