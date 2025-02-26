using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SimpleLogClient.Core.Configuration;

namespace SimpleLogClient.Core
{
    public class SimpleLogger
    {

        // REQUIREMENTS:
        // * Common config source for multiple apps (windows registry).
        // * Singleton config object.
        // * Support for web.config and/or app.config.
        // * Logger levels.
        // * Failover to file/ windows events.


        public static string LogEntryId = "WIZ";

        /// <summary>
        /// maximum number of attempts allowed for writing to the target.
        /// </summary>
        const int MaxAttempts = 3;

        /// <summary>
        /// Number of seconds before settings are reloaded from registry.
        /// </summary>
        const int RegistrySettingsUpdateSeconds = 10;

        /// <summary>
        /// Number of milliseconds to wait before making another attempt to write log entry.
        /// </summary>
        private static int WriteFailureAttemptDelayMilliseconds = 300;


        //private readonly LoggerSettingsInfo _logSettings = null;


        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the file to write the log to.
        /// </summary>
        /// <value>
        /// Overrides the filename setting in logfilesettings object.
        /// </value>
        public string LogFileName { get; set; }


        public string HostName
        {
            get;
            private set;
        }

        public string LogFileBaseName
        {
            get;
            private set;
        }

        public string ModuleName
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LocationField
        {
            get;
            private set;
        }

        /// <summary>
        /// By making this property public available allows calling code to skip msg prep work if log will not be written.
        /// </summary>
        public TraceLevel ApplicationTraceLevel { get; private set; }

        #endregion




        #region "Constructors"

        public static SimpleLogger GetCustomLogger(string loggerFileBaseName, string moduleName)
        {
            LoggerElement loggerConfig = GetLoggerConfig(LoggerSettingsInfo.Current, "");
            loggerConfig.logfilenameprefix.value = loggerFileBaseName;
            return new SimpleLogger(loggerConfig, moduleName, "");
        }

        public static SimpleLogger GetLogger(string loggerName, string moduleName, string hostName)
        {
            //SimpleLogger logger;
           // try
            //{
                LoggerElement loggerConfig = GetLoggerConfig(LoggerSettingsInfo.Current, loggerName);
                if (loggerConfig == null)
                {
                    // TODO: Create a default if DEFAULT logger config exists, but use "perf" for name.
                    //return new NullLoggerService();
                    return null;
                }
                else
                {
                    /*
                     (TraceLevel)loggerConfigurationElement.tracelevel.value, 
                moduleName, 
                loggerConfigurationElement.logfilelocation.value,
                loggerConfigurationElement.logfilenameprefix.value,
                hostName
                    */

                    return new SimpleLogger(loggerConfig, moduleName, hostName);
                }
            //}
            //catch (Exception ex)
            //{
                //return new SimpleLogger(loggerConfig, moduleName, hostName);
           // }
        }

        // TODO: May be nice to have something like this...
        /*
        public static SimpleLogger CreateLogger(LoggerSettingsInfo logSettings)
        {
            SimpleLogger logger = new SimpleLogger();
            logger.LogFileName = "";
            try
            {
                logSettings.ValidateSettings();
            }
            catch (Exception ex)
            {
                Util.WriteErrorToEventLog("Logging", "", ex);
            }
            return new SimpleLogger(loggerConfig, moduleName, hostName);
        }
        */


        private static LoggerElement GetLoggerConfig(LoggerSettingsInfo loggerSettings, string loggerName)
        {
            // TODO: If no logger config is found in web.config, create a default? Also, send WARN debug message. OR... Throw exception? make this mandatory?
            if (loggerSettings == null)
            {
                //throw new Exception("AAA");
                // If no logger config found, turn off logger...
                LoggerElement retVal = new LoggerElement();
                retVal.tracelevel.value = 0;
                return retVal;
            }
            else
            {
                if (string.IsNullOrEmpty(loggerName) || loggerSettings.LoggerServiceConfig.Loggers == null || loggerSettings.LoggerServiceConfig.Loggers.Count == 0 || loggerSettings.LoggerServiceConfig.Loggers[loggerName] == null)
                {
                    return loggerSettings.LoggerServiceConfig.DefaultLogger;
                }
                else
                {
                    return loggerSettings.LoggerServiceConfig.Loggers[loggerName];
                }
            }
        }

