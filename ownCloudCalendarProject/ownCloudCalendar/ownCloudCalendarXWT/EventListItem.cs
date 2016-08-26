using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ownCloudCalendarXWT.Common;
using Xwt;
using Xwt.Drawing;

namespace ownCloudCalendarXWT
{
    public class EventListItem : BaseForm
    {
        #region Private fields

        Label lblEventDate = new Label("Event date") 
        {
            Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(10)
        };
        Label lblEventSummary = new Label("Event summary")
        {
            Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(12)
        };
        Label lblEventStartTime = new Label("15:30:00");
        Label lblMiddleLine = new Label("-");
        Label lblEventEndTime = new Label("15:30:00");
        Label lblAllDayEvent = new Label("All day event");
        Label lblLocation = new Label("Location:");
        Label lblEventLocation = new Label("Event location");
        Label lblDescription = new Label("Description:");
        Label lblEventDescription = new Label("Event description");
        Label lblLine = new Label("_________________________________________________________________________________________________");

        #endregion Private fields

        #region Non-virtual methods

        private void DrawControls()
        {
            lblEventDate.MinWidth = 100;
            AddChild(lblEventDate, 361, 0);
            lblEventSummary.MinWidth = 500;
            AddChild(lblEventSummary, 7, 10);
            AddChild(lblEventStartTime, 7, 37);
            AddChild(lblMiddleLine, 62, 37);
            AddChild(lblEventEndTime, 78, 37);
            AddChild(lblAllDayEvent, 7, 37);
            AddChild(lblLocation, 7, 61);
            AddChild(lblEventLocation, 76, 61);
            AddChild(lblDescription, 7, 87);
            lblEventDescription.MinWidth = 250;
            AddChild(lblEventDescription, 76, 87);
            AddChild(lblLine, 0, 150);
        }

        private void PopulateControls(DataRow eventItem, bool isAllDay)
        {
            lblEventDate.Text = eventItem["EventDate"].ToString();
            lblEventSummary.Text = eventItem["EventSummary"].ToString();
            lblEventStartTime.Text = eventItem["EventStartTime"].ToString();
            lblEventEndTime.Text = eventItem["EventEndTime"].ToString();
            lblEventLocation.Text = eventItem["EventLocation"].ToString();
            lblEventDescription.Text = eventItem["EventDescription"].ToString();

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

        #endregion Non-virtual methods

        #region Constructors

        public EventListItem(DataRow eventItem, bool isAllDay)
        {
            try
            {
                DrawControls();
                PopulateControls(eventItem, isAllDay);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Constructors
    }
}
