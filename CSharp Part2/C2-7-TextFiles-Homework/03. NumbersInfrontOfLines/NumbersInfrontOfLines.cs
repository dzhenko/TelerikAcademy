//Write a program that reads a text file and inserts line numbers in front of each of its lines. 
//The result should be written to another text file.


using System;
using System.IO;


class NumbersInfrontOfLines
{
    static void Main()
    {
        string filelocation = @"..\..\input.txt";

        string destinationfile = @"..\..\output.txt";

        StreamWriter writer = new StreamWriter(destinationfile, false);

        StreamReader reader = new StreamReader(filelocation);

        using (reader)
        {
            using (writer)
            {
                string currLine = reader.ReadLine();
                int line = 1;
                while (currLine != null)
                {
                    writer.WriteLine(line + ". " + currLine);
                    currLine = reader.ReadLine();
                    line++;
                }
            }
        }
    }
}