        /// <summary>
        /// Creates a new Logger object with empty settings.
        /// </summary>
        /// <remarks>
        /// When empty constructor is called, an empty settings object is created that will be set to load settings from the host computer's registry.
        /// The logger will not be functional unless appropriate registry settings exist!
        /// </remarks>
        /*
        public SimpleLogger()
            : this(new LoggerSettingsInfo())
        {}

        // ctor for simple logger settings.
        public SimpleLogger(string logDirectory, string logFileName)
            : this(new LoggerSettingsInfo(LoggerSettingsInfo.LogWriteTarget.FileStore, logFileName, logDirectory, logDirectory, logDirectory, "", 0) { DisableLoadFromRegistry = true })
        {}
        
        // ctor with full log settings.
        public SimpleLogger(LoggerSettingsInfo logSettings)
        {
            LogFileName = "";
            // WriteErrorToEventLog("logSettings null? " + (logSettings == null).ToString());
            _logSettings = logSettings;

            try
            {
                _logSettings.ValidateSettings();
            }
            catch (Exception ex)
            {
                Util.WriteErrorToEventLog("Logging", "", ex);
            }
        }
        */

        private SimpleLogger(LoggerElement loggerConfigurationElement, string moduleName, string hostName)
            : this(
            (TraceLevel)loggerConfigurationElement.tracelevel.value, 
            moduleName, 
            loggerConfigurationElement.logfilelocation.value,
            loggerConfigurationElement.logfilenameprefix.value,
            hostName)
        { }

        private SimpleLogger(TraceLevel traceLevel, string moduleName, string locationField, string logFileBaseName, string hostName)
        {
            
            ApplicationTraceLevel = traceLevel;
            ModuleName = moduleName;
            LocationField = locationField;
            LogFileBaseName = logFileBaseName;
            HostName = hostName;

            LogFileName = String.Format("{0}_{1:yyyyMMdd}.log", LogFileBaseName, DateTime.Today);
            //_logSettings = new LoggerSettingsInfo();
            //_logSettings = LoggerSettingsInfo.CreateLoggerSettingsFromRegistry();
        }

        #endregion




        #region "Public Methods"
        

        public bool IsInTraceLevel(TraceLevel traceLevel)
        {
            return ApplicationTraceLevel.GetHashCode() >= traceLevel.GetHashCode();
        }


        public void WriteError(string logMessage, Exception ex)
        {
            WriteLog(LoggerSettingsInfo.Current.LogTarget, "", TraceLevel.Error, 0, "", "", "", logMessage + "\r\n[[Exception]]\r\n" + ex.ToString());
        }

        /// <summary>
        /// Writes a simple log message with specified trace level.
        /// </summary>
        /// <param name="traceLevel">The <see cref="System.Diagnostics.TraceLevel"/> to write the log entry as.</param>
        /// <param name="logMessage">The mesage to write.</param>
        public void WriteLog(TraceLevel traceLevel, string logMessage)
        {
            WriteLog(LoggerSettingsInfo.Current.LogTarget, "", traceLevel, 0, "", "", "", logMessage);
        }

        /// <summary>
        /// Writes a simple log message and exception data with specified trace level.
        /// </summary>
        /// <param name="traceLevel"></param>
        /// <param name="logMessage"></param>
        /// <param name="ex"></param>
        public void WriteLog(TraceLevel traceLevel, string logMessage, Exception ex)
        {
            WriteLog(LoggerSettingsInfo.Current.LogTarget, "", traceLevel, 0, "", "", "", logMessage + "\r\n[[Exception]]\r\n" + ex.ToString());
        }

