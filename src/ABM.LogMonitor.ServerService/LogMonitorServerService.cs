using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using LogMonitor.ServerService.Properties;
using LogMonitor.Core.Listeners;

namespace LogMonitor.ServerService
{


    /* 
     * To improve performance, we should try to leave the file open for some milliseconds when huge rate of messages are coming for given file.
     * Without this, we lose some entries when sending hundreds per sec.
     * 
     * To implement, leave file open and queue closures by using a Timer, or if a message comes in for a different file.
     * */

    /// <summary>
    /// A very simple UDP listener log file writer.
    /// </summary>
    public partial class LogMonitorServerService : ServiceBase
    {

        private UdpListener _listener;
        private StreamWriter _fileOutputStream = null;


        public LogMonitorServerService()
        {
            InitializeComponent();
        }

        #region "Not yet used."

        // NOTE: Only needed for multi-thread.
        //delegate void AppendDataCallback(string target, IPEndPoint source, string text);
        //AppendDataCallback _appendDataCallback;
        //AppendDataCallback _appendDataToGridCallback;
        //private bool _listenerRunning = false;

        private int _fileFlushInterval;
        private int _fileCloseInterval;
        private Timer _fileOpenTimer;

        // For maintaining list of multiple log files in cache. Not yet used.
        private void OnTimerCallback(object state)
        {
            try
            {
                if (_fileOutputStream != null)
                {
                    _fileOutputStream.Close();
                }
                /*
                int i;
                lock (m_FileList)
                {
                    DateTime dt = DateTime.UtcNow.AddMilliseconds(-_fileCloseInterval);
                    LogFile file;
                    i = 0;
                    while (i < m_FileList.Count && m_Stopped == 0)
                    {
                        file = (LogFile)m_FileList[i];
                        if (file.m_LastWrite < dt)
                            m_FileList.RemoveAt(i);
                        else
                        {
                            file.Flush();
                            i++;
                        }
                    }
                }
                ClientThread thread;
                i = 0;
                lock (m_ThreadList)
                {
                    while (i < m_ThreadList.Count && m_Stopped == 0)
                    {
                        thread = (ClientThread)m_ThreadList[i];
                        if (thread.Terminated)
                            m_ThreadList.RemoveAt(i);
                        else
                            i++;
                    }
                }
                 */
            }
            catch (Exception ex)
            {
                //ErrorLoggerSingleton.GetErrorLogger().LogError(string.Format("{0}: {1} \r\n{2}", m_ServerName, ex.Message, ex.StackTrace), 0);
            }
        }
        #endregion

        protected override void OnStart(string[] args)
        {

            _listener = new UdpListener(LoggerServiceSettingsInfo.Current.ListenerPort);
            _listener.OnMessageReceived += filters_OnMessageReceived;

            //_fileOpenTimer = new Timer(new TimerCallback(OnTimerCallback));
            //_fileOpenTimer.Change(_fileFlushInterval, _fileFlushInterval);
            //_appendDataCallback = new AppendDataCallback(AppendDataToFile);

            _listener.StartListener();
            base.EventLog.WriteEntry(string.Format("[Service Start] Running Build: {0};", Assembly.GetExecutingAssembly().GetName().Version));
            
            //base.EventLog.WriteEntry("Root directory: " + Settings.Default.LogFileRootDirectory);
            base.EventLog.WriteEntry(string.Format("[Service Settings]\r\n\tRelative target base log path: {0}\r\n\tListening on port: {1}", LoggerServiceSettingsInfo.Current.LogFileRootDirectory, LoggerServiceSettingsInfo.Current.ListenerPort));
            //LoggerServiceSettingsInfo
            try
            {
                EnsureDirectoryExists(LoggerServiceSettingsInfo.Current.LogFileRootDirectory, true);
            }
            catch (Exception ex)
            {
                base.EventLog.WriteEntry("ERROR on Service Start: " + ex);
            }

        }

