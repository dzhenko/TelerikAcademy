//Write a program that reads two integer numbers N and K and an array of N elements from the console. 
//Find in the array those K elements that have maximal sum.


using System;

class MaximumSumOfKElementsNArray
{
    static void Main()
    {
        Console.Write("Number of elements in the array ( N ) ?  ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.Write("Number of elements to sum ( K ) ?  ");
        int k = int.Parse(Console.ReadLine());
        while (k > n)
        {
            Console.Write("Re - enter K - it has to be smaller than N!  ");
            k = int.Parse(Console.ReadLine());
        }        

        for (int i = 0; i < n; i++)
        {
            Console.Write("Element " + (i + 1) + " of the array? ");
            array[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);

        int sum = 0;
        for (int i = n - 1; i >= n - k; i--)
        {
            sum = sum + array[i];
        }
        Console.WriteLine(sum);
    }
}

