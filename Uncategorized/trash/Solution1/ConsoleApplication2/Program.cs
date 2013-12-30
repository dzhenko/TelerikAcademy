using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("golemina na kilima?");
        int carpetWH = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= (carpetWH/2); i++)
        {
            Console.Write(new string('.', carpetWH / 2 - i));
            if (i % 2 == 0 )
            {
                for (int j = 1; j <= i/2; j++)
                {
                    Console.Write('/');
                    Console.Write(' ');
                }
                for (int j = 1; j <= i / 2; j++)
                {
                    Console.Write(' ');
                    Console.Write('\\');
                }
                Console.Write(new string('.', carpetWH / 2 - i));
                Console.WriteLine();
            }
            else
            {
                if (i == 1)
                {
                    Console.Write('/');
                    Console.Write('\\');
                    Console.Write(new string('.', carpetWH / 2 - i));
                    Console.WriteLine();
                }
                else
                {
                    for (int k = 1; k <= (i - 1) / 2; k++)
                    {
                        Console.Write('/');
                        Console.Write(' ');
                    }
                    Console.Write('/');
                    Console.Write('\\');
                    for (int k = 1; k <= (i - 1) / 2; k++)
                    {
                        Console.Write(' ');
                        Console.Write('\\');
                    }
                    Console.Write(new string('.', carpetWH / 2 - i));
                    Console.WriteLine();
                }             
            }       
        }
        for (int i = carpetWH/2 ; i >= 1; i--)
        {
            Console.Write(new string('.', carpetWH / 2 - i));
            if (i % 2 == 0 )
            {
                for (int j = 1; j <= i/2; j++)
                {
                    Console.Write('\\');
                    Console.Write(' ');
                }
                for (int j = 1; j <= i / 2; j++)
                {
                    Console.Write(' ');
                    Console.Write('/');
                }
                Console.Write(new string('.', carpetWH / 2 - i));
                Console.WriteLine();
            }
            else
            {
                if (i == 1)
                {
                    Console.Write('\\');
                    Console.Write('/');
                    Console.Write(new string('.', carpetWH / 2 - i));
                    Console.WriteLine();
                }
                else
                {
                    for (int k = 1; k <= (i - 1) / 2; k++)
                    {
                        Console.Write('\\');
                        Console.Write(' ');
                    }
                    Console.Write('\\');
                    Console.Write('/');
                    for (int k = 1; k <= (i - 1) / 2; k++)
                    {
                        Console.Write(' ');
                        Console.Write('/');
                    }
                    Console.Write(new string('.', carpetWH / 2 - i));
                    Console.WriteLine();
                }             
            }
        }
    }
}

