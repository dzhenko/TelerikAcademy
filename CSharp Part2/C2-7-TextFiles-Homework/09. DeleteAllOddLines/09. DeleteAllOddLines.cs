//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.Collections.Generic;
using System.IO;

class DeleteAllOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");


        List<string> allEvenLines = new List<string>();

        string currLine = null;

        while (1 == 1)
        {
            currLine = reader.ReadLine();//Line1 (1/3/5/7)
            currLine = reader.ReadLine();//Line2 (4/6/8/10)
            if (currLine == null)
            {
                break;
            }
            allEvenLines.Add(currLine);
        }
        reader.Close();

        StreamWriter writer = new StreamWriter(@"..\..\input.txt", false); // after closing the reader
        foreach (string line in allEvenLines)
        {
            writer.WriteLine(line);
        }
        writer.Close();
     }
}

