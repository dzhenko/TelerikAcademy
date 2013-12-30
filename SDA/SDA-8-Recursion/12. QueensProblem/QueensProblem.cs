//* Write a recursive program to solve the "8 Queens Puzzle" with backtracking. Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle


using System;
using System.Collections.Generic;
using System.Linq;

class QueensProblem
{
    static int solutioncounter = 0;
    static List<string> Coordinates = new List<string>();

    static void Main()
    {
        int[,] matrix = new int[8, 8];
        PlaceQueen(0,0,matrix);
        Console.WriteLine("Total solutions found : " + solutioncounter);
        Console.WriteLine();
        Console.WriteLine("Idea was taken from Saykorz");

        Console.WriteLine("https://github.com/saykorz/TelerikAkademy/blob/master/CSharpDevelopment/DataStructureAndAlgorithms/Recursion/EightQueensPuzzle/Program.cs");
        Console.WriteLine();
        //https://github.com/saykorz/TelerikAkademy/blob/master/CSharpDevelopment/DataStructureAndAlgorithms/Recursion/EightQueensPuzzle/Program.cs
    }

    static void PlaceQueen(int col,int queensPlaced,int[,] matrix)
    {
        for (int row = 0; row < 8; row++)
        {
            if (matrix[row, col] == 0)
            {
                string adder = row.ToString() + " : " + col.ToString();
                Coordinates.Add(adder);

                queensPlaced++;
                matrix[row, col] = 9;

                if (queensPlaced == 8)
                {
                    PrintBoard(matrix);
                    solutioncounter++;
                    PrintCoords();
                    //Environment.Exit(0); // looking for only 1 combo
                }
                
                FieldModifier(row, col, 1, matrix);
                if (col+1 < 8)
                {
                    PlaceQueen(col + 1,queensPlaced,matrix);
                }
                matrix[row, col] = 1;
                FieldModifier(row, col, -1, matrix);
                Coordinates.RemoveAt(Coordinates.Count - 1);
                queensPlaced--;
            }
        }
    }
    private static void PrintCoords()
    {
        Console.WriteLine();
        Console.WriteLine("Coordinates:");
        Console.WriteLine();
        foreach (var item in Coordinates)
        {
            Console.WriteLine("  " + item);
        }
        Console.WriteLine();
        Console.WriteLine("------------");
        Console.WriteLine();
    }
    private static void PrintBoard(int[,] matrix)
    {
        for (int z1 = 0; z1 < 8; z1++)
        {
            Console.Write("  ");
            for (int z2 = 0; z2 < 8; z2++)
            {
                if (matrix[z1,z2] == 9)
                {
                    Console.Write("Q");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
    }


    private static void FieldModifier(int row, int col, int sum,int[,] matrix)
    {
        SetBeatenColumns(matrix, row, sum);
        SetBeatenRows(matrix, col, sum);
        SetBeatenTopLeftBottomRight(matrix, row, col, sum);
        SetBeatenTopRightBottomLeft(matrix, row, col, sum);
    }

    private static void SetBeatenTopRightBottomLeft(int[,] matrix, int row, int col, int sum)
    {
        int currentRow = row;
        int currentCol = col;
        while (currentRow  - 1 >= 0 && currentCol + 1 < 8)
        {
            matrix[currentRow  - 1, currentCol + 1] += sum;
            currentRow--;
            currentCol++;
        }

        currentRow = row;
        currentCol = col;
        while (currentRow + 1 < 8 && currentCol - 1 >= 0 )
        {
            matrix[currentRow + 1, currentCol - 1] += sum;
            currentRow++;
            currentCol--;
        }
    }

    private static void SetBeatenTopLeftBottomRight(int[,] matrix, int row, int col, int sum)
    {
        int startCol;
        int startRow = 0;
        startCol = col - row;

        for (int i = 0; i < 8; i++)
        {
            if (startRow + i < 8 && startCol + i < 8 && startCol + i >= 0 &&
                matrix[startRow + i, startCol + i] >= 0 && matrix[startRow + i, startCol + i] < 9)
            {
                matrix[startRow + i, startCol + i] += sum;
                if (matrix[startRow + i, startCol + i] < 0)
                {
                    matrix[startRow + i, startCol + i] = 0;
                }
            }
        }
    }

    private static void SetBeatenRows(int[,] matrix, int col, int sum)
    {
        for (int i = 0; i < 8; i++)
        {
            if (matrix[i, col] >= 0 && matrix[i, col] < 9)
            {
                matrix[i, col] += sum;
                if (matrix[i, col] < 0)
                {
                    matrix[i, col] = 0;
                }
            }
        }
    }

    private static void SetBeatenColumns(int[,] matrix, int row, int sum)
    {
        for (int i = 0; i < 8; i++)
        {
            if (matrix[row, i] >= 0 && matrix[row, i] < 9)
            {
                matrix[row, i] += sum;
                if (matrix[row, i] < 0)
                {
                    matrix[row, i] = 0;
                }
            }
        }
    }


    //private static void FieldModifier(int row, int col, int symbol, int[,] matrix)
    //{
    //    for (int i = 0; i < 8; i++)
    //    {
    //        matrix[row, i] += symbol;
    //    }
    //    for (int i = 0; i < 8; i++)
    //    {
    //        matrix[i, col] += symbol;
    //    }
    //    for (int i = 1; i < 8; i++)
    //    {
    //        if ((row + i < 8) && (col + i < 8) && (row + i > -1) && (col + i > -1))
    //        {
    //            matrix[row + i, col + i] += symbol;
    //        }
    //        if ((row - i < 8) && (col + i < 8) && (row - i > -1) && (col + i > -1))
    //        {
    //            matrix[row - i, col + i] += symbol;
    //        }
    //        if ((row + i < 8) && (col - i < 8) && (row + i > -1) && (col - i > -1))
    //        {
    //            matrix[row + i, col - i] += symbol;
    //        }
    //        if ((row - i < 8) && (col - i < 8) && (row - i > -1) && (col - i > -1))
    //        {
    //            matrix[row - i, col - i] += symbol;
    //        }
    //    }
    //    matrix[row, col] = matrix[row, col] - 2;
    //}


    
}

