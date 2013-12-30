using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8];
            int currentNumber = 0;

            for (int row = 0; row < 8; row++)
            {
                currentNumber = int.Parse(Console.ReadLine());
                for (int col = 0; col < 8; col++)
                {
                    if (((currentNumber>>col) & 1) == 1)
                    {
                        matrix[row, 7 - col] = 1;
                    }
                }
            }

            int countLeft = 0;
            int countRight = 0;
            int targetCol = -1;
            while (true)
            {
                targetCol++;
                countLeft = 0;
                countRight = 0;

                if (targetCol == 8)
                {
                    Console.WriteLine("No");
                    break;
                }
                for (int col = 0; col < targetCol; col++)
                {
                    for (int row = 0; row < 8; row++)
                    {
                        if (matrix[row,col] == 1)
                        {
                            countLeft++;
                        }
                    }
                }
                for (int col = targetCol + 1; col < 8; col++)
                {
                    for (int row = 0; row < 8; row++)
                    {
                        if (matrix[row, col] == 1)
                        {
                            countRight++;
                        }
                    }
                }

                if (countLeft==countRight)
                {
                    Console.WriteLine(7 - targetCol);
                    Console.WriteLine(countRight);
                    break;
                }
            }
        }
    }
}
