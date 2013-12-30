using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<string[]> commands = new List<string[]>();
        List<int> commandLine = new List<int>();
        string currLine = null;
        int indexOfIdent = 0;
        while (true)
        {
            currLine = Console.ReadLine();
            if (currLine=="RUN")
            {
                break;
            }

            indexOfIdent = currLine.IndexOf(' ');
            commandLine.Add(int.Parse(currLine.Substring(0, indexOfIdent)));
            currLine = (currLine.Substring(indexOfIdent + 1));
            commands.Add(currLine.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries));
        }
        int v = 0;
        int w = 0;
        int x = 0;
        int y = 0;
        int z = 0;
        StringBuilder answer = new StringBuilder();

        for (int i = 0; i < commands.Count; i++)
        {
            string[] current = commands[i];
        here:
            if (current[0] == "IF")
            {
                string command = null;
                int iferr = 1;
                while (current[iferr] != "THEN")
                {
                    command += current[iferr];
                    iferr++;
                }
                int indexOfOperator = command.IndexOf('=');
                if (indexOfOperator < 0)
	            {   
		            indexOfOperator = command.IndexOf('<');
                    if (indexOfOperator < 0)
                    {
		                indexOfOperator = command.IndexOf('>');
                    }
	            }
                string leftIffer = command.Substring(0, indexOfOperator);
                string rightIffer = command.Substring(indexOfOperator + 1);

                int left = 0;
                int right = 0;
                switch (leftIffer)
                {
                    case "V": left = v;  break;
                    case "W": left = w;  break;
                    case "X": left = x;  break;
                    case "Y": left = y;  break;
                    case "Z": left = z;  break;
                    default: left = int.Parse(leftIffer);
                        break;
                }
                switch (rightIffer)
                {
                    case "V": right = v; break;
                    case "W": right = w; break;
                    case "X": right = x; break;
                    case "Y": right = y; break;
                    case "Z": right = z; break;
                    default: right = int.Parse(rightIffer);
                        break;
                }

                bool ToExecute = false;
                if (command[indexOfOperator] == '=')
                {
                    if (left == right)
                    {
                        ToExecute = true;
                    }
                }
                else if (command[indexOfOperator] == '<')
                {
                    if (left < right)
                    {
                        ToExecute = true;
                    }
                }
                else
                {
                    if (left > right)
                    {
                        ToExecute = true;
                    }
                }
                if (ToExecute)
                {
                    iferr++;
                    string[] LeftToDo = new string[current.Length - iferr];
                    for (int tiredOfVars = 0; tiredOfVars < LeftToDo.Length; tiredOfVars++)
                    {
                        LeftToDo[tiredOfVars] = current[tiredOfVars + iferr];
                    }
                    current = null;
                    current = LeftToDo;
                    goto here;
                }
            }
            else if (current[0] == "STOP")
            {
                goto there;
            }
            else if (current[0] == "CLS")
            {
                answer.Clear();
            }
            else if (current[0] == "PRINT")
            {
                string LineToAppend = null;
                switch (current[1])
                {
                    case "V": LineToAppend = v.ToString() + "\n"; break;
                    case "W": LineToAppend = w.ToString() + "\n"; break;
                    case "X": LineToAppend = x.ToString() + "\n"; break;
                    case "Y": LineToAppend = y.ToString() + "\n"; break;
                    case "Z": LineToAppend = z.ToString() + "\n"; break;
                }
                answer.Append(LineToAppend);
            }
            else if (current[0] == "GOTO")
            {
                i = commandLine.IndexOf((int.Parse(current[1])));
                i--;
            }
            else 
            {
                string operations = null;
                foreach (string item in current)
	            {
		            operations+= item;
	            }

                int sighn = 0;
                if (operations[2] == '-')
                {
                    sighn = 1;
                }
                int right1 = 0;
                int right2 = 0;
                int right = 0;
                int indexOfSighn = 2 + sighn;
                switch (operations[2 + sighn])
                {
                    case 'V': right1 = v; indexOfSighn ++; break;
                    case 'W': right1 = w; indexOfSighn ++; break;
                    case 'X': right1 = x; indexOfSighn ++; break;
                    case 'Y': right1 = y; indexOfSighn ++; break;
                    case 'Z': right1 = z; indexOfSighn ++; break;
                    default: string thispart = null;
                        int helpindexer = 2 + sighn;
                        while (helpindexer < operations.Length && (operations[helpindexer] != '-') && (operations[helpindexer] != '+'))
                        {
                            thispart = thispart + operations[helpindexer];
                            helpindexer++;
                            indexOfSighn++;
                        }
                        right1 = int.Parse(thispart); break;
                }
                if (sighn==1)
                {
                    right1 = right1 * (-1);
                }


                if (indexOfSighn >= operations.Length)
                {
                    right = right1;
                }
                else
                {
                    switch (operations[indexOfSighn + 1])
                    {
                        case 'V': right2 = v; break;
                        case 'W': right2 = w; break;
                        case 'X': right2 = x; break;
                        case 'Y': right2 = y; break;
                        case 'Z': right2 = z; break;
                        default: string thispart = null;
                            int helpindexer = indexOfSighn + 1;
                            while (helpindexer < operations.Length)
                            {
                                thispart = thispart + operations[helpindexer];
                                helpindexer++;
                            }
                            right2 = int.Parse(thispart); break;
                    }
                }
                if (indexOfSighn < operations.Length)
                {
                    if (operations[indexOfSighn] == '+')
                    {
                        right = right1 + right2;
                    }
                    else
                    {
                        right = right1 - right2;
                    }
                }
                

                switch (operations[0])
                {
                    case 'V': v = right; break;
                    case 'W': w = right; break;
                    case 'X': x = right; break;
                    case 'Y': y = right; break;
                    case 'Z': z = right; break;
                }
            }
            
        }
        there:
        Console.Write(answer.ToString());
    }
}

