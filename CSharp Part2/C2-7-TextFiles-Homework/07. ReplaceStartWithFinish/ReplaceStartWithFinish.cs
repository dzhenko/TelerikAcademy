//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
//Ensure it will work with large files (e.g. 100 MB).


using System;
using System.Collections.Generic;
using System.IO;

class ReplaceStartWithFinish
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\input.txt");

        StreamWriter writer = new StreamWriter(@"..\..\output.txt",false); //i take it that a new text file is requared

        string currLine = reader.ReadLine();
        string tempLine = null;
        string extraTempLine = null;
        int indexStart = 0;
        int secondStart = 0;
        while (currLine != null)
        {
        here:
            indexStart = currLine.IndexOf("Start");
            if (indexStart != -1)
            {
                tempLine = (currLine.Substring(0,indexStart) + "Finish" + 
                    currLine.Substring(indexStart+5,currLine.Length-indexStart-5));

                secondStart = tempLine.IndexOf("start");
                if (secondStart != -1)
                {
                    extraTempLine = (tempLine.Substring(0, secondStart) + "фinish" +
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
                if (secondStart != -1)
                {
                    extraTempLine = (currLine.Substring(0, secondStart) + "Finish" +
                        currLine.Substring(secondStart + 5, currLine.Length - secondStart - 5));
                }
                else
                {
                    extraTempLine = currLine;
                }
            }
            int check1 = extraTempLine.IndexOf("Start");
            int check2 = extraTempLine.IndexOf("start");
            if ((check1 != -1) || (check2 != -1))
            {
                currLine = extraTempLine;
                goto here;//i know its bad but if there are more than 2 words start it has to continue replacing ..
            }
            writer.WriteLine(extraTempLine);
            currLine = reader.ReadLine();
        }

        reader.Close();
        writer.Close();
    }
}

