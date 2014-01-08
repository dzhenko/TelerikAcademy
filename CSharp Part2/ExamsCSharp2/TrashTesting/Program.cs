using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Slides
{
    static void Main()
    {
        if (File.Exists(@"input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        string[] measures = Console.ReadLine().Split(' ');
        int w = int.Parse(measures[0]);
        int h = int.Parse(measures[1]);
        int d = int.Parse(measures[2]);
        string[, ,] cube = new string[w, h, d];
        ReadingAndInput(cube);
        string[] dropPoint = Console.ReadLine().Split(' ');
        int[] position = { int.Parse(dropPoint[0]), 0, int.Parse(dropPoint[1]) };
        Moving(position, cube);
    }

    static void Moving(int[] position, string[, ,] cube)
    {
        while (true)
        {
            bool yes = false;
            int[] currPosition = new int[3];
            Array.Copy(position, currPosition, 3);
            char move = cube[position[0], position[1], position[2]][1];

            switch (move)
            {
                case 'S': Slide(cube[position[0], position[1], position[2]], position); break;
                case 'T': Teleport(cube[position[0], position[1], position[2]], position); break;
                case 'E': position[1]++; break;
                case 'B': Printing(currPosition, yes); break;
            }
            if (move == 'B') break;
            if (position[0] < 0 || position[0] >= cube.GetLength(0) || (position[1] == cube.GetLength(1) && move == 'S')
                || position[2] < 0 || position[2] >= cube.GetLength(2) || position[1] > cube.GetLength(1))
            {
                if (position[1] >= cube.GetLength(1)) yes = true;
                Printing(currPosition, yes);
                break;
            }
        }
    }

    static void Printing(int[] endPosition, bool end)
    {
        if (end)
        {
            Console.WriteLine("Yes");
            Console.WriteLine(string.Join(" ", endPosition));
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine(string.Join(" ", endPosition));
        }
    }

    static void Teleport(string move, int[] position)
    {
        position[0] = int.Parse(move[3].ToString());
        position[2] = int.Parse(move[5].ToString());
    }

    static void Slide(string move, int[] position)
    {
        for (int i = 3; i <= 4; i++)
        {
            switch (move[i])
            {
                case 'L': position[0]--; break;
                case 'R': position[0]++; break;
                case 'B': position[2]++; break;
                case 'F': position[2]--; break;
            }
        }
        position[1]++;
    }

    static void ReadingAndInput(string[, ,] cube)
    {
        for (int h = 0; h < cube.GetLength(1); h++)
        {
            string[] currLine = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < cube.GetLength(2); d++)
            {
                string[] currItems = currLine[d].Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < cube.GetLength(0); w++)
                {
                    cube[w, h, d] = currItems[w].TrimStart().TrimStart('(');
                }
            }
        }
    }
}