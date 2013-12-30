using System;
using System.Globalization;

class InvalidRangeExceptionTesting
{
    static void Main()
    {
        int startInt = 1;
        int endInt = 100;

        int pointInInt;
        Console.WriteLine("Enter Point in int");

        try
        {
            pointInInt = int.Parse(Console.ReadLine());
            if ((pointInInt < startInt) || (pointInInt > endInt))
            {
                throw new InvalidRangeException<int>("damn boy! Please consider the range!",startInt, endInt);
            }
        }
        catch (InvalidRangeException<int> e)
        {
            Console.WriteLine("Range should be [{0}...{1}]!",e.Start,e.End);
            Console.WriteLine(e.Message);
        }

        DateTime startDate = new DateTime(1880, 01, 01);
        DateTime endDate = DateTime.Now;

        DateTime dateTime;
        CultureInfo provider = CultureInfo.InvariantCulture;
        Console.WriteLine("Enter your birthDate (Format : 06/15/2008 )");

        try
        {
            dateTime = DateTime.ParseExact(Console.ReadLine(),"d",provider);
            if ((dateTime < startDate) || (dateTime > endDate))
            {
                throw new InvalidRangeException<DateTime>("damn boy! Please consider the range!", startDate, endDate);
            }
        }
        catch (InvalidRangeException<DateTime> e)
        {
            Console.WriteLine("Range should be [{0}...{1}]!", e.Start, e.End);
            Console.WriteLine(e.Message);
        }
    }
}

