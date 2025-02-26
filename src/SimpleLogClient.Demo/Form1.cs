using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SimpleLogClient.Core;

namespace SimpleLogClient.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestTypeComboBox.SelectedIndex = 1;
            LoggerClassComboBox.SelectedIndex = 0;
            TestMessageTextBox.Enabled = (TestTypeComboBox.Text != "InitOnly");

            UpdateOverrideConfigFileInputsUI();
        }

        private void RunTestButton_Click(object sender, EventArgs e)
        {
            string logTestClassDisplay = LoggerClassComboBox.Text;
            string logFileName = LogFileNameTextBox.Text.Replace("%LOG_CLASS%", logTestClassDisplay);

            int iterations = (int)TestIterationsNumericUpDown.Value;

            if (logTestClassDisplay.Length < 10)
            {
                logTestClassDisplay += "\t";
            }
            TestResultsListBox.Items.Add(String.Format(">> Start {0}\tTest: {1}\tAttempts: {2:#,##0}", logTestClassDisplay, TestTypeComboBox.Text, iterations));
            string msg = TestMessageTextBox.Text;

            var stopw = new Stopwatch();

            Application.DoEvents();
            stopw.Start();
            try
            {

                if (LoggerClassComboBox.Text == "SimpleLogClient")
                {
                    RunLoggerTest(iterations, msg, LogFileDirectoryTextBox.Text, logFileName, (TestTypeComboBox.Text == "InitOnly"), NewLoggerPerWriteCheckBox.Checked);
                }
                else
                {
                     // Other logger clients later... 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            stopw.Stop();
            Application.DoEvents();
            TestResultsListBox.Items.Add(String.Format("<< Stop {0}\tTest: {1}\tAttempts: {2:#,##0}\tTime: {3:#,##0}ms\tRate: {4:#,##0.0} per sec. ", logTestClassDisplay, TestTypeComboBox.Text, iterations, stopw.ElapsedMilliseconds, (stopw.ElapsedMilliseconds > 0 ? ((iterations * 1000) / stopw.ElapsedMilliseconds) : 0)));


            var logMsg = new StringBuilder();

            logMsg.Append("========================================== " + SystemInformation.ComputerName + "\r\n");
            logMsg.Append(String.Format("Test Date:\t{0}\r\n", DateTime.Now));
            logMsg.Append(String.Format("Logger Class:\t{0}\r\n", logTestClassDisplay));
            logMsg.Append(String.Format("Test Type:\t{0}\r\n", TestTypeComboBox.Text));
            logMsg.Append(String.Format("Log Location:\t{0} {1}\r\n", LogFileDirectoryTextBox.Text, logFileName));
            logMsg.Append(String.Format("Message Size:\t{0:#,##0} chars.\r\n", msg.Length));

            logMsg.Append("---- Performance Data ----\r\n");
            logMsg.Append(String.Format("\tCount:\t{0:#,##0}\r\n", iterations));
            logMsg.Append(String.Format("\tTime:\t{0:#,##0} ms\r\n", stopw.ElapsedMilliseconds));
            logMsg.Append(String.Format("\tRate:\t{0:#,##0.0} per sec.\r\n", (stopw.ElapsedMilliseconds > 0 ? ((iterations * 1000) / stopw.ElapsedMilliseconds) : 0)));


            WriteTestResultsLog(logMsg.ToString());

            // Logger Class
            // Test Date
            // Test Type: TestTypeComboBox.Text
            // Bytes Written
            // Log Location
            // Iterations
            // Time
            // Rate

            //TestResultsListBox.Items.Add(String.Format("<< Stop ({0} attempts): {1} [[ {2:##0.0} per sec ]]", iterations, stopw.ElapsedMilliseconds, (iterations * 1000) / stopw.ElapsedMilliseconds));
            
        }

        private void TestTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestMessageTextBox.Enabled = (TestTypeComboBox.Text != "InitOnly");
        }

        private void UseUdpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseUdpCheckBox.Checked)
            {
                LogFileDirectoryTextBox.Text = "\\testlogs\\GKCC2_Test\\";
            }
            else
            {
                LogFileDirectoryTextBox.Text = "d:\\Logs";
            }
        }

        private void RunLoggerTest(int iterations, string msg, string logDirectory, string logFileName, bool initOnlyNoWrite, bool newLoggerPerWrite)
        {

            SimpleLogger logger = InitNewLogger(logDirectory, logFileName);

            CurrentConfigTextBox.Text = string.Format("UDP Host: {0}\r\nUDP Port: {1}", LoggerSettingsInfo.Current.UdpHost, LoggerSettingsInfo.Current.UdpPort);

            int iterDelayMs = 0;
            
            if (!int.TryParse(txtIterDelay.Text, out iterDelayMs)){
                txtIterDelay.Text = "0";

            }



            for (int i = 0; i < iterations; ++i)
            {
                if (!initOnlyNoWrite)
                    logger.WriteLog("testproc", TraceLevel.Error, 700, "test", "TESTUSER", "127.0.0.1", i + "] " + msg);
                if (newLoggerPerWrite)
                {
                    logger = InitNewLogger(logDirectory, logFileName);
                }
                if (iterDelayMs > 0)
                {
                    Thread.Sleep(iterDelayMs);
                }

            }

        }

        private SimpleLogger InitNewLogger(string logDirectory, string logFileName)
        {
            SimpleLogger logger = SimpleLogger.GetLogger("", "TestModule", "local");

            if (chkOverrideConfigFile.Checked)
            {
                LoggerSettingsInfo.Current.LogFileDirectory = logDirectory;
                LoggerSettingsInfo.Current.LogFileName = logFileName;
                LoggerSettingsInfo.Current.LogTarget = UseUdpCheckBox.Checked ? LoggerSettingsInfo.LogWriteTarget.UDP : LoggerSettingsInfo.LogWriteTarget.FileStore;
                LoggerSettingsInfo.Current.LogTarget = LoggerSettingsInfo.LogWriteTarget.UDP;
            }
            return logger;
        }

        static void WriteTestResultsLog(string msg)
        {
            string fileName = "c:\\SimpleLogClientDemo_TestResults.log";

            //LogFileDirectoryTextBox.Text
            //(new StreamWriter(fileName, true)).WriteLine(msg);

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(msg);
                writer.Flush();
            }
            //				writer.WriteLine(S);
        }


        private void chkOverrideConfigFile_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOverrideConfigFileInputsUI();
        }



        private void UpdateOverrideConfigFileInputsUI()
        {
            LogFileDirectoryTextBox.Enabled = chkOverrideConfigFile.Checked;
            LogFileNameTextBox.Enabled = chkOverrideConfigFile.Checked;
            UseUdpCheckBox.Enabled = chkOverrideConfigFile.Checked;
        }

        
    }
}
