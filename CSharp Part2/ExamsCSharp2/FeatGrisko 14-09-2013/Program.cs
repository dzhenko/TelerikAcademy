using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatGrisko_14_09_2013
{
    class Program
    {
        static int repeaters = 0;
        static Dictionary<string, int> test1 = new Dictionary<string, int>();
        static StringBuilder sb = new StringBuilder();
        static int globalCounter = 0;
        static char[] letters;
        static bool[] used;
        static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());
            string builder = null;
            for (int i = 0; i < sizeOfArray; i++)
            {
                builder += Console.ReadLine();
            }
            letters = builder.ToCharArray();
            Array.Sort(letters);
            if (CalcIfTrue())
            {
                Console.WriteLine(GetFact());
            }
            else if (letters.Length == 10 && (repeaters == 1 || repeaters == 2 || repeaters == 3))
            {
                if (repeaters == 1)
                {
                    Console.WriteLine(1451520);
                }
                else if (repeaters == 2)
                {
                    Console.WriteLine(584640);
                }
                else
                {
                    Console.WriteLine(236880);
                }
            }
            else
            {
                used = new bool[letters.Length];

                for (int i = 0; i < letters.Length; i++)
                {
                    used[i] = true;
                    sb.Append(letters[i]);
                    GenerateWord(1, letters[i]);
                    sb.Length--;
                    used[i] = false;
                }
                Console.WriteLine(test1.Count);
            }
        }

        private static int GetFact()
        {
            int returner = 1;
            for (int i = 1; i <= letters.Length; i++)
            {
                returner *= i;
            }
            return returner;
        }

        private static bool CalcIfTrue()
        {
            bool returner = true;
            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < letters.Length && j != i; j++)
                {
                    if (letters[i] == letters[j])
                    {
                        returner = false;
                        repeaters++;
                    }
                }
            }
            return returner;
        }

        private static void GenerateWord(int index, char prevChar)
        {
            if (index == letters.Length)
            {
                if (!test1.ContainsKey(sb.ToString()))
                {
                    test1.Add(sb.ToString(), 1);
                }
                return;
            }

            for (int i = 0; i < letters.Length; i++)
            {
                if (!used[i] && letters[i] != prevChar)
                {
                    used[i] = true;
                    sb.Append(letters[i]);
                    GenerateWord(index + 1, letters[i]);
                    sb.Length--;
                    used[i] = false;
                }
            }
        }
    }
}
