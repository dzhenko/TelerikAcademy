namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            long mainDiagonal = 0;

            bool solutionFound = false;

            int absoluteMaxStarter = int.MinValue;

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = tokens[col];
                    if (row == col)
                    {
                        mainDiagonal += tokens[col];
                    }
                }
            }

            for (int row = 0; row < size-2; row++)
            {
                for (int col = 0; col < size - 4; col++)
                {
                    int currStarter = matrix[row,col];
                    if (matrix[row,col+1] == currStarter+1 &&
                        matrix[row,col+2] == currStarter+2 &&
                        matrix[row+1,col+2] == currStarter + 3 &&
                        matrix[row+2,col+2] == currStarter+4 &&
                        matrix[row+2,col+3] == currStarter+5 &&
                        matrix[row+2,col+4] == currStarter+6)
                    {
                        solutionFound = true;
                        if (currStarter > absoluteMaxStarter)
                        {
                            absoluteMaxStarter = currStarter;
                        }
                    }
                }
            }

            if (solutionFound)
            {
                Console.WriteLine("YES {0}",absoluteMaxStarter*7 + 21);
            }
            else
            {
                Console.WriteLine("NO {0}", mainDiagonal);
            }
        }
    }
}
