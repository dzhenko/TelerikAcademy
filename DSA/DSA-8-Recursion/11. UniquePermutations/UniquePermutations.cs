//* Write a program to generate all permutations with repetitions of given multi-set. 
//For example the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
//{ 1, 3, 5, 5 }	{ 1, 5, 3, 5 }
//{ 1, 5, 5, 3 }	{ 3, 1, 5, 5 }
//{ 3, 5, 1, 5 }	{ 3, 5, 5, 1 }
//{ 5, 1, 3, 5 }	{ 5, 1, 5, 3 }
//{ 5, 3, 1, 5 }	{ 5, 3, 5, 1 }
//{ 5, 5, 1, 3 }	{ 5, 5, 3, 1 }
//Ensure your program efficiently avoids duplicated permutations. 
//Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.

namespace _11.UniquePermutations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class UniquePermutations
    {
        public static HashSet<string> answer = new HashSet<string>();

        public static int[] multiSet = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5};

        public static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            Permute(new int[multiSet.Length], new bool[multiSet.Length], 0);
            Console.WriteLine("Time: {0}",sw.Elapsed);
            Console.WriteLine(string.Join(Environment.NewLine,answer));
        }

        public static void Permute(int[] vector, bool[] used, int index)
        {
            if (index == vector.Length)
            {
                answer.Add(string.Join(", ", vector));
                return;
            }

            for (int i = 0; i < multiSet.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    vector[index] = multiSet[i];

                    Permute(vector, used, index + 1);

                    used[i] = false;
                }
            }
        }
    }
}
