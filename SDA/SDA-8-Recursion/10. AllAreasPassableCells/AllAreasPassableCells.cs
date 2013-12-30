//* We are given a matrix of passable and non-passable cells. Write a recursive program for finding all areas of passable cells in the matrix.


using System;
using System.Collections.Generic;
using System.Linq;

class AllAreasPassableCells
{
    static string[,] labyrinth = 
    {
        {" ", " ", " ", "*", " ", " ", " "},
        {" ", " ", " ", "*", " ", " ", " "},
        {"*", "*", "*", "*", "*", "*", "*"},
        {" ", " ", " ", "*", "*", " ", " "},
        {" ", " ", " ", "*", "*", " ", " "},
    };

    private static int maxSum = 0;
    private static int count = 0;

    static void Main()
    {

        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == " ")
                {
                    DFS(row, col);
                    if (count > maxSum)
                    {
                        maxSum = count;
                    }
                    Console.WriteLine(maxSum);
                    maxSum = 0;
                    count = 0;
                }
            }
        }
    }

    static void DFS(int row, int col)
    {
        if (row < 0 || col < 0 ||
            row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1) ||
            labyrinth[row, col] != " ")
        {
            return;
        }

        labyrinth[row, col] = count.ToString();

        count++;

        DFS(row, col - 1);
        DFS(row - 1, col);
        DFS(row, col + 1);
        DFS(row + 1, col);
    }
}

