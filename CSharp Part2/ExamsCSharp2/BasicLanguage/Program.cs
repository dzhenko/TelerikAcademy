using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BasicLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string currLine;
            while (true)
            {
                currLine = Console.ReadLine();
                sb.Append(currLine);
                if (currLine.Contains("EXIT;"))
                {
                    break;
                }
            }
            List<string> allCommands = new List<string>();

            string allInput = sb.ToString();

            sb.Clear();

            foreach (var symb in allInput)
            {
                sb.Append(symb);
                if (symb == ';')
                {
                    allCommands.Add(sb.ToString());
                    sb.Clear();
                }
            }

            sb.Clear();

            foreach (var linecCommands in allCommands)
            {
                int times = 1;
                string[] currComnads = linecCommands.Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var thecommand in currComnads)
                {
                    string singleCommand = thecommand.TrimStart();
                    if (singleCommand.StartsWith("FOR"))
                    {
                        currLine = singleCommand.Substring(singleCommand.IndexOf('(') + 1);
                        if (currLine.Contains(','))
                        {
                            string[] twoParams = currLine.Split(',');
                            times = times * (int.Parse(twoParams[1]) - int.Parse(twoParams[0]) + 1);
                        }
                        else
                        {
                            times = times * int.Parse(currLine);
                        }
                    }
                    else if (singleCommand.StartsWith("PRINT"))
                    {
                        currLine = singleCommand.Substring(singleCommand.IndexOf('(') + 1);

                        for (int i = 0; i < times; i++)
                        {
                            sb.Append(currLine);
                        }
                    }
                    else if (singleCommand.StartsWith("EXIT"))
                    {
                        Console.WriteLine(sb.ToString());
                        return;
                    }
                }
            }
        }
    }
}
