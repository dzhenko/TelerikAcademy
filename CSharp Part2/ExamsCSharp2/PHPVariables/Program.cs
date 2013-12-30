using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPVariables
{
    class Program
    {
        static List<string> validVariables = new List<string>();

        static void Main()
        {
            StringBuilder sb = new StringBuilder();

            bool multycomment = false;


            string currLine = Console.ReadLine();

            while (true)
            {
                bool singleString = false;
                bool doubleString = false;
            readnewline:
                currLine = Console.ReadLine();
                //end
                if (currLine == "?>")
                {
                    break;
                }
                //single line comment //
                for (int i = 0; i < currLine.Length; i++)
                {
                    if (currLine[i] == '/' && !multycomment && !singleString && !doubleString)
                    {
                        if (i + 1 < currLine.Length)
                        {
                            if (currLine[i + 1] == '/')
                            {
                                goto readnewline;
                            }
                        }
                    }
                    //single line comment #
                    if (currLine[i] == '#' && !multycomment && !singleString && !doubleString)
                    {
                        goto readnewline;
                    }
                    //start of multyline comment
                    if (currLine[i] == '/' && !multycomment && !singleString && !doubleString)
                    {
                        if (i+1 < currLine.Length)
                        {
                            if (currLine[i + 1] == '*' )
                            {
                                multycomment = true;
                            }
                        }
                    }
                    //end of multyline comment
                    if (currLine[i] == '*' && !singleString && !doubleString)
                    {
                        if (i + 1 < currLine.Length)
                        {
                            if (currLine[i + 1] == '/')
                            {
                                multycomment = false;
                            }
                        }
                    }
                    if (currLine[i] == '\'' && !multycomment)
                    {
                        if (doubleString)
                        {
                            continue;
                        }
                        else
                        {
                            singleString = !singleString;
                        }
                    }
                    if (currLine[i] == '\"' && !multycomment)
                    {
                        if (singleString)
                        {
                            continue;
                        }
                        else
                        {
                            doubleString = !doubleString;
                        }
                    }
                    if (currLine[i] == '$' && !multycomment)
                    {
                        if (i - 1 > 0 && currLine[i - 1] == '\\' && i - 2 > 0 && currLine[i - 2] != '\\') 
                        {
                            continue;
                        }
                        else
                        {
                            if (i + 1 < currLine.Length && (currLine[i+1] == '_' || char.IsLetter(currLine[i+1])))
                            {
                                i++;
                                sb.Append(currLine[i]);
                                while ( (i+1 < currLine.Length) && (char.IsLetterOrDigit(currLine[i+1]) || currLine[i+1] == '_' ) )
                                {
                                    i++;
                                    sb.Append(currLine[i]);
                                }
                                if (!validVariables.Contains(sb.ToString()))
                                {
                                    validVariables.Add(sb.ToString());
                                }
                                sb.Clear();
                            }
                        }
                    }
                }

            }

            validVariables.Sort(StringComparer.Ordinal);
            StreamWriter sw = new StreamWriter("output.txt",false);
            sw.WriteLine(validVariables.Count);
            //Console.WriteLine(validVariables.Count);
            foreach (var item in validVariables)
            {
                sw.WriteLine(item);
                //Console.WriteLine(item);
            }
            sw.Close();
        }
    }
}
