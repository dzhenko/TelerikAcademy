using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        public static char[, ,] cube;
        public static int[] answers = new int[128];

        static void Main()
        {
            int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            cube = new char[whd[0], whd[1], whd[2]];

            for (int h = 0; h < whd[1]; h++)
            {
                string[] CurrLine = Console.ReadLine().Split();
                for (int d = 0; d < whd[2]; d++)
                {
                    for (int w = 0; w < whd[0]; w++)
                    {
                        cube[w, h, d] = CurrLine[d][w];
                    }
                }
            }
            int globalcounter = 0;
            for (int w = 1; w < whd[0] - 1; w++)
            {
                for (int h = 1; h < whd[1] - 1; h++)
                {
                    for (int d = 1; d < whd[2] - 1; d++)
                    {
                        if (cube[w, h, d] == cube[w, h, d + 1] && cube[w, h, d] == cube[w, h, d - 1] &&
                            cube[w, h, d] == cube[w, h + 1, d] && cube[w, h, d] == cube[w, h - 1, d] &&
                            cube[w, h, d] == cube[w + 1, h, d] && cube[w, h, d] == cube[w - 1, h, d])
                        {
                            answers[(int)cube[w, h, d]]++;
                            globalcounter++;
                        }
                    }
                }
            }
            Console.WriteLine(globalcounter);
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (answers[(int)i] != 0)
                {
                    Console.WriteLine("{0} {1}", i, answers[(int)i]);
                }
            }
        }
    }
}