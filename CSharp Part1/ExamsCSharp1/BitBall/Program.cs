using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int input = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                int bit = (input>>j) & 1;
                if (bit == 1)
                {
                    matrix[i, j] = 10;
                }
            }
        }

        for (int i = 0; i < 8; i++)
        {
            int input = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                int bit = (input >> j) & 1;
                if (bit == 1)
                {
                    if (matrix[i, j] == 10)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = 100;
                    }
                }
            }
        }
        int player10 = 0;
        int player100 = 0;
        bool seen10 = false;
        bool seen100 = false;
        bool scored10 = false;
        bool scored100 = false;
        for (int col = 0; col < 8; col++)
        {
            seen10 = false;
            seen100 = false;
            scored10 = false;
            scored100 = false;
            for (int row = 0; row < 8; row++)
            {
                if (matrix[row,col] == 100)
                {
                    if (!seen10 && !scored100)
                    {
                        player100++;
                        scored100 = true;
                    }
                }

                if (matrix[row,col] == 10)
                {
                    seen10 = true;
                    if (!scored10)
                    {
                        seen100 = false;
                        for (int i = row; i < 8; i++)
                        {
                            if (matrix[i, col] == 100)
                            {
                                seen100 = true;
                            }
                        }
                        if (!seen100)
                        {
                            scored10 = true;
                            player10++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("{0}:{1}",player10,player100);
    }
}

