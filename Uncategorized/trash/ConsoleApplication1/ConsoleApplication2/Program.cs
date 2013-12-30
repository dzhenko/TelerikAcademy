using System;

class Program
{
    static void Main()
    {
        int x = Convert.ToInt32(Console.ReadLine());
        int horns = x / 2 + 1;
        int width = (2 * x - 1) + (horns - 1) * 2;
        for (int i = 1; i < width; i++)
        {   
            if (i <= horns)
            {
                Console.Write(new string('.', horns - i));

                if (i != 1)
                {
                    Console.Write('*' + new string('.', i*2 - 3));
                }

                Console.Write('*' + new string('.', width-((horns-1)*2+2*i)) + '*');

                if (i != 1)
                {
                    Console.Write(new string('.', i * 2 - 3) + '*');
                }

                Console.Write(new string('.', horns - i));
                Console.WriteLine();
            }
            else
            {
                if (i > x)
                {
                    if (i < 2 * x - 1)
                    {
                        Console.WriteLine();
                    }
                    if (i > 2 * x - 1)
                    {
                        Console.WriteLine();
                    }
                    if (i == 2*x - 1)
                    {
                        Console.Write(new string('.', horns - 1));
                        Console.Write('*' + new string('.', width-2*horns + '*'));
                        Console.Write(new string('.', horns - 1));
                        Console.WriteLine();
                    }
                }
                else
                {
                    if (i < x)
                    {
                        Console.Write(new string('.', i + 2));
                        Console.Write('*' + new string('.', width - (2 * (i + 2) + 2)) + '*');
                        Console.Write(new string('.', i + 2));
                        Console.WriteLine();
                    }
                    if (i == x)
                    {
                        Console.Write(new string('.', (width-1)/2) + '*' + new string('.', (width-1)/2));
                        Console.WriteLine();
                    }        
                }
            }
        }
        Console.Write(new string('.', (width - 1) / 2) + '*' + new string('.', (width - 1) / 2));
        Console.WriteLine();
    }
}

