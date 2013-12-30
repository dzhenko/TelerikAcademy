//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.


using System;
using System.Collections.Generic;

class MaximumSumSquare
{
    
    static void Main()
    {
        int n, m;
        DataCollector(out n,out m);
        int[,] matrix = new int[n, m];
        GenerateMatrix(matrix);

        if ((n ==3) && (m == 3))
        {
            Console.WriteLine("The entered matrix is already 3x3");
            ShowMatrix(matrix);
            return;
        }

        int max = 0;
        int tempsum = 0;
        int maxROW = 0;
        int maxCOL = 0;
        for (int i = 0; i < n-2; i++)
        {
            for (int j = 0; j < m-2; j++)
            {
                tempsum = 0;
                for (int row = i; row < i + 3; row++)
                {
                    for (int col = j; col < j + 3; col++)
                    {
                        tempsum += matrix[row, col];
                    }
                }
                if (tempsum>max)
                {
                    max = tempsum;
                    maxROW = i;
                    maxCOL = j;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("The maximum sum is "+max);
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0}".PadLeft(5,' '),matrix[maxROW+i,maxCOL+j]);
            }
            Console.WriteLine();
        }

    }

    static void DataCollector(out int n, out int m)
    {
        Console.Write("Enter N: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter M: ");
        m = int.Parse(Console.ReadLine());
        while ((n < 3) || (m < 3))
        {
            if (n < 3)
            {
                Console.Write("Enter N: It has to be at least 3 ");
                n = int.Parse(Console.ReadLine());
            }
            if (m < 3)
            {
                Console.Write("Enter M: It has to be at least 3 ");
                m = int.Parse(Console.ReadLine());
            }
        }
    }

    private static void ShowMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0}".PadLeft(3,' '),matrix[i,j]);
            }
            Console.WriteLine();
        }
    }

    private static void GenerateMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("Enter Element on row {0} col {1} : ",i+1,j+1);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
    }
}

