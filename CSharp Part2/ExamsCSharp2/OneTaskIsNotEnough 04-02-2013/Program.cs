using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Solve1();

        Solve2();

        Solve2();
    }

    private static void Solve2()
    {
        string line = Console.ReadLine();

        int x = 0;
        int y = 0;

        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };

        int orientation = 0;

        for (int i = 0; i < 4; i++)
        {
            foreach (char comm in line)
            {
                if (comm == 'S')
                {
                    x += dx[orientation];
                    y += dy[orientation];
                }
                else if (comm == 'L')
                {
                    orientation += 3;
                    orientation %= 4;
                }
                else
                {
                    orientation++;
                    orientation %= 4;
                }
            }
        }
        if (x== 0 && y==0)
        {
            Console.WriteLine("bounded");
        }
        else
        {
            Console.WriteLine("unbounded");
        }
        return;
    }

    private static void Solve1()
    {
        int countOff = int.Parse(Console.ReadLine());

        bool[] turnOnNow = new bool[countOff + 1];
        int[] lampsStillOff = new int[countOff + 1];

        int lastLamp = 0;

        for (int i = 1; i <= countOff; i++)
        {
            lampsStillOff[i] = i;
        }

        int jump = 1;

        while (countOff > 0)
        {
            jump++;

            Array.Clear(turnOnNow, 1, countOff);

            for (int i = 1; i <= countOff; i+=jump)
            {
                turnOnNow[i] = true;
            }
            int newCountOff = 0;
            for (int i = 1; i <= countOff; i++)
            {
                if (!turnOnNow[i])
                {
                    newCountOff++;
                    lampsStillOff[newCountOff] = lampsStillOff[i];
                    lastLamp = lampsStillOff[i];
                }
            }

            countOff = newCountOff;
        }

        Console.WriteLine(lastLamp);
        return;
    }
}

