//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
//Ensure it will work with large files (e.g. 100 MB).
//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
//Modify the solution of the previous problem to replace only whole words (not substrings).


using System;
using System.Collections.Generic;
using System.IO;

class ReplaceStartWholeWordsOnly
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");

        StreamWriter writer = new StreamWriter(@"..\..\output.txt", false); //i take it that a new text file is requared

        string currLine = reader.ReadLine();
        string tempLine = null;
        string extraTempLine = null;
        int indexStart = 0;
        int secondStart = 0;
        while (currLine != null)
        {
        here:
            indexStart = currLine.IndexOf("Start");
            if ((indexStart != -1) && (IsTheWordWhole(currLine,indexStart)))
            {
                tempLine = (currLine.Substring(0, indexStart) + "Finish" +
                    currLine.Substring(indexStart + 5, currLine.Length - indexStart - 5));

                secondStart = tempLine.IndexOf("start");
                if ((secondStart != -1) && (IsTheWordWhole(tempLine,secondStart)))
                {
                    extraTempLine = (tempLine.Substring(0, secondStart) + "Finish" +
                        tempLine.Substring(secondStart + 5, tempLine.Length - secondStart - 5));
                }
                else
                {
                    extraTempLine = tempLine;
                }
            }
            else
            {

                secondStart = currLine.IndexOf("start");
                if ((secondStart != -1) && (IsTheWordWhole(currLine,secondStart)))
                {
                    extraTempLine = (currLine.Substring(0, secondStart) + "Finish" +
                        currLine.Substring(secondStart + 5, currLine.Length - secondStart - 5));
                }
                else
                {
                    extraTempLine = currLine;
                }
            }
            

            writer.WriteLine(extraTempLine);
            currLine = reader.ReadLine();
        }

        reader.Close();
        writer.Close();
    }

    private static bool IsTheWordWhole(string inputline, int index)
    {
        bool wordIsWhole = false;
        if ((index+5 < inputline.Length)&&(inputline[index+5] == ' '))
        {
            wordIsWhole = true;
        }
        else if ((index-1 > -1)&&(inputline[index-1] == ' '))
        {
            wordIsWhole = true;
        }
        else if (index==inputline.Length-5)
        {
            wordIsWhole = true;
        }
        return wordIsWhole;
    }
}

