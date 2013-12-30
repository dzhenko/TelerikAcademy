//* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console 
//the numbers 1 ... N numbers arranged as a spiral.


using System;

class SpiralArranger
{
    static void Main()
    {
        Console.WriteLine("N ?");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int number = 1;
        for (int i = 0; i < n; i++)
        {
            matrix[0, i] = number;
            number++;
        }
        for (int main = 0; main < n / 2; main++)
        {
            for (int i = 0; i < n - 1 - main * 2; i++)    // 1
            {
                matrix[i + 1 + main, n - 1 - main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n - 1 - main * 2; i++)    // 2
            {
                matrix[n - 1 - main, n - 2 - i - main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n - 2 - main * 2; i++)    //3
            {
                matrix[n - 2 - i - main, main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n - 2 - main * 2; i++)    //4
            {
                matrix[main + 1, i + main + 1] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
        }
         here:
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,5}", matrix[i, j]); //up to n = 15 u can see it fine
                
            }
            Console.WriteLine();
        }
    }
}

