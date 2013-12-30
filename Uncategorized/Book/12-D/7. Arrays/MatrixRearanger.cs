using System;

class MatrixRearanger
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
        for (int main = 0; main < n/2; main++)
        {
            for (int i = 0; i < n-1-main*2; i++)    // 1
            {
                matrix[i + 1+main, n - 1 - main] = number;
                number++;
                if (number == n*n+1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n-1-main*2; i++)    // 2
            {
                matrix[n - 1 - main, n - 2 - i - main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n-2-main*2; i++)    //3
            {
                matrix[n - 2 - i - main, main] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
            for (int i = 0; i < n-2-main*2; i++)    //4
            {
                matrix[main + 1, i +main+ 1] = number;
                number++;
                if (number == n * n + 1)
                {
                    goto here;
                }
            }
        }
        here :
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i,j]+" ");
                if (matrix[i,j]< 10)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

