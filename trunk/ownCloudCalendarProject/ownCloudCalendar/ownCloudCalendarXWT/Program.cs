using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xwt;

namespace ownCloudCalendarXWT
{
    class Program
    {
        public static void Main(string[] args)
        {
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
    }
}
