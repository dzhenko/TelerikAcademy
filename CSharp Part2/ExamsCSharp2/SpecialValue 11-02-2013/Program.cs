using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int[][] field = new int[lines][];
        bool[][] visited = new bool[lines][];

        for (int i = 0; i < lines; i++)
        {
            field[i] = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            visited[i] = new bool[field[i].Length];
        }

        int absoluteMax = 0;

        for (int Rcol = 0; Rcol < field[0].Length; Rcol++)
        {
            int col = Rcol;
            int currPath = 1;
            int row = 0;
            while (field[row][col] >= 0 && !visited[row][col])
            {
                visited[row][col] = true;
                currPath++;
                col = field[row][col];
                row++;
                if (row >= lines)
                {
                    row = 0;
                }
            }
            if (!visited[row][col])
            {
                currPath += field[row][col] * (-1);
            }
            if (currPath > absoluteMax)
            {
                absoluteMax = currPath;
            }
        }

        Console.WriteLine(absoluteMax);
    }
}

