using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleLogClient.Core
{
    internal class HiResTimer
    {
        [DllImport("kernel32.dll")]
        public extern static short QueryPerformanceCounter(ref ulong X);

        [DllImport("kernel32.dll")]
        public extern static short QueryPerformanceFrequency(ref ulong X);

        static ulong freq = 0;

        static public ulong Frequency
        {
            get
            {
                if (freq == 0)
                    lock (typeof(object))
                        if (freq == 0)
                            QueryPerformanceFrequency(ref freq);
                return freq;
            }
        }

        static public float GetSeconds()
        {
            ulong ticks = 0;
            lock (typeof(object))
                QueryPerformanceCounter(ref ticks);

            ulong v1 = (ticks * 1000 / Frequency) % 60000;

            float secs = (ticks * 1000 / Frequency) % 60000;
            return (ticks * 1000 / Frequency) % 60000;
        }

        static public string SecMillisec
        {
            get
            {
                ulong ticks = 0;
                lock (typeof(object))
                    QueryPerformanceCounter(ref ticks);
                ulong secs = (ticks * 1000 / Frequency) % 60000;
                ulong millisecs = secs % 1000;
                secs = (secs - millisecs) / 1000;
                return string.Format("[{0:0#}.{1:00#}]", secs, millisecs); // (ticks*1000/Frequency)%100000;
            }
        }
    }
}
