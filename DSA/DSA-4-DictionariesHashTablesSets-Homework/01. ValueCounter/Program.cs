using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueCounter
{
    class Program
    {
        static void Main()
        {
            var array = new[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dict = array.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());

            foreach (var keyValue in dict)
            {
                Console.WriteLine("{0} -> {1} times", keyValue.Key, keyValue.Value);
            }

            //// or in one line...
            //Console.WriteLine(string.Join(Environment.NewLine, 
            //    new[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 }
            //        .GroupBy(x => x)
            //        .ToDictionary(gr => gr.Key, gr => gr.Count())
            //        .Select(kv => kv.Key + " -> " + kv.Value + "times")));
        }
    }
}
