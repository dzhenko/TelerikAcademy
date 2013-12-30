//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class QuickSortAlgorith
{
    public static void Main()
    {
        List<int> array = ArrayInput();

        List<int> sortedArray = QuickSort(array);

        PrintArray(sortedArray);
    }

    public static List<int> QuickSort(List<int> input)
    {
        if (input.Count < 2)
        {
            return input; //array of 1 or 0 elements is sorted
        }

        if (input.Count == 2)
        {
            if (input[0] <= input[1])
            {
                return input; //this array is sorted
            }
            else
            {
                int temp = input[0];
                input.RemoveAt(0);
                input.Add(temp);
                return input; //switch the elements and return them
            }
        }


        List<int> leftPart = new List<int>();
        List<int> rightPart = new List<int>();
        List<int> pivot = new List<int>();

        int currpivot = input[1];

        foreach (int element in input)
        {
            if (element < currpivot)
            {
                leftPart.Add(element);
            }
            else if (element>currpivot)
            {
                rightPart.Add(element);
            }
            else
            {
                pivot.Add(element); // in case there are more than 1 equal pivots selected
            }
        }

        leftPart = QuickSort(leftPart);
        rightPart = QuickSort(rightPart);

        return ConcatinateListsAndPivot(leftPart, pivot, rightPart);
    }

    private static List<int> ConcatinateListsAndPivot(List<int> leftPart, List<int> pivot, List<int> rightPart)
    {
        List<int> answer = new List<int>();

        foreach (var item in leftPart)
        {
            answer.Add(item);
        }

        foreach (var item in pivot)
        {
            answer.Add(item);
        }

        foreach (var item in rightPart)
        {
            answer.Add(item);
        }

        return answer;
    }

    public static void PrintArray(List<int> array)
    {
        Console.Write(array[0]);

        for (int i = 1; i < array.Count; i++)
        {
            Console.Write(", ");
            Console.Write(array[i]);
        }
        Console.WriteLine();
    }

    public static List<int> ArrayInput()
    {
        //input
        Console.Write("Enter array size: ");
        int n = int.Parse(Console.ReadLine());
        List<int> array = new List<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element {0}: ", i + 1);
            array.Add(int.Parse(Console.ReadLine()));
        }
        return array;
    }
}

