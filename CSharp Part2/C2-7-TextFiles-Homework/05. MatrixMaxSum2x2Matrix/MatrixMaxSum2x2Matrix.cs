//Write a program that reads a text file containing a square matrix of numbers and finds in 
//the matrix an area of size 2 x 2 with a maximal sum of its elements. 
//The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
//The output should be a single number in a separate text file. Example:
//4
//2 3 3 4
//0 2 3 4			
//3 7 1 2        ---> 17
//4 3 3 2



using System;
using System.IO;

class MatrixMaxSum2x2Matrix
{
    static void Main()
    {
        string inputPath = @"..\..\input.txt";
        string outputPath = @"..\..\output.txt";
        StreamReader reader = new StreamReader(inputPath);
        StreamWriter writer = new StreamWriter(outputPath,false);
        int n = int.Parse(reader.ReadLine());

        int[,] matrix = new int[n, n];
        int maxsum = 0;

        for (int i = 0; i < n; i++)
        {
            string[] numbersOnThisLine = new string[n];
            numbersOnThisLine = reader.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(numbersOnThisLine[j]);
            }
        }
        reader.Close();
        maxsum = FindMaxSum(n, matrix, maxsum);

        writer.WriteLine(maxsum);
        writer.Close();

    }

    private static int FindMaxSum(int n, int[,] matrix, int maxsum)
    {
        for (int i = 0; i < n - 1; i++)
        {
            int tempsum = 0;
            for (int j = 0; j < n - 1; j++)
            {
                tempsum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                if (maxsum < tempsum)
                {
                    maxsum = tempsum;
                }
            }
        }
        return maxsum;
    }
}

