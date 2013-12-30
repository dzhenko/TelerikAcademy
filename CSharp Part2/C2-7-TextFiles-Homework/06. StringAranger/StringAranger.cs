//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
//	Ivan			George
//	Peter			Ivan
//	Maria			Maria
//	George			Peter


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class StringAranger
{
    static void Main()
    {
        StreamReader read = new StreamReader(@"..\..\input.txt");
        StreamWriter write = new StreamWriter(@"..\..\output.txt");

        List<string> allLines = new List<string>();
        string currLine = read.ReadLine();

        while (currLine!=null)
        {
            allLines.Add(currLine);
            currLine = read.ReadLine();
        }
        read.Close();
        allLines.Sort();

        foreach (string line in allLines)
        {
            write.WriteLine(line);
        }
        write.Close();
    }
}
