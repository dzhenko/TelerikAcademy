//* Read in MSDN about the keyword event in C# and how to publish events. 
//Re-implement the above using .NET events and following the best practices.

using System;
using System.Threading;

namespace Events
{
    public class TimeChangedEventArgs : EventArgs
    {
        public int TickCount { get; set; }
        public TimeChangedEventArgs(int TickCount)
        {
            this.TickCount = TickCount;
        }
    }
    public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs e);
    public class Timer
    {
        private int delay;
        private int clicks;

        public int Delay 
        {
            get
            {
                return this.delay;
            }
        }

        public int Clicks
        {
            get
            {
                return this.clicks;
            }
        }

        public Timer(int delay, int clicks)
        {
            this.delay = delay;
            this.clicks = clicks;
        }

        public event TimeChangedEventHandler TimeChanged;

        protected void OnTimeChanged(int tick)
        {
            if (TimeChanged != null)
            {
                TimeChanged(this, new TimeChangedEventArgs(tick));
            }
        }

        public void Run()
        {
            int tick = this.Clicks;

            Thread newThread = new Thread(() =>
            {
                while (tick > 0)
                {
                    Thread.Sleep(this.Delay * 1000);
                    tick--;
                    OnTimeChanged(tick);
                }
            });
            newThread.Start();
        }
    }
    public class Test
    {
        public static void Timer_TimeChanged(object sender, TimeChangedEventArgs e)
        {
            Console.WriteLine("Time has changed " + e.TickCount);
        }
        static void Main()
        {
            Timer newTimer = new Timer(1, 10);
            newTimer.TimeChanged += Timer_TimeChanged;
            newTimer.Run();
        }
    }
}