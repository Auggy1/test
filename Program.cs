//===================================================================
// AUTHORS: 
//          FIRST CYCLE:  Karan Singh, Michelle Jaro
//          SECOND CYCLE: Maxwell Partington, Ranier Limpiado
//
//===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Project_Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {    
        bool ok;
        Mutex m = new System.Threading.Mutex(true, "ChuckD", out ok);

        if (! ok)
        {
            MessageBox.Show("ERROR: Another instance is already running.");
            return;
        }
    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());

        GC.KeepAlive(m);
    }
    
        }
}

