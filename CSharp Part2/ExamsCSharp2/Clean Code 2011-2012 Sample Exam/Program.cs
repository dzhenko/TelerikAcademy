using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Code_2011_2012_Sample_Exam
{
    class Program
    {
        static void Main()
        {
            string[] input = new string[int.Parse(Console.ReadLine())];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (Console.ReadLine());
            }

            StringBuilder output = new StringBuilder();
            StringBuilder currLineToAppend = new StringBuilder();
            bool multyComment = false;
            bool instring = false;
            bool insecondstring = false;

            foreach (string currLine in input)
            {
                for (int i = 0; i < currLine.Length; i++)
                {
                    if (currLine[i] =='/' && !instring && !multyComment && !insecondstring)
                    {
                        if (i + 1 < currLine.Length && currLine[i + 1] == '/' && currLine[i + 2] != '/')
                        {
                            goto endOfThisLine;
                        }
                        else if (i+1 < currLine.Length && currLine[i+1] == '*')
                        {
                            multyComment = true;
                            i++;
                            continue;
                        }
                    }
                    else if (currLine[i] == '*' && !instring && !insecondstring)
                    {
                        if (i + 1 < currLine.Length && currLine[i + 1] == '/')
                        {
                            multyComment = false;
                            i++;
                            continue;
                        }
                    }
                    else if (currLine[i] == '@' && !multyComment && !instring && !insecondstring)
                    {
                        if (i+1 < currLine.Length && currLine[i+1] == '\"')
                        {
                            insecondstring = true;
                            i++;
                            currLineToAppend.Append("@");
                        }
                    }
                    else if (currLine[i] == '\"')
                    {
                        if (insecondstring)
                        {
                            insecondstring = false;
                        }
                        else if (i-1 > 0 && currLine[i-1] != '\\' )
                        {
                            instring = !instring;
                        }
                    }
                    if (!multyComment)
                    {
                        currLineToAppend.Append(currLine[i]);
                    }
                }
            endOfThisLine:
                if (!string.IsNullOrWhiteSpace(currLineToAppend.ToString()) && !multyComment)
                {
                    output.AppendLine(currLineToAppend.ToString());
                    currLineToAppend.Clear();
                }
                if (string.IsNullOrWhiteSpace(currLineToAppend.ToString()))
                {
                    currLineToAppend.Clear();
                }
            }
            Console.Write(output.ToString());
        }

    }
}
