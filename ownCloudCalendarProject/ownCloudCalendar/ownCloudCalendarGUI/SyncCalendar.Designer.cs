namespace ownCloudCalendarGUI
{
    partial class SyncCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncCalendar));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCalendarName = new System.Windows.Forms.Label();
            this.txtCalendarName = new System.Windows.Forms.TextBox();
            this.btnSyncCalendar = new System.Windows.Forms.Button();
            this.cbAutomaticSync = new System.Windows.Forms.CheckBox();
            this.lblAutomaticSync = new System.Windows.Forms.Label();
            this.lblTimerInterval = new System.Windows.Forms.Label();
            this.txtTimerInterval = new System.Windows.Forms.TextBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.epCalendarName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTimerInterval = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epCalendarName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTimerInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(143, 24);
            this.lblTitle.TabIndex = 105;
            this.lblTitle.Text = "Sync calendar";
            // 
            // lblCalendarName
            // 
            this.lblCalendarName.AutoSize = true;
            this.lblCalendarName.Location = new System.Drawing.Point(14, 56);
            this.lblCalendarName.Name = "lblCalendarName";
            this.lblCalendarName.Size = new System.Drawing.Size(78, 13);
            this.lblCalendarName.TabIndex = 106;
            this.lblCalendarName.Text = "Calendar name";
            // 
            // txtCalendarName
            // 
            this.txtCalendarName.Location = new System.Drawing.Point(105, 53);
            this.txtCalendarName.Name = "txtCalendarName";
            this.txtCalendarName.Size = new System.Drawing.Size(266, 20);
            this.txtCalendarName.TabIndex = 101;
            // 
            // btnSyncCalendar
            // 
            this.btnSyncCalendar.Location = new System.Drawing.Point(370, 177);
            this.btnSyncCalendar.Name = "btnSyncCalendar";
            this.btnSyncCalendar.Size = new System.Drawing.Size(102, 23);
            this.btnSyncCalendar.TabIndex = 104;
            this.btnSyncCalendar.Text = "Sync now";
            this.btnSyncCalendar.UseVisualStyleBackColor = true;
            this.btnSyncCalendar.Click += new System.EventHandler(this.btnSyncCalendar_Click);
            // 
            // cbAutomaticSync
            // 
            this.cbAutomaticSync.AutoSize = true;
            this.cbAutomaticSync.Location = new System.Drawing.Point(105, 88);
            this.cbAutomaticSync.Name = "cbAutomaticSync";
            this.cbAutomaticSync.Size = new System.Drawing.Size(15, 14);
            this.cbAutomaticSync.TabIndex = 102;
            this.cbAutomaticSync.UseVisualStyleBackColor = true;
            this.cbAutomaticSync.Click += new System.EventHandler(this.cbAutomaticSync_Click);
            // 
            // lblAutomaticSync
            // 
            this.lblAutomaticSync.AutoSize = true;
            this.lblAutomaticSync.Location = new System.Drawing.Point(14, 88);
            this.lblAutomaticSync.Name = "lblAutomaticSync";
            this.lblAutomaticSync.Size = new System.Drawing.Size(79, 13);
            this.lblAutomaticSync.TabIndex = 107;
            this.lblAutomaticSync.Text = "Automatic sync";
            // 
            // lblTimerInterval
            // 
            this.lblTimerInterval.AutoSize = true;
            this.lblTimerInterval.Location = new System.Drawing.Point(14, 118);
            this.lblTimerInterval.Name = "lblTimerInterval";
            this.lblTimerInterval.Size = new System.Drawing.Size(85, 13);
            this.lblTimerInterval.TabIndex = 108;
            this.lblTimerInterval.Text = "Set timer interval";
            // 
            // txtTimerInterval
            // 
            this.txtTimerInterval.Enabled = false;
            this.txtTimerInterval.Location = new System.Drawing.Point(105, 115);
            this.txtTimerInterval.Name = "txtTimerInterval";
            this.txtTimerInterval.Size = new System.Drawing.Size(51, 20);
            this.txtTimerInterval.TabIndex = 103;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(162, 118);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(49, 13);
            this.lblMinutes.TabIndex = 108;
            this.lblMinutes.Text = "minute(s)";
            // 
            // epCalendarName
            // 
            this.epCalendarName.ContainerControl = this;
            // 
            // epTimerInterval
            // 
            this.epTimerInterval.ContainerControl = this;
            // 
            // SyncCalendar
            // 
            this.AcceptButton = this.btnSyncCalendar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.txtTimerInterval);
            this.Controls.Add(this.lblTimerInterval);
            this.Controls.Add(this.lblAutomaticSync);
            this.Controls.Add(this.cbAutomaticSync);
            this.Controls.Add(this.btnSyncCalendar);
            this.Controls.Add(this.txtCalendarName);
            this.Controls.Add(this.lblCalendarName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 250);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "SyncCalendar";
            this.Text = "ownCloud Calendar Client";
            ((System.ComponentModel.ISupportInitialize)(this.epCalendarName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTimerInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCalendarName;
        private System.Windows.Forms.TextBox txtCalendarName;
        private System.Windows.Forms.Button btnSyncCalendar;
        private System.Windows.Forms.CheckBox cbAutomaticSync;
        private System.Windows.Forms.Label lblAutomaticSync;
        private System.Windows.Forms.Label lblTimerInterval;
        private System.Windows.Forms.TextBox txtTimerInterval;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.ErrorProvider epCalendarName;
        private System.Windows.Forms.ErrorProvider epTimerInterval;
    }
}