        protected override void OnStop()
        {
            _listener.StopListener();
        }

        protected void filters_OnMessageReceived(object sender, MessageReceivedArgs e)
        {
            // sender is the UdpListener object.
            //updates.InvalidateFilters();
            string msg = "";
            if (LoggerServiceSettingsInfo.Current.LogEntryMaxChars >= 0 && e.RawMessage.MessageText.Length > LoggerServiceSettingsInfo.Current.LogEntryMaxChars)
            {
                msg = e.RawMessage.MessageText.Substring(0, LoggerServiceSettingsInfo.Current.LogEntryMaxChars);
            }
            else
            {
                msg = e.RawMessage.MessageText;
            }

            // \log_gkcc\GKCC2_dev\
            // c:\logs\mylog.log
            string filePath = GeneratePath(LoggerServiceSettingsInfo.Current.LogFileRootDirectory, e.RawMessage.MessageTarget);

           
            AppendDataToFile(filePath, e.RawMessage.MessageSource, msg);
        }

        private static string GeneratePath(string configuredRootPath, string pathFromMessage)
        {
            string path = "";
            
            // Handle absolute path.
            if (pathFromMessage.IndexOf(@":\") == 1 && pathFromMessage.IndexOf(@"\\") == 0)
            {
                //path = LoggerServiceSettingsInfo.Current.LogFileRootDirectory + pathFromMessage;
                path= pathFromMessage;
            }
            else
            {
                // Remove starting backslash if it exists.
                if (pathFromMessage.IndexOf(@"\") == 0)
                {
                    pathFromMessage = pathFromMessage.Remove(0, 1);
                }
                path = Path.Combine(configuredRootPath, pathFromMessage);
            }
            return path;
        }

        private object _lockobj = null;

        private void AppendDataToFile(string target, IPEndPoint source, string text)
        {

            //\log_gkcc\GKCC2_dev\
            string msg = "";

            try
            {
                EnsureDirectoryExists(target,false);
                source = source ?? new IPEndPoint(0, 0);
                string formatStr = "{2}";
                if (LoggerServiceSettingsInfo.Current.PrependSourceIpToMessages)
                {
                    formatStr = "{0} {2}";
                }
                msg = string.Format(formatStr, source, DateTime.Now.ToString("hh:mm:ss:ff"),  text );
                // Some loggers add line break to msg, so only add line break for loggers that don't.
                // 20170511: To support fragments, we cannot add line break. Let client handle it.
                /*if (!msg.EndsWith("\n"))
                {
                    msg += "\n";
                }*/

                // Single threaded, so no need to lock!
                //lock (_lockobj)
                {
                    //var inputFileInfo = new FileInfo(target);
                    var fsOut = new FileStream(target, FileMode.Append, FileAccess.Write);
                    var srOut = new StreamWriter(fsOut);
                    srOut.Write( msg );
                    srOut.Close();
                }

            }
            catch (Exception ex)
            {

                base.EventLog.WriteEntry("ERROR on AppendDataToFile: FileTarget=" + target + "; Msg=" + msg + "; EXC=" + ex);
            }

        }


        private void EnsureDirectoryExists(string filePath, bool isFolder)
        {
            string folderPath = filePath;
            if (!isFolder)
            {
                folderPath = Path.GetDirectoryName(filePath); // folderPath.Substring(0, filePath.LastIndexOf('\\'));
            }
            if (!string.IsNullOrEmpty(folderPath) && !Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception ex)
                {
                    base.EventLog.WriteEntry("ERROR on EnsureDirectoryExists: " + ex);
                    throw;
                }
            }
        }


        /// <summary>
        /// Ensures UDP message follows expected format ().
        /// </summary>
        private void ValidateMessageFormat()
        {
            // TODO: Implement.
            // Write to a special log folder/file that is reserved for bad messages.
        }

    }
}
