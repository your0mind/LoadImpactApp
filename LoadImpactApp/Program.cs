using System;
using System.Windows.Forms;

namespace LoadImpactApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings.GetFromFile("UserSettings.xml");
            //Settings.SaveToFile("UserSettings.xml");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectionForm());
        }
    }
}
