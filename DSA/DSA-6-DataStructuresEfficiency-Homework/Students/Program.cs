using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Students
{
    class Program
    {
        static void Main()
        {
            var allStudentsText = new StreamReader("students.txt");

            var dict = new OrderedMultiDictionary<string, Tuple<string, string>>(true);

            var line = allStudentsText.ReadLine();

            while (line != null)
            {
                var tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                if (!dict.ContainsKey(tokens[2]))
                {
                    dict.Add(tokens[2], new Tuple<string, string>(tokens[0], tokens[1]));
                }
                else
                {
                    dict[tokens[2]].Add(new Tuple<string, string>(tokens[0], tokens[1]));
                }

                line = allStudentsText.ReadLine();
            }

            foreach (var kv in dict)
            {
                Console.Write(kv.Key + ": ");
                Console.WriteLine(string.Join(", ", kv.Value.OrderBy(x => x.Item2).ThenBy(x => x.Item1).Select(x => x.Item1 + " " + x.Item2)));
            }
        }
    }
}
