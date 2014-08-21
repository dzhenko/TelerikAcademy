//* We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x).
//We can move from an empty cell to another empty cell if they share common wall. 
//Given a starting position (*) calculate and fill in the array the minimal distance 
//from this position to any other cell in the array. Use "u" for all unreachable cells. Example:

namespace _14.Maze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Maze
    {
        //marking x as -1 and start as -2
        public static int[,] maze = new int[,] {{0,0,0,-1,0,-1},
                                                {0,-1,0,-1,0,-1},
                                                {0,-2,-1,0,-1,0} ,
                                                {0,-1,0,0,0,0},
                                                {0,0,0,-1,-1,0},
                                                {0,0,0,-1,0,-1}};
        public static void Main()
        {
            int[] startCoords = FindStartCoords();

            Solve(startCoords[0], startCoords[1] + 1, 1);
            Solve(startCoords[0], startCoords[1] - 1, 1);
            Solve(startCoords[0] + 1, startCoords[1], 1);
            Solve(startCoords[0] - 1, startCoords[1], 1);

            PrintProperAnswer();
        }

        private static void PrintProperAnswer()
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row,col] == 0)
                    {
                        Console.Write("u ");
                    }
                    else if (maze[row,col] == -1)
                    {
                        Console.Write("x ");
                    }
                    else if (maze[row, col] == -2)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(maze[row,col] + " " );
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Solve(int row, int col, int stepCounter)
        {
            if (row < 0 || row > maze.GetLength(0) - 1 || col < 0 || col > maze.GetLength(1) - 1)
            {
                return;//out of range
            }
            if (maze[row,col] < 0)
            {
                return;//blocked
            }

            if (maze[row,col] != 0 && maze[row,col] < stepCounter)
            {
                return;
            }

            maze[row, col] = stepCounter;
            

            Solve(row, col + 1, stepCounter + 1);
            Solve(row, col - 1, stepCounter + 1);
            Solve(row + 1, col, stepCounter + 1);
            Solve(row - 1, col, stepCounter + 1);
        }

        private static int[] FindStartCoords()
        {
            int[] coordsToReturn = new int[2];

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row,col] == -2)
                    {
                        coordsToReturn[0] = row;
                        coordsToReturn[1] = col;
                        return coordsToReturn;
                    }
                }
            }
            throw new ApplicationException("Start position not found (Marked as 2 in the maze matrix)");
        }
    }
}
