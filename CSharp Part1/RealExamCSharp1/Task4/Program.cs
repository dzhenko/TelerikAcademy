using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = 3*n + 1;//shirochina
        int height = 2*n;//visochina
        int dotstobeguin = (width - n + 1) / 2;
        //at 6 - top + bot = 12 - 2 = 10 2 for the middle = 8 --- by 4 untill middle and if pos 1 is * only dots
        Console.WriteLine(new string('.', dotstobeguin) + new string('*', n - 1) + new string('.', dotstobeguin));

        for (int i = 1; i <= n - 2; i++)
        {
            if (dotstobeguin - 2 * i < 2)
            {
                Console.WriteLine(".*" + new string('.', width - 4) + "*.");
            }
            else
            {
                Console.WriteLine(new string('.', dotstobeguin - 2 * i) + "*" + new string('.', width - 2 - (2 * (dotstobeguin - 2 * i))) + "*" + new string('.', dotstobeguin - 2 * i));
            }
        }

        Console.Write(".*@");
        for (int i = 0; i < (width-5)/2; i++)
        {
            Console.Write(".@");
        }
        Console.WriteLine("*.");

        Console.Write(".*.");
        for (int i = 0; i < (width - 5) / 2; i++)
        {
            Console.Write("@.");
        }
        Console.WriteLine("*.");

        for (int i = n-2; i >= 1; i--)
        {
            if (dotstobeguin - 2 * i < 2)
            {
                Console.WriteLine(".*" + new string('.', width - 4) + "*.");
            }
            else
            {
                Console.WriteLine(new string('.', dotstobeguin - 2 * i) + "*" + new string('.', width - 2 - (2 * (dotstobeguin - 2 * i))) + "*" + new string('.', dotstobeguin - 2 * i));
            }
        }

        Console.WriteLine(new string('.', dotstobeguin) + new string('*', n - 1) + new string('.', dotstobeguin));
    }
}

