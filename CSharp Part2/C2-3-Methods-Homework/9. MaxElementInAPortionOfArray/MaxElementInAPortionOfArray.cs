//Write a method that return the maximal element in a portion of array of integers starting at given index. 
//Using it write another method that sorts an array in ascending / descending order.


using System;

class MaxElementInAPortionOfArray
{
    static void ArrayInput(int[] array)
    {

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element " + (i) + " : ");
            array[i] = int.Parse(Console.ReadLine());
        }
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static int MaxElement(int startPosition, int[] array, ref int maxpos, int finishPosition)
    {
        int max = array[startPosition];
        maxpos = startPosition;
        for (int i = startPosition; i < finishPosition; i++)
        {
            if (max < array[i])
            {
                max = array[i];
                maxpos = i;
            }
        }
        return max;
    }

    static void AscendingSorter(int[] array)
    {
        int max = 0;
        int maxPosition = 0;

        for (int i = 0; i < array.Length; i++)
        {
            max = MaxElement(0, array, ref maxPosition,array.Length-i);
            array[maxPosition] = array[array.Length - 1 - i];
            array[array.Length - 1 - i] = max;
        }
    }

    static void DescendingSorter(int[] array)
    {
        int max = 0;
        int maxPosition = 0;

        int[] SortedArray = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            max = MaxElement(i, array, ref maxPosition, array.Length);
            array[maxPosition] = array[i];
            array[i] = max;
        }
    }

    static void Main()
    {
        Console.WriteLine("What is the size of the array? ");
        int size = int.Parse(Console.ReadLine());
        int[] arrayInput = new int[size];
        ArrayInput(arrayInput);

        Console.WriteLine("From which position to start the search (From 0 to {0})? ",size-1);
        int position = int.Parse(Console.ReadLine());
        int positionOfMaxEl = 0;
        int maxElement = MaxElement(position,arrayInput, ref positionOfMaxEl,arrayInput.Length);//the last var is for the other tasks
        Console.WriteLine("The maximum element is : {0} and its position is {1} ",maxElement,positionOfMaxEl);

        int[] arrayInputAscending = new int[size];
        int[] arrayInputDescending = new int[size];

        Array.Copy(arrayInput, arrayInputAscending,size);
        Array.Copy(arrayInput, arrayInputDescending, size);

        AscendingSorter(arrayInputAscending);
        DescendingSorter(arrayInputDescending);

        PrintArray(arrayInput);
        Console.WriteLine();

        PrintArray(arrayInputAscending);
        Console.WriteLine();

        PrintArray(arrayInputDescending);
        Console.WriteLine();
    }
}

