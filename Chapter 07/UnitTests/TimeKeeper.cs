// Credit: Daniel Strigl
// Url: http://www.codeproject.com/csharp/highperformancetimercshar.asp

using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace Chapter07.UnitTests
{
    internal class TimeKeeper
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long startTime, stopTime;
        private long freq;

        public TimeKeeper()
        {
            startTime = 0;
            stopTime  = 0;
            if (QueryPerformanceFrequency(out freq) == false)
            {
                // high-performance counter not supported
                throw new Win32Exception();
            }
        }

        public void Reset()
        {
            startTime = 0;
        }

        // Start the timer
        public void Start()
        {
            // lets do the waiting threads there work
            Thread.Sleep(0);
            QueryPerformanceCounter(out startTime);
        }

        // Stop the timer
        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }
        
        public double Duration
        {
            get
            {
                return (double)(stopTime - startTime) / (double) freq;
            }
        }
    }
}
