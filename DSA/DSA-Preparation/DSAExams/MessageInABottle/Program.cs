using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageInABottle
{
    public class Program
    {
        public static Dictionary<string, char> charsByNum = new Dictionary<string, char>();

        public static SortedSet<string> messages = new SortedSet<string>();

        public static StringBuilder sb = new StringBuilder();

        public static string code;

        public static void Main()
        {
            code = Console.ReadLine();

            GenerateDict();

            Solve(code, sb);

            Console.WriteLine(messages.Count);

            Console.WriteLine(string.Join(Environment.NewLine,messages));
        }
  
        private static void GenerateDict()
        {
            string chiper = Console.ReadLine();

            var currChar = chiper[0];

            for (int i = 1; i < chiper.Length; i++)
            {
                if (char.IsDigit(chiper[i]))
                {
                    sb.Append(chiper[i]);
                }
                else
                {
                    charsByNum.Add(sb.ToString(), currChar);
                    sb.Clear();
                    currChar = chiper[i];
                }
            }

            charsByNum.Add(sb.ToString(), currChar);

            sb.Clear();
        }

        private static void Solve(string subCode, StringBuilder answer)
        {
            if (subCode.Length == 0)
            {
                messages.Add(answer.ToString());
                return;
            }

            StringBuilder curr = new StringBuilder();

            for (int i = 0; i < subCode.Length; i++)
            {
                curr.Append(subCode[i]);

                if (charsByNum.ContainsKey(curr.ToString()))
                {
                    answer.Append(charsByNum[curr.ToString()]);
                    Solve(subCode.Substring(curr.Length), answer);
                    answer.Length--;
                }
            }
        }
    }
}
