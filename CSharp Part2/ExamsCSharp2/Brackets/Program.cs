using System;
using System.Numerics;

namespace Brackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            BigInteger[,] matrix = new BigInteger[input.Length + 1, input.Length + 2];
            matrix[0, 0] = 1;
            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input.Length+2; col++)
                {
                    if (input[row] == '(')
                    {
                        if (col != 0)
                        {
                            matrix[row + 1, col] = matrix[row, col - 1];
                        }
                        else
                        {
                            matrix[row + 1, col] = 0;
                        }
                    }
                    else if (input[row] == ')')
                    {
                        if (col != input.Length+1 )
                        {
                            matrix[row + 1, col] = matrix[row, col + 1];
                        }
                        else
                        {
                            matrix[row + 1, col] = 0;
                        }
                    }
                    else
                    {
                        if (col == 0)
                        {
                            matrix[row + 1, col] = matrix[row, col + 1];
                        }
                        else if (col ==input.Length+1 )
                        {
                            matrix[row + 1, col] = matrix[row, col - 1];
                        }
                        else
                        {
                            matrix[row + 1, col] = matrix[row, col + 1] + matrix[row, col - 1];
                        }
                    }
                }
            }

            Console.WriteLine(matrix[matrix.GetLength(0) - 1 ,0]);
        }
    }
}
