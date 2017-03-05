using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ColorMatchingSystemAPP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            primaryForm _form = new primaryForm();
            _form.Text = COMMON.Common.ConfigVariable("DistributorName") + " Color Matching System";
            Application.Run(_form);
        }
    }
}
