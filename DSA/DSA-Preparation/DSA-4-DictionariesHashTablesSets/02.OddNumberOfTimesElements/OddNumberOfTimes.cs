//Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
//{C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

namespace _02.OddNumberOfTimesElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    public class OddNumberOfTimes
    {
        public static void Main()
        {
            var array = GetRandomArrayWithStrings();

            FirstWay(array);

            SecondWay(array);
        }

        private static string[] GetRandomArrayWithStrings()
        {
            var array = new string[1000000];
            var values = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = values[rnd.Next(0, values.Length)];
            }

            return array;
        }
  
        private static void SecondWay(string[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string[] secondWay = array.GroupBy(x => x)
                                      .ToDictionary(g => g.Key, g => g.Count())
                                      .Where(x => x.Value % 2 != 0)
                                      .Select(x => x.Key)
                                      .ToArray();

            Console.WriteLine("2nd way: (" + sw.ElapsedTicks + " stopwatch ticks)");
            Console.WriteLine(string.Join(", ", secondWay));
        }
  
        private static void FirstWay(string[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var dict1 = new Dictionary<string, int>();

            foreach (var str in array)
            {
                if (dict1.ContainsKey(str))
                {
                    dict1[str]++;
                }
                else
                {
                    dict1.Add(str, 1);
                }
            }

            HashSet<string> oddElements = new HashSet<string>();

            foreach (var pair in dict1)
            {
                if (pair.Value % 2 != 0)
                {
                    oddElements.Add(pair.Key);
                }
            }

            string[] answer = new string[oddElements.Count];

            int counter = 0;
            foreach (var str in oddElements)
            {
                answer[counter] = str;
                counter++;
            }

            Console.WriteLine("1st way: (" + sw.ElapsedTicks + " stopwatch ticks)");
            Console.WriteLine(string.Join(", ", answer));
        }
    }
}
