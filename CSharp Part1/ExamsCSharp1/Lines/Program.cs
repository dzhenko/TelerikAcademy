using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8];
            for (int row = 0; row < 8; row++)
            {
                int input = int.Parse(Console.ReadLine());
                for (int col = 0; col < 8; col++)
                {
                    if (((input>>col) & 1) == 1 )
                    {
                        matrix[row, 7 - col] = 1;
                    }
                }
            }
            int temp = 0;
            int longest = 0;
            int counter = 0;
            int howmanyarethey = 0;

            for (int row = 0; row < 8; row++)
            {
                counter = 0;
                temp = 0;
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row,col] == 1)
                    {
                        temp++;
                    }
                    else
                    {
                        if (counter<temp)
                        {
                            counter = temp;
                            temp = 0;
                        }
                    }
                }
                if (longest < counter)
                {
                    longest = counter;
                }
            }

            for (int col = 0; col < 8; col++)
            {
                counter = 0;
                temp = 0;
                for (int row = 0; row < 8; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        temp++;
                    }
                    else
                    {
                        if (counter < temp)
                        {
                            counter = temp;
                            temp = 0;
                        }
                    }
                }
                if (longest < counter)
                {
                    longest = counter;
                }
            }

            for (int row = 0; row < 8; row++)
            {
                counter = 0;
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        counter++;
                    }
                    else
                    {
                        if (longest == counter)
                        {
                            howmanyarethey++;
                            counter = 0;
                        }
                    }
                }
                if (longest == counter)
                {
                    howmanyarethey++;
                }
            }


            for (int col = 0; col < 8; col++)
            {
                counter = 0;
                for (int row = 0; row < 8; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        counter++;
                    }
                    else
                    {
                        if (longest == counter)
                        {
                            howmanyarethey++;
                            counter = 0;
                        }
                    }
                }
                if (longest == counter)
                {
                    howmanyarethey++;
                }
            }


            Console.WriteLine(longest);
            Console.WriteLine(howmanyarethey);
        }
    }
}
