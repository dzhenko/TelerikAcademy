//task on link http://downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%201.zip

//answer is 2 to the power of the number of * chars, but we will also show all the possibilities with recursion

namespace _01.BinaryPasswords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BinaryPassword
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int counter = 0;

            foreach (var ch in input)
            {
                if (ch == '*')
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine(1);
                return;
            }
            ulong answer = 1;
            for (int i = 0; i < counter; i++)
            {
                answer *= 2;
            }
            Console.WriteLine(answer);
            //bgCoder
            return;
            Solve(input.ToCharArray(), 0,ref counter);

            Console.WriteLine(counter);
        }

        private static void Solve(char[] input, int index, ref int globalCounter)
        {
            if (index == input.Length)
            {
                Console.WriteLine(new string(input));
                globalCounter++;
                return;
            }

            if (input[index] == '*')
            {
                input[index] = '0';
                Solve(input, index + 1, ref globalCounter);
                input[index] = '1';
                Solve(input, index + 1, ref globalCounter);
                input[index] = '*';
            }
            else
            {
                Solve(input, index + 1, ref globalCounter);
            }
        }
    }
}
