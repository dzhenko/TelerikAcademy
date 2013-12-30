//Write a program that reads a string from the console and lists all different words 
//in the string along with information how many times each word is found.



namespace _22.WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WordsCounter
    {
        static void Main()
        {
            string source = Console.ReadLine();
            string[] allWords = source.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> answer = new Dictionary<string, int>();
            foreach (string word in allWords)
            {
                if (answer.ContainsKey(word))
                {
                    answer[word]++;
                }
                else
                {
                    answer.Add(word, 1);
                }
            }
            Console.WriteLine();
            var orderedByTimes = answer.OrderByDescending(x => x.Value);
            foreach (var word in orderedByTimes)
            {
                Console.WriteLine("{0} -> {1} ",word.Key,word.Value);
            }
        }
    }
}
