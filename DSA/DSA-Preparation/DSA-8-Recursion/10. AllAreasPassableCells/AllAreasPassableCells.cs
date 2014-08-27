//* We are given a matrix of passable and non-passable cells.
//Write a recursive program for finding all areas of passable cells in the matrix.


using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.LargestEmptyCellsArea
{
    class LargestEmptyCellsArea
    {
        public const int MatrixRows = 8;
        public const int MatrixCols = 8;

        public static int[,] matrix = new int[MatrixRows, MatrixCols];

        public static int finalLongest = 0;
        public static HashSet<Tuple<int, int>> finalAnswer = new HashSet<Tuple<int, int>>();

        static void Main()
        {
            GenerateRandomNonPassableTerain();

            for (int i = 0; i < MatrixRows; i++)
            {
                for (int j = 0; j < MatrixCols; j++)
                {
                    if (matrix[i, j] == 0)
                    {

                        Solve(i, j, 0);

                    }
                }
            }
            Console.WriteLine(finalLongest);

            PrintMatrix();
        }

        private static void Solve(int row, int col, int current)
        {
            if (row < 0 || col < 0 || row >= MatrixRows || col >= MatrixCols)
            {
                return;
            }

            if (matrix[row, col] == 0)
            {
                finalAnswer.Add(new Tuple<int, int>(row, col));
                finalLongest++;
                matrix[row, col] = 1;

                Solve(row + 1, col, current + 1);
                Solve(row - 1, col, current + 1);
                Solve(row, col + 1, current + 1);
                Solve(row, col - 1, current + 1);
            }
        }

        static void GenerateRandomNonPassableTerain()
        {
            Random rnd = new Random();

            int decideHelper = MatrixRows * MatrixCols;
            int count = rnd.Next(decideHelper / 4, decideHelper - decideHelper / 4 + 1);

            for (int i = 0; i < count; i++)
            {
                matrix[rnd.Next(0, MatrixRows), rnd.Next(0, MatrixCols)] = 1;
            }
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < MatrixRows; i++)
            {
                for (int j = 0; j < MatrixCols; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (finalAnswer.Contains(new Tuple<int, int>(i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        matrix[i, j]--;
                    }
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
