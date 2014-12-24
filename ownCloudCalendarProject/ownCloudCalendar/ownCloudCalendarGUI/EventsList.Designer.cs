namespace ownCloudCalendarGUI
{
    partial class EventsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsList));
            this.niCalendarClient = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showEventsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToSyncConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEventMenagment = new System.Windows.Forms.Button();
            this.drEvents = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.lblEventLocation = new System.Windows.Forms.Label();
            this.lblEventStartTime = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.lblMiddleLine = new System.Windows.Forms.Label();
            this.lblEventSummary = new System.Windows.Forms.Label();
            this.lblEventEndTime = new System.Windows.Forms.Label();
            this.lblAllDayEvent = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNoEventsMessages = new System.Windows.Forms.Label();
            this.btnSyncNow = new System.Windows.Forms.Button();
            this.cmsRightClick.SuspendLayout();
            this.drEvents.ItemTemplate.SuspendLayout();
            this.drEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // niCalendarClient
            // 
            this.niCalendarClient.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.niCalendarClient.Icon = ((System.Drawing.Icon)(resources.GetObject("niCalendarClient.Icon")));
            this.niCalendarClient.Text = "ownCloud Calendar Client";
            this.niCalendarClient.Visible = true;
            this.niCalendarClient.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niCalendarClient_MouseClick);
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showEventsListToolStripMenuItem,
            this.goToSyncConfigurationToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(206, 92);
            // 
            // showEventsListToolStripMenuItem
            // 
            this.showEventsListToolStripMenuItem.Name = "showEventsListToolStripMenuItem";
            this.showEventsListToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.showEventsListToolStripMenuItem.Text = "Show events list";
            this.showEventsListToolStripMenuItem.Click += new System.EventHandler(this.showEventsListToolStripMenuItem_Click);
            // 
            // goToSyncConfigurationToolStripMenuItem
            // 
            this.goToSyncConfigurationToolStripMenuItem.Name = "goToSyncConfigurationToolStripMenuItem";
            this.goToSyncConfigurationToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.goToSyncConfigurationToolStripMenuItem.Text = "Go to sync configuration";
            this.goToSyncConfigurationToolStripMenuItem.Click += new System.EventHandler(this.goToSyncConfigurationToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // btnEventMenagment
            // 
            this.btnEventMenagment.Location = new System.Drawing.Point(372, 427);
            this.btnEventMenagment.Name = "btnEventMenagment";
            this.btnEventMenagment.Size = new System.Drawing.Size(107, 23);
            this.btnEventMenagment.TabIndex = 105;
            this.btnEventMenagment.Text = "Menage events";
            this.btnEventMenagment.UseVisualStyleBackColor = true;
            this.btnEventMenagment.Click += new System.EventHandler(this.btnEventMenagment_Click);
            // 
            // drEvents
            // 
            this.drEvents.AllowUserToAddItems = false;
            this.drEvents.AllowUserToDeleteItems = false;
            this.drEvents.ItemHeaderVisible = false;
            // 
            // drEvents.ItemTemplate
            // 
            this.drEvents.ItemTemplate.Controls.Add(this.lblDescription);
            this.drEvents.ItemTemplate.Controls.Add(this.lblLocation);
            this.drEvents.ItemTemplate.Controls.Add(this.lblEventDescription);
            this.drEvents.ItemTemplate.Controls.Add(this.lblEventLocation);
            this.drEvents.ItemTemplate.Controls.Add(this.lblEventStartTime);
            this.drEvents.ItemTemplate.Controls.Add(this.lblEventDate);
            this.drEvents.ItemTemplate.Controls.Add(this.lblMiddleLine);
            this.drEvents.ItemTemplate.Controls.Add(this.lblEventSummary);
            this.drEvents.ItemTemplate.Controls.Add(this.lblEventEndTime);
            this.drEvents.ItemTemplate.Controls.Add(this.lblAllDayEvent);
            this.drEvents.ItemTemplate.Size = new System.Drawing.Size(470, 114);
            this.drEvents.Location = new System.Drawing.Point(1, 40);
            this.drEvents.Name = "drEvents";
            this.drEvents.Size = new System.Drawing.Size(478, 378);
            this.drEvents.TabIndex = 103;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(7, 87);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 107;
            this.lblDescription.Text = "Description:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(7, 61);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 106;
            this.lblLocation.Text = "Location:";
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.AutoSize = true;
            this.lblEventDescription.Location = new System.Drawing.Point(76, 87);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(89, 13);
            this.lblEventDescription.TabIndex = 12;
            this.lblEventDescription.Text = "Event description";
            // 
            // lblEventLocation
            // 
            this.lblEventLocation.AutoSize = true;
            this.lblEventLocation.Location = new System.Drawing.Point(76, 61);
            this.lblEventLocation.Name = "lblEventLocation";
            this.lblEventLocation.Size = new System.Drawing.Size(75, 13);
            this.lblEventLocation.TabIndex = 11;
            this.lblEventLocation.Text = "Event location";
            // 
            // lblEventStartTime
            // 
            this.lblEventStartTime.AutoSize = true;
            this.lblEventStartTime.Location = new System.Drawing.Point(7, 37);
            this.lblEventStartTime.Name = "lblEventStartTime";
            this.lblEventStartTime.Size = new System.Drawing.Size(49, 13);
            this.lblEventStartTime.TabIndex = 8;
            this.lblEventStartTime.Text = "15:30:00";
            this.lblEventStartTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDate.Location = new System.Drawing.Point(361, 0);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEventDate.Size = new System.Drawing.Size(86, 17);
            this.lblEventDate.TabIndex = 7;
            this.lblEventDate.Text = "Event date";
            // 
            // lblMiddleLine
            // 
            this.lblMiddleLine.AutoSize = true;
            this.lblMiddleLine.Location = new System.Drawing.Point(62, 37);
            this.lblMiddleLine.Name = "lblMiddleLine";
            this.lblMiddleLine.Size = new System.Drawing.Size(10, 13);
            this.lblMiddleLine.TabIndex = 10;
            this.lblMiddleLine.Text = "-";
            // 
            // lblEventSummary
            // 
            this.lblEventSummary.AutoSize = true;
            this.lblEventSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSummary.Location = new System.Drawing.Point(6, 10);
            this.lblEventSummary.Name = "lblEventSummary";
            this.lblEventSummary.Size = new System.Drawing.Size(131, 20);
            this.lblEventSummary.TabIndex = 6;
            this.lblEventSummary.Text = "Event summary";
            // 
            // lblEventEndTime
            // 
            this.lblEventEndTime.AutoSize = true;
            this.lblEventEndTime.Location = new System.Drawing.Point(78, 37);
            this.lblEventEndTime.Name = "lblEventEndTime";
            this.lblEventEndTime.Size = new System.Drawing.Size(49, 13);
            this.lblEventEndTime.TabIndex = 9;
            this.lblEventEndTime.Text = "15:30:00";
            this.lblEventEndTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblAllDayEvent
            // 
            this.lblAllDayEvent.AutoSize = true;
            this.lblAllDayEvent.Location = new System.Drawing.Point(10, 37);
            this.lblAllDayEvent.Name = "lblAllDayEvent";
            this.lblAllDayEvent.Size = new System.Drawing.Size(68, 13);
            this.lblAllDayEvent.TabIndex = 105;
            this.lblAllDayEvent.Text = "All day event";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(131, 24);
            this.lblTitle.TabIndex = 102;
            this.lblTitle.Text = "List of events";
            // 
            // lblNoEventsMessages
            // 
            this.lblNoEventsMessages.AutoSize = true;
            this.lblNoEventsMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoEventsMessages.Location = new System.Drawing.Point(13, 52);
            this.lblNoEventsMessages.Name = "lblNoEventsMessages";
            this.lblNoEventsMessages.Size = new System.Drawing.Size(331, 20);
            this.lblNoEventsMessages.TabIndex = 104;
            this.lblNoEventsMessages.Text = "There is no upcoming events in calendar";
            // 
            // btnSyncNow
            // 
            this.btnSyncNow.Location = new System.Drawing.Point(5, 427);
            this.btnSyncNow.Name = "btnSyncNow";
            this.btnSyncNow.Size = new System.Drawing.Size(75, 23);
            this.btnSyncNow.TabIndex = 106;
            this.btnSyncNow.Text = "Sync now";
            this.btnSyncNow.UseVisualStyleBackColor = true;
            this.btnSyncNow.Click += new System.EventHandler(this.btnSyncNow_Click);
            // 
            // EventsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.btnSyncNow);
            this.Controls.Add(this.btnEventMenagment);
            this.Controls.Add(this.drEvents);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNoEventsMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "EventsList";
            this.ShowInTaskbar = false;
            this.Text = "ownCloud Calendar Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventsList_FormClosing);
            this.cmsRightClick.ResumeLayout(false);
            this.drEvents.ItemTemplate.ResumeLayout(false);
            this.drEvents.ItemTemplate.PerformLayout();
            this.drEvents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater drEvents;
        private System.Windows.Forms.Label lblNoEventsMessages;
        private System.Windows.Forms.Label lblEventLocation;
        private System.Windows.Forms.Label lblEventStartTime;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.Label lblMiddleLine;
        private System.Windows.Forms.Label lblEventSummary;
        private System.Windows.Forms.Label lblEventEndTime;
        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.Label lblAllDayEvent;
        private System.Windows.Forms.Button btnEventMenagment;
        private System.Windows.Forms.NotifyIcon niCalendarClient;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEventsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ToolStripMenuItem goToSyncConfigurationToolStripMenuItem;
        private System.Windows.Forms.Button btnSyncNow;
    }
}