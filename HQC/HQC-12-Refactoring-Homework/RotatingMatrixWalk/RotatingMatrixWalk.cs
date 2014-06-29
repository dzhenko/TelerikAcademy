namespace RotatingMatrixWalk
{
    using System;
    public class RotatingMatrixWalk
    {
        static void Main()
        {
            var matrix = InitializeMatrix();

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(matrix);

            PrintMatrix(matrix);
        }

        private static int[,] InitializeMatrix()
        {
            var matrixSize = ReadMatrixSize();

            return new int[matrixSize, matrixSize];
        }

        private static int ReadMatrixSize()
        {
            Console.WriteLine(UserMessages.EnterPositiveNumberMessage);

            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || NumberIsInRange(n))
            {
                Console.WriteLine(UserMessages.WrongInputMessage);
                Console.WriteLine(UserMessages.EnterPositiveNumberMessage);
                input = Console.ReadLine();
            }

            return n;
        }

        private static bool NumberIsInRange(int number)
        {
            var inRange = number < 1 && number > 100;
            return inRange;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
