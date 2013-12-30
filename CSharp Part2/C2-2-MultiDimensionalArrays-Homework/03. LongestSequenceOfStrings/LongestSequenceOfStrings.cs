//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located 
//on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix.


using System;
using System.Collections.Generic;

class LongestSequenceOfStrings
{
    private static void ShowMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0}".PadLeft(6, ' '), matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static void GenerateMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("Enter Element on row {0} col {1} : ", i + 1, j + 1);
                matrix[i, j] = Console.ReadLine();
            }
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter M: ");
        int m = int.Parse(Console.ReadLine());
        string[,] matrix = new string[n, m];

        GenerateMatrix(matrix);
        int absolutemax = 0;
        int longestCount = 0;
        string theElement = null;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                string currElement = matrix[row, col];
                longestCount = 1;
                int colChanges = 0;
                int rowChanges = 0;
                //right
                while (col+1 < m)
                {
                    if (currElement==matrix[row,col+1])
                    {
                        col++;
                        colChanges++;
                        longestCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                col = col - colChanges;
                colChanges = 0;
                if (longestCount > absolutemax)
                {
                    absolutemax = longestCount;
                    theElement = currElement;
                }
                longestCount = 1;
                //down
                while (row + 1 < n)
                {
                    if (currElement == matrix[row + 1, col ])
                    {
                        row++;
                        rowChanges++;
                        longestCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                row = row - rowChanges;
                rowChanges = 0;
                if (longestCount > absolutemax)
                {
                    absolutemax = longestCount;
                    theElement = currElement;
                }
                longestCount = 1;
                //diagonal 1
                while ((row + 1 < n) && (col + 1 < m))
                {
                    if (currElement == matrix[row + 1, col + 1])
                    {
                        row++;
                        col++;
                        rowChanges++;
                        colChanges++;
                        longestCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                col = col - colChanges;
                row = row - rowChanges;

                if (longestCount > absolutemax)
                {
                    absolutemax = longestCount;
                    theElement = currElement;
                }
            }
        }
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("The longest sequence of equal strings is {0} and it is the element {1}    ",absolutemax,theElement);
    }
}
