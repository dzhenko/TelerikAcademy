//Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 


using System;
using System.Collections.Generic;

class LargestNumInArrayThatIsNotK
{
    static void Main()
    {
        Console.Write("Enter K: ");
        int K = int.Parse(Console.ReadLine());

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element {0} : ",i+1);
            array[i] = int.Parse(Console.ReadLine());
        }
        array[n] = K;
        Array.Sort(array);

        int indexK = Array.BinarySearch(array, 99);

        if (indexK == n)
        {
            Console.WriteLine(array[n-1]);
        }
        else if (array[indexK] == array[indexK+1])
        {
            Console.WriteLine(array[indexK]);
        }
        else if (indexK == 0)
        {
            Console.WriteLine("All the elements are larger than K");
        }
        else
        {
            Console.WriteLine(array[indexK-1]);
        }
    }
}
