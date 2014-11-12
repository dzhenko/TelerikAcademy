using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _4_RecoverMessage
{
    class Program
    {
        static List<char> allAnswers = new List<char>();

        static SortedDictionary<char, SortedSet<char>> graph = new SortedDictionary<char, SortedSet<char>>();

        static Dictionary<char, int> occurs = new Dictionary<char, int>();

        static OrderedSet<char> startElements = new OrderedSet<char>();
        static OrderedSet<char> endElements = new OrderedSet<char>();

        static void Main(string[] args)
        {
            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var line = Console.ReadLine();
                var ocurDict = new Dictionary<char, int>();

                // adding connections
                for (int j = 0; j < line.Length; j++)
                {
                    var ch = line[j];

                    ocurDict[ch] = ocurDict.ContainsKey(ch) ? ocurDict[ch] + 1 : 1;

                    if (!graph.ContainsKey(ch))
                    {
                        graph.Add(ch, new SortedSet<char>());
                    }
                }

                foreach (var kv in ocurDict)
                {
                    occurs[kv.Key] = occurs.ContainsKey(kv.Key) ? Math.Max(occurs[kv.Key], ocurDict[kv.Key]) : ocurDict[kv.Key];
                }
            }

            var bag = new OrderedSet<char>(startElements.Difference(endElements));

            while (bag.Count > 0)
            {
                var nextQueue = new OrderedSet<char>();
                foreach (var nextPoint in bag)
                {
                    allAnswers.Add(nextPoint);
                    nextQueue.AddMany(graph[nextPoint]);
                }

                bag = nextQueue;
            }

            Console.WriteLine(string.Join("", allAnswers));
        }
    }
}