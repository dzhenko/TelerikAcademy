using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCol
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] all = new int[n];
            for (int i = 0; i < n; i++)
            {
                all[i] = ((int)(char.Parse(Console.ReadLine())) - 64);
            }

            BigInteger number = 0;

            for (int i = 0; i < n; i++)
            {
                number = number + all[i] * (BigInteger)Math.Pow(26, n - 1 - i);
            }

            Console.WriteLine(number);
        }
    }
}
