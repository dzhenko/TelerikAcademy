using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //readData
            int maxWord = 0;
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>(n);
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
                if (words[i].Length > maxWord)
                {
                    maxWord = words[i].Length;
                }
            }

            StringBuilder answer = new StringBuilder();
            //moving
            for (int i = 0; i < n; i++)
            {
                int newPos = words[i].Length % (n + 1);
                if (newPos > i)
                {
                    words.Insert(newPos, words[i]);
                    words.RemoveAt(i);
                }
                if (newPos < i)
                {
                    words.Insert(newPos, words[i]);
                    words.RemoveAt(i + 1);
                }
            }

            for (int i = 0; i < maxWord; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (i < words[j].Length)
                    {
                        answer.Append(words[j][i]);
                    }
                }
            }
            Console.WriteLine(answer.ToString());
        }
    }
}
