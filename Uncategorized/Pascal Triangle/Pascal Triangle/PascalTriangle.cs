using System;

class PascalTriangle
{
    static void Main()
    {
        const int HEIGHT = 12;

        long[][] triangle = new long[HEIGHT + 1][];
        for (int row = 0; row < HEIGHT; row++)
        {
            triangle[row] = new long[row + 1];
        }
        triangle[0][0] = 1;
        for (int row = 0; row < HEIGHT - 1; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                triangle[row + 1][col] = triangle[row + 1][col] + triangle[row][col];
                triangle[row + 1][col+1] = triangle[row + 1][col+1] + triangle[row][col];
            }
        }
        for (int row = 0; row < HEIGHT; row++)
        {
            Console.Write("".PadLeft((HEIGHT - row) * 2));
            for (int col = 0; col <= row; col++)
            {
                Console.Write("{0,3} ", triangle[row][col]);
            }
            Console.WriteLine();
        }
    }
}

