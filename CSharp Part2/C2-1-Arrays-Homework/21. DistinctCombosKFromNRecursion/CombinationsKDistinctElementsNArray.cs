//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
//N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}


using System;

class CombinationsKDistinctElementsNArray
{
    static void Combinations(int nRange, int kCount, int[] arrInput, int position, int start)
    {
        if (position == kCount)
        {
            Console.Write(arrInput[0]);
            for (int i = 1; i < kCount; i++)
            {
                Console.Write(", " + arrInput[i]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = start; i <= nRange; i++)
            {
                arrInput[position] = i;
                Combinations(nRange, kCount, arrInput, position + 1, start + 1);
                start++;
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] combos = new int[k];
        Combinations(n, k, combos, 0, 1);
    }
}

