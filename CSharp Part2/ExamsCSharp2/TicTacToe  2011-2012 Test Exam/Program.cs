using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe__2011_2012_Test_Exam
{
    class Program
    {
        static int XWins = 0;
        static int OWins = 0;
        static int Draw = 0;

        static int xPlaced = 0;
        static int oPlaced = 0;

        static int[,] field = new int[3, 3];

        static void Main()
        {
            ReadInput();

            Solver();

            Console.WriteLine(XWins);

            Console.WriteLine(Draw);

            Console.WriteLine(OWins);
        }

        static void Solver()
        {
            int winner = CheckWhoWins();
            if (winner == 1)
            {
                XWins++;
                return;
            }
            if (winner == 2)
            {
                OWins++;
                return;
            }
            if (xPlaced + oPlaced == 9)
            {
                Draw++;
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == 0)
                    {
                        int toPlace = 0;
                        if (xPlaced > oPlaced)
                        {
                            toPlace = 2;
                            oPlaced++;
                        }
                        else
                        {
                            toPlace = 1;
                            xPlaced++;
                        }
                        field[i, j] = toPlace;

                        Solver();
                        if (field[i, j] == 1)
                        {
                            xPlaced--;
                        }
                        else
                        {
                            oPlaced--;
                        }
                        field[i, j] = 0;
                    }
                }
            }

        }

        private static int CheckWhoWins()
        {
            if (field[0, 0] == field[0, 1] && field[0, 1] == field[0, 2])
            {
                if (field[0, 0] == 1)
                {
                    return 1;
                }
                else if (field[0, 0] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[1, 0] == field[1, 1] && field[1, 1] == field[1, 2])
            {
                if (field[1, 0] == 1)
                {
                    return 1;
                }
                else if (field[1, 0] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[2, 0] == field[2, 1] && field[2, 1] == field[2, 2])
            {
                if (field[2, 0] == 1)
                {
                    return 1;
                }
                else if (field[2, 0] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[0, 0] == field[1, 0] && field[1, 0] == field[2, 0])
            {
                if (field[0, 0] == 1)
                {
                    return 1;
                }
                else if (field[0, 0] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[0, 1] == field[1, 1] && field[1, 1] == field[2, 1])
            {
                if (field[0, 1] == 1)
                {
                    return 1;
                }
                else if (field[0, 1] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[0, 2] == field[1, 2] && field[1, 2] == field[2, 2])
            {
                if (field[0, 2] == 1)
                {
                    return 1;
                }
                else if (field[0, 2] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2])
            {
                if (field[0, 0] == 1)
                {
                    return 1;
                }
                else if (field[0, 0] == 2)
                {
                    return 2;
                }
                 
            }
            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0])
            {
                if (field[1, 1] == 1)
                {
                    return 1;
                }
                else if (field[1, 1] == 2)
                {
                    return 2;
                }
            }
            return 0;
        }

        private static void ReadInput()
        {
            string Line1 = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                if (Line1[i] == 'X')
                {
                    field[0, i] = 1;
                    xPlaced++;
                }
                else if (Line1[i] == 'O')
                {
                    field[0, i] = 2;
                    oPlaced++;
                }
            }
            string Line2 = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                if (Line2[i] == 'X')
                {
                    field[1, i] = 1;
                    xPlaced++;
                }
                else if (Line2[i] == 'O')
                {
                    field[1, i] = 2;
                    oPlaced++;
                }
            }
            string Line3 = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                if (Line3[i] == 'X')
                {
                    field[2, i] = 1;
                    xPlaced++;
                }
                else if (Line3[i] == 'O')
                {
                    field[2, i] = 2;
                    oPlaced++;
                }
            }
        }
    }
}
