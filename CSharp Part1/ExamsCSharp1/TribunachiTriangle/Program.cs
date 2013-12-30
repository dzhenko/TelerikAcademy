using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribunachiTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long t1 = long.Parse(Console.ReadLine());
            long t2 = long.Parse(Console.ReadLine());
            long t3 = long.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            int numbers = 0;
            for (int i = 1; i <= lines; i++)
            {
                numbers = numbers + i;
            }
            long[] all = new long[numbers];
            all[0] = t1;
            all[1] = t2;
            all[2] = t3;
            int index = 0;
            for (int i = 3; i < numbers; i++)
            {
                all[i] = all[i - 1] + all[i - 2] + all[i - 3];
            }

            for (int line = 1; line <= lines; line++)
            {
                Console.Write(all[index]);
                index++;
                for (int i = 1; i < line; i++)
                {
                    Console.Write(" " + all[index]);
                    index++;
                }
                Console.WriteLine();
            }
        }
    }
}
