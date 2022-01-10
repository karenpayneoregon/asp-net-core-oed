using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(PathHelpers.GetShortPath(@"C:\Program Files\dotnet"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
#if Staging

#elif Dev

#elif Prod

#endif
        }
    }
}
