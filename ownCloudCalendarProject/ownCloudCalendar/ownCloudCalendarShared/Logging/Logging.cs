using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ownCloudCalendarShared.Logging
{
    public class Logging
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Logging class.
        /// </summary>
        public Logging()
        {
        }

        #endregion Constructors

        #region Non-virtual methods

        /// <summary>
        /// Logs error
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="loggingCategories">Logging category</param>
        public static void LogError(Exception ex, LoggingCategories loggingCategories)
        {
            Log4NetLogger.Log.Error(loggingCategories.ToString(), ex);
        }

        /// <summary>
        /// Logs warning
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="loggingCategories">Logging category</param>
        public static void LogWarning(Exception ex, LoggingCategories loggingCategories)
        {
            Log4NetLogger.Log.Warn(loggingCategories.ToString(), ex);
        }

        /// <summary>
        /// Logs information
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="loggingCategories">Logging category</param>
        public static void LogInformation(Exception ex, LoggingCategories loggingCategories)
        {
            Log4NetLogger.Log.Info(loggingCategories.ToString(), ex);
        }

        #endregion Non-virtual methods
    }
}
