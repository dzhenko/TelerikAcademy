using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //first line
            Console.WriteLine(new string('.',n/2 - 1) + "/\\" +new string('.',n/2 - 1 ));
            //magic after first line
            for (int row = 1; row < n/2-1; row++)
            {
                Console.Write(new string('.', n / 2 - 1 - row));
                if (row % 2 == 0)
                {
                    for (int i = 0; i < row/2; i++)
                    {
                        Console.Write("/ ");
                    }
                    Console.Write("/");
                    Console.Write("\\");
                    for (int i = 0; i < row/2; i++)
                    {
                        Console.Write(" \\");
                    }
                }
                else
                {
                    for (int i = 0; i < row/2 + 1; i++)
                    {
                        Console.Write("/ ");
                    }
                    for (int i = 0; i < row/2 + 1; i++)
                    {
                        Console.Write(" \\");
                    }
                }
                Console.WriteLine(new string('.', n / 2 - 1 - row));
            }
            //before mid
            if (n % 4 == 0)
            {
                for (int i = 0; i < n/4; i++)
                {
                    Console.Write("/ ");
                }
                for (int i = 0; i < n / 4; i++)
                {
                    Console.Write(" \\");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("/");
                for (int i = 0; i < n / 4 ; i++)
                {
                    Console.Write(" /");
                }
                for (int i = 0; i < n / 4 ; i++)
                {
                    Console.Write("\\ ");
                }
                Console.WriteLine("\\");
            }

            ////after mid
            if (n % 4 == 0)
            {
                for (int i = 0; i < n / 4; i++)
                {
                    Console.Write("\\ ");
                }
                for (int i = 0; i < n / 4; i++)
                {
                    Console.Write(" /");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("\\");
                for (int i = 0; i < n / 4; i++)
                {
                    Console.Write(" \\");
                }
                for (int i = 0; i < n / 4; i++)
                {
                    Console.Write("/ ");
                }
                Console.WriteLine("/");
            }
            //magic after mid
            for (int row = n/2 - 2; row >= 1; row--)
            {
                Console.Write(new string('.', n / 2 - 1 - row));
                if (row % 2 == 0)
                {
                    for (int i = 0; i < row / 2; i++)
                    {
                        Console.Write("\\ ");
                    }
                    Console.Write("\\");
                    Console.Write("/");
                    for (int i = 0; i < row / 2; i++)
                    {
                        Console.Write(" /");
                    }
                }
                else
                {
                    for (int i = 0; i < row / 2 + 1; i++)
                    {
                        Console.Write("\\ ");
                    }
                    for (int i = 0; i < row / 2 + 1; i++)
                    {
                        Console.Write(" /");
                    }
                }
                Console.WriteLine(new string('.', n / 2 - 1 - row));
            }
            //last line
            Console.WriteLine(new string('.',n/2 - 1) + "\\/" +new string('.',n/2 - 1 ));
        }
    }
}
