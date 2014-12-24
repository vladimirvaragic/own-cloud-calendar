using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ownCloudCalendarShared.Exceptions
{
    public class LoggedException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LoggedException class.
        /// </summary>
        public LoggedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the LoggedException class.
        /// </summary>
        /// <param name="ex">Exception that is already logged</param>
        public LoggedException(Exception ex)
            : base(String.Empty, ex)
        {

        }

        /// <summary>
        /// Initializes a new instance of the LoggedException class.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="ex">Exception that is already logged</param>
        public LoggedException(string message, Exception ex)
            : base(message, ex)
        {

        }

        #endregion Constructors
    }
}
