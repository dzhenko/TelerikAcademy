//Write a program that reads a string from the console and replaces all series of consecutive 
//identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

namespace _23.RepeatingLettersReplacer
{
    using System;
    using System.Text;

    class RepeatingLettersReplacer
    {
        static void Main()
        {
            string input = "aaaaabbbbbcdddeeeedssaa";

            StringBuilder answer = new StringBuilder();
            answer.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i-1])
                {
                    answer.Append(input[i]);
                }
            }
            Console.WriteLine(answer.ToString());
        }
    }
}
