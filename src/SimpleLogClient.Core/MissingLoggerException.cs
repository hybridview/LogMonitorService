using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace SimpleLogClient.Core
{
    /// <summary>
    /// Settings are missing and cannot be loaded from anywhere.
    /// </summary>
    [Serializable]
    public class MissingLoggerSettingsException : Exception
    {

        public MissingLoggerSettingsException()
            : base()
        {

        }

        public MissingLoggerSettingsException(string msg)
            : base(msg)
        {

        }

        protected MissingLoggerSettingsException(SerializationInfo info,
             StreamingContext context)
            : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info,
           StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            base.GetObjectData(info, context);
        }



    }
}
