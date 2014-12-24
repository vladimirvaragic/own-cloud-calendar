using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDay.iCal;
using ownCloudCalendarController;
using ownCloudCalendarGUI.Common;

namespace ownCloudCalendarGUI
{
    public partial class LogIn : BaseForm
    {
        #region Constants

        private const string cLogInUrlExtension = "/remote.php/webdav";

        #endregion Constants

        #region Constructors

        public LogIn()
        {
            try
            {
                InitializeComponent();
                CenterToScreen();
#if DEBUG
                txtServerAddress.Text = "http://se.csk.kg.ac.rs/owncloud";//"http://se.csk.kg.ac.rs/owncloud/remote.php/caldav/calendars/vladimir.varagic/personal?export";
                txtUsername.Text = "vladimir.varagic";
                txtPassword.Text = "vlada14";
#else
            txtServerAddress.Text = String.Empty;
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;            
#endif
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion Constructors

        #region Non-virtual methods

        private bool ValidateControls()
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(txtServerAddress.Text))
            {
                epServerAddress.SetError(txtServerAddress, "Required field");
                isValid = false;
            }
            else
            {
                epServerAddress.Clear();
            }

            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                epUsername.SetError(txtUsername, "Required field");
                isValid = false;
            }
            else
            {
                epUsername.Clear();
            }

            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                epPassword.SetError(txtPassword, "Required field");
                isValid = false;
            }
            else
            {
                epPassword.Clear();
            }

            return isValid;
        }

        #endregion Non-virtual methods

        #region Events

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = ValidateControls();

                if (!isValid)
                    return;

                owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

                string url = txtServerAddress.Text.Trim() + cLogInUrlExtension;
                if (!connector.CheckCredentials(url, txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                {
                    ShowMessage("There is a problem with connection to server. Please, check server address, username and password and try again.", "ownCloud Login Unavailable");
                }
                else
                {
                    Hide();
                    SyncCalendar syncCalendar = new SyncCalendar(txtServerAddress.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    syncCalendar.ShowDialog();
                    if (syncCalendar.IsHiden)
                    {
                        Hide();
                    }
                    else
                    {
                        Close();
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