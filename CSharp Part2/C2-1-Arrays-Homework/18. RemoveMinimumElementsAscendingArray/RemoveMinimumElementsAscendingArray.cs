//* Write a program that reads an array of integers and removes from it a minimal number of elements in such way 
//that the remaining array is sorted in increasing order. Print the remaining sorted array. Example:
//	{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

class RemoveMinimumElementsAscendingArray
{
    static void Main()
    {
        int[] array = new int[] { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

        int originalLength = array.Length;

        for (int elementsToRemove = 1; elementsToRemove < array.Length - 1; elementsToRemove++)
        {
            RemoveElements(elementsToRemove, array, originalLength);
        }
    }

    private static void RemoveElements(int elementsToRemove, int[] array, int originalLenghth)
    {
        if (array.Length == originalLenghth-elementsToRemove)//we have removed enough elements
        {
            if(CheckIfArrayIsSorted(array))
            {
                PrintArray(array);
                Environment.Exit(0);
            }
            return;
        }

        List<int> currArrayCreator = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            currArrayCreator.Clear();
            for (int j = 0; j < array.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }
                currArrayCreator.Add(array[j]);
            }
            int[] currArray = currArrayCreator.ToArray();
            RemoveElements(elementsToRemove, currArray, originalLenghth);
        }
    }

    private static void PrintArray(int[] array)
    {
        Console.Write(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            Console.Write(", ");
            Console.Write(array[i]);
        }
        Console.WriteLine();
    }

    private static bool CheckIfArrayIsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i-1])
            {
                return false;
            }
        }
        return true;
    }
}

