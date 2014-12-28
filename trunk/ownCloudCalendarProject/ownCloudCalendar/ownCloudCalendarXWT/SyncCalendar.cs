using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ownCloudCalendarXWT.Common;

namespace ownCloudCalendarXWT
{
    public class SyncCalendar : BaseForm
    {
        #region Constants

        private const string cCalDavUrlExtension = "/remote.php/caldav/calendars/";
        private const string cCalDavUrlExtensionSlash = "/";
        private const string cCalDavUrlExtensionExport = "?export";

        #endregion Constants

        #region Private fields

        string serverAddress = String.Empty;
        string username = String.Empty;
        string password = String.Empty;

        #endregion Private fields

        #region Properties

        public bool IsHiden
        {
            get;
            set;
        }

        private Uri serverUrl
        {
            get;
            set;
        }

        #endregion Properties

        #region Constructors

        public SyncCalendar(string serverUrl, string userName, string pswrd)
        {
            try
            {
                serverAddress = serverUrl;
                username = userName;
                password = pswrd;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public SyncCalendar(string calendarName, bool isAutomaticSyncChecked, int? syncTimerInterval, string serverUrl, string userName, string pswrd)
        {
            try
            {
                //txtCalendarName.Text = calendarName;
                //cbAutomaticSync.Checked = isAutomaticSyncChecked;
                //txtTimerInterval.Text = isAutomaticSyncChecked ? syncTimerInterval.ToString() : String.Empty;
                //txtTimerInterval.Enabled = cbAutomaticSync.Checked;

                serverAddress = serverUrl;
                username = userName;
                password = pswrd;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Constructors
    }
}
