//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

namespace _01.IsYearALeapOne
{
    using System;

    class IsYearALeapOne
    {
        public static void Main()
        {
            Console.Write("Enter the year : ");
            int year = int.Parse(Console.ReadLine());
            bool isYearLeap = DateTime.IsLeapYear(year);
            Console.Write("The year {0} is ",year);
            if (!isYearLeap)
            {
                Console.Write("NOT ");
            }

            Console.WriteLine("a leap year");
        }
    }
}
