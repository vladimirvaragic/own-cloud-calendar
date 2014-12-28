using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ownCloudCalendarShared.Exceptions;
using ownCloudCalendarShared.Logging;
using Xwt;

namespace ownCloudCalendarXWT.Common
{
    public class BaseForm : Canvas
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

            MessageDialog.ShowMessage("There was an error in the application");
        }

        protected void ShowMessage(string message, string title)
        {
            MessageDialog.ShowMessage(message, title);
        }
        
        #endregion Non-virtual methods
    }
}
