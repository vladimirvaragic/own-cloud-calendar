using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;
using ownCloudCalendarController;
using ownCloudCalendarXWT.Common;
using Xwt;
using Xwt.Drawing;

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

        Label lblTitle = new Label("Sync calendar")
        {
            Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(14)
        };
        Label lblCalendarName = new Label("Calendar name");
        TextEntry txtCalendarName = new TextEntry();
        Label lblAutomaticSync = new Label("Automatic sync");
        CheckBox cbAutomaticSync = new CheckBox();
        Label lblTimerInterval = new Label("Set timer interval");
        TextEntry txtTimerInterval = new TextEntry();
        Label lblMinutes = new Label("minute(s)");
        Button btnSyncCalendar = new Button("Sync now");

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

                DrawControls();

                btnSyncCalendar.Clicked += delegate
                {
                    btnSyncCalendar_Click();
                };

                cbAutomaticSync.Clicked += delegate
                {
                    cbAutomaticSync_Click();
                };
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
                txtCalendarName.Text = calendarName;
                cbAutomaticSync.Active = isAutomaticSyncChecked;
                txtTimerInterval.Text = isAutomaticSyncChecked ? syncTimerInterval.ToString() : String.Empty;
                txtTimerInterval.ReadOnly = !cbAutomaticSync.Active;

                serverAddress = serverUrl;
                username = userName;
                password = pswrd;

                DrawControls();

                btnSyncCalendar.Clicked += delegate
                {
                    btnSyncCalendar_Click();
                };

                cbAutomaticSync.Clicked += delegate
                {
                    cbAutomaticSync_Click();
                };
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Constructors

        #region Non-virtual methods

        private void DrawControls()
        {
            lblTitle.MinWidth = 220;
            AddChild(lblTitle, 13, 13);
            AddChild(lblCalendarName, 13, 56);
            txtCalendarName.WidthRequest = 266;
            AddChild(txtCalendarName, 105, 53);

            AddChild(lblAutomaticSync, 13, 88);
            AddChild(cbAutomaticSync, 105, 88);

            AddChild(lblTimerInterval, 13, 118);
            txtTimerInterval.WidthRequest = 51;
            txtTimerInterval.ReadOnly = true;
            AddChild(txtTimerInterval, 105, 115);
            AddChild(lblMinutes, 162, 118);

            btnSyncCalendar.MinWidth = 102;
            btnSyncCalendar.MinHeight = 23;
            btnSyncCalendar.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnSyncCalendar, 370, 177);
        }

        private string ValidateControls()
        {
            StringBuilder validationMessage = new StringBuilder();
            string msg = String.Empty;

            if (String.IsNullOrEmpty(txtCalendarName.Text))
            {
                msg = "Calendar name is required field";
                if (validationMessage.Length == 0)
                {
                    validationMessage.Append(msg);
                }
                else
                {
                    validationMessage.Append(Environment.NewLine);
                    validationMessage.Append(msg);
                }
            }

            if (cbAutomaticSync.Active && String.IsNullOrEmpty(txtTimerInterval.Text))
            {
                msg = "Timer interval is required field when Automatic sync is checked";
                if (validationMessage.Length == 0)
                {
                    validationMessage.Append(msg);
                }
                else
                {
                    validationMessage.Append(Environment.NewLine);
                    validationMessage.Append(msg);
                }
            }

            if (!cbAutomaticSync.Active && !String.IsNullOrEmpty(txtTimerInterval.Text))
            {
                msg = "If You want to enable automatic sync, please check field Automatic sync too";
                if (validationMessage.Length == 0)
                {
                    validationMessage.Append(msg);
                }
                else
                {
                    validationMessage.Append(Environment.NewLine);
                    validationMessage.Append(msg);
                }
            }

            if (cbAutomaticSync.Active && !String.IsNullOrEmpty(txtTimerInterval.Text))
            {
                msg = "Timer interval has a bad format";
                try
                {
                    int interval = Convert.ToInt16(txtTimerInterval.Text);

                    if (interval <= 0)
                    {
                        if (validationMessage.Length == 0)
                        {
                            validationMessage.Append(msg);
                        }
                        else
                        {
                            validationMessage.Append(Environment.NewLine);
                            validationMessage.Append(msg);
                        }
                    }
                }
                catch
                {
                    if (validationMessage.Length == 0)
                    {
                        validationMessage.Append(msg);
                    }
                    else
                    {
                        validationMessage.Append(Environment.NewLine);
                        validationMessage.Append(msg);
                    }
                }
            }

            return validationMessage.ToString();
        }

        private void HideForm()
        {
            IsHiden = true;
            this.ParentWindow.Hide();
        }

        private IICalendarCollection GetCalendarEventsData()
        {
            owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

            string url = serverAddress + cCalDavUrlExtension + username + cCalDavUrlExtensionSlash + txtCalendarName.Text.Trim().ToLower() + cCalDavUrlExtensionExport;
            serverUrl = new Uri(url);

            return connector.ownCloudCalendar_GetEvents(serverUrl, username, password);
        }

        #endregion Non-virtual methods

        #region Events

        private void btnSyncCalendar_Click()
        {
            try
            {
                string validationMessage = ValidateControls();

                if (!String.IsNullOrEmpty(validationMessage))
                {
                    MessageDialog.ShowError(validationMessage);
                    return;
                }

                IICalendarCollection iCalCollection = GetCalendarEventsData();

                if (iCalCollection == null)
                {
                    MessageDialog.ShowMessage("There is no calendar with the name " + txtCalendarName.Text.Trim());
                }
                else
                {
                    Hide();
                    int? syncTimerInterval = null;
                    if (!String.IsNullOrEmpty(txtTimerInterval.Text))
                    {
                        syncTimerInterval = Convert.ToInt32(txtTimerInterval.Text);
                    }

                    var eventListWindow = new Window()
                    {
                        Title = "ownCloud Calendar Client",
                        Width = 500,
                        Height = 500
                    };
                    eventListWindow.Resizable = false;
                    eventListWindow.ShowInTaskbar = false;                    
                    EventsList eventsList = new EventsList(iCalCollection, cbAutomaticSync.Active, syncTimerInterval, txtCalendarName.Text, serverUrl, username, password, serverAddress);
                    eventListWindow.Content = eventsList;
                    eventListWindow.Show();

                    if (eventsList.IsHiden)
                    {
                        HideForm();
                    }
                    else
                    {
                        this.ParentWindow.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void cbAutomaticSync_Click()
        {
            try
            {
                if (!cbAutomaticSync.Active) txtTimerInterval.Text = String.Empty;
                txtTimerInterval.ReadOnly = !cbAutomaticSync.Active;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Events
    }
}
