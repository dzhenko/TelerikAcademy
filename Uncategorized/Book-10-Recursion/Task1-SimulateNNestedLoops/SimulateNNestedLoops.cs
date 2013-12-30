using System;

class SimulateNNestedLoops
{
    static void NestedLoops(int n ,int index, int[] array)
    {
        if (index == n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                array[index] = i;
                NestedLoops(n, index+1, array);
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int index = 0;
        int[] arrayOriginal = new int[n];
        NestedLoops(n, index, arrayOriginal);
    }
}

