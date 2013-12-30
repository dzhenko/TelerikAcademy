using System;

    class Program
    {
        static void Main()
        {
            int height = Convert.ToInt32(Console.ReadLine());
            int width = 2 * height;
            for (int i = 1; i <= height; i++)
            {
                Console.Write(new string('.',height-i)+"/");
                if (i == 2 || i == 4 || i == 7 || i == 11 || i == 16 || i == 22 || i == 29 || i == 37)
                {
                    Console.Write(new string('-', (i-1)*2));
                }
                else
                {
                    Console.Write(new string('.', (i - 1) * 2));
                }
                Console.Write("\\"+new string('.', height - i));
                Console.WriteLine();
            }
        }
    }

