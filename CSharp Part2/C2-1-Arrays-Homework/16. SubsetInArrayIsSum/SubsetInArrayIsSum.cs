//* We are given an array of integers and a number S. 
//Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
//	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)


using System;
using System.Collections.Generic;

class SubsetInArrayIsSum
{
    public static int[] array = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
    public static int sum = 15;

    static void Main()
    {
        for (int numsToTake = 1; numsToTake < array.Length; numsToTake++)
        {
            bool[] used = new bool[array.Length];
            int[] vector = new int[numsToTake];
            GenerateSubSetSum(0, used, vector);
        }

        Console.WriteLine("No");//if we reach here so not good
    }

    public static void GenerateSubSetSum(int index, bool[] used, int[] vector)
    {
        if (index == vector.Length)
        {
            int currSum = 0;
            foreach (var item in vector)
            {
                currSum += item;
            }
            if (currSum == sum)
            {
                Console.WriteLine("Yes");
                Console.Write(vector[0]);
                for (int i = 1; i < vector.Length; i++)
                {
                    Console.Write(", ");
                    Console.Write(vector[i]);
                }
                Console.WriteLine(" = " + sum);
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
        if (sumYet > sum)
        {
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                vector[index] = array[i];

                GenerateSubSetSum(index + 1, used, vector);

                used[i] = false;
            }
        }
    }
}

