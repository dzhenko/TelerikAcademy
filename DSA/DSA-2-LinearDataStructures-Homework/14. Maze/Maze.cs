using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Maze
{
    class Program
    {
        //marking x as -1 and start as -2
        public static int[,] maze = new int[,] {{0,0,0,-1,0,-1},
                                                {0,-1,0,-1,0,-1},
                                                {0,-2,-1,0,-1,0} ,
                                                {0,-1,0,0,0,0},
                                                {0,0,0,-1,-1,0},
                                                {0,0,0,-1,0,-1}};

        static void Main(string[] args)
        {
            var startRow = 0;
            var startCol = 0;

            FindStart(ref startRow, ref startCol);

            Solve(startRow, startCol, 0);

            PrintAswer();
        }

        static void Solve(int row, int col, int step)
        {
            if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1) || maze[row, col] == -1)
            {
                return;
            }

            if (maze[row, col] < step && maze[row, col] > 0)
            {
                return;
            }

            if (maze[row, col] == 0 || maze[row, col] > step)
            {
                maze[row, col] = step;
            }

            Solve(row + 1, col, step + 1);
            Solve(row - 1, col, step + 1);
            Solve(row, col + 1, step + 1);
            Solve(row, col - 1, step + 1);
        }

        static void FindStart(ref int startRow, ref int startCol)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == -2)
                    {
                        startRow = i;
                        startCol = j;
                        return;
                    }
                }
            }
        }

        private static void PrintAswer()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == -2)
                    {
                        Console.Write(" *");
                    }
                    else if (maze[i, j] == -1)
                    {
                        Console.Write(" x");
                    }
                    else if (maze[i, j] == 0)
                    {
                        Console.Write(" u");
                    }
                    else
                    {
                        Console.Write(" " + maze[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
