using BSmith.ChemistrySolver.Controllers;
using System;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver
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
            Application.Run(new LauncherController());
        }
    }
}
