//Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace TimerExecuteActionAtEachSecond
{
    using System;
    using System.Threading;

    public delegate void TimerEvent();

    public class Timer
    {
        private int count;
        private int interval; // in miliseconds
        private TimerEvent tE;
        private int ticks;

        //constructor with both thicks and interval in seconds
        public Timer(int count, int interval, TimerEvent TE)
        {
            this.Count = count;
            this.Interval = interval;
            this.tE = TE;
            this.ticks = 0;
        }

        //constructor with only interval in seconds and max thicks
        public Timer(int interval, TimerEvent TE)
            : this(int.MaxValue, interval, TE) { }

        //empty constructor - max thicks and 1 second interval
        public Timer(TimerEvent TE)
            : this(int.MaxValue, 1, TE) { }

        public int Interval
        {
            get
            {
                return this.interval;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Interval must be > 0 !");
                }
                this.interval = value * 1000;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Count must be > 0 !");
                }
                this.count = value;
            }
        }

        public void Run()
        {
            while (ticks < this.count)
            {
                Thread.Sleep(this.Interval);
                ticks++;
                tE();
            }
        }
    }

    public class TimerTest
    {
        public static void Main()
        {
            TimerEvent te1 = new TimerEvent(ExecuteEach3Seconds);
            Timer tm1 = new Timer(3, te1);

            TimerEvent te2 = new TimerEvent(SecondExecuteEach5Seconds);
            Timer tm2 = new Timer(5, te2);

            Timer tm3 = new Timer(new TimerEvent(delegate() { Console.WriteLine("Hi each second"); }));

            Thread timer1Thread = new Thread(new ThreadStart(tm1.Run));
            timer1Thread.Start();

            Thread timer2Thread = new Thread(new ThreadStart(tm2.Run));
            timer2Thread.Start();

            Thread timer3Thread = new Thread(new ThreadStart(tm3.Run));
            timer3Thread.Start();
        }

        private static void ExecuteEach3Seconds()
        {
            Console.WriteLine("You can only see me every 3rd second");
        }

        private static void SecondExecuteEach5Seconds()
        {
            Console.WriteLine("I am here every 5 seconds lol");
        }
    }
}
