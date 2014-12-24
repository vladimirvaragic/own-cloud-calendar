using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ownCloudCalendarShared.Exceptions;
using ownCloudCalendarShared.Logging;

namespace ownCloudCalendarGUI.Common
{
    public class BaseForm : Form
    {
        #region Non-virtual methods

        protected void HandleException(Exception ex)
        {
            if (ex is LoggedException)
            {
            }
            else
            {
                Logging.LogError(ex, LoggingCategories.GUI);
            }

            MessageBox.Show("There was an error in the application");
        }

        protected void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        
        #endregion Non-virtual methods
    }
}
