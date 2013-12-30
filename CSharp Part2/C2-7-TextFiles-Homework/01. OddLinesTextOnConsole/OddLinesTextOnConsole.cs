//Write a program that reads a text file and prints on the console its odd lines.


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class OddLinesTextOnConsole
{
    static void Main()
    {
        int currLine = 0;
        using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
        {
            string line = reader.ReadLine();
            while (line!=null)
            {
                currLine++;
                if (currLine%2 == 1)
                {
                    Console.WriteLine(line);
                }
                line = reader.ReadLine();
            }
        }
    }
}

