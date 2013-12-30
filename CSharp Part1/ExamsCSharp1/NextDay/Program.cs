using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            DateTime answer = new DateTime(y, m, d);

            answer = answer.AddDays(1);

            d = answer.Day;
            m = answer.Month;
            y = answer.Year;
            Console.WriteLine(d+"."+m+"."+y);
        }
    }
}
