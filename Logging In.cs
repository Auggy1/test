using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Venture_Business_Management
{
    public partial class Logging_In : Form
    {
        public Logging_In()
        {
            InitializeComponent();
        }

        private void Loggin_In_Load(object sender, EventArgs e)
        {
            login_progress.Maximum = 100;
            login_progress.Step = 1;
            login_progress.Value = 0;

            for (int i = 0; i < 200; i++)
                login_progress.Value = i;
            login_progress.Hide();
        }
    }
}
