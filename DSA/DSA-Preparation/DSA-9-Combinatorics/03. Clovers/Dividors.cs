//task on link http://downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%203.zip
namespace _03.Clovers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dividors
    {
        public static int answer = int.MaxValue;
        public static int ccanswer = int.MaxValue;

        public static List<int> digitsList = new List<int>();

        public static void Main()
        {
            int digCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < digCount; i++)
            {
                var curr = int.Parse(Console.ReadLine());
                if (curr != 0)
                {
                    digitsList.Add(curr);
                }
            }

            Solve(0, new bool[digitsList.Count], new int[digitsList.Count]);

            Console.WriteLine(answer);

        }

        private static void Solve(int index, bool[] used, int[] vector)
        {
            if (index == vector.Length)
            {
                int number = GetNumber(vector);
                int currAnswer = CheckDelitels(number);
                if (currAnswer <= ccanswer)
                {
                    if (currAnswer < ccanswer)
                    {
                        ccanswer = currAnswer;
                        answer = number;
                    }
                    else
                    {
                        answer = Math.Min(answer, number);
                    }
                }

                return;
            }

            for (int i = 0; i < digitsList.Count; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    var old = vector[index];
                    vector[index] = digitsList[i];

                    Solve(index + 1, used, vector);

                    vector[index] = old;
                    used[i] = false;
                }
            }
        }

        public static int CheckDelitels(int number)
        {
            int answer = 0;

            for (int i = 1; i <= 99999; i++)
            {
                if (number % i == 0)
                {
                    answer++;
                }
            }

            return answer;
        }

        private static int GetNumber(int[] num)
        {
            int number = 0;
            for (int i = 0; i < num.Length; i++)
            {
                number += num[num.Length - 1 - i] * (int)Math.Pow(10, i);
            }
            return number;
        }
    }
}
