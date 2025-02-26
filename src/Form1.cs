using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LogMonitor.Core.Listeners;
using LogMonitor.Core.ViewModels;

namespace LogMonitor
{
    public partial class Form1 : Form
    {
        UdpListener _listener;

        delegate void AppendDataCallback(string target, IPEndPoint source, string text);
        AppendDataCallback _appendDataCallback;
        AppendDataCallback _appendDataToGridCallback;

        private bool _listenerRunning = false;


        public Form1()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
           //LoggerDataGridView.DataSourceChanged += LoggerDataGridView_OnDataSourceChanged();
            //this.LoggerDataGridView.DataSourceChanged += new EventHandler(this.LoggerDataGridView_DataSourceChanged);
        }

        void filters_OnMessageListChanged(object sender, MessageReceivedArgs e)
        {
            // sender is the UdpListener object.
            //updates.InvalidateFilters();
            
            AppendDataToText(e.RawMessage.MessageTarget, e.RawMessage.MessageSource, e.RawMessage.MessageText);
            AppendDataToGrid(e.RawMessage.MessageTarget, e.RawMessage.MessageSource, e.RawMessage.MessageText);
            
            //updates.InvalidateMessages();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listener = new UdpListener(int.Parse(Settings_PortTextBox.Text));
            _listener.OnMessageReceived += filters_OnMessageListChanged;

            _appendDataCallback = new AppendDataCallback(AppendDataToText);
            _appendDataToGridCallback = new AppendDataCallback(AppendDataToGrid);
            //LoggerMessageListBox.DataSource = _listener.RawMessageList;
            //_listener.StartListener();
            PauseResumeListener(true);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _listener.Dispose();
        }


        public void OnUpdateView()
        {
            UpdateView();
        }

        void UpdateView()
        {}


        private void AppendDataToText(string target, IPEndPoint source, string text)
        {
            source = source ?? new IPEndPoint(0, 0);
            if (RawDataOutputTextBox.InvokeRequired == true)
            {
                this.Invoke(_appendDataCallback,  target,  source,  text);
            }
            else
            {
                RawDataOutputTextBox.AppendText(string.Format("[[ UDP Received From '{0}', to target '{1}' @ {2} ]]\r\n{3}\r\n\r\n", source, target, DateTime.Now.ToString("hh:mm:ss:ff"), text));
            }
        }

