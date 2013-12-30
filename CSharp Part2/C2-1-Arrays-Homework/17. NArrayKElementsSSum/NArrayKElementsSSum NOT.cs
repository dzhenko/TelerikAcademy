//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
//Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;
using System.Collections.Generic;

class SubsetInArrayIsSum
{

    static void Main()
    {
        Console.Write("Enter N : ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K : ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter S : ");
        int s = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }

        
        bool[] used = new bool[n];
        int[] vector = new int[k];
        GenerateSubSetSum(array,s,0, used, vector);
        

        Console.WriteLine("Not Such Sum");//if we reach here so not good
    }

    public static void GenerateSubSetSum(int[] array, int s, int index, bool[] used, int[] vector)
    {
        if (index == vector.Length)
        {
            int currSum = 0;
            foreach (var item in vector)
            {
                currSum += item;
            }
            if (currSum == s)
            {
                Console.WriteLine("Yes");
                Console.Write(vector[0]);
                for (int i = 1; i < vector.Length; i++)
                {
                    Console.Write(" + ");
                    Console.Write(vector[i]);
                }
                Console.WriteLine(" = " + s);
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        int sumYet = 0;
        foreach (var item in vector)
        {
            sumYet += item;
        }
        if (sumYet > s)
        {
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                vector[index] = array[i];

                GenerateSubSetSum(array,s,index + 1, used, vector);

                used[i] = false;
            }
        }
    }
}

