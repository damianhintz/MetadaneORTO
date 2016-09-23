using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MetadaneORTO.Core;

namespace MetadaneORTO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GdalConfiguration.ConfigureOgr();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
