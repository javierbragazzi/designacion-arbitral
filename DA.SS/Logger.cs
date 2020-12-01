using log4net;

namespace DA.SS
{
    /// <summary>
    /// Class Logger
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        public static ILog Log
        {
            get { return _log; }
        }    }
}

