using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FridayTask5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ulong[,] grid = new ulong[NM[0], NM[1]];

            int coinsCount = int.Parse(Console.ReadLine());

            //reading enemies
            for (int i = 0; i < coinsCount; i++)
            {
                int[] currCoinXY = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                grid[currCoinXY[0], currCoinXY[1]] += 1;
            }

            ulong answer = grid[0, 0];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }
                    else if (row == 0)
                    {
                        grid[row, col] += grid[row, col - 1];
                        if (answer < grid[row,col])
                        {
                            answer = grid[row, col];
                        }
                    }
                    else if (col == 0)
                    {
                        grid[row, col] += grid[row - 1, col];
                        if (answer < grid[row, col])
                        {
                            answer = grid[row, col];
                        }
                    }
                    else
                    {
                        grid[row, col] += Math.Max(grid[row, col - 1], grid[row - 1, col]);
                        if (answer < grid[row, col])
                        {
                            answer = grid[row, col];
                        }
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }
}
