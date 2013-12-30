//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;
using System.Linq;

class MergeSort
{
    static void Main()
    {
        //int[] allInput = ArrayInput(); //enter the array from console
        int[] array = new int[] {1,5,2,8,1,4,9}; // easier Testing

        int[] sortedInput = MergeThoseDamnArrays(array); // :)

        PrintArray(sortedInput);
    }

    private static int[] MergeThoseDamnArrays(int[] array)
    {
        if (array.Length <= 1) // array of 1 or less elements is always sorted !
        {
            return array;
        }

        int half = array.Length / 2; 

        int[] leftHalf = new int[half];
        int[] rightHalf = new int[array.Length - half];

        for (int i = 0; i < half; i++) //just filling the left array with the first half of the input array
        {
            leftHalf[i] = array[i];
        }

        for (int i = half; i < array.Length; i++)
        {
            rightHalf[i - half] = array[i];//and filling the right array with the rest of the input array
        }

        leftHalf = MergeThoseDamnArrays(leftHalf);   //recursevly calls until only 1 element exists
        rightHalf = MergeThoseDamnArrays(rightHalf); //same here

        return MergeAndSortRightLeft(leftHalf, rightHalf);
    }

    private static int[] MergeAndSortRightLeft(int[] leftHalf, int[] rightHalf)
    {
        int[] sortedArray = new int[leftHalf.Length + rightHalf.Length];

        int currLeftIndex = 0; //these two will save the position on each array which we will compare
        int currRightIndex = 0;

        for (int i = 0; i < sortedArray.Length; i++)
        {
            if (currRightIndex == rightHalf.Length) //stands for if we used all of the elements in one array
            {
                sortedArray[i] = leftHalf[currLeftIndex];
                currLeftIndex++;
            }                                                   //if the element is <= so it must be in the answer before
            else if (currLeftIndex < leftHalf.Length && leftHalf[currLeftIndex] <= rightHalf[currRightIndex])
            {       //we dont want to go out of array boundary
                sortedArray[i] = leftHalf[currLeftIndex]; 
                currLeftIndex++;//next time we will check the next element
            }
            else //if none of the above are true so we are out of left elements OR the left element is bigger than the right
            {
                sortedArray[i] = rightHalf[currRightIndex];
                currRightIndex++;//next time we will check the next element
            }
        }

        return sortedArray;
    }

    private static int[] ArrayInput()
    {
        Console.Write("Enter array size: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
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
        

    
}

