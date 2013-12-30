//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)


using System;
using System.Collections.Generic;

class Print4TypesOfMatrix
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine();
        PrintType1(n);
        Console.WriteLine();
        Console.WriteLine();
        PrintType2(n);
        Console.WriteLine();
        Console.WriteLine();
        PrintType3(n);
        Console.WriteLine();
        Console.WriteLine();
        PrintType4(n);
        Console.WriteLine();
    }

    private static void ShowMatrix(int[,] matrix)
    {
        int padder = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i,j] < 10)
                {
                    padder = 7;
                }
                else if (matrix[i, j] < 100)
                {
                    padder = 6;
                }
                else
                {
                    padder = 5;
                }
                Console.Write("{0}".PadLeft(padder,' '),matrix[i,j]);
            }
            Console.WriteLine();
        }
    }

    private static void PrintType1(int n)
    {
        int counter = 0;
        int[,] matrix = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                counter++;
                matrix[row, col] = counter;
            }
        }
        ShowMatrix(matrix);
    }

    private static void PrintType2(int n)
    {
        int[,] matrix = new int[n, n];
        int counter = 0;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                if (col % 2 == 0)
                {
                    counter++;
                    matrix[row, col] = counter;
                }
                else
                {
                    counter++;
                    matrix[n - row - 1, col] = counter;
                }
            }
        }
        ShowMatrix(matrix);
    }

    private static void PrintType3(int n)
    {
        int[,] matrix = new int[n, n];
        int counter = 0;
        for (int diagonal = 1; diagonal <= n*2 - 1; diagonal++)
        {
            int col = 0;
            int row = n - diagonal;
            int cellstofill = diagonal;
            if (cellstofill>n)
            {
                cellstofill = 2 * n - cellstofill;
                col = diagonal - n;
                row = 0;
            }
            for (int action = 0; action < cellstofill; action++)
            {
                counter++;
                matrix[row, col] = counter;
                row++;
                col++;
            }
        }
        ShowMatrix(matrix);
    }

    private static void PrintType4(int n)
    {
        int[,] matrix = new int[n, n];
        int number = 1;
        for (int i = 0; i < n; i++)
        {
            matrix[i, 0] = number;
            number++;
        }
        for (int main = 0; main < n / 2; main++)
        {
            for (int i = 0; i < n - 1 - main * 2; i++)    // 1
            {
                matrix[n - 1 - main, i + 1 + main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n - 1 - main * 2; i++)    // 2
            {
                matrix[n - 2 - i - main, n - 1 - main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n - 2 - main * 2; i++)    //3
            {
                matrix[main, n - 2 - i - main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n - 2 - main * 2; i++)    //4
            {
                matrix[i + main + 1, main + 1] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
        }
    here:
        ShowMatrix(matrix);
        
    }
}

