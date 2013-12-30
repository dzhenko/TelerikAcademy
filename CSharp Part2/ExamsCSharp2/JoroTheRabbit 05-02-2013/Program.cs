using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] field = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int maximalPositionsVisited = 0;


        for (int i = 0; i < field.Length; i++)
        {
            for (int step = 1; step < field.Length; step++)
            {
                int curr = i;
                int next = (i + step);
                if (next >= field.Length)
                {
                    next = next - field.Length;
                }
                int currJumps = 1;
                while (field[curr] < field[next])
                {
                    currJumps++;
                    curr = next;
                    next = (next + step);
                    if (next >= field.Length)
                    {
                        next = next - field.Length;
                    }
                }
                if (currJumps > maximalPositionsVisited)
                {
                    maximalPositionsVisited = currJumps;
                }
            }
        }
        Console.WriteLine(maximalPositionsVisited);

    }
}

