//Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
//Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
//-2.5  2 times
//3  4 times
//4  3 times

namespace _01.DoublesCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    public class DoubleCounter
    {
        public static void Main()
        {
            var array = GetArrayWithRandomDoubleValues();

            Solve1stWay(array);

            Console.WriteLine();

            Solve2ndWay(array);
        }

        private static double[] GetArrayWithRandomDoubleValues()
        {
            var array = new double[1000000];
            var values = new double[] { 1.5, 4.9, -4.6, -2.5, 3.1, -3.77, 4.85, 3.1, -2.5 };
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = values[rnd.Next(0, values.Length)];
            }

            return array;
        }

        private static void PrintResult(IDictionary<double, int> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} --> {1} times", pair.Key, pair.Value);
            }
        }

        private static void Solve1stWay(IEnumerable<double> array)
        {
            var sw = new Stopwatch();
            sw.Start();

            var dict1 = new Dictionary<double, int>();

            foreach (var num in array)
            {
                if (dict1.ContainsKey(num))
                {
                    dict1[num]++;
                }
                else
                {
                    dict1.Add(num, 1);
                }
            }

            sw.Stop();
            Console.WriteLine("1st way: (" + sw.ElapsedTicks + " stopwatch ticks)");

            PrintResult(dict1);
        }

        private static void Solve2ndWay(IEnumerable<double> array)
        {
            var sw = new Stopwatch();
            sw.Start();

            var dict2 = array.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            sw.Stop();
            Console.WriteLine("1st way: (" + sw.ElapsedTicks + " stopwatch ticks)");

            PrintResult(dict2);
        }
    }
}
