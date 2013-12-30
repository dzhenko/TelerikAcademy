//Write a program that reads a list of words from a file words.txt and finds how many times each of the words is 
//contained in another file test.txt. The result should be written in the file result.txt and 
//the words should be sorted by the number of their occurrences in descending order. 
//Handle all possible exceptions in your methods.


namespace _13.WordsInTextFileOcurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    class WordsInTextFileOcurences
    {
        static List<string> wordsToSearchFor = new List<string>();
        static Dictionary<string, int> countedWords = new Dictionary<string, int>();

        static void Main()
        {
            ReadListOfWordsToSearch();

            CountWordsSearchedFor();

            WriteResult();
        }

        private static void WriteResult()
        {
            var sorted = countedWords.OrderByDescending(x => x.Value);
            StreamWriter writer = new StreamWriter(@"..\..\result.txt", false);
            using (writer)
            {
                foreach (var word in sorted)
                {
                    try
                    {
                        writer.WriteLine("{0} -> {1}", word.Key, word.Value);
                    }
                    catch 
                    {
                        throw new ArgumentException("Something is wrong!");
                    }
                }
            }
        }

        private static void CountWordsSearchedFor()
        {
            StreamReader reader1 = new StreamReader(@"..\..\test.txt");
            using (reader1)
            {
                try
                {
                    string currLine = reader1.ReadLine();
                    while (currLine != null)
                    {
                        string[] words = currLine.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in words)
                        {
                            if (countedWords.ContainsKey(word))
                            {
                                countedWords[word]++;
                            }
                        }
                        currLine = reader1.ReadLine();
                    }
                }
                catch 
                {
                    throw new ArgumentException("Something is wrong here!");
                }
                
            }
        }

        private static void ReadListOfWordsToSearch()
        {
            try
            {
                StreamReader reader2 = new StreamReader(@"..\..\words.txt");
                using (reader2)
                {
                    string currLine = reader2.ReadLine();
                    while (currLine!=null)
                    {
                        wordsToSearchFor.Add(currLine);
                        currLine = reader2.ReadLine();
                    }
                }
                foreach (string word in wordsToSearchFor)
                {
                    countedWords.Add(word, 0);
                }
            }
            catch
            {
                throw new ArgumentException("Something is wrong here!");
            }
        }
    }
}
