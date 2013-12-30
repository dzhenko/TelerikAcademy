using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        string formater = Console.ReadLine();

        int openedBrackets = 0;

        StringBuilder sb = new StringBuilder();
        StringBuilder answer = new StringBuilder();
        bool whiteUsed = false;
        for (int z = 0; z < lines; z++)
        {
            string currLine = Console.ReadLine();

            for (int i = 0; i < currLine.Length; i++)
            {
                if (currLine[i] == '{' || currLine[i] == '}')
                {
                    if (currLine[i] == '{')
                    {
                        if (!string.IsNullOrWhiteSpace(sb.ToString()))
                        {
                            for (int aa = 0; aa < openedBrackets; aa++)
                            {
                                answer.Append(formater);
                            }
                            answer.AppendLine(sb.ToString());
                            sb.Clear();
                        }
                        for (int aa = 0; aa < openedBrackets; aa++)
                        {
                            answer.Append(formater);
                        }
                        answer.AppendLine("{");
                        openedBrackets++;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sb.ToString()))
                        {
                            for (int aa = 0; aa < openedBrackets; aa++)
                            {
                                answer.Append(formater);
                            }
                            answer.AppendLine(sb.ToString());
                            sb.Clear();
                        }
                        openedBrackets--;
                        for (int aa = 0; aa < openedBrackets; aa++)
                        {
                            answer.Append(formater);
                        }
                        answer.AppendLine("}");
                    }
                }
                else if (currLine[i] == ' ')
                {
                    if (whiteUsed)
                    {
                        continue;
                    }
                    else if (!string.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append(currLine[i]);
                        whiteUsed = true;
                    }
                }
                else if (currLine[i] != '\t')
                {
                    sb.Append(currLine[i]);
                    whiteUsed = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                for (int aa = 0; aa < openedBrackets; aa++)
                {
                    answer.Append(formater);
                }
                answer.AppendLine(sb.ToString());
                sb.Clear();
            }
        }
        Console.WriteLine(answer.ToString());
    }
}

