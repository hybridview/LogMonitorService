using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace LogMonitor.ServerService
{
    public class Util
    {
        /// <summary>
        /// Helper.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyString(object input)
        {
            return (input == null || input.ToString() == String.Empty);
        }

        public static void DebugOut(string msg)
        {
            Debug.Write(string.Format("[{0}] {1}",DateTime.Now, msg));
        }

    }
}
