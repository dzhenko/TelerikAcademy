//* We are given numbers N and M and the following operations:
//N = N+1
//N = N+2
//N = N*2
//Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
//Example: N = 5, M = 16
//Sequence: 5  7  8  16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.ShortestSequenceOfOperations
{
    class ShortestSequenceOfOperations
    {
        static void Main()
        {
            List<int> operations = new List<int>();

            int N = 5;
            int M = 16;

            int newTarget = M;
            int multyPlierCounter = 0;

            operations.Add(N);

            while (newTarget / 2 >= N)
            {
                newTarget /= 2;
                multyPlierCounter++;
            }

            while (N < newTarget)
            {
                if (N + 2 < newTarget)
                {
                    N += 2;
                    operations.Add(N);
                }
                else if (N < newTarget)
                {
                    N++;
                    operations.Add(N);
                }
            }

            for (int i = 0; i < multyPlierCounter; i++)
            {
                N *= 2;
                operations.Add(N);
            }

            Console.WriteLine(string.Join(" -> ",operations));
        }
    }
}
