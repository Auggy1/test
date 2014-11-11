//=====================================================================
// AUTHORS: 
//          Cycle 2: Maxwell Partington & Ranier Limpiado     
// PURPOSE: This is the help form of the program that calls the showhelp
//          function from the data.cs file and displays the appropriate
//          help information for the user. 
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

namespace Project_Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //===========================================================
        // AUTHOR:  Maxwell Partington & Ranier Limpiado 
        // PURPOSE: This function calls the showHelpInfo function that
        //          will populate the windows form with the correct information. 
        // PARAMS:  None.
        // UPDATED: 11/3/14
        //===========================================================
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            Control helpDisplay = new Control();
            richTextBox1.Text = helpDisplay.GrabHelpInfo(node.Text); 
        }//end
        //===========================================================
      
    }

}
