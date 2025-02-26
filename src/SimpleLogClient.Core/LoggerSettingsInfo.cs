using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Win32;
using SimpleLogClient.Core.Configuration;

namespace SimpleLogClient.Core
{
    public class LoggerSettingsInfo
    {

        public static LoggerSettingsInfo Current
        {
            get
            {
                return Nested.Instance;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static Nested()
            {
            }
            internal static readonly LoggerSettingsInfo Instance = LoggerSettingsInfo.LoadSettings();
        }

        /// <summary>
        /// Logger configuration from file.
        /// </summary>
        public LoggerServiceSection LoggerServiceConfig { get; private set; }

        public TraceSwitch AppTraceSwitch { get; private set; }

        private string _logFileDirectory = "";
        private string _altLogFileDirectory = "";
        private string _defaultLogFileDirectory = "";
        private int _udpPort;
        private bool _settingsLoaded = false;

        public enum LogWriteTarget
        {
            NOT_SET = -1,
            UDP = 0,
            FileStore = 1,
            Console = 2
        }

        public LoggerSettingsInfo()
        {
            LogFileName = "";
            DisableLoadFromRegistry = false;
            UdpPort = 0;
            UdpHost = "";
            //LogFormat = LogFormatType.NOT_SET;
            LogTarget = LogWriteTarget.NOT_SET;
            LogFileDirectory = "";
            DefaultLogFileDirectory = "";
            _settingsLoaded = false;
            //LoadSettings();
        }


        public LoggerSettingsInfo(
            LogWriteTarget logTarget,
            string logFileName,
            string logFileDirectory,
            string altLogFileDirectory,
            string defaultLogFileDirectory,
            string udpHost,
            int udpPort)
        {
            DisableLoadFromRegistry = false;
            LogFileName = logFileName;
            LogFileDirectory = logFileDirectory;
            AltLogFileDirectory = altLogFileDirectory;
            DefaultLogFileDirectory = defaultLogFileDirectory;

            LogTarget = logTarget;

            UdpHost = udpHost;
            UdpPort = udpPort;

            _settingsLoaded = true;
            //_LastUpdateFromRegistryTimeStamp
        }

        public string HostName { get; set; }

        /// <summary>
        /// The name of the log file. If left empty, a generic name is generated using a time stamp.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL.</para>
        /// </remarks>
        public string LogFileName { get; set; }

        /// <summary>
        /// The directory that the log file is to be written to. This is configured per application.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL if 
        /// <see cref="AltLogFileDirectory"/> or <see cref="DefaultLogFileDirectory"/> are valid.</para>
        /// </remarks>
        public string LogFileDirectory
        {
            get { return _logFileDirectory; }
            set { 
                _logFileDirectory = value;
                if (!string.IsNullOrEmpty(_logFileDirectory) && !_logFileDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    _logFileDirectory += Path.DirectorySeparatorChar;
                }
            }
        }


        /// <summary>
        /// The directory that the log file is to be written to if writing to the preferred directory fails.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL if <see cref="DefaultLogFileDirectory"/> is valid.</para>
        /// </remarks>
        public string AltLogFileDirectory
        {
            get { return _altLogFileDirectory; }
            set { 
                _altLogFileDirectory = value;
                if (!string.IsNullOrEmpty(_altLogFileDirectory) && !_altLogFileDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    _altLogFileDirectory += Path.DirectorySeparatorChar;
                }
            }
        }

        /// <summary>
        /// The directory that the log file is to be written to if no LogFileDirectory is specified in application settings. 
        /// This is configured per server.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL if <see cref="LogFileDirectory"/> or <see cref="AltLogFileDirectory"/> are valid.</para>
        /// </remarks>
        public string DefaultLogFileDirectory
        {
            get { return _defaultLogFileDirectory; }
            set { 
                _defaultLogFileDirectory = value;
                if (!string.IsNullOrEmpty(_defaultLogFileDirectory) && !_defaultLogFileDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    _defaultLogFileDirectory += Path.DirectorySeparatorChar;
                }
            }
        }


        /// <summary>
        /// Specifies the destination type to log to. This could be UDP, filestore, etc...
        /// </summary>
        /// <remarks>
        /// OPTIONAL. If not set, logger will pick the best setting based on what parameters are present (ie. if UDP settings exist, LogTarget will be set to UDP).
        /// </remarks>
        public LogWriteTarget LogTarget { get; set; }

        /// <summary>
        /// UDP host server name.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL.</para>
        /// <para>NOTE: This property will always be overwritten by the registry value if registry access is enabled and UDP settings are found.</para>
        /// </remarks>
        public string UdpHost { get; private set; }

        /// <summary>
        /// UDP host server port.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL.</para>
        /// <para>NOTE: This property will always be overwritten by the registry value if registry access is enabled and UDP settings are found.</para>
        /// </remarks>
        public int UdpPort
        {
            get { return _udpPort; }
            private set
            {
                if (value != 0 && (value < IPEndPoint.MinPort || value > IPEndPoint.MaxPort))
                {
                    throw new ArgumentOutOfRangeException("value", (object)value,
                        "The value specified is less than " +
                        IPEndPoint.MinPort.ToString(NumberFormatInfo.InvariantInfo) +
                        " or greater than " +
                        IPEndPoint.MaxPort.ToString(NumberFormatInfo.InvariantInfo) + ".");
                }
                else
                {
                    _udpPort = value;
                }
            }
        }

        /// <summary>
        /// Gets the timestamp of last update from registry. This is used to determine whether settings should be refreshed from registry.
        /// </summary>
        public DateTime LastUpdateFromRegistryTimeStamp { get; private set; }

        /// <summary>
        /// Disables loading values from registry if <c>true</c>. Custom settings, like UDP connect info, will be preserved when <c>true</c>.
        /// </summary>
        public bool DisableLoadFromRegistry { get; set; }


        public static LoggerSettingsInfo LoadSettings()
        {
            //var appSettingsReader = new AppSettingsReader();
            LoggerSettingsInfo settings;
            if (!TryCreateLoggerSettingsFromRegistry(out settings))
            {
                // If failed to load anys ettings from registry, then check web.config as a backup only.
                settings = new LoggerSettingsInfo(
                    LogWriteTarget.NOT_SET,
                    "", "", "", "",
                    Util.GetConfigValueOrDefault("AppLogUdpHost", ""),
                    int.Parse(Util.GetConfigValueOrDefault("AppLogUdpPort", "0")));
            }

            try
            {
                settings.AppTraceSwitch = new TraceSwitch("TraceLevel", "Trace Level");
            }
            catch (Exception)
            {
                settings.AppTraceSwitch = new TraceSwitch("TraceLevel", "Trace Level", "Verbose");
            }


            // LEGACY support.
            settings.LogFileDirectory = Util.GetConfigValueOrDefault("AppLogPath", @"\log\");
            // END LEGACY support.

            settings.LogTarget = !string.IsNullOrEmpty(settings.UdpHost) ? LogWriteTarget.UDP : LogWriteTarget.FileStore;

            try
            {
                settings.LoggerServiceConfig = (LoggerServiceSection)ConfigurationManager.GetSection("LoggerServiceSection");

                if (settings.LoggerServiceConfig != null)
                {
                    if (!string.IsNullOrEmpty(settings.LoggerServiceConfig.DefaultLogger.logfilelocation.value))
                    {
                        settings.LogFileDirectory = settings.LoggerServiceConfig.DefaultLogger.logfilelocation.value;
                    }
                    settings.ApplyApplicableDefaults();
                }
                else
                {
                    settings.LoggerServiceConfig = CreateLoggerConfig((int)settings.AppTraceSwitch.Level, "APP", settings.LogFileDirectory);
                }
            }
            catch (Exception ex)
            {
                settings.LoggerServiceConfig = CreateLoggerConfig((int)settings.AppTraceSwitch.Level, "APP", settings.LogFileDirectory);
            }

            return settings;
        }

        private static LoggerServiceSection CreateLoggerConfig(int traceLevel, string logFileNamePrefix, string logFileLocation)
        {
            // TODO: This is a hack to get log client working when no config exists.
            if (traceLevel == 0) { traceLevel = 3; }

            LoggerServiceSection config = new LoggerServiceSection();
            config.DefaultLogger = new DefaultLoggerElement();
            config.DefaultLogger.tracelevel = new TraceLevelElement();
            config.DefaultLogger.tracelevel.value = 4; // traceLevel;
            config.DefaultLogger.logfilenameprefix = new LogFileNamePrefixElement();
            config.DefaultLogger.logfilenameprefix.value = logFileNamePrefix;
            config.DefaultLogger.logfilelocation = new LogFileLocationElement();
            config.DefaultLogger.logfilelocation.value = logFileLocation;
           
            return config;

        }

        /// <summary>
        /// Migrates default settings to named loggers missing said settings.
        /// </summary>
        private void ApplyApplicableDefaults()
        {
            foreach (LoggerElement logger in LoggerServiceConfig.Loggers)
            {
                if (string.IsNullOrEmpty(logger.logfilelocation.value))
                {
                    logger.logfilelocation.value = LoggerServiceConfig.DefaultLogger.logfilelocation.value;
                }

                if (string.IsNullOrEmpty(logger.logfilenameprefix.value))
                {
                    logger.logfilenameprefix.value = LoggerServiceConfig.DefaultLogger.logfilenameprefix.value;
                }
            }
        }

        /// <summary>
        /// Returns a new log settings object with values loaded from registry.
        /// </summary>
        /// <exception cref="MissingLoggerSettingsException">If no settings loaded and values not found in registry.</exception>
        private static LoggerSettingsInfo CreateLoggerSettingsFromRegistry()
        {
            var retVal = new LoggerSettingsInfo();
            retVal.LoadConfigFromRegistryInternal();
            return retVal;
        }

        /// <summary>
        /// Tries to get a new log settings object with values loaded from registry.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns><c>true</c> if attempt to load settings from registry is successfull.</returns>
        private static bool TryCreateLoggerSettingsFromRegistry(out LoggerSettingsInfo settings)
        {
            settings = new LoggerSettingsInfo();
            try
            {
                settings.LoadConfigFromRegistryInternal();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Load the config from registry. Ensures all components and services log with the same settings.
        /// </summary>
        /// <remarks>
        /// <para>
        /// PERF WARNING: Many projects create new logger instance for each log write. Registry will have to be read EACH 
        /// time this happens. Instead, let app handle loading settings and pass into ZLogger ctor as params.
        /// </para>
        /// </remarks>
        internal void LoadConfigFromRegistryInternal()
        {
            using (RegistryKey sc = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WizCompass\\SimpleLogger", RegistryKeyPermissionCheck.ReadSubTree))
            {
                if (sc != null)
                {
                    // NOTE: If existing settings are passed in, preserve some of the values.
                    _settingsLoaded = true;
                    // These keys would most likely be overridden by the APP, so keep existing values if they exist.
                    if (Util.IsNullOrEmptyString(DefaultLogFileDirectory))
                    {
                        DefaultLogFileDirectory = sc.GetValue("Default Log File Directory", "").ToString();
                    }
                    if (Util.IsNullOrEmptyString(AltLogFileDirectory))
                    {
                        AltLogFileDirectory =
                            sc.GetValue("Alternative Log File Directory", AltLogFileDirectory).ToString();
                    }

                    // Very important reg values. These will always overwrite existing values.
                    UdpHost = sc.GetValue("UDP Host", "").ToString();
                    UdpPort = Convert.ToInt32(sc.GetValue("UDP Port", 0));
                }
                else
                {
                    if (!_settingsLoaded)
                    {
                        // Empty settings passed and no registry settings found. Throw an exception. Previously, the log entry was just "eaten" with no explaination.
                        throw new MissingLoggerSettingsException();
                    }
                }
            }

            if (LogTarget == LogWriteTarget.NOT_SET)
            {
                LogTarget = (Util.IsNullOrEmptyString(UdpHost) ? LogWriteTarget.FileStore : LogWriteTarget.UDP);
            }

            LastUpdateFromRegistryTimeStamp = DateTime.Now;
        }


        /// <summary>
        /// Validate that all settings are compatible.
        /// </summary>
        /// <exception cref="SimpleLogClient.Core.MissingLoggerSettingsException">If no settings loaded and values not found in registry.</exception>
        internal void ValidateSettings()
        {

            if (LogTarget == LogWriteTarget.NOT_SET)
            {
                LogTarget = (Util.IsNullOrEmptyString(UdpHost) ? LogWriteTarget.FileStore : LogWriteTarget.UDP);
            }
            // Check for log directory value, and set to DEFAULT if not found.
            if (Util.IsNullOrEmptyString(_logFileDirectory))
            {
                LogFileDirectory = _defaultLogFileDirectory;
            }

            if (!_settingsLoaded)
            {
                // Empty settings passed and no registry settings found. Throw an exception. Previously, the log entry was just "eaten" with no explaination.
                throw new MissingLoggerSettingsException();
            }
            

            switch (LogTarget)
            {
                case LogWriteTarget.UDP:
                    if (UdpPort == 0 || Util.IsNullOrEmptyString(UdpHost))
                    {
                        // TODO: Make this better. It's really hard to configure in production...
                        Util.WriteErrorToEventLog("Logging", "ValidateSettings", "Logger is configured to OutToUdp, but udp_port and/or udp_host is missing or invalid. Attempting alternate log method...");
                        
                        // Don't throw an exception, so that we can fall back to filestore mode.
                        //throw new ArgumentException("Logger is configured to OutToUdp, but udp_port and/or udp_host is missing or invalid.");
                        
                        LogTarget = LogWriteTarget.NOT_SET; // Setting to NOT_SET and running this method again will set the Target to FileStore since UDP values are missing.
                        ValidateSettings();
                    }
                    break;
                case LogWriteTarget.FileStore:
                    string dir = Path.GetDirectoryName(LogFileDirectory);
                    if (Util.IsNullOrEmptyString(dir))
                    {			// trick to avoid null in the dir variable
                        dir = Path.GetPathRoot(LogFileDirectory);
                    }
                    if (Util.IsNullOrEmptyString(dir))
                    {
                        throw new ArgumentException("Logger is configured to OutToFile, but directory is invalid.");
                    }
                    break;
            }
        }
    }
}
