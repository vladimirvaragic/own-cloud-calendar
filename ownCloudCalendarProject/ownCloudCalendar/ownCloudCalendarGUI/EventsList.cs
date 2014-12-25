using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
    public partial class EventsList : BaseForm
    {
        #region Constructors

        public EventsList()
        {
            try
            {
                InitializeComponent();
                CenterToScreen();
                IsClosed = false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public EventsList(IICalendarCollection iCalCollection, bool isAutomaticSyncChecked, int? syncTimerInterval, string calendarName, Uri url, string username, string password, string serverAddress)
        {
            try
            {
                InitializeComponent();
                CenterToScreen();
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
            BindingSource bsEvents = new BindingSource();
            bool isAllDay = false;

            bsEvents.DataSource = GetDataTableFromCollection(out isAllDay);
            if (lblEventSummary.DataBindings.Count == 0)
            {
                lblEventSummary.DataBindings.Add("Text", bsEvents, "EventSummary");
                lblEventDate.DataBindings.Add("Text", bsEvents, "EventDate");
                lblEventStartTime.DataBindings.Add("Text", bsEvents, "EventStartTime");
                lblEventEndTime.DataBindings.Add("Text", bsEvents, "EventEndTime");
                lblEventLocation.DataBindings.Add("Text", bsEvents, "EventLocation");
                lblEventDescription.DataBindings.Add("Text", bsEvents, "EventDescription");
            }
            drEvents.DataSource = bsEvents;

            if (isAllDay)
            {
                lblAllDayEvent.Visible = true;
                lblEventStartTime.Visible = false;
                lblMiddleLine.Visible = false;
                lblEventEndTime.Visible = false;
            }
            else
            {
                lblAllDayEvent.Visible = false;
                lblEventStartTime.Visible = true;
                lblMiddleLine.Visible = true;
                lblEventEndTime.Visible = true;
            }
        }

        private void HideForm()
        {
            IsHiden = true;
            Hide();
        }

        private void CloseForm()
        {
            IsHiden = false;
            IsClosed = true;
            Close();
        }

        private void SetNotificationTimer()
        {
            Timer timer = new Timer();
            int pingTimeInterval;

            pingTimeInterval = Convert.ToInt32(ConfigurationManager.AppSettings["notificationPingTimeInterval"].ToString());
            timer.Tick += new EventHandler(CheckEventStartTime);

            timer.Interval = pingTimeInterval;
            timer.Start();
            CheckEventStartTime(this, null);
        }

        private void SetSyncTimer(bool isAutomaticSyncChecked, int? syncTimerInterval)
        {
            if (isAutomaticSyncChecked)
            {
                Timer timer = new Timer();
                int pingTimeInterval = Convert.ToInt32(syncTimerInterval) * 60000;

                timer.Tick += new EventHandler(AutomaticSyncEvents);

                timer.Interval = pingTimeInterval;
                timer.Start();
                AutomaticSyncEvents(this, null);
            }
        }

        private IICalendarCollection GetCalendarEventsData()
        {
            owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

            return connector.ownCloudCalendar_GetEvents(ServerUrl, Username, Password);
        }

        #endregion Non-virtual methods

        #region Events

        private void EventsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IsClosed)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    HideForm();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void niCalendarClient_Click(object sender, EventArgs e)
        {
            try
            {
                CenterToScreen();
                Show();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void niCalendarClient_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    cmsRightClick.Show(this, Control.MousePosition);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    CenterToScreen();
                    Show();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnEventMenagment_Click(object sender, EventArgs e)
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

        private void CheckEventStartTime(object sender, EventArgs e)
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

                            MessageBox.Show(message, "Event notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void AutomaticSyncEvents(object sender, EventArgs e)
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

        private void showEventsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Show();
                CenterToScreen();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void goToSyncConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseForm();
                SyncCalendar syncCalendar = new SyncCalendar(CalendarName, IsAutomaticSyncChecked, SyncTimerInterval, ServerAddress, Username, Password);
                syncCalendar.Show();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseForm();
                LogIn logIn = new LogIn();
                logIn.Show();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    frm.Close();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnSyncNow_Click(object sender, EventArgs e)
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

        #endregion Events

    }
}