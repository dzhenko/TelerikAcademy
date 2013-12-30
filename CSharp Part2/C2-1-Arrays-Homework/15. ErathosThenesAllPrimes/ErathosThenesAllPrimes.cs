// Write a program that finds all prime numbers in the range [1...10 000 000]. 
// Use the sieve of Eratosthenes algorithm (find it in Wikipedia).


using System;
using System.Collections.Generic;

class ErathosThenesAllPrimes
{
    static void Main()
    {
        bool[] arr = new bool[10000001];

        int max = (int)Math.Sqrt(arr.Length);

        for (int i = 2; i <= max; i++)
        { 
            if (!arr[i])
            {
                for (int j = i * i; j < arr.Length; j += i)
                {
                    arr[j] = true;
                }
            }
        }

        for (int i = 2; i < arr.Length; i++)
        {
            if (!arr[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}

