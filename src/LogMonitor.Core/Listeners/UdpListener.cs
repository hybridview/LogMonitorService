using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using LogMonitor.Core.Models;

namespace LogMonitor.Core.Listeners
{


    // Useful sockets info.
    // http://msdn.microsoft.com/en-us/magazine/cc300760.aspx


    


    public class MessageReceivedArgs : EventArgs
    {
        public MessageReceivedArgs(RawMessageItem rawMessage)
        {
            //this._changeAffectsMessageListResult = changeAffectsMessageListResult;
            _rawMessage = rawMessage;
        }
        /*
        public bool ChangeAffectsMessageListResult
        {
            get { return _changeAffectsMessageListResult; }
        }

        readonly bool _changeAffectsMessageListResult;
        */

        readonly RawMessageItem _rawMessage;
        public RawMessageItem RawMessage
        {
            get { return _rawMessage; }
        }
    };


    public class UdpListener : IDisposable
    {
        /// <summary>
        /// UDP Message is received event.
        /// </summary>
        public event EventHandler<MessageReceivedArgs> OnMessageReceived;

        //public delegate void AppendDataCallback(string text, IPEndPoint from);
        //public EventHandler Changed;


        private int _udpPort = 6514;

        private UdpClient _udpclient;

        /// <summary>
        /// The listener thread waits for socket connections
        /// </summary>
        private Thread _listenerThread;

        private RawMessageItem _rawMessage;

        

        public RawMessageItem RawMessage
        {
            get { return _rawMessage; }
        }
        public UdpListener(int udpPort)
        {
            _udpPort = udpPort;
            //_rawMessageList = new List<RawMessageItem>();
        }

        protected void OnChange()
        {
            //if (owner != null)
            //    owner.FireOnPropertiesChanged(this, changeAffectsFilterResult);
            if (OnMessageReceived != null)
                OnMessageReceived(this, new MessageReceivedArgs(RawMessage));
        }


        private void ReceiveData()
        {
            //Console.WriteLine("ReceiveData START ");
            //Debug.WriteLine("ReceiveData START ");
            if (_udpclient != null)
            {
                _udpclient.Close();
            }
            _udpclient = new UdpClient(_udpPort);
            IPEndPoint remote = null;
            //_udpclient.Ttl
            // 
            while (true)
            {
                try
                {
                    // This is "blocking" so cpu cycles not being burned by WHILE TRUE.
                    byte[] bytes = _udpclient.Receive(ref remote);
                    string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    _rawMessage = new RawMessageItem(remote, str);
                    OnChange();
                }
                catch
                {
                    //Debug.WriteLine("ReceiveData Error! " + ex);
                    //Console.WriteLine("ReceiveData Error! " + ex);
                    //throw;
                    break;
                }
            }
        }

        public void StartListener()
        {
            if (_listenerThread != null && _listenerThread.IsAlive)
            {
                _listenerThread.Abort();

            }
            //_port = int.Parse(Settings_PortTextBox.Text);

            _listenerThread = new Thread(new ThreadStart(ReceiveData)) { IsBackground = true };

            if (!_listenerThread.IsAlive)
            {
                _listenerThread.Start();
            }
        }

        public void StopListener()
        {
            _listenerThread.Abort();

        }
        public void Dispose()
        {
            if (_udpclient != null)
            {
                _udpclient.Close();
            }
        }
    }
}
