using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DDay.iCal;
using ownCloudCalendarController;
using ownCloudCalendarXWT.Common;
using Xwt;
using Xwt.Drawing;

namespace ownCloudCalendarXWT
{
    public class EventsList : BaseForm
    {
        #region Private fields

        Xwt.Drawing.Image iconImage = Xwt.Drawing.Image.FromFile(@"D:\Vladimir Varagic\Privatno\Diplomski rad\svnVersion\ownCloudCalendar\trunk\ownCloudCalendarProject\ownCloudCalendar\ownCloudCalendarXWT\Images\20141129064955676_easyicon_net_32.ico");

        Label lblNoEventsMessages = new Label("There is no upcoming events in calendar")
        {
            Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(12)
        };
        Label lblTitle = new Label("List of events")
        {
            Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(14)
        };

        VBox drEvents = new VBox()
        {
            ExpandHorizontal = true,
            ExpandVertical = true
        };

        Button btnSyncNow = new Button("Sync now");
        Button btnEventManagment = new Button("Manage events");
        Button btnSettings = new Button("Sync settings");
        Button btnLogOut = new Button("Log out");
        Button btnQuit = new Button("Quit");

        Label lblLine = new Label("_________________________________________________________________________________________________");

        #endregion Private fields

        #region Constructors

        public EventsList(IICalendarCollection iCalCollection, bool isAutomaticSyncChecked, int? syncTimerInterval, string calendarName, Uri url, string username, string password, string serverAddress)
        {
            try
            {
                DrawControls();
                IsClosed = false;
                CalCollection = iCalCollection;
                CalendarName = calendarName;
                ServerUrl = url;
                Username = username;
                Password = password;
                IsAutomaticSyncChecked = isAutomaticSyncChecked;
                SyncTimerInterval = syncTimerInterval;
                ServerAddress = serverAddress;

                PopulateEventsList();
                SetNotificationTimer();
                SetSyncTimer(IsAutomaticSyncChecked, SyncTimerInterval);

                btnSyncNow.Clicked += delegate
                {
                    btnSyncNow_Click();
                };

                btnEventManagment.Clicked += delegate
                {
                    btnEventManagment_Click();
                };

                btnSettings.Clicked += delegate
                {
                    btnSettings_Click();
                };

                btnLogOut.Clicked += delegate
                {
                    btnLogOut_Click();
                };

                btnQuit.Clicked += delegate
                {
                    btnQuit_Click();
                };
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Constructors

        #region Properties

        public bool IsHiden
        {
            get;
            set;
        }

        public bool IsClosed
        {
            get;
            set;
        }

        private IICalendarCollection CalCollection
        {
            get;
            set;
        }

        private string CalendarName
        {
            get;
            set;
        }

        private Uri ServerUrl
        {
            get;
            set;
        }

        private string Username
        {
            get;
            set;
        }

        private string Password
        {
            get;
            set;
        }

        private bool IsAutomaticSyncChecked
        {
            get;
            set;
        }

        private int? SyncTimerInterval
        {
            get;
            set;
        }

        private string ServerAddress
        {
            get;
            set;
        }

        #endregion Properties

        #region Non-virtual methods

        private void DrawControls()
        {
            lblTitle.MinWidth = 220;
            AddChild(lblTitle, 13, 13);
            lblNoEventsMessages.MinWidth = 220;
            AddChild(lblNoEventsMessages, 13, 52);
            AddChild(lblLine, 0, 20);

            drEvents.MinWidth = 478;
            drEvents.MinHeight = 378;
            AddChild(drEvents, 1, 40);

            btnSyncNow.MinWidth = 75;
            btnSyncNow.MinHeight = 23;
            btnSyncNow.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnSyncNow, 5, 427);

            btnEventManagment.MinWidth = 105;
            btnEventManagment.MinHeight = 23;
            btnEventManagment.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnEventManagment, 85, 427);

            btnSettings.MinWidth = 115;
            btnSettings.MinHeight = 23;
            btnSettings.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnSettings, 200, 427);

            btnLogOut.MinWidth = 75;
            btnLogOut.MinHeight = 23;
            btnLogOut.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnLogOut, 320, 427);

