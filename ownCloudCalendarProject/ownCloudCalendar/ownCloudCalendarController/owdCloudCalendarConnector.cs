using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;
using ownCloudCalendarShared.Exceptions;
using ownCloudCalendarShared.Logging;

namespace ownCloudCalendarController
{
    public class owdCloudCalendarConnector
    {
        #region Non-virtual methods

        public bool CheckCredentials(string url, string username, string password)
        {
            var web = new WebClient();
            web.Credentials = new System.Net.NetworkCredential(username, password);

            try
            {
                web.DownloadData(url);
                return true;
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return false;
                }

                Logging.LogError(ex, LoggingCategories.Controller);
                throw new LoggedException(ex);
            }
        }

        public IICalendarCollection ownCloudCalendar_GetEvents(Uri server, string username, string password)
        {
            IICalendarCollection iCalCollection = null;
            try
            {
                iCalCollection = iCalendar.LoadFromUri(server, username, password);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, LoggingCategories.Controller);
                throw new LoggedException(ex);
            }
            return iCalCollection;
        }

        #endregion Non-virtual methods
    }
}