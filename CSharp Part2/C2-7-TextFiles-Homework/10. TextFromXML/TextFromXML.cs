//Write a program that extracts from given XML file all the text without the tags

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class TextFromXML
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");
        StreamWriter writer = new StreamWriter(@"..\..\output.txt", false);

        string line = reader.ReadLine();

        while (line != null)
        {
            WriteOnlyText(line,writer);
            line = reader.ReadLine();
        }
        writer.Close();
        reader.Close();
    }

    private static void WriteOnlyText(string line,StreamWriter writer)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '<')
            {
                while ((i+1 < line.Length)&&(line[i] != '>'))
                {
                    i++;
                }
            }
            else
            {
                writer.Write(line[i]);
            }
        }
        writer.WriteLine();
    }
}
