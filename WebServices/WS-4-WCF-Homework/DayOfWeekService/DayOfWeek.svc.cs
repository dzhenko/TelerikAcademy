using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DayOfWeekService
{
    public class DayOfWeekGetter : IDayOfWeekGetter
    {
        public string GetDayOfWeek(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case System.DayOfWeek.Friday: return "Петък";
                case System.DayOfWeek.Monday: return "Понеделник";
                case System.DayOfWeek.Saturday: return "Събота";
                case System.DayOfWeek.Sunday: return "Неделя";
                case System.DayOfWeek.Thursday: return "Четвъртък";
                case System.DayOfWeek.Tuesday: return "Вторник";
                case System.DayOfWeek.Wednesday: return "Сряда";
                default: return null;
            }
        }
    }
}
