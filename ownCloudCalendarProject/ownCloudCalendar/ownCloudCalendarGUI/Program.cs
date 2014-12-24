using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ownCloudCalendarGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string logConfigFile = AppDomain.CurrentDomain.BaseDirectory + @"config.log4net";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(logConfigFile));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstanceApplication.Run(new LogIn(), StartupNextInstanceHandler);
        }

        static void StartupNextInstanceHandler(object sender, Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
        {
            MessageBox.Show("ownCloudCalendar application is already started.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
