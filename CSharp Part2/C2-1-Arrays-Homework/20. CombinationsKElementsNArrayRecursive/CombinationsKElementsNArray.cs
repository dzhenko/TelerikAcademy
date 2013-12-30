//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
//N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}


using System;

class CombinationsKElementsNArray
{
    static void Combinations(int nRange,int kCount, int[] arrInput, int position) //recursion time
    {
        if (position == kCount)
        {
            Console.Write(arrInput[0]);
            for (int i = 1; i < kCount; i++)
            {
                Console.Write(", "+arrInput[i]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = 1; i <= nRange; i++)
            {
                arrInput[position] = i;
                Combinations(nRange, kCount, arrInput, position + 1);
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] combos = new int[k];
        Combinations(n,k, combos,0);
    }
}

