using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MovingLetters
{
    static StringBuilder sb = new StringBuilder();
    static char[] rawData;
    static void Main(string[] args)
    {
        string[] rawAllInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int longestWord = rawAllInput.Max(x => x.Length);

        for (int i = 0; i < longestWord; i++)
        {
            for (int j = 0; j < rawAllInput.Length; j++)
            {
                if (i < rawAllInput[j].Length)
                {
                    sb.Append(rawAllInput[j][rawAllInput[j].Length - 1 - i]);
                }
            }
        }
        rawData = sb.ToString().ToCharArray();

        for (int curr = 0; curr < rawData.Length; curr++)
        {
            int calcNewIndex = GetNewIndex(curr);
            char orgchar = rawData[curr];
            if (calcNewIndex > curr)
            {
                for (int i = curr; i < calcNewIndex; i++)
                {
                    rawData[i] = rawData[i + 1];
                }
                rawData[calcNewIndex] = orgchar;
            }
            else if (calcNewIndex < curr)
            {
                for (int i = curr; i > calcNewIndex; i--)
                {
                    rawData[i] = rawData[i - 1];
                }
                rawData[calcNewIndex] = orgchar;
            }
        }

        Console.WriteLine(new string(rawData));
    }

    private static int GetNewIndex(int curr)
    {
        int newPos = curr;
        int timesToMove = (rawData[curr] - 64);
        if (char.IsLower(rawData[curr]))
        {
            timesToMove -= 32;
        }
        newPos += timesToMove;
        if (newPos >= rawData.Length)
        {
            newPos = newPos % rawData.Length;
        }
        return newPos;
    }
}

