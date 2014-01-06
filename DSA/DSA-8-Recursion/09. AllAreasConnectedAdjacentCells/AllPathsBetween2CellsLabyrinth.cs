//Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.


using System;
using System.Collections.Generic;
using System.Linq;

class AllPathsBetween2CellsLabyrinth
{
    static char[,] matrix = {   {' ', ' ', ' ', '*', ' ', ' ', ' ' },   //you can change the maze here and from the program
                                {'*', '*', ' ', '*', ' ', '*', ' ' },
                                {' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                                {' ', '*', '*', '*', '*', '*', ' ' },
                                {' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                            };
    static int counter = 0;
    static List<int> area = new List<int>();
    static void Main()
    {

        for (int i = 0; i < 5; i++)     //we start searching from every possible cell
        {
            for (int j = 0; j < 7; j++)
            {
                FindExit(i, j);
            }
        }
        
        int maxarea = area.Max();
        Console.WriteLine("Maximum number of adjacent cells is : " + maxarea);

    }

    private static void FindExit(int row, int col)
    {
        if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1))
                     || (row >= matrix.GetLength(0)))
        {
            //out of range!
            return;
        }
        
        else if (matrix[row, col] != ' ')
        {
            return;
        }
        else
        {
            counter++;
            
            area.Add(counter);

            matrix[row, col] = 'S';

            FindExit(row - 1, col);
            FindExit(row, col + 1);
            FindExit(row + 1, col);
            FindExit(row, col - 1);

            area.Remove(counter-1);

            counter--;
            matrix[row, col] = ' ';
        }
    }
}

