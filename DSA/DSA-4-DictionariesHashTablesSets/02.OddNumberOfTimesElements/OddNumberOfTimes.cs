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
            var array = new string[] {"C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"
            ,"SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#","SQL","PHP","PHP","SQL","SQL","JAVA","C#","C#"};

            FirstWay(array);

            //very slow
            SecondWay(array);
        }
  
        private static void SecondWay(string[] array)
        {
            Console.WriteLine("2nd way:");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string[] secondWay = array.GroupBy(x => x)
                                      .ToDictionary(g => g.Key, g => g.Count())
                                      .Where(x => x.Value % 2 != 0)
                                      .Select(x => x.Key)
                                      .ToArray();
            Console.WriteLine(sw.ElapsedTicks);
            Console.WriteLine(string.Join(", ", secondWay));
        }
  
        private static void FirstWay(string[] array)
        {
            Console.WriteLine("1st way:");
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
            Console.WriteLine(sw.ElapsedTicks);
            Console.WriteLine(string.Join(", ", answer));
        }
    }
}
