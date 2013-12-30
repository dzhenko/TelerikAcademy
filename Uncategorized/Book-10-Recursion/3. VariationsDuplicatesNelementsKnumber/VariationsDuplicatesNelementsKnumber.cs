using System;

class VariationsDuplicatesNelementsKnumber
{
    static void NestedLoops(int n, int k, int index, int[] array,int start)
    {
        if (index == k)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                array[index] = i;
                NestedLoops(n, k, index + 1, array,start);
                start++;
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int index = 0;
        int[] arrayOriginal = new int[k];
        NestedLoops(n, k, index, arrayOriginal,1);
    }
}