        private void AppendDataToGrid(string target, IPEndPoint source, string text)
        {
            source = source ?? new IPEndPoint(0, 0);
            if (LoggerDataGridView.InvokeRequired)
            {
                Invoke(_appendDataToGridCallback, target, source, text);
            }
            else
            {
                //VScrollBar scr = (VScrollBar)LoggerDataGridView.Controls.Find("vertScrollBar", false)[0];
                //AppendDataToText("", null, LoggerDataGridView.VerticalScrollingOffset.ToString() + ":" + LoggerDataGridView.DisplayedRowCount(false).ToString()); //LoggerDataGridView.FirstDisplayedScrollingRowIndex));
                //AppendDataToText("", null, scr.Value.ToString() + ":" + LoggerDataGridView.FirstDisplayedScrollingRowIndex.ToString() + ":" + LoggerDataGridView.DisplayedRowCount(false).ToString()); //LoggerDataGridView.FirstDisplayedScrollingRowIndex));

                bool scrollToEnd = false;
                if (LoggerDataGridView.VerticalScrollingOffset == 0)
                {
                    scrollToEnd = true;
                }
                
                messageDataItemBindingSource.Add(new MessageDataItem(source.ToString(), target, text));

               // Debug.WriteLine("");
               // Debug.WriteLine("RowCount = {0}", LoggerDataGridView.RowCount);
               // Debug.WriteLine("DisplayedRowCount(false/true) = {0}/{1}", LoggerDataGridView.DisplayedRowCount(false), LoggerDataGridView.DisplayedRowCount(true));
               // Debug.WriteLine("VerticalScrollingOffset = {0}", LoggerDataGridView.VerticalScrollingOffset);
               // Debug.WriteLine("FirstDisplayedScrollingRowIndex = {0}", LoggerDataGridView.FirstDisplayedScrollingRowIndex);

                if (FollowTailEnabledCheckBox.Checked && LoggerDataGridView.DisplayedRowCount(false) < LoggerDataGridView.RowCount)
                {
                    try {

                        int expectedFirst = LoggerDataGridView.RowCount - LoggerDataGridView.DisplayedRowCount(true);
                        if (expectedFirst > LoggerDataGridView.FirstDisplayedScrollingRowIndex)
                        {
                            LoggerDataGridView.FirstDisplayedScrollingRowIndex = expectedFirst;
                        }else
                        {
                            
                        }
                        LoggerDataGridView.FirstDisplayedScrollingRowIndex += 1;
                        int n = LoggerDataGridView.FirstDisplayedScrollingRowIndex + (LoggerDataGridView.RowCount - LoggerDataGridView.DisplayedRowCount(true));
                        
                        
                        
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("ERROR = {0}", ex);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RawDataOutputTextBox.Text = "";
            messageDataItemBindingSource.Clear();
            //LoggerDataGridView.FirstDisplayedScrollingRowIndex = 0;
        }

       

        private void PauseResumeListenerButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                _filter = new Regex(textBox1.Text);
            }
            else
            {
                _filter = null;
            }

            PauseResumeListener(!_listenerRunning);
        }

        public void PauseResumeListener(bool listenerRunning)
        {
            _listenerRunning = listenerRunning;
            if (_listenerRunning)
            {
                _listener.StartListener();
                PauseResumeListenerButton.Text = "Pause";
            }
            else
            {
                _listener.StopListener();
                PauseResumeListenerButton.Text = "Resume";
            }
        }


        private System.Text.RegularExpressions.Regex _filter;


        private void UpdateRowColors()
        {
            


            //counter++;
            //Debug.WriteLine("UpdateRowColors\t" + counter);

            int start = LoggerDataGridView.FirstDisplayedScrollingRowIndex;
            int end = LoggerDataGridView.FirstDisplayedScrollingRowIndex + LoggerDataGridView.DisplayedRowCount(true);
            if (end > LoggerDataGridView.RowCount)
            {
                end = LoggerDataGridView.RowCount;
            }


            for (int i = start; i < end; i++)
            {
                MessageDataItem itm = (MessageDataItem)messageDataItemBindingSource[i];


                bool isMatch = false;

                if (_filter != null)
                {
                    isMatch = _filter.IsMatch(itm.MessageText);
                }

                if (isMatch)
                {
                    if (LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor != Color.PaleVioletRed)
                    {
                        LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                }
                else
                {
                    if (LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor != Color.White)
                    {
                        LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }

                /*
                if (itm.MessageReceivedTimeStamp.AddMinutes(5).CompareTo(DateTime.Now) >= 0)
                {
                    if (LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor != Color.LimeGreen)
                    {
                        LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                    }
                }
                else
                {
                    if (LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor != Color.White)
                    {
                        LoggerDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
                 */
            }
        }

        private void LogInterfaceUpdateTimer_Tick(object sender, EventArgs e)
        {
            
            UpdateRowColors();

            
        }

        int counter = 0;

        private void LoggerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoggerDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            //e.RowIndex
        }

        private void LoggerDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateRowColors();
            
        }

        
        

        /*
        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            this.RefreshColumnsAndRows();
            this.InvalidateRowHeights();
            EventHandler handler = base.Events[EVENT_DATAGRIDVIEWDATASOURCECHANGED] as EventHandler;
            if (((handler != null) && !this.dataGridViewOper[0x100000]) && !base.IsDisposed)
            {
                handler(this, e);
            }
            if ((this.dataConnection != null) && (this.dataConnection.CurrencyManager != null))
            {
                this.OnDataBindingComplete(ListChangedType.Reset);
            }
        }

 */


    }
}
