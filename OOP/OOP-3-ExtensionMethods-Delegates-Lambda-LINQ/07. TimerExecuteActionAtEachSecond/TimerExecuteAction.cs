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

        public int ticks = 0;

        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value * 1000;
            }
        }

        public Timer(int count, int interval, TimerEvent TE) //constructor with both thicks and interval in seconds
        {
            this.count = count;
            this.Interval = interval;
            this.tE = TE;
        }
        public Timer(int interval, TimerEvent TE) //constructor with only interval in seconds and max thicks
        {
            this.Interval = interval;
            this.count = int.MaxValue;
            this.tE = TE;
        }
        public Timer(TimerEvent TE)//empty constructor - max thicks and 1 second interval
        {
            this.count = int.MaxValue;
            this.Interval = 1;
            this.tE = TE;
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
