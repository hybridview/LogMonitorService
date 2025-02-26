using System;
using System.Configuration;
using System.Diagnostics;
using SimpleLogClient.Core.Configuration;

namespace SimpleLogClient.Core
{
    public class SimpleLoggerSettings{
     public static SimpleLoggerSettings Current
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
            internal static readonly SimpleLoggerSettings Instance = new SimpleLoggerSettings();
        }


        private SimpleLoggerSettings()
        {
            ModuleNameVerboseIgnoreList = "";
            LoadSettings();
        }


        /// <summary>
        /// Logger configuration from file.
        /// </summary>
        public LoggerServiceSection LoggerServiceConfig { get; private set; }

        /// <summary>
        /// Current logger settings. This includes settings loaded from registry and dynamically set settings.
        /// </summary>
        public LoggerSettingsInfo LoggerSettings { get; private set; }


        public TraceSwitch AppTraceSwitch { get; private set; }

        public string ModuleNameVerboseIgnoreList { get; private set; }



        private void LoadSettings()
        {
            //ILogFormatter formatter;
            //LoggerBaseSettings.LogWriteTarget logTarget;

            //var appSettingsReader = new AppSettingsReader();
            LoggerSettingsInfo settings;
            if (LoggerSettingsInfo.TryCreateLoggerSettingsFromRegistry(out settings))
            {
                LoggerSettings = settings;
            }
            else
            {
                // If failed to load anys ettings from registry, then check web.config as a backup only.
                LoggerSettings = new LoggerSettingsInfo(
                    LoggerSettingsInfo.LogWriteTarget.NOT_SET, 
                    "", "", "", "",
                    Util.GetConfigValueOrDefault("AppLogUdpHost", ""),
                    int.Parse(Util.GetConfigValueOrDefault("AppLogUdpPort", "0")));
            }

            //LoggerSettings.HostName = "";

            //LoggerSettings = LoggerBaseSettings.CreateLoggerSettingsFromRegistry();

            try
            {
                AppTraceSwitch = new TraceSwitch("TraceLevel", "Trace Level");
            }
            catch (Exception)
            {
                AppTraceSwitch = new TraceSwitch("TraceLevel", "Trace Level", "Verbose");
            }

            
            //if (_LoggerSettings != null)
            //{

            // LEGACY support.
            LoggerSettings.LogFileDirectory = Util.GetConfigValueOrDefault("AppLogPath", @"\log\");
            // END LEGACY support.

            if (!string.IsNullOrEmpty(LoggerSettings.UdpHost))
            {
                LoggerSettings.LogTarget = LoggerSettingsInfo.LogWriteTarget.UDP;
            }
            else
            {
                LoggerSettings.LogTarget = LoggerSettingsInfo.LogWriteTarget.FileStore;
            }

            LoggerServiceConfig = (LoggerServiceSection)ConfigurationManager.GetSection("LoggerServiceSection");

            if (LoggerServiceConfig != null)
            {


                if (!string.IsNullOrEmpty(LoggerServiceConfig.DefaultLogger.logfilelocation.value))
                {
                    LoggerSettings.LogFileDirectory = LoggerServiceConfig.DefaultLogger.logfilelocation.value;
                }

                ApplyApplicableDefaults();
            }

            
        }

        /// <summary>
        /// Migrates default settings to named loggers missing said settings.
        /// </summary>
        private void ApplyApplicableDefaults()
        {
            //LoggerServicesSettings.DefaultLogger.logformatter.value;

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


        
    }
}
