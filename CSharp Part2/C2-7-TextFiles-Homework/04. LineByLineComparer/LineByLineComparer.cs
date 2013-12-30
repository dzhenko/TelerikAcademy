//Write a program that compares two text files line by line and prints the number of lines that 
//are the same and the number of lines that are different. Assume the files have equal number of lines.


using System;
using System.IO;


class LineByLineComparer
{
    static void Main()
    {
        string filelocation1 = @"..\..\input1.txt";

        string filelocation2 = @"..\..\input2.txt";

        StreamReader reader1 = new StreamReader(filelocation1);
        StreamReader reader2 = new StreamReader(filelocation2);

        int samelines = 0;
        int differentlines = 0;

        string line1 = reader1.ReadLine();
        string line2 = reader2.ReadLine();

        while (line1 != null)
        {
            if (line1 == line2)
            {
                samelines++;
            }
            else
            {
                differentlines++;
            }

            line1 = reader1.ReadLine();
            line2 = reader2.ReadLine();
        }
        Console.WriteLine("The number of same lines are {0}",samelines);
        Console.WriteLine("The number of different lines are {0}",differentlines);


    }
}