        /// <summary>
        /// Writes a log message.
        /// </summary>
        /// <param name="procId">An identifier for the current process or thread.</param>
        /// <param name="traceLevel">The <see cref="System.Diagnostics.TraceLevel"/> to write the log entry as.</param>
        /// <param name="errorCode">A custom error code to write to the log.</param>
        /// <param name="scriptName">Used to identify a module name, page, class, etc. that wrote the entry.</param>
        /// <param name="auditId">Used to identify the context of the user whom triggered the log entry.</param>
        /// <param name="clientIp">IP address or location of the user whom triggered the log entry.</param>
        /// <param name="logMessage">The mesage to write.</param>
        public void WriteLog(string procId, TraceLevel traceLevel, long errorCode, string scriptName, string auditId, string clientIp, string logMessage)
        {
            WriteLog(LoggerSettingsInfo.Current.LogTarget, procId, traceLevel, errorCode, scriptName, auditId, clientIp, logMessage);
        }


        /// <summary>
        /// Writes a log message.
        /// </summary>
        /// <param name="target">The <see cref="LoggerSettingsInfo.LogWriteTarget"/> to write the entry to.</param>
        /// <param name="procId">An identifier for the current process or thread.</param>
        /// <param name="traceLevel">The <see cref="System.Diagnostics.TraceLevel"/> to write the log entry as.</param>
        /// <param name="errorCode">A custom error code to write to the log.</param>
        /// <param name="scriptName">Used to identify a module name, page, class, etc. that wrote the entry.</param>
        /// <param name="auditId">Used to identify the context of the user whom triggered the log entry.</param>
        /// <param name="clientIp">IP address or location of the user whom triggered the log entry.</param>
        /// <param name="logMessage">The mesage to write.</param>
        public void WriteLog(LoggerSettingsInfo.LogWriteTarget target,
            string procId, TraceLevel traceLevel, long errorCode, string scriptName, string auditId, string clientIp, string logMessage)
        {
            WriteLogInt( target,procId, traceLevel, errorCode, scriptName, auditId, clientIp, logMessage);
        }


