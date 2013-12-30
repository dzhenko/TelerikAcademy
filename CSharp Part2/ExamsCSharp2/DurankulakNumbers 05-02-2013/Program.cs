using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<string> digits = new List<string>();
        List<int> realDigits = new List<int>();
        for (char i = 'A'; i <= 'Z'; i++)
        {
            digits.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'f'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits.Add(i + "" + j);
            }
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLower(input[i]))
            {
                sb.Append(input[i]);
            }
            else
            {
                sb.Append(input[i]);
                realDigits.Add(digits.IndexOf(sb.ToString()));
                sb.Clear();
            }
        }

        ulong answer = 0;

        for (int i = 0; i < realDigits.Count; i++)
        {
            answer += (uint)realDigits[i] * (ulong)Math.Pow(168, realDigits.Count - 1 - i);
        }

        Console.WriteLine(answer);
    }
}

