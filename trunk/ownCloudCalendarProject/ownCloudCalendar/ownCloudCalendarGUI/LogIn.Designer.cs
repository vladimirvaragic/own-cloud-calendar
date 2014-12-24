namespace ownCloudCalendarGUI
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.epServerAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.epUsername = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epServerAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(211, 24);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Connect to ownCloud";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(12, 60);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(78, 13);
            this.lblServerAddress.TabIndex = 6;
            this.lblServerAddress.Text = "Server address";
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(96, 57);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(278, 20);
            this.txtServerAddress.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(14, 90);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(96, 87);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(278, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(96, 117);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(278, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(14, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Location = new System.Drawing.Point(382, 170);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(90, 30);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // epServerAddress
            // 
            this.epServerAddress.ContainerControl = this;
            // 
            // epUsername
            // 
            this.epUsername.ContainerControl = this;
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // LogIn
            // 
            this.AcceptButton = this.btnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.lblServerAddress);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 250);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "LogIn";
            this.Text = "ownCloud Calendar Client";
            ((System.ComponentModel.ISupportInitialize)(this.epServerAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.ErrorProvider epServerAddress;
        private System.Windows.Forms.ErrorProvider epUsername;
        private System.Windows.Forms.ErrorProvider epPassword;
    }
}