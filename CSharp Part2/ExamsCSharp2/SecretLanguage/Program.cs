using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretLanguage
{
    class Program
    {
        static string[] words;
        static string target;
        static string[] sortedWords;

        static string StringRearanger(string input)
        {
            char[] symbs = input.ToCharArray();
            Array.Sort(symbs);
            return new string(symbs);
        }

        static void Main()
        {
            target = Console.ReadLine();
            words = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim('\"')).ToArray();
            sortedWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                sortedWords[i] = StringRearanger(words[i]);
            }

            int[] answers = new int[target.Length + 1].Select(x=>x = 999999).ToArray();
            answers[0] = 0;
            

            for (int currSymb = 0; currSymb < target.Length; currSymb++)
            {
                for (int word = 0; word < words.Length; word++)
                {
                    if (currSymb >= words[word].Length - 1) 
                    {
                        string pieceOfTarget = target.Substring(currSymb - sortedWords[word].Length + 1, sortedWords[word].Length);
                        if (sortedWords[word] == StringRearanger(pieceOfTarget))
                        {
                            if (answers[currSymb + 1 - sortedWords[word].Length] != 999999)
                            {
                                answers[currSymb + 1] = Math.Min(answers[currSymb + 1 - sortedWords[word].Length] + Price(words[word], pieceOfTarget),
                                    answers[currSymb+1]);
                            }
                        }
                    }
                }
            }
            if (answers[answers.Length-1] == 999999)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(answers[answers.Length - 1]);
            }
            

        }

        private static int Price(string original, string sorted)
        {
            int price = 0;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != sorted[i])
                {
                    price++;
                }
            }
            return price;
        }

        
    }
}
