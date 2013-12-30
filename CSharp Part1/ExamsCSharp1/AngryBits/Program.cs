using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBits
{
    class Program
    {
        static int Checker(int pigscount, int row, int col, int[,] realmatrix)
        {
            if ((row + 1 < 8) && (col + 1 < 16))
            {
                if (realmatrix[row + 1, col + 1] == 1)
                {
                    realmatrix[row + 1, col + 1] = 0;
                    pigscount++;
                }
            }
            if ((row + 1 < 8) && (col - 1 > -1))
            {
                if (realmatrix[row + 1, col - 1] == 1)
                {
                    realmatrix[row + 1, col - 1] = 0;
                    pigscount++;
                }
            }
            if ((row + 1 < 8) && true)
            {
                if (realmatrix[row + 1, col] == 1)
                {
                    realmatrix[row + 1, col] = 0;
                    pigscount++;
                }
            }


            if ((row - 1 > -1) && (col + 1 < 16))
            {
                if (realmatrix[row - 1, col + 1] == 1)
                {
                    realmatrix[row - 1, col + 1] = 0;
                    pigscount++;
                }
            }
            if ((row - 1 > -1) && (col - 1 > -1))
            {
                if (realmatrix[row - 1, col - 1] == 1)
                {
                    realmatrix[row - 1, col - 1] = 0;
                    pigscount++;
                }
            }
            if ((row - 1 > -1) && true)
            {
                if (realmatrix[row - 1, col] == 1)
                {
                    realmatrix[row - 1, col] = 0;
                    pigscount++;
                }
            }

            if (col + 1 < 16)
            {
                if (realmatrix[row,col + 1] == 1)
                {
                    realmatrix[row, col + 1] = 0;
                    pigscount++;
                }
            }
            if (col - 1 > -1)
            {
                if (realmatrix[row, col - 1] == 1)
                {
                    realmatrix[row, col - 1] = 0;
                    pigscount++;
                }
            }

            return pigscount;
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 16];
            int currentnumber = 0;
            for (int i = 0; i < 8; i++)
            {
                currentnumber = int.Parse(Console.ReadLine());
                for (int j = 0; j < 16; j++)
                {
                    matrix[i,j] = (currentnumber>>j) & 1;
                }
            }

            int[,] realmatrix = new int[8, 16];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    realmatrix[i, 15 - j] = matrix[i, j];
                }
            }


            int flight = 0;
            int pigscount = 0;
            int finalscore = 0;
            bool anyoneleft = false;

            for (int col = 7; col >= 0; col--)
            {
                flight = 0;
                pigscount = 0;
                for (int row = 0; row < 8; row++)
                {
                    if (realmatrix[row,col] == 1)
                    {
                        realmatrix[row, col] = 0;
                        int flightup = row;
                        int flightdown = Math.Min((15 - col - flightup), 7);

                        if (flightup != 0)
                        {
                            for (int i = 1; i <= flightup; i++)
                            {
                                flight++;
                                if (realmatrix[row-i,col+i] == 1)
                                {
                                    pigscount++;
                                    realmatrix[row - i, col + i] = 0;
                                    pigscount = Checker(pigscount, row - i, col + i, realmatrix);
                                    goto here;
                                }
                            }
                        }
                        for (int i = 1; i <= flightdown; i++)
                        {
                            flight++;
                            if (realmatrix[i, col + flightup + i] == 1)
                            {
                                pigscount++;
                                realmatrix[i, col + flightup + i] = 0;
                                pigscount = Checker(pigscount, i, col + flightup + i, realmatrix);
                                goto here;
                            }
                        }
                    }
                }
            here:
                finalscore = finalscore + (pigscount * flight);
            }
            string answer = " Yes";
            for (int i = 0; i < 8; i++)
			{
                for (int j = 8; j < 16; j++)
                {
                    if (realmatrix[i,j] == 1)
                    {
                        anyoneleft = true;
                    }
                }
			}
            if (anyoneleft)
            {
                answer = " No";
            }
            Console.WriteLine(finalscore + answer);
        }
    }
}
