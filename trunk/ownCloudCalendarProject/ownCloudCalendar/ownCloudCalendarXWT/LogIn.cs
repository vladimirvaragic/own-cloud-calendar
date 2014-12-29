using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ownCloudCalendarController;
using ownCloudCalendarXWT.Common;
using Xwt;
using Xwt.Drawing;

namespace ownCloudCalendarXWT
{
    public class LogIn : BaseForm
    {
        #region Constants

        private const string cLogInUrlExtension = "/remote.php/webdav";

        #endregion Constants

        #region Private fields

        Label lblTitle = new Label("Connect to ownCloud")
        {
            Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(14)
        };
        Label lblServerAddress = new Label("Server address");
        TextEntry txtServerAddress = new TextEntry();
        Label lblUserName = new Label("Username");
        TextEntry txtUsername = new TextEntry();
        Label lblPassword = new Label("Password");
        PasswordEntry txtPassword = new PasswordEntry();
        Button btnLogIn = new Button("Log in");

        #endregion Private fields

        #region Constructors

        public LogIn()
        {
            try
            {
                DrawControls();

#if DEBUG
                txtServerAddress.Text = "http://se.csk.kg.ac.rs/owncloud";
                txtUsername.Text = "vladimir.varagic";
                txtPassword.Password = "vlada14";
#else
            txtServerAddress.Text = String.Empty;
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;            
#endif

                btnLogIn.Clicked += delegate
                {
                    btnLogIn_Click();
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
            AddChild(lblServerAddress, 13, 60);
            txtServerAddress.WidthRequest = 278;
            AddChild(txtServerAddress, 96, 57);

            AddChild(lblUserName, 13, 90);
            txtUsername.WidthRequest = 278;
            AddChild(txtUsername, 96, 87);

            AddChild(lblPassword, 13, 120);
            txtPassword.WidthRequest = 278;
            AddChild(txtPassword, 96, 117);

            btnLogIn.MinWidth = 90;
            btnLogIn.MinHeight = 30;
            btnLogIn.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
            AddChild(btnLogIn, 382, 170);
        }

        private string ValidateControls()
        {
            StringBuilder validationMessage = new StringBuilder();
            string msg = String.Empty;

            if (String.IsNullOrEmpty(txtServerAddress.Text))
            {
                msg = "Server address is required field";
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

            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                msg = "Username is required field";
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

            if (String.IsNullOrEmpty(txtPassword.Password))
            {
                msg = "Password is required field";
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

            return validationMessage.ToString();
        }

        #endregion Non-virtual methods

        #region Events

        private void btnLogIn_Click()
        {
            try
            {
                string validationMessage = ValidateControls();

                if (!String.IsNullOrEmpty(validationMessage))
                {
                    MessageDialog.ShowError(validationMessage);
                    return;
                }

                owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

                string url = txtServerAddress.Text.Trim() + cLogInUrlExtension;
                if (!connector.CheckCredentials(url, txtUsername.Text.Trim(), txtPassword.Password.Trim()))
                {
                    MessageDialog.ShowMessage("There is a problem with connection to server. Please, check server address, username and password and try again.");
                }
                else
                {
                    this.ParentWindow.Hide();

                    var syncCalendarWindow = new Window()
                    {
                        Title = "ownCloud Calendar Client",
                        Width = 500,
                        Height = 250
                    };
                    syncCalendarWindow.Resizable = false;
                    SyncCalendar syncCalendar = new SyncCalendar(txtServerAddress.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Password.Trim());
                    syncCalendarWindow.Content = syncCalendar;
                    syncCalendarWindow.Show();

                    if (syncCalendar.IsHiden)
                    {
                        this.ParentWindow.Hide();
                    }
                    else
                    {
                        this.ParentWindow.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Events
    }
}