using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] steps = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int start = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        int[,] table = new int[steps.Length, max + 1];

        if (start + steps[0] <= max)
        {
            table[0,start + steps[0]] = 1;
        }
        if (start - steps[0] >= 0)
        {
            table[0, start - steps[0]] = 1;
        }

        for (int i = 0; i < table.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                if (table[i,j] == 1)
                {
                    if (j + steps[i+1] <= max)
                    {
                        table[i + 1, j + steps[i + 1]] = 1;
                    }
                    if (j - steps[i + 1] >= 0)
                    {
                        table[i + 1, j - steps[i + 1]] = 1;
                    }
                }
            }
        }
        for (int i = table.GetLength(1) - 1; i >= 0; i--)
        {
            if (table[table.GetLength(0) - 1,i] == 1)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}

