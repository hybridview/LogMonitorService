using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMonitor.ServerService
{
    public class LogMonitorServiceSettingException : Exception
    {

        public LogMonitorServiceSettingException(string msg):base("There was a problem with the services settings: " + msg)
        {


        }

        public LogMonitorServiceSettingException(string msg, Exception ex):base("There was a problem with the services settings: " + msg + "; REF=" + ex.ToString())
        {

        }
    }
}
