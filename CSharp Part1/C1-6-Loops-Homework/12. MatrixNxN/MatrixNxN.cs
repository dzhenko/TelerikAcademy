//Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:

using System;

class MatrixNxN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int starter = 1;
        for (int i = 0; i < n; i++)
        {       
            for (int j = 0; j < n; j++)
            {
                Console.Write(starter + j);              
            }
            starter = starter + 1;
            Console.WriteLine();
        }
    }
}

