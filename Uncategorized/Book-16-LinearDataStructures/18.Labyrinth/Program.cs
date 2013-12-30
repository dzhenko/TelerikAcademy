using System;
using System.Linq;

namespace ExtensionMethodsDemo
{
    class Program
    {
        static string[,] field = new string[,] {{"0","0","0","x","0","x"},
                                                {"0","x","0","x","0","x"},
                                                {"0","*","x","0","x","0"},
                                                {"0","x","0","0","0","0"},
                                                {"0","0","0","x","x","0"},
                                                {"0","0","0","x","0","x"}};
        static void Main()
        {
            int[] startCoords = FindStartPosition();

            SolveMaze(startCoords[0] - 1, startCoords[1], 1);
            SolveMaze(startCoords[0] + 1, startCoords[1], 1);
            SolveMaze(startCoords[0], startCoords[1] + 1, 1);
            SolveMaze(startCoords[0], startCoords[1] - 1, 1);

            PutUnreachableMarks();

            PrintTheMaze();
        }

        private static void PrintTheMaze()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static void PutUnreachableMarks()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == "0")
                    {
                        field[i, j] = "u";
                    }
                }
            }
        }

        private static void SolveMaze(int row, int col, int stepCounter) //out of the field
        {
            if (row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1))
            {
                return;
            }
            if (field[row, col] == "x" || field[row, col] == "*") //wall or start
            {
                return;
            }
            if (field[row, col] == "0") // 0 just mark the step
            {
                field[row, col] = stepCounter.ToString();
                SolveMaze(row + 1, col, stepCounter + 1);
                SolveMaze(row - 1, col, stepCounter + 1);
                SolveMaze(row, col + 1, stepCounter + 1);
                SolveMaze(row, col - 1, stepCounter + 1);
            }
            else
            {
                int currFieldDigit = int.Parse(field[row, col]);
                if (currFieldDigit > stepCounter)
                {
                    field[row, col] = stepCounter.ToString();
                    SolveMaze(row + 1, col, stepCounter + 1);
                    SolveMaze(row - 1, col, stepCounter + 1);
                    SolveMaze(row, col + 1, stepCounter + 1);
                    SolveMaze(row, col - 1, stepCounter + 1);
                }
                else //if lower then return
                {
                    return;
                }
            }


        }

        private static int[] FindStartPosition()
        {
            int[] coords = new int[2];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == "*")
                    {
                        coords[0] = i;
                        coords[1] = j;
                        return coords;
                    }
                }
            }
            return new int[] { 0, 0 };
        }
    }
}