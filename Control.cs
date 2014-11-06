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
    //          transfer data between class data and forms. Some methods are calle din a specific order from 
    //          the data class in order to give a certain effect.
    // PARAMS: None
    // UPDATED: 11/3/2014
    // ========================================================================
    class Control
    {
        //=====================================================================
        // AUTHOR: Karan Singh
        // PURPOSE:Public string that gets a value and sets it so other forms can call it.
        // PARAMS: None
        // ====================================================================
        public string ReturnValue1 
        { 
            get; 
            set; 
        }//end 
        //========================================================================

        //========================================================================
        // AUTHORS: Karan Singh
        // PURPOSE: Public list with which the last date can be determined in multiple forms
        // PARAMS: None
        //========================================================================
        public List<DateTime> passList
        { 
            get; 
            set; 
        }//end
        //========================================================================
                
        //========================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Multiple Public arrays, meant to store and transport data back to the forms
        // PARAMS:  Name, Date
        //========================================================================
        public List<string> expenses { get; set; }
        public List<DateTime> datedata { get; set; }
        public List<string> nametrans { get; set; }
        public List<string> catrans { get; set; }
        //========================================================================


        //=====================================================================
        // AUTHOR: Karan Singh
        // PURPOSE: This calls the xmlcreate function in the data IF the xml check call returns a false
        // PARAMS: None
        //=====================================================================
        public void createxmlfile()
        {
            Data xmlcreation = new Data();
            if (xmlcreation.xmlcheck() == false)//if xml create returns a false
            {
                xmlcreation.xmlcreate();//create a new xml file based on the template in Data class
                xmlcreation.userXml();
                xmlcreation.categoriesXml(); //added 10/24/14
                xmlcreation.detailed_transaction();
                xmlcreation.userAdminXml(); //added 10/26/2014
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
        public void addatransaction(decimal expenditure, string category, DateTime date, string name, string comments)
        {
            Data newtransaction = new Data();
            newtransaction.add_transaction(expenditure, category, date, name, comments);
            newtransaction.add_history(date, name);
        }//end addatransaction
        //=====================================================================



        //=======================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Uses the passList above to store an array of all dates that 
        //          it gets by calling login_history in the Data class.
        // PARAMS:  Name
        //========================================================================
        public void getHistory(string name)
        {
            Data history = new Data();
            history.login_history(name);
            List<DateTime> lastdate = history.login;
            this.passList = lastdate;
        }
        //========================================================================

        //========================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Serves as a messenger to the Data class to tell it to log the current login activity 
        // PARAMS:  Name, Date 
        //========================================================================
        public void add_history(string name, DateTime date)
        {
            Data newtransaction = new Data();
            newtransaction.add_login_history(name, date);
        }
        //========================================================================


        //========================================================================
        // AUTHOR:  Karan Singh
        // PURPOSE: Load records loads all the records that are needed to generate view history datagrid
        // PARAMS:  Name, start and end dates, category
        //========================================================================
        public void load_records(DateTime start, DateTime end, string category, string name)
        {
            Data report = new Data();
            report.load_name(start, end, category, name);//load name function gets all the data from the xml
            //readin the data lists as are created by data into declared lists
            List<DateTime> temp = report.trans;
            List<string> check = report.lists;
            List<string> names = report.trans1;
            List<string> categories = report.trans2;
            //set the lists to appropriate public list for use by forms
            this.expenses = check;
            this.datedata = temp;
            this.nametrans = names;
            this.catrans = categories;
        }//end load_records 
        //========================================================================

        //========================================================================
        // AUTHOR: Michelle Jaro
        // PURPOSE: Load records loads all the records that are needed to generate the Expense Reports
        // PARAMS: Start and end dates, category, Reference List of Transactions, Ref decimal
        //========================================================================
        public void loadExpenseReport(DateTime start, DateTime end, string category, ref List<Transaction> expenseReport, ref decimal totalExpense, string addBy)
        {
            Data expenses = new Data();
            expenses.loadExpenses(start, end, category, ref expenseReport, ref totalExpense, addBy);
        }//end loadExpenseReport 
        //========================================================================

        //========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado
        // PURPOSE Load records loads all the records that are needed to generate the Expense Reports
        // PARAMS: Start and end dates, category, Reference List of Transactions, Ref decimal
        //========================================================================
        public void loadDetailedExpenseReport(DateTime start, DateTime end, string category, ref List<DetailedTransaction> expenseReport, ref decimal totalExpense, string addBy)
        {
            //call the loadExpenses function in data
            Data expenses = new Data();
            expenses.loadDetailedExpenses(start, end, category, ref expenseReport, ref totalExpense, addBy);
        }//end loadDetailedExpenseReport 
        //========================================================================

        //========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: Loads all of the users from xml files, after a user logins.  
        //========================================================================
        public List<string> loadUserList()
        {
            Data users = new Data();
            return users.loadUsers();
        }//end loadUserList
        //========================================================================

        //========================================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: THis function only load lists after a user logs into the application.
        // PARAMS:  10/29/2014
        //========================================================================
        public List<string> loadCategoryList()
        {
            Data categories = new Data();
            return categories.loadCat();
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
        public string showHelpInfo(string nodeName)
        {
            Data helpData = new Data();
            return (helpData.displayHelpInfo(nodeName)); 
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
        public int mileage(DateTime start, DateTime end)
        {
            Data miles = new Data();
           return miles.getMileage(start, end);
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
        public void export(DataGridView gridview, string total, string mileage)
        {
            Data excel = new Data();
            excel.exportExcel(gridview, total, mileage);
        }//end
        //========================================================================
    }
    //========================================================================
}//end control 
//========================================================================
