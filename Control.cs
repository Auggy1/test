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
    class Control
    {
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
            Data xml_creation = new Data();
            if (!xml_creation.CheckXMLExistence())
            {
                xml_creation.CreateTransactionXML();
                xml_creation.CreateUserXML();
                xml_creation.CreateCategoriesXML(); 
                xml_creation.CreateAdminXML();
            }
        }//end createxmlfile
        //========================================================================


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
            Data newtransaction = new Data();
            newtransaction.AddTransaction(expenditure, category, date, name, comments);
            newtransaction.UpdateTransactionHistory(date, name);
        }//end addatransaction
        //=====================================================================

        //========================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Serves as a messenger to the Data class to tell it to log the 
        //          current login activity 
        // PARAMS:  Name, Date 
        //========================================================================
        public void SetLoginHistory(string name, DateTime date)
        {
            Data newtransaction = new Data();
            newtransaction.SetLoginHistory(name, date);
        }
        //========================================================================

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
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: THis function only load lists after a user logs into the application.
        // PARAMS:  10/29/2014
        //========================================================================
        public List<string> GetCategories()
        {
            Data categories = new Data();
            return categories.GetCategories();
        }//end 
        //========================================================================

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
            Data helpData = new Data();
            return (helpData.GrabHelpInfo(nodeName)); 
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
            Data miles = new Data();
            return miles.GetMileage(start, end);
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
            Data excel = new Data();
            excel.ExportToExcel(gridview, total, mileage, start, end, user);
        }//end
        //========================================================================
    }
    //========================================================================
}//end control 
//========================================================================
