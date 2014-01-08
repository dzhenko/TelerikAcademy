using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[] dimensions    ;
    public static int[] laser         ;
    public static int[] direction     ;
    public static bool[, ,] burned    ;
    static void Main()
    {
        dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

        laser      = Console.ReadLine().Split().Select(int.Parse).ToArray();

        direction  = Console.ReadLine().Split().Select(int.Parse).ToArray();

        burned = new bool[dimensions[0], dimensions[1], dimensions[2]];

        laser[0]--;
        laser[1]--;
        laser[2]--;

        burned[laser[0], laser[1], laser[2]] = true;

        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (laser[i] + direction[i] < 0 || laser[i] + direction[i] >= burned.GetLength(i))
                {
                    direction[i] = direction[i] * (-1);
                }
            }

            if (burned[laser[0] + direction[0],laser[1] + direction[1],laser[2] + direction[2]])
            {
                Console.WriteLine("{0} {1} {2}",laser[0] + 1,laser[1] + 1,laser[2] + 1);
                return;
            }

            laser[0] += direction[0];
            laser[1] += direction[1];
            laser[2] += direction[2];

            if (AreWeOnEdge())
            {
                Console.WriteLine("{0} {1} {2}",laser[0] + 1 - direction[0],laser[1] + 1- direction[1],laser[2] + 1- direction[2]);
                return;
            }
        }
    }
    static bool AreWeOnEdge()
    {
        if ((laser[0] == 0 || laser[0] == burned.GetLength(0) - 1) &&
        (laser[1] == 0 || laser[1] == burned.GetLength(1) - 1) &&
        (laser[2] == 0 || laser[2] == burned.GetLength(2) - 1))
        {
            return true;
        }
        return false;
    }
}