            btnQuit.MinWidth = 75;
            btnQuit.MinHeight = 23;
            btnQuit.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnQuit, 400, 427);
        }

        private void PopulateEventsList()
        {
            if (CalCollection[0] != null && CalCollection[0].Events.Count > 0)
            {
                lblNoEventsMessages.Visible = false;
                drEvents.Visible = true;
                BindEventRepeater();
            }
            else
            {
                lblNoEventsMessages.Visible = true;
                drEvents.Visible = false;
            }
        }

        private DataTable GetDataTableFromCollection(out bool isAllDayEvent)
        {
            DataTable dtEvents = null;

            isAllDayEvent = false;

            var eventsList = CalCollection[0].Events;

            if (eventsList != null && eventsList.Count > 0)
            {
                String s = String.Empty;
                DateTime d = new DateTime();
                dtEvents = new DataTable();
                dtEvents.Columns.Add("EventSummary", s.GetType());
                dtEvents.Columns.Add("EventDate", s.GetType());
                dtEvents.Columns.Add("EventStartTime", s.GetType());
                dtEvents.Columns.Add("EventEndTime", s.GetType());
                dtEvents.Columns.Add("EventLocation", s.GetType());
                dtEvents.Columns.Add("EventDescription", s.GetType());
                dtEvents.Columns.Add("EventStartDateDateFormat", d.Date.GetType());
                dtEvents.Columns.Add("EventStartTimeTimeFormat", d.TimeOfDay.GetType());

                foreach (var item in eventsList)
                {
                    string summary = !String.IsNullOrEmpty(item.Summary) ? item.Summary : String.Empty;
                    int durationDays = item.Duration.Days * (-1);
                    int durationHours = item.Duration.Hours * (-1);
                    int durationMinutes = item.Duration.Minutes * (-1);
                    int durationSeconds = item.Duration.Seconds * (-1);
                    var startDateDateFormat = item.End.AddDays(durationDays).AddHours(durationHours).AddMinutes(durationMinutes).AddSeconds(durationSeconds).Date;
                    string startDate = startDateDateFormat.ToShortDateString();
                    var startTimeTimeFormat = item.End.AddDays(durationDays).AddHours(durationHours).AddMinutes(durationMinutes).AddSeconds(durationSeconds).TimeOfDay;
                    string startTime = startTimeTimeFormat.ToString();
                    var endDateDateFormat = item.End.Date;
                    string endTime = item.End.TimeOfDay.ToString();
                    string locaton = !String.IsNullOrEmpty(item.Location) ? item.Location : String.Empty;
                    string description = !String.IsNullOrEmpty(item.Description) ? item.Description : String.Empty;
                    isAllDayEvent = item.IsAllDay;

                    if (startDateDateFormat == endDateDateFormat)
                    {
                        dtEvents.Rows.Add(summary, startDate, startTime, endTime, locaton, description, startDateDateFormat, startTimeTimeFormat);
                    }
                    else
                    {
                        int i = 0;

                        if (isAllDayEvent)
                        {
                            while (startDateDateFormat.AddDays(i) < endDateDateFormat)
                            {
                                DateTime startDateTime = Convert.ToDateTime(startDateDateFormat.AddDays(i).Date.ToShortDateString() + " 00:00:01");
                                dtEvents.Rows.Add(summary, startDateTime.ToShortDateString(), "00:00:01", endTime, locaton, description, startDateTime.Date, startDateTime.TimeOfDay);
                                i++;
                            }
                        }
                        else
                        {
                            while (startDateDateFormat.AddDays(i) <= endDateDateFormat)
                            {
                                if (i == 0)
                                {
                                    dtEvents.Rows.Add(summary, startDate, startTime, "23:59:59", locaton, description, startDateDateFormat, startTimeTimeFormat);
                                }
                                else if (i > 0 && startDateDateFormat.AddDays(i) == endDateDateFormat)
                                {
                                    DateTime startDateTime = Convert.ToDateTime(startDateDateFormat.AddDays(i).Date.ToShortDateString() + " 00:00:01");
                                    dtEvents.Rows.Add(summary, startDateTime.ToShortDateString(), "00:00:01", endTime, locaton, description, startDateTime.Date, startDateTime.TimeOfDay);
                                }
                                else if (i > 0 && startDateDateFormat.AddDays(i) < endDateDateFormat)
                                {
                                    DateTime startDateTime = Convert.ToDateTime(startDateDateFormat.AddDays(i).Date.ToShortDateString() + " 00:00:01");
                                    dtEvents.Rows.Add(summary, startDateTime.ToShortDateString(), "00:00:01", "23:59:59", locaton, description, startDateTime.Date, startDateTime.TimeOfDay);
                                }
                                i++;
                            }
                        }
                    }
                }

                dtEvents.DefaultView.Sort = "EventStartDateDateFormat" + " " + "ASC" + ", " + "EventStartTimeTimeFormat" + " " + "ASC";

            }

            return dtEvents;
        }

        private void BindEventRepeater()
        {
            bool isAllDay = false;

            DataTable dtEvents = GetDataTableFromCollection(out isAllDay);

            foreach (DataRow drEvent in dtEvents.Rows)
            {
                EventListItem eventListItem = new EventListItem(drEvent, isAllDay);
                eventListItem.MinHeight = 300;
                drEvents.PackStart(eventListItem, true, true);
            }
        }

        private void HideForm()
        {
            IsHiden = true;
            this.ParentWindow.Hide();
        }

        private void CloseForm()
        {
            IsHiden = false;
            IsClosed = true;
            this.ParentWindow.Dispose();
        }

        private void SetNotificationTimer()
        {
            Timer timer = new Timer();
            int pingTimeInterval;

            pingTimeInterval = Convert.ToInt32(ConfigurationManager.AppSettings["notificationPingTimeInterval"].ToString());
            timer.Elapsed += delegate
            {
                CheckEventStartTime();
            };

            timer.Interval = pingTimeInterval;
            timer.Start();
            CheckEventStartTime();
        }

        private void SetSyncTimer(bool isAutomaticSyncChecked, int? syncTimerInterval)
        {
            if (isAutomaticSyncChecked)
            {
                Timer timer = new Timer();
                int pingTimeInterval = Convert.ToInt32(syncTimerInterval) * 60000;

                timer.Elapsed += delegate
                {
                    AutomaticSyncEvents();
                };

                timer.Interval = pingTimeInterval;
                timer.Start();
                AutomaticSyncEvents();
            }
        }

        private IICalendarCollection GetCalendarEventsData()
        {
            owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

            return connector.ownCloudCalendar_GetEvents(ServerUrl, Username, Password);
        }

        #endregion Non-virtual methods

        #region Events

        //private void EventsList_FormClosing(object sender, CloseRequestedEventArgs e)
        //{
        //    try
        //    {
        //        if (IsClosed)
        //        {
        //            e.Cancel = false;
        //        }
        //        else
        //        {
        //            e.Cancel = true;
        //            HideForm();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        //private void niCalendarClient_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CenterToScreen();
        //        Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        //private void niCalendarClient_MouseClick(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Button == MouseButtons.Right)
        //        {
        //            cmsRightClick.Show(this, Control.MousePosition);
        //        }
        //        else if (e.Button == MouseButtons.Left)
        //        {
        //            CenterToScreen();
        //            Show();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        private void btnEventManagment_Click()
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("http://se.csk.kg.ac.rs/owncloud/index.php/apps/calendar");
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void CheckEventStartTime()
        {
            try
            {
                if (CalCollection[0].Events.Count > 0)
                {
                    foreach (var item in CalCollection[0].Events)
                    {
                        int notificationMessageTimerInMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["notificationMessageTimerInMinutes"].ToString());

                        int durationDays = item.Duration.Days * (-1);
                        int durationHours = item.Duration.Hours * (-1);
                        int durationMinutes = item.Duration.Minutes * (-1);
                        int durationSeconds = item.Duration.Seconds * (-1);
                        var startDateDateFormat = item.End.AddDays(durationDays).AddHours(durationHours).AddMinutes(durationMinutes).AddSeconds(durationSeconds);
                        var currentDateTime = DateTime.Now;

                        if (currentDateTime.Date == startDateDateFormat.Date
                                && currentDateTime.AddMinutes(notificationMessageTimerInMinutes).Hour == startDateDateFormat.TimeOfDay.Hours
                                && currentDateTime.AddMinutes(notificationMessageTimerInMinutes).Minute == startDateDateFormat.TimeOfDay.Minutes)
                        {
                            string message = String.Format("Event {0} will start in 5 minutes", item.Summary.ToString());

                            MessageDialog.ShowMessage(this.ParentWindow, message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void AutomaticSyncEvents()
        {
            try
            {
                CalCollection = GetCalendarEventsData();
                PopulateEventsList();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //private void showEventsListToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Show();
        //        CenterToScreen();
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        //private void goToSyncConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CloseForm();
        //        SyncCalendar syncCalendar = new SyncCalendar(CalendarName, IsAutomaticSyncChecked, SyncTimerInterval, ServerAddress, Username, Password);
        //        syncCalendar.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        //private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CloseForm();
        //        LogIn logIn = new LogIn();
        //        logIn.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        //private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FormCollection fc = Application.OpenForms;

        //        foreach (Form frm in fc)
        //        {
        //            frm.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        private void btnSyncNow_Click()
        {
            try
            {
                CalCollection = GetCalendarEventsData();
                PopulateEventsList();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnQuit_Click()
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnLogOut_Click()
        {
            try
            {
                this.ParentWindow.Hide();

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
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnSettings_Click()
        {
            try
            {
                this.ParentWindow.Hide();

                var syncCalendarWindow = new Window()
                {
                    Title = "ownCloud Calendar Client",
                    Width = 500,
                    Height = 250
                };
                syncCalendarWindow.Resizable = false;
                SyncCalendar syncCalendar = new SyncCalendar(ServerAddress, Username, Password);
                syncCalendarWindow.Content = syncCalendar;
                syncCalendarWindow.Show();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Events
    }
}
