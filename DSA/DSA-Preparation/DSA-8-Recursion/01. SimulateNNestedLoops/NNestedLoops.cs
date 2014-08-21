//Write a recursive program that simulates the execution of n nested loops from 1 to n.

using System;

class NNestedLoops
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[] vector = new int[n];
        NestedLoops(0,vector);
    }

    private static void NestedLoops(int index, int[] vector)
    {
        if (index >= vector.Length)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {
            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index] = i;
                NestedLoops(index + 1, vector);
            }
        }
    }
}

