using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LogMonitor.Core.Util
{
    public class Helper
    {


        /// <summary>
        /// Writes to windows event log.
        /// </summary>
        /// <param name="errorSource"></param>
        /// <param name="msgHeader"></param>
        /// <param name="msg"></param>
        public static void WriteErrorToEventLog(string errorSource, string msgHeader, string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(msgHeader))
                {
                    msgHeader = "GeneralError";
                }
                Debug.WriteLine(string.Format("Error Writing to Log: [{0}] {1}", msgHeader, msg));
                EventLog.WriteEntry(errorSource, string.Format("[{0}] {1}", msgHeader, msg), EventLogEntryType.Error);
            }
            catch { }
        }

        public static void WriteErrorToEventLog(string errorSource, string msgHeader, Exception ex)
        {
            WriteErrorToEventLog(errorSource, msgHeader, ex.ToString());
        }

        public static void WriteToEventLog(string msgsrc, string msgHeader, string msg, EventLogEntryType etype)
        {
            try
            {
                if (string.IsNullOrEmpty(msgHeader))
                {
                    msgHeader = "General";
                }

                EventLog.WriteEntry(msgsrc, string.Format("[{0}] {1}", msgHeader, msg), etype);
            }
            catch { }
        }
    }
}
