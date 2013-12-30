using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb1 = new StringBuilder();
        
        string rawInput = Console.ReadLine();
        string chipher = Console.ReadLine();

        //chipher and rawInput proccessing
        if (chipher.Length <= rawInput.Length) // cycle is around the rawInput
        {
            int chipherIndex = -1;
            for (int i = 0; i < rawInput.Length; i++)
            {
                chipherIndex++;
                if (chipherIndex >= chipher.Length)
                {
                    chipherIndex = 0;
                }
                sb1.Append((char)(((rawInput[i] - 65) ^ (chipher[chipherIndex] - 65)) + 65));
            }
        }
        else
        {
            char[] rawToChar = rawInput.ToCharArray();
            int rawIndex = -1;
            for (int i = 0; i < chipher.Length; i++)
            {
                rawIndex++;
                if (rawIndex >= rawInput.Length)
                {
                    rawIndex = 0;
                }
                rawToChar[rawIndex] = (char)(((rawToChar[rawIndex] - 65) ^ (chipher[i] - 65)) + 65);
            }
            sb1.Append(new string(rawToChar));
        }
        string rawCriptedText = sb1.ToString() + chipher + "*";
        sb1.Clear();

        int repeatingCounter = 0;
        char currChar = rawCriptedText[0];

        for (int i = 0; i < rawCriptedText.Length; i++)
        {
            if (currChar == rawCriptedText[i])
            {
                repeatingCounter++;
            }
            else
            {
                if (repeatingCounter == 1)
                {
                    sb1.Append(currChar);
                    currChar = rawCriptedText[i];
                    repeatingCounter = 0;
                }
                else if (repeatingCounter == 2)
                {
                    sb1.Append(currChar);
                    sb1.Append(currChar);
                    currChar = rawCriptedText[i];
                    repeatingCounter = 0;
                }
                else
                {
                    sb1.Append(repeatingCounter);
                    repeatingCounter = 0;
                    sb1.Append(currChar);
                    currChar = rawCriptedText[i];
                }
                i--;
            }
        }
        sb1.Append(chipher.Length);
        Console.WriteLine(sb1);
    }
}

