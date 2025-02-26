using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using LogMonitor.Core.Util;
using LogMonitor.ServerService.Properties;
using Microsoft.Win32;

namespace LogMonitor.ServerService
{
   
    public class LoggerServiceSettingsInfo
    {
        public static string REGISTRY_KEY_NAME = "LogMonitorServerService";
        public static string REGISTRY_KEY = "SOFTWARE\\GainsKeeper\\" + REGISTRY_KEY_NAME;


        public static LoggerServiceSettingsInfo Current
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
            internal static readonly LoggerServiceSettingsInfo Instance = LoggerServiceSettingsInfo.LoadSettings();
        }


        public TraceSwitch AppTraceSwitch { get; private set; }

        private int _udpPort;
        private bool _settingsLoaded = false;

        public string LogFileRootDirectory
        {
            get;
            set;
        }



        public int LogEntryMaxChars { get; set; }


        public bool PrependSourceIpToMessages { get; private set; }

        /// <summary>
        /// UDP host server port.
        /// </summary>
        /// <remarks>
        /// <para>OPTIONAL.</para>
        /// <para>NOTE: This property will always be overwritten by the registry value if registry access is enabled and UDP settings are found.</para>
        /// </remarks>
        public int ListenerPort
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

        public LoggerServiceSettingsInfo()
            :this("",0,false,0)
        {
            _settingsLoaded = false;
            //LoadSettings();
        }


        public LoggerServiceSettingsInfo(
            string logFileRootDirectory,
            int logEntryMaxChars,
            bool prependSourceIpToMessages,
            int udpPort)
        {
            DisableLoadFromRegistry = false;
            LogFileRootDirectory = logFileRootDirectory;
            LogEntryMaxChars = logEntryMaxChars;
            PrependSourceIpToMessages = prependSourceIpToMessages;
            ListenerPort = udpPort;
            _settingsLoaded = true;
            //_LastUpdateFromRegistryTimeStamp
        }

        private static string EventLogSource = "LogMonitorServerService Settings";


        public static LoggerServiceSettingsInfo LoadSettings()
        {
            Helper.WriteToEventLog(EventLogSource, "LoadSettings", "Loading settings from registry key '" + REGISTRY_KEY + "'.", EventLogEntryType.Information);
            //var appSettingsReader = new AppSettingsReader();
            LoggerServiceSettingsInfo settings = null; // new LoggerServiceSettingsInfo();
            try
            {
                if (!TryLoadConfigFromRegistryInternal(out settings))
                {
                    CreateDefaultConfigInRegistryInternal();
                    if (!TryLoadConfigFromRegistryInternal(out settings))
                    {
                        // Empty settings passed and no registry settings found. Throw an exception. Previously, the log entry was just "eaten" with no explaination.
                        throw new LogMonitorServiceSettingException("Logger settings not found and defaults could not be created.");
                    }
                }
            }
            catch (LogMonitorServiceSettingException lsex)
            {
                Helper.WriteErrorToEventLog(EventLogSource, "LoadSettings", lsex);
                throw;
            }
            catch (Exception ex)
            {
                Helper.WriteErrorToEventLog(EventLogSource, "LoadSettings", ex);
                throw new LogMonitorServiceSettingException("Unhandled error.", ex);
            }

            try
            {
                settings.AppTraceSwitch = new TraceSwitch("TraceLevel", "Trace Level");
            }
            catch (Exception)
            {
                settings.AppTraceSwitch = new TraceSwitch("TraceLevel", "Trace Level", "Verbose");
            }

            return settings;
        }


        /// <summary>
        /// Load the config from registry. Ensures all components and services log with the same settings.
        /// 
        /// NOTE: This is called on initial load of service.
        /// </summary>
        /// <remarks>
        /// <para>
        /// PERF WARNING: Many projects create new logger instance for each log write. Registry will have to be read EACH 
        /// time this happens. Instead, let app handle loading settings and pass into ZLogger ctor as params.
        /// </para>
        /// </remarks>
        internal static bool TryLoadConfigFromRegistryInternal(out LoggerServiceSettingsInfo settings)
        {
            settings = new LoggerServiceSettingsInfo();
            using (RegistryKey sc = Registry.LocalMachine.OpenSubKey(REGISTRY_KEY, RegistryKeyPermissionCheck.ReadSubTree))
            {
                if (sc != null)
                {
                    try
                    {
                        // NOTE: If existing settings are passed in, preserve some of the values.
                        // These keys would most likely be overridden by the APP, so keep existing values if they exist.
                        if (Util.IsNullOrEmptyString(settings.LogFileRootDirectory))
                        {
                            settings.LogFileRootDirectory = sc.GetValue("LogFileRootDirectory", "").ToString();
                        }
                        settings.PrependSourceIpToMessages = (sc.GetValue("PrependSourceIpToMessages").ToString() == "1");
                        settings.LogEntryMaxChars = Convert.ToInt32(sc.GetValue("LogEntryMaxChars", 32000));

                        // Very important reg values. These will always overwrite existing values.
                        settings.ListenerPort = Convert.ToInt32(sc.GetValue("ListenerPort", 0));
                        settings.LastUpdateFromRegistryTimeStamp = DateTime.Now;

                        settings._settingsLoaded = true;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Helper.WriteErrorToEventLog(EventLogSource, "LoadSettings", "Error reading one or more registry values. Defaults will be set. Error: "+ ex.ToString());
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        internal static void CreateDefaultConfigInRegistryInternal()
        {
            var key = Registry.LocalMachine.CreateSubKey(REGISTRY_KEY);
            key.Flush();
            key.Close();
            using (RegistryKey sc = Registry.LocalMachine.OpenSubKey(REGISTRY_KEY, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                if (sc != null)
                {
                    sc.SetValue("LogFileRootDirectory", "c:\\Logs\\", RegistryValueKind.String);
                    sc.SetValue("PrependSourceIpToMessages", "0", RegistryValueKind.String);
                    sc.SetValue("LogEntryMaxChars", "32000", RegistryValueKind.String);
                    sc.SetValue("ListenerPort", "6514", RegistryValueKind.String); // GKLoggerNet uses 6514. If you are getting junk messages from other apps, you can change the port in regsitry.
                    sc.Flush();
                    sc.Close();
                    Helper.WriteToEventLog(EventLogSource, "LoadSettings", "Defaults have been saved to registry in key [" + REGISTRY_KEY + "]; Values used were: LogFileRootDirectory='" + "c:\\Logs\\" + "'; ListenerPort='" + "6512" + "'; etc...", EventLogEntryType.Information);
                }
                else
                {
                    throw new LogMonitorServiceSettingException("Could not read the registry key '" + REGISTRY_KEY + "'. Service cannot run.");
                }
            }
        }

        /// <summary>
        /// Validate that all settings are compatible.
        /// </summary>
        /// <exception cref="Exception">If no settings loaded and values not found in registry.</exception>
        internal void ValidateSettings()
        {
            // Check for log directory value, and set to DEFAULT if not found.
            if (Util.IsNullOrEmptyString(LogFileRootDirectory))
            {
                throw new Exception("Logger setting not valid. LogFileRootDirectory=" + LogFileRootDirectory);
            }

            if (!_settingsLoaded)
            {
                // Empty settings passed and no registry settings found. Throw an exception. Previously, the log entry was just "eaten" with no explaination.
                throw new Exception("Empty settings passed and no registry settings found.");
            }
            

        }
    }
}
