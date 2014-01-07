using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program
{
    public static long[] DoneStacks;
    public static long[] DoneVerticals;
    public static long[] DoneHorizonts;

    public static int Answer = 0;
    public static short[,] matrix;
    public static int[] whd;
    static void Main()
    {
        whd = Console.ReadLine().Split().Select(int.Parse).ToArray();

        DoneStacks = new long[whd[2]];
        DoneVerticals = new long[whd[0]];
        DoneHorizonts = new long[whd[1]];

        matrix = new short[whd[1], whd[0] * whd[2]];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            short[] values = Console.ReadLine().Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = values[col];
            }
        }

        CutByHorizont();

        CutByVerticals();

        CutByStacks();

        Console.WriteLine(Answer);
    }

    private static void CutByHorizont()
    {
        //@"    4 2 3
        //      3 4 1 9 | 1 2 3 8 | 1 5 6 7
        //      1 2 1 9 | 5 1 3 9 | 5 3 3 8
        for (int hor = 1; hor < whd[1]; hor++)
        {
            long up = 0;
            long down = 0;

            for (int i = 0; i < hor; i++)
            {
                if (DoneHorizonts[i] == 0)
                {
                    long currStacker = 0;
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        up += matrix[i, col];
                        currStacker += matrix[i, col];
                    }
                    DoneHorizonts[i] = currStacker;
                }
                else
                {
                    up += DoneHorizonts[i];
                }
            }

            for (int i = hor; i < whd[1]; i++)
            {
                if (DoneHorizonts[i] == 0)
                {
                    long currStacker = 0;
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        down += matrix[i, col];
                        currStacker += matrix[i, col];
                    }
                    DoneHorizonts[i] = currStacker;
                }
                else
                {
                    down += DoneHorizonts[i];
                }
            }

            if (up == down)
            {
                Answer++;
            }
        }
    }

    private static void CutByVerticals()
    {
        for (int vert = 1; vert < whd[0]; vert++)
        {
            long left = 0;
            long right = 0;
            //@"    4 2 3
            //      3 4 1 9 | 1 2 3 8 | 1 5 6 7
            //      1 2 1 9 | 5 1 3 9 | 5 3 3 8

            for (int i = 0; i < vert; i++)
            {
                if (DoneVerticals[i] == 0)
                {
                    long CurrStacker = 0;

                    for (int curCollToTake = i; curCollToTake < matrix.GetLength(1); curCollToTake = (curCollToTake + whd[0]))
                    {
                        for (int row = 0; row < whd[1]; row++)
                        {
                            left += matrix[row, curCollToTake];
                            CurrStacker += matrix[row, curCollToTake];
                        }
                    }
                    DoneVerticals[i] = CurrStacker;
                }
                else
                {
                    left += DoneVerticals[i];
                }
            }

            for (int i = vert; i < whd[0]; i++)
            {
                if (DoneVerticals[i] == 0)
                {
                    long CurrStacker = 0;

                    for (int curCollToTake = i; curCollToTake < matrix.GetLength(1); curCollToTake = (curCollToTake + whd[0]))
                    {
                        for (int row = 0; row < whd[1]; row++)
                        {
                            right += matrix[row, curCollToTake];
                            CurrStacker += matrix[row, curCollToTake];
                        }
                    }
                    DoneVerticals[i] = CurrStacker;
                }
                else
                {
                    right += DoneVerticals[i];
                }
            }

            if (left == right)
            {
                Answer++;
            }
        }
    }

    private static void CutByStacks()
    {
        for (int st = 1; st < whd[2]; st++)
        {
            long left = 0;
            long right = 0;

            for (int i = 0; i < st; i++)
            {
                if (DoneStacks[i] == 0)
                {
                    long currStacker = 0;
                    for (int row = 0; row < whd[1]; row++)
                    {
                        for (int colCURR = i * whd[0]; colCURR < (i + 1) * whd[0]; colCURR++)
                        {
                            left += matrix[row, colCURR];
                            currStacker += matrix[row, colCURR];
                        }
                    }
                    DoneStacks[i] = currStacker;
                }
                else
                {
                    left += DoneStacks[i];
                }
            }
            //@"4 2 3
            //3 4 1 9 | 1 2 3 8 | 1 5 6 7
            //1 2 1 9 | 5 1 3 9 | 5 3 3 8

            for (int i = st; i < whd[2]; i++)
            {
                if (DoneStacks[i] == 0)
                {
                    long currStacker = 0;
                    for (int row = 0; row < whd[1]; row++)
                    {
                        for (int colCURR = i * whd[0]; colCURR < (i + 1) * whd[0]; colCURR++)
                        {
                            right += matrix[row, colCURR];
                            currStacker += matrix[row, colCURR];
                        }
                    }
                    DoneStacks[i] = currStacker;
                }
                else
                {
                    right += DoneStacks[i];
                }
            }

            if (left == right)
            {
                Answer++;
            }
        }
    }
}