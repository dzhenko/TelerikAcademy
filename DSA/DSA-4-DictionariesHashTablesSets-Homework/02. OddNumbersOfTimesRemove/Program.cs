using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OddNumbersOfTimesRemove
{
    class Program
    {
        static void Main()
        {
            var array = new[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var dict = array.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());

            var newArray = dict.Select(x => x.Key).Where(x => dict[x] % 2 != 0);

            Console.WriteLine(string.Join(", ", newArray));
        }
    }
}
