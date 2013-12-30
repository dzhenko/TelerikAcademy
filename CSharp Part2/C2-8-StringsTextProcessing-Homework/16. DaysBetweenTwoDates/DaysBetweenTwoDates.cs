//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2004
//Distance: 4 days

namespace _16.DaysBetweenTwoDates
{

    using System;
    using System.Text;

    class DaysBetweenTwoDates
    {
        static void Main()
        {
            Console.WriteLine("Write The First date (dd.mm.yyy format): ");
            string input1Raw = Console.ReadLine();

            Console.WriteLine("Write The Second date (dd.mm.yyy format): ");
            string input2Raw = Console.ReadLine();

            string[] Date1 = input1Raw.Split('.');
            string[] Date2 = input2Raw.Split('.');

            DateTime start = new DateTime(int.Parse(Date1[2]),int.Parse(Date1[1]),int.Parse(Date1[0]));
            DateTime end = new DateTime(int.Parse(Date2[2]), int.Parse(Date2[1]), int.Parse(Date2[0]));

            int daysBetween = (int)(end - start).TotalDays;
            Console.WriteLine("Distance: {0} days",daysBetween);

        }
    }
}
