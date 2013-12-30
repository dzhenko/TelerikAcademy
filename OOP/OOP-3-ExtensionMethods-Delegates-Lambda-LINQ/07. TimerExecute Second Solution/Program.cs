//Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace TimerExecuteActionAtEachSecond
{
    using System;
    using System.Threading;

    public delegate void TimerEvent();

    public class Timer
    {
        public delegate void MethodDelegate();
        public int Delay { get; set; }
        public MethodDelegate MethodProperty { get; set; }

        public Timer(int delay,MethodDelegate invokedMethod)
        {
            this.Delay = delay;
            this.MethodProperty = invokedMethod;

            Thread newThread = new Thread(() =>
            {
                while (1 == 1)
                {
                    this.MethodProperty();
                    Thread.Sleep(this.Delay * 1000);
                }
            });
            newThread.Start();
        }
    }

    public class TimerTest
    {
        public static void Main()
        {
            Timer t1 = new Timer(1, Click1);

            Timer t2 = new Timer(2, Click2);

            Timer t3 = new Timer(3, Click3);
        }
        public static void Click1()
        {
            Console.WriteLine("Click 1");
        }
        public static void Click2()
        {
            Console.WriteLine("Click 2");
        }

        public static void Click3()
        {
            Console.WriteLine("Click 3");
        }
    }
}
