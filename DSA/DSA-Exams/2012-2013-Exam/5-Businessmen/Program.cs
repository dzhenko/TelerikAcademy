using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Businessmen
{
    class Program
    {
        static ulong[] answers = new ulong[71];

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            answers[0] = 1;
            answers[2] = 1;
            answers[4] = 2;
            answers[6] = 5;

            Console.WriteLine(Solve(n));
        }

        static ulong Solve(int num)
        {
            if (answers[num] == 0)
            {
                for (int i = 0; i <= num - 2; i+=2)
                {
                    answers[num] += Solve(i) * Solve(num - 2 - i);
                }
            }

            return answers[num];
        }
    }
}