        internal void WriteLogInt(LoggerSettingsInfo.LogWriteTarget target,
            string procId, TraceLevel traceLevel, long errorCode, string scriptName, string auditId, string clientIp, string logMessage
            )
        {
            if (IsInTraceLevel(traceLevel))
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    // Reload registry settings if needed. Must always check this in case admin changes values while app is running.
                    if (!LoggerSettingsInfo.Current.DisableLoadFromRegistry
                        && LoggerSettingsInfo.Current.LastUpdateFromRegistryTimeStamp.AddSeconds(RegistrySettingsUpdateSeconds) < dt)
                    {
                        LoggerSettingsInfo.Current.LoadConfigFromRegistryInternal();
                        LoggerSettingsInfo.Current.ValidateSettings();
                    }
                    string hostName = "";
                    if (!string.IsNullOrEmpty(LoggerSettingsInfo.Current.HostName))
                    {
                        hostName = LoggerSettingsInfo.Current.HostName;
                    }
                    else
                    {
                        // hostName = System.Windows.Forms.SystemInformation.ComputerName;
                         hostName = "";
                    }

       
                   // string msg = string.Format("{0} {8} ({1}) ({2}) [{3:0#}:{4:0#}:{5:0#}:{6:00#}]{7}|{9}|{10}|{12}: {13}",
                   //             "WIZ", (int)traceLevel, procId, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, HiResTimer.SecMillisec,
                   //             hostName, clientIp, auditId,
                   //             errorCode, scriptName, logMessage);

                    string msg = string.Format("{0} {8} ({1}) ({2}) [{3:0#}:{4:0#}:{5:0#}:{6:00#}]{7}|{9}|{10}|{11}: {12}",
                                LogEntryId, (int)traceLevel, procId, dt.Hour, dt.Minute, dt.Second, dt.Millisecond, HiResTimer.SecMillisec,
                                hostName, clientIp, auditId,
                                scriptName, logMessage);
                    //string msg = _logFormatter.FormatLogEntry(dt, GetMillisec.SecMillisec, hostName, procId, traceLevel, errorCode, scriptName, auditId, clientIp, logMessage);
                    WriteLogToTarget(msg, dt);

                    if (traceLevel == TraceLevel.Verbose)
                    {
                        Debug.WriteLine(msg);
                    }

                }
                catch (Exception ex)
                {
                    Util.WriteErrorToEventLog("WriteLog", "", ex);
                }
            }
        }


        #endregion



        #region "Private Methods"

        private void WriteLogToTarget(string content, DateTime logEntryTimeStamp)
        {
            // Assemble full log content.
            //string content = string.Concat(headerContent, _messageBodySep, bodyContent); // Compare to string.Format?

            // Make 1st attempt to primary location.
            bool logWriteSuccess = false;

            string logFileName = LoggerSettingsInfo.Current.LogFileName;

            // The internal LogFileName property overrides the one from LogSettings, if present.
            if (LogFileName != "")
            {
                logFileName = LogFileName;
            }
            //System.Diagnostics.Debug.WriteLine(String.Format("{0} called: DirInfo={1}\\{2}; Target={3}", "WriteLogToTarget", _LogSettings.LogFileDirectory, logFileName, _LogSettings.LogTarget.ToString()));
            try
            {
                switch (LoggerSettingsInfo.Current.LogTarget)
                {
                    case LoggerSettingsInfo.LogWriteTarget.UDP:
                        logWriteSuccess = AttemptLogWriteToUdp(MaxAttempts, true, LoggerSettingsInfo.Current.LogFileDirectory, logFileName, content);
                        // TODO: If UDP fails, try to write to local file?
                        break;
                    case LoggerSettingsInfo.LogWriteTarget.FileStore:
                        string firstOutFilePath = "";
                        logWriteSuccess = AttemptLogWriteToFile(MaxAttempts, false, LoggerSettingsInfo.Current.LogFileDirectory, logFileName, content, logEntryTimeStamp, out firstOutFilePath);
                        //WriteErrorToEventLog("First pass. " + _LogSettings.LogFileDirectory + "\\" + firstOutFilePath);
                        if (!logWriteSuccess)
                        {
                            //WriteErrorToEventLog("Error first pass. " + firstOutFilePath);
                            // If first attempt fails, try writing to alt directory.

                            //content = string.Format("{0}{1}*** logging to {2} failed. message:{3}{4}", headerContent,
                            //        separator, firstFileName, separator, (bodyContent.Length <= 100 ? bodyContent : bodyContent.Substring(0, 100)));
                            logWriteSuccess = AttemptLogWriteToFile(MaxAttempts, true, LoggerSettingsInfo.Current.AltLogFileDirectory, logFileName, content, logEntryTimeStamp, out firstOutFilePath);
                            //if (!logWriteSuccess)
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.WriteErrorToEventLog("WriteLog", "", ex);
            }

            // If fail, email admin (if enabled).
            /*
            if (!logWriteSuccess && LoggerSettingsInfo.Current.EnableFailureEmailAlert)
            {
                // TODO: Limit this to prevent flood of inbox due to repeated failures.
                AttemptLogWriteToEmail(content);
            }*/
        }


        /// <summary>
        /// Attempts to write to UDP location <paramref name="maxAttempts"/> # of times.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="maxAttempts">Number of attempts to write a message to this target before giving up.</param>
        /// <param name="finalTry">If <c>true</c>, then failure of this method (<paramref name="maxAttempts"/> applies) will result 
        /// in a thrown exception in order to pass exception info to caller.</param>
        /// <param name="logFileDirectory">Log file path.</param>
        /// <param name="fileName">Name of log file.</param>
        /// <param name="content">Message.</param>
        /// <returns><c>true</c> if successfull.</returns>
        /// <exception cref="T:System.Net.Sockets.SocketException">udp.Send results in a socket exception of "No such host is known", or <paramref name="finalTry"/> is true, <paramref name="maxAttempts"/> is exceeded, and udp.Send results any socket exception.</exception>
        /// <exception cref="T:System.Exception"><paramref name="finalTry"/> is true, <paramref name="maxAttempts"/> is exceeded, and udp.Send results in an unhandled exception.</exception>
        private bool AttemptLogWriteToUdp(int maxAttempts, bool finalTry, string logFileDirectory, string fileName, string content)
        {
            //Common.WriteErrorToEventLog("WriteLog", "", logFileDirectory + fileName + ":" + content);
            string msgg = logFileDirectory + fileName + "|" + content + "";
            byte[] msg = Encoding.ASCII.GetBytes(logFileDirectory + fileName + "|" + content + "");
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    using (var udp = new UdpClient(LoggerSettingsInfo.Current.UdpHost, LoggerSettingsInfo.Current.UdpPort))
                    {
                        udp.Send(msg, msg.Length);
                        return true;
                    }
                }
                catch (SocketException sock_ex)
                {
                    // [a.moore 20110128] 
                    // A SocketException "No such host is known" means DNS lookup failed... Retrying will lock up thread for many seconds, so give up immediately. 
                    // The thread lockup will still be a few seconds (as opposed to (#maxAttempts x 2 sec)).
                    Util.WriteErrorToEventLog("WriteLog", "AttemptLogWriteToUdp", sock_ex);
                    if ((finalTry && i >= maxAttempts - 1) || sock_ex.Message.IndexOf("No such host is known") >= 0)
                    {
                        throw;
                    }
                    Thread.Sleep(WriteFailureAttemptDelayMilliseconds);
                }
                catch (Exception ex)
                {
                    Util.WriteErrorToEventLog("WriteLog", "AttemptLogWriteToUdp", ex);
                    if (finalTry && i >= maxAttempts - 1)
                    {
                        throw;
                    }
                    Thread.Sleep(WriteFailureAttemptDelayMilliseconds);
                }
            }
            return false;
        }

        /// <summary>
        /// Attempts to write to the log <paramref name="maxAttempts"/> # of times.
        /// </summary>
        /// <param name="maxAttempts">Number of attempts to write a message to this target before giving up.</param>
        /// <param name="finalTry">If true, then failure will result in a thrown exception in order to pass exception info to caller.</param>
        /// <param name="logFileDirectory">Log file path.</param>
        /// <param name="fileName">Name of log file.</param>
        /// <param name="content">Message.</param>
        /// <param name="logEventTimeStamp">The time stamp of the original log call. This is not affected by repeated log attempts after failure.</param>
        /// <param name="outputFullFilePath">Outputs final path+file name of log file being written to.</param>
        /// <returns><c>true</c> if successfull.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="logFileDirectory"/> is null or empty.</exception>
        /// <exception cref="T:System.Exception"><paramref name="finalTry"/> is true, <paramref name="maxAttempts"/> is exceeded, and log write results in an unhandled exception.</exception>
        private static bool AttemptLogWriteToFile(int maxAttempts, bool finalTry, string logFileDirectory, string fileName, string content, 
            DateTime logEventTimeStamp, out string outputFullFilePath)
        {
            outputFullFilePath = "";

            if (Util.IsNullOrEmptyString(logFileDirectory))
            {
                throw new ArgumentException("Logger logFileDirectory is missing or invalid.");
            }

            if (Util.IsNullOrEmptyString(fileName))
            {
                // File name is empty, so autogenerate.
                fileName = string.Format("{0:0#}{1:0#}.log", logEventTimeStamp.Month, logEventTimeStamp.Day);
            }

            outputFullFilePath = Path.Combine(logFileDirectory, fileName);
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(outputFullFilePath))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine(content);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Util.WriteErrorToEventLog("WriteLog", "AttemptLogWriteToFile", ex);
                    // If attempts limit reached and finalTry, send the exception to the caller.
                    if (finalTry && i >= maxAttempts - 1)
                    {
                        throw;
                    }
                    // More attempts remain, so sleep, then retry.
                    Thread.Sleep(WriteFailureAttemptDelayMilliseconds);
                }
            }
            return false;
        }


        // Send email alert. Not yet needed...
        /*
        private void AttemptLogWriteToEmail(string content)
        {
            try
            {
                LoggerSettingsInfo.Current.AlertMailMessage.Body = content;
                (new SmtpClient(SimpleLoggerSettings.Current.LoggerSettings.AlertMailMessageSmtpServer)).Send(SimpleLoggerSettings.Current.LoggerSettings.AlertMailMessage);
            }
            catch (Exception ex) { Util.WriteErrorToEventLog("WriteLog", "AttemptLogWriteToEmail", ex); }
        }
        */

        #endregion

    }
}
