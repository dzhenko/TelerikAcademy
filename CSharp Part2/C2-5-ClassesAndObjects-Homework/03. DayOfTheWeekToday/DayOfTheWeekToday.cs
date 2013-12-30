//Write a program that prints to the console which day of the week is today. Use System.DateTime.


namespace _03.DayOfTheWeekToday
{
    using System;

    class DayOfTheWeekToday
    {
        public static void Main()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}
