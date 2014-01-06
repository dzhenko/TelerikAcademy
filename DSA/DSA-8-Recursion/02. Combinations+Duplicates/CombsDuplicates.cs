//Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. 
// Example:	n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

using System;

class CombsDuplicates
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());
        int[] vector = new int[k];
        Combos(0,n,1,vector);
    }

    private static void Combos(int index,int n,int start, int[] vector)
    {
        if (index >= vector.Length)
        {
            Print(vector);
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                vector[index] = i;
                Combos(index + 1, n, i, vector);
            }
        }
    }

    private static void Print(int[] vector)
    {
        Console.Write(vector[0]);
        for (int i = 1; i < vector.Length; i++)
        {
            Console.Write(" "+vector[i]);
        }
        Console.WriteLine();
    }
}

