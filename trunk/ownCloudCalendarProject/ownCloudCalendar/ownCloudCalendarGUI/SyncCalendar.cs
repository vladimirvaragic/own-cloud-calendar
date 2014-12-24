using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDay.iCal;
using ownCloudCalendarController;
using ownCloudCalendarGUI.Common;

namespace ownCloudCalendarGUI
{
    public partial class SyncCalendar : BaseForm
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

        public SyncCalendar()
        {
            try
            {
                InitializeComponent();
                CenterToScreen();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public SyncCalendar(string serverUrl, string userName, string pswrd)
        {
            try
            {
                InitializeComponent();
                CenterToScreen();

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
                InitializeComponent();
                CenterToScreen();

                txtCalendarName.Text = calendarName;
                cbAutomaticSync.Checked = isAutomaticSyncChecked;
                txtTimerInterval.Text = isAutomaticSyncChecked ? syncTimerInterval.ToString() : String.Empty;
                txtTimerInterval.Enabled = cbAutomaticSync.Checked;

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
        
        #region Non-virtual methods

        private IICalendarCollection GetCalendarEventsData()
        {
            owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

            string url = serverAddress + cCalDavUrlExtension + username + cCalDavUrlExtensionSlash + txtCalendarName.Text.Trim().ToLower() + cCalDavUrlExtensionExport;
            serverUrl = new Uri(url);

            return connector.ownCloudCalendar_GetEvents(serverUrl, username, password);
        }

        private bool ValidateControls()
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(txtCalendarName.Text))
            {
                epCalendarName.SetError(txtCalendarName, "Required field");
                isValid = false;
            }
            else
            {
                epCalendarName.Clear();
            }

            if (cbAutomaticSync.Checked && String.IsNullOrEmpty(txtTimerInterval.Text))
            {
                epTimerInterval.SetError(lblMinutes, "Required field when Automatic sync is checked");
                isValid = false;
            }
            else
            {
                epTimerInterval.Clear();
            }

            if (!cbAutomaticSync.Checked && !String.IsNullOrEmpty(txtTimerInterval.Text))
            {
                epTimerInterval.SetError(lblMinutes, "If You want to enable automatic sync, please check field Automatic sync too");
                isValid = false;                
            }

            if (cbAutomaticSync.Checked && !String.IsNullOrEmpty(txtTimerInterval.Text))
            {
                try
                {
                    int interval = Convert.ToInt16(txtTimerInterval.Text);

                    if (interval <= 0)
                    {
                        epTimerInterval.SetError(lblMinutes, "Bad format");
                        isValid = false; 
                    }
                }
                catch
                {
                    epTimerInterval.SetError(lblMinutes, "Bad format");
                    isValid = false;   
                }
            }

            return isValid;
        }

        private void HideForm()
        {
            IsHiden = true;
            Hide();
        }

        #endregion Non-virtual methods

        #region Events

        private void btnSyncCalendar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    IICalendarCollection iCalCollection = GetCalendarEventsData();

                    if (iCalCollection == null)
                    {
                        ShowMessage("There is no calendar with the name " + txtCalendarName.Text.Trim(), "ownCloud Calendar Sync Unavailable");
                    }
                    else
                    {
                        Hide();
                        int? syncTimerInterval = null;
                        if(!String.IsNullOrEmpty(txtTimerInterval.Text))
                        {
                            syncTimerInterval = Convert.ToInt32(txtTimerInterval.Text);
                        }
                        EventsList eventsList = new EventsList(iCalCollection, cbAutomaticSync.Checked, syncTimerInterval, txtCalendarName.Text, serverUrl, username, password, serverAddress);
                        eventsList.ShowDialog();
                        if (eventsList.IsHiden)
                        {
                            HideForm();
                        }
                        else
                        {
                            Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void cbAutomaticSync_Click(object sender, EventArgs e)
        {
            try 
            {
                if (!cbAutomaticSync.Checked) txtTimerInterval.Text = String.Empty;
                txtTimerInterval.Enabled = cbAutomaticSync.Checked;                
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Events       
    }
}
