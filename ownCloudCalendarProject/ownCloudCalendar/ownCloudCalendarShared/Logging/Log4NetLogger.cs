using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ownCloudCalendarShared.Logging
{
    public class Log4NetLogger
    {
        #region Static fields

        /// <summary>
        /// Log object.
        /// </summary>
        public static readonly ILog Log = LogManager.GetLogger("ownCloudCalendar");

        #endregion Static fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Log4NetLogger class.
        /// </summary>
        public Log4NetLogger()
        {
        }

        #endregion Constructors
    }
}
