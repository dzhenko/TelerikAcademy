//Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.


namespace _09.LargestEmptyCellsArea
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class LargestEmptyCellsArea
    {
        public const int MatrixRows = 8;
        public const int MatrixCols = 8;

        public static int[,] matrix = new int[MatrixRows, MatrixCols];

        public static int currLongest = 0;
        public static List<Tuple<int, int>> currAnswer = new List<Tuple<int, int>>();

        public static int finalLongest = 0;
        public static List<Tuple<int, int>> finalAnswer = new List<Tuple<int, int>>();

        static void Main()
        {
            GenerateRandomNonPassableTerain();
            
            for (int i = 0; i < MatrixRows; i++)
            {
                for (int j = 0; j < MatrixCols; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        var tupleList = new List<Tuple<int, int>>();
                        tupleList.Add(new Tuple<int,int>(i,j));

                        Solve(i, j, 0, tupleList);

                        if (currLongest > finalLongest)
                        {
                            finalLongest = currLongest;
                            finalAnswer = new List<Tuple<int, int>>(currAnswer);
                        }
                    }
                    currAnswer.Clear();
                    currLongest = 0;
                }
            }
            Console.WriteLine(finalLongest);

            PrintMatrix();
        }

        private static void Solve(int row, int col, int current, List<Tuple<int,int>> visited)
        {
            if (row < 0 || col < 0 || row >= MatrixRows || col >= MatrixCols)
            {
                return;
            }

            if (current > currLongest)
            {
                currLongest = current;
                currAnswer = new List<Tuple<int, int>>(visited);
            }

            if (matrix[row, col] == 0)
            {
                visited.Add(new Tuple<int, int>(row, col));
                matrix[row, col] = 1;

                Solve(row + 1, col, current + 1, visited);
                Solve(row - 1, col, current + 1, visited);
                Solve(row, col + 1, current + 1, visited);
                Solve(row, col - 1, current + 1, visited);

                matrix[row, col] = 0;
                visited.RemoveAt(visited.Count - 1);
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
                    }
                    Console.Write(matrix[i,j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
