using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    class Crossword
    {
        static List<string[]> allCombos = new List<string[]>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] allWords = new string[2 * n];
            for (int i = 0; i < allWords.Length; i++)
            {
                allWords[i] = Console.ReadLine();
            }

            string[] answer = new string[n];

            PutWords(allWords, answer, 0);

            if (allCombos.Count == 0)
            {
                Console.WriteLine("NO SOLUTION!");
            }
            else if (allCombos.Count==1)
            {
                Print(0);
            }
            else
            {
                int combinationToUse = 0;
                string[] combs = new string[allCombos.Count];
                for (int i = 0; i < allCombos.Count; i++)
                {
                    string currcomb = null;
                    for (int j = 0; j < n; j++)
                    {
                        currcomb += allCombos[i][j];
                    }
                    combs[i] = currcomb;
                    
                }
                string theComb = combs.Min();
                combinationToUse = Array.IndexOf(combs,theComb);
                Print(combinationToUse);
            }

        }

        private static void Print(int index)
        {
            foreach (string item in allCombos[index])
            {
                Console.WriteLine(item);
            }
        }

        private static void PutWords(string[] allWords, string[] answer, int line)
        {
            if (line==allWords.Length/2)
            {
                if (CheckWords(allWords,answer,line))
                {
                    string[] currCombo = new string[answer.Length];
                    Array.Copy(answer, currCombo, answer.Length);
                    allCombos.Add(currCombo);
                }
                return;
            }
            if (CheckWords(allWords,answer,line))
            {
                for (int word = 0; word < allWords.Length; word++)
                {
                    answer[line] = allWords[word];
                    PutWords(allWords, answer, line + 1);
                }
            }

        }

        private static bool CheckWords(string[] allWords, string[] answer,int line)
        {
            bool toUse = true;
            int linesSoFar = line;
            if (line==0)
            {
                return true;
            }
            for (int col = 0; col < allWords.Length/2; col++)
            {
                string parts = null;
                for (int linez = 0; linez < linesSoFar; linez++)
                {
                    parts += answer[linez][col];
                }
                int mainIndex = -1;
                for (int j = 0; j < allWords.Length; j++)
                {
                    int currindex = allWords[j].IndexOf(parts);
                    if (currindex>mainIndex)
                    {
                        mainIndex = currindex;
                        break;
                    }
                }
                if (mainIndex < 0)
                {
                    return false;
                }
            }
            return toUse;
        }

    }
}
