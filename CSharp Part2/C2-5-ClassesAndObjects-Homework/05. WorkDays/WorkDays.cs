//Write a method that calculates the number of workdays between today and given date, passed as parameter. 
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

namespace _05.WorkDays
{
    using System;

    class WorkDays
    {
        static void Main()
        {
            DateTime[] holidays = {new DateTime(2013,11,2) , new DateTime(2013,10,3) };

            Console.WriteLine("Enter Date (format DD.MM.YYYY) : ");

            string[] rawInput = Console.ReadLine().Split('.');

            int workDays = 0;

            DateTime targetDay = new DateTime(int.Parse(rawInput[2]), int.Parse(rawInput[1]), int.Parse(rawInput[0]));

            DateTime startDay = DateTime.Today;

            if (targetDay < startDay)
            {
                DateTime temp = startDay;
                startDay = targetDay;
                targetDay = startDay;
            }

            for (int i = 0; i < (targetDay-startDay).Days; i++)
            {
                bool isAHoliday = false;
                DateTime currDate = startDay.AddDays(i);
                if (currDate.DayOfWeek != DayOfWeek.Saturday && currDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    foreach (DateTime day in holidays)
                    {
                        if (day == currDate)
                        {
                            isAHoliday = true;
                        }
                    }
                }
                if (!isAHoliday)
                {
                    workDays++;
                }
            }

            Console.WriteLine(workDays);

            
        }
    }
}
