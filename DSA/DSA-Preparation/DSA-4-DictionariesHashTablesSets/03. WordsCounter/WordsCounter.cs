//Write a program that counts how many times each word from given text file words.txt appears in it. 
//The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. Example:
//This is the TEXT. Text, text, text – THIS TEXT! Is this the text?

//	is  2
//	the  2
//	this  3
//	text  6


namespace _03.WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordsCounter
    {
        public const string FileNotFoundErrorMessage = "File text.txt not found";

        public const string FilePath = "text.txt";

        public static void Main()
        {
            var dict = GetDictionaryWithWordsCounted();

            PrintResult(dict);
        }
  
        private static Dictionary<string, int> GetDictionaryWithWordsCounted()
        {
            var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            var separators = new char[] { ' ', ',', ';', '.', '!', '?', ':', ';'};

            try
            {
                StreamReader sr = new StreamReader(FilePath);

                using (sr)
                {
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var word in words)
                        {
                            word.Trim(separators);
                            if (word.Length == 1)
                            {
                                continue;
                            }

                            if (dict.ContainsKey(word))
                            {
                                dict[word]++;
                            }
                            else
                            {
                                dict.Add(word, 1);
                            }
                        }

                        line = sr.ReadLine();
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine(FileNotFoundErrorMessage);
            }

            return dict;
        }

        private static void PrintResult(Dictionary<string, int> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} --> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
