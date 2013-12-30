//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints 
//the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.


namespace _17.TimeAfter630Hours
{

    using System;
    using System.Globalization;

    class TimeAfter630Hours
    {
        static void Main()
        {
            string str = "24.01.2013 23:00:00";

            DateTime date = DateTime.ParseExact(str, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            date = date.AddHours(6.5);

            Console.WriteLine("{0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);
        }
    }
    
}
