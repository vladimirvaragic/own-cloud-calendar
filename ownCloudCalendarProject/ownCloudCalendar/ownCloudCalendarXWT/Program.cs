using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xwt;

namespace ownCloudCalendarXWT
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Mutex mutex = new System.Threading.Mutex(false, "OwnCloudCalendarConnerctor");
            try
            {
                if (mutex.WaitOne(0, false))
                {
                    string logConfigFile = AppDomain.CurrentDomain.BaseDirectory + @"config.log4net";
                    log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(logConfigFile));

                    Application.Initialize(ToolkitType.Gtk);
                    Xwt.Drawing.Image iconImage = Xwt.Drawing.Image.FromFile(@"D:\Vladimir Varagic\Privatno\Diplomski rad\svnVersion\ownCloudCalendar\trunk\ownCloudCalendarProject\ownCloudCalendar\ownCloudCalendarXWT\Images\20141129064955676_easyicon_net_32.ico");

                    var mainWindow = new Window()
                    {
                        Title = "ownCloud Calendar Client",
                        Width = 500,
                        Height = 250,
                        Icon = iconImage
                    };

                    mainWindow.Resizable = false;

                    LogIn logIn = new LogIn();

                    mainWindow.Content = logIn;

                    mainWindow.Show();
                    Application.Run();
                    mainWindow.Dispose();

                }
                else
                {
                    Application.Initialize(ToolkitType.Gtk);                    
                    MessageDialog.ShowMessage("An instance of the application is already running.");
                }
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                    mutex = null;
                }
            }
        }
    }
}
