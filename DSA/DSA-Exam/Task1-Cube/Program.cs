using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task1_Cube
{
    class Program
    {
        static int[,] matrix;

        static BigInteger absoluteMax = 0;

        static void Main(string[] args)
        {
            var start = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();

            matrix = new int[rc[0], rc[1]];

            var used = new bool[rc[0], rc[1]];

            for (int i = 0; i < rc[0]; i++)
            {
                var tokens = Console.ReadLine().Split();

                for (int j = 0; j < rc[1]; j++)
                {
                    if (tokens[j] == "#")
                    {
                        matrix[i, j] = -1;
                        used[i,j] = true;
                    }
                    else
                    {
                        matrix[i, j] = int.Parse(tokens[j]);
                    }
                }
            }

            DFS(start[0], start[1], 0, ref used);

            Console.WriteLine(absoluteMax);
        }

        private static void DFS(int row, int col, BigInteger sumSoFar, ref bool[,] used)
        {
            if (row >= 0 && row < used.GetLength(0) &&
                col >= 0 && col < used.GetLength(1) && matrix[row, col] != -1)
            {
                if (absoluteMax < sumSoFar)
                {
                    absoluteMax = sumSoFar;
                }

                var power = matrix[row, col];

                if (!used[row, col])
                {
                    used[row, col] = true;
                    sumSoFar += power;

                    DFS(row - power, col, sumSoFar, ref used);
                    DFS(row + power, col, sumSoFar, ref used);
                    DFS(row, col - power, sumSoFar, ref used);
                    DFS(row, col + power, sumSoFar, ref used);

                    used[row, col] = false;
                    sumSoFar -= power;
                }
            }
        }
    }
}
