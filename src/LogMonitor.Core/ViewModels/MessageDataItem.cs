using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMonitor.Core.ViewModels
{
    public class MessageDataItem
    {
         private string _messageText;
        private string _messageSource;
        private string _messageTarget;
        private DateTime _messageReceivedTimeStamp;



        public MessageDataItem(string messageSource, string messageTarget, string messageText):this(messageSource,messageTarget,messageText,DateTime.Now)
        {
          
        }


        public MessageDataItem(string messageSource, string messageTarget, string messageText,
            DateTime messageReceivedTimeStamp)
        {
            _messageTarget = messageTarget;
            _messageText = messageText;
            _messageSource = messageSource;
            _messageReceivedTimeStamp = messageReceivedTimeStamp;
        }

       

        public string MessageTarget
        {
            get { return _messageTarget; }
        }

        public string MessageSource
        {
            get { return _messageSource; }
        }

        public string MessageText
        {
            get { return _messageText; }
        }

        public DateTime MessageReceivedTimeStamp
        {
            get { return _messageReceivedTimeStamp; }
        }
    }
}
