using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        StringBuilder answer = new StringBuilder();
        StringBuilder currLine = new StringBuilder();
        int linesCount = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        List<string> allWords = new List<string>();
        for (int i = 0; i < linesCount; i++)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToArray();
            allWords.AddRange(words);
        }

        for (int i = 0; i < allWords.Count; i++)
        {
            List<string> wordsToBeAppended = new List<string>();
            int spacesUsed = allWords[i].Length;
            wordsToBeAppended.Add(allWords[i]);

        here:
            if (i+1 < allWords.Count && allWords[i+1].Length + spacesUsed + 1 <= max)
            {
                i++;
                wordsToBeAppended.Add(allWords[i]);
                spacesUsed += allWords[i].Length + 1;
                goto here;
            }
            else if (wordsToBeAppended.Count != 1)
            {
                int spacesToUse = 1;
                int spacesLeft = max - spacesUsed;
                while (spacesLeft >= wordsToBeAppended.Count - 1)
                {
                    spacesToUse++;
                    spacesLeft -= (wordsToBeAppended.Count - 1);
                }
                currLine.Append(wordsToBeAppended[0]);
                for (int h = 1; h < wordsToBeAppended.Count; h++)
                {
                    currLine.Append(new string(' ', spacesToUse));
                    if (spacesLeft > 0)
                    {
                        currLine.Append(" ");
                        spacesLeft--;
                    }
                    currLine.Append(wordsToBeAppended[h]);
                }
                answer.AppendLine(currLine.ToString());
                currLine.Clear();
            }
            else
            {
                answer.AppendLine(wordsToBeAppended[0]);
            }
        }

        Console.Write(answer.ToString());
    }
}

