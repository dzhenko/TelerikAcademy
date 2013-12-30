using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int times = int.Parse(Console.ReadLine());
        for (int i = 0; i < times; i++)
        {
            int x = 0;
            int y = 0;

            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };

            int direction = 0;

            string line = Console.ReadLine();

            foreach (char symb in line)
            {
                if (symb == 'W')
                {
                    x += dx[direction];
                    y += dy[direction];
                }
                else if (symb == 'L')
                {
                    direction += 3;
                    if (direction >= 4)
                    {
                        direction -= 4;
                    }
                }
                else
                {
                    direction += 1;
                    if (direction >= 4)
                    {
                        direction -= 4;
                    }
                }
            }

            if (x % 3 == 0)
            {
                if (y % 3 == 0)
                {
                    Console.WriteLine("GREEN");
                }
                else
                {
                    Console.WriteLine("BLUE");
                }
            }
            else
            {
                if (y % 3 == 0)
                {
                    Console.WriteLine("BLUE");
                }
                else
                {
                    Console.WriteLine("RED");
                }
            }
        }
    }
}

