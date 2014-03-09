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

    public class DoubleCounter
    {
        public static void Main()
        {
            var array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Console.WriteLine("1st way:");

            var dict1 = GetDictionaryFromIEnum1(array);

            PrintResult(dict1);



            Console.WriteLine("2nd way:");

            var dict2 = GetDictionaryFromIEnum2(array);

            PrintResult(dict2);
        }

        private static Dictionary<double, int> GetDictionaryFromIEnum1(IEnumerable<double> array)
        {
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
            return dict1;
        }

        private static Dictionary<double, int> GetDictionaryFromIEnum2(IEnumerable<double> array)
        {
            var dict2 = array.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            return dict2;
        }

        private static void PrintResult(IDictionary<double,int> dict)
        {
            foreach (var pair in dict)
	        {
                Console.WriteLine("{0} --> {1} times",pair.Key,pair.Value);
	        }
        }
    }
}
