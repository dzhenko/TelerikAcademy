//Modify the above program to check whether a path exists between two cells without finding all possible paths. 
//Test it over an empty 100 x 100 matrix.


using System;
using System.Collections.Generic;

public class AllPathsBetween2CellsLabyrinth
{
    static char[,] matrix = {   {' ', ' ', ' ', '*', ' ', ' ', ' ' },   //you can change the maze here and from the program
                                {'*', '*', ' ', '*', ' ', '*', ' ' },
                                {' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                                {' ', '*', '*', '*', '*', '*', ' ' },
                                {' ', ' ', ' ', ' ', ' ', ' ', 'e' }
                            };

    static List<char> path = new List<char>();
    static int ExitCounter = 0;
    static void Main()
    {
        //int[] startEnd = GetStartEnd();

        int[] startEnd = new int[] { 0, 0 };

        FindExit(startEnd[0], startEnd[1], 'S');

    }

    private static void FindExit(int row, int col, char direction)
    {
        if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1))
                     || (row >= matrix.GetLength(0)))
        {
            //out of range!
            return;
        }
        else if (matrix[row, col] == 'e')
        {
            //Found the exit!
            PrintExit();
        }
        else if (matrix[row, col] != ' ')
        {
            return;
        }
        else
        {
            path.Add(direction);
            matrix[row, col] = 'S';
            FindExit(row - 1, col, 'U');
            FindExit(row, col + 1, 'R');
            FindExit(row + 1, col, 'D');
            FindExit(row, col - 1, 'L');

            path.RemoveAt(path.Count - 1);
            matrix[row, col] = ' ';
        }
    }

    private static void PrintExit()
    {
        ExitCounter++;
        Console.Write("Exit N {0} --> ", ExitCounter);
        foreach (char item in path)
        {
            Console.Write(item);
        }
        Console.WriteLine('E');
    }

    private static int[] GetStartEnd() //getting the start and the exit of the labyrinth
    {
        int[] startCoord = new int[2];
        startCoord[0] = 0;
        startCoord[1] = 0;
        Console.WriteLine("Press 1 if you want to change the start and exit of the labyrinth");
        Console.WriteLine("If you enter anything else than 1 start will be 0,0 and exit - 6,4");
        Console.WriteLine("In other words start will be top left and exit is bottom right");
        if (Console.ReadLine() == "1")
        {
            int[] exitcoords = new int[2];

            Console.WriteLine("Start Coordinates");
            Console.Write("Enter Start row (from 0 to 4) : ");
            startCoord[0] = int.Parse(Console.ReadLine());
            Console.Write("Enter Start col (from 0 to 6) : ");
            startCoord[1] = int.Parse(Console.ReadLine());
            matrix[startCoord[0], startCoord[1]] = ' ';

            Console.WriteLine("Exit Coordinates");
            Console.Write("Enter Exit row (from 0 to 4) : ");
            exitcoords[0] = int.Parse(Console.ReadLine());
            Console.Write("Enter Exit col (from 0 to 6) : ");
            exitcoords[1] = int.Parse(Console.ReadLine());
            matrix[4, 6] = ' ';
            matrix[exitcoords[0], exitcoords[1]] = 'e';
        }
        return startCoord;
    }
}

