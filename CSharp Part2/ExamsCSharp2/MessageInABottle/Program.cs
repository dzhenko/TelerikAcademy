using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageInABottle
{
    class Program
    {
        static Dictionary<string, char> decripter = new Dictionary<string, char>();

        static StringBuilder chipCreator = new StringBuilder();
        static string code;
        
        static List<string> answers = new List<string>();

        static void Main()
        {
            code = Console.ReadLine();

            string chiper = Console.ReadLine();
            
            StringBuilder chipCreator = new StringBuilder();

            char currLetter = chiper[0];

            for (int i = 1; i < chiper.Length; i++)
            {
                if (Char.IsDigit(chiper[i]))
                {
                    chipCreator.Append(chiper[i]);
                }
                else
                {
                    decripter.Add(chipCreator.ToString(), currLetter);
                    currLetter = chiper[i];
                    chipCreator.Clear();
                }
            }
            decripter.Add(chipCreator.ToString(), currLetter);

            chipCreator.Clear();

            Solve(0,chipCreator);

            Console.WriteLine(answers.Count);

            answers.Sort();

            foreach (var item in answers)
            {
                Console.WriteLine(item);
            }
        }

        private static void Solve(int index, StringBuilder chipCreator)
        {
            if (index == code.Length)
            {
                answers.Add(chipCreator.ToString());
                return;
            }

            foreach (var item in decripter)
            {
                if (code.Substring(index).StartsWith(item.Key))
                {
                    chipCreator.Append(item.Value);

                    Solve(index + item.Key.Length, chipCreator);

                    chipCreator.Length--;
                }
            }
        }
    }
}
