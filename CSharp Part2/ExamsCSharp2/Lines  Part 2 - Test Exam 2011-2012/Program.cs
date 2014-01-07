using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[, ,] cube;


    static void Main()
    {
        int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();

        cube = new int[whd[0], whd[1], whd[2]];

        for (int h = 0; h < whd[1]; h++)
        {
            string[] currLine = Console.ReadLine().Split();
            for (int d = 0; d < whd[2]; d++)
            {
                for (int w = 0; w < whd[0]; w++)
                {
                    cube[w, h, d] = (int)currLine[d][w];
                }
            }
        }

    }
}

