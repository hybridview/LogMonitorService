using System;
using System.Net;

namespace LogMonitor.Core.Models
{
    public class RawMessageItem
    {

        private string _messageText;
        private IPEndPoint _messageSource;
        private string _messageTarget;

        // MEssage format is:
        // <target_path>|<msg>


        public RawMessageItem(IPEndPoint messageSource, string messageTarget, string messageText)
        {
            _messageTarget = messageTarget;
            _messageText = messageText;
            _messageSource = messageSource;
        }

        public RawMessageItem(IPEndPoint messageSource, string rawMessageText)
        {
            if (rawMessageText.IndexOf('|')>=0)
            {
                _messageTarget = rawMessageText.Substring(0, rawMessageText.IndexOf('|'));
                _messageText = rawMessageText.Substring(rawMessageText.IndexOf('|')+1);
            } else
            {
                _messageTarget = "undefined";
                _messageText = rawMessageText;
            }


           
            
            _messageSource = messageSource;
        }

        public string MessageTarget
        {
            get { return _messageTarget; }
        }

        public IPEndPoint MessageSource
        {
            get { return _messageSource; }
        }

        public string MessageText
        {
            get { return _messageText; }
        }
    }
}
