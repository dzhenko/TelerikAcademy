//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).


using System;

class Program
{
    static void Main()
    {
        Console.Write("The wanted number ( X ) ?  ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Number of elements in the array ( N ) ?  ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element " + (i + 1) + " of the array? (the array should be ascending) ");
            array[i] = int.Parse(Console.ReadLine());
        }
        int low = 0;
        int high = n - 1;
        int mid=0;

        while (low <= high)
        {
            mid = low + (high - low) / 2;

            if (x == array[mid])
            {
                Console.WriteLine("The searched item is at position " + (mid+1));
                Environment.Exit(0);
            }
            else if (x < array[mid])
                high = mid - 1;
            else
                low = mid + 1;
        }
        Console.WriteLine("Not Found :( ");
    }
}

