using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordsCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new StreamReader("text.txt").ReadToEnd().ToLower();
            var words = text.Split(new char[] { '.', '!', '?', ';', ' ', ':',',','-' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = words.Where(w => w.Length > 1).GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());

            foreach (var kv in dict)
            {
                Console.WriteLine("{0} -> {1}",kv.Key, kv.Value);
            }
        }
    }
}
