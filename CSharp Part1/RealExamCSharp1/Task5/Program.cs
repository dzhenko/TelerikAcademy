using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int[,] matrix = new int[8, width];
        ulong[] numbers = new ulong[8];
        int[] bitsCount = new int[8];
        for (int i = 0; i < 8; i++)
        {
            ulong currNum = ulong.Parse(Console.ReadLine());
            numbers[i] = currNum;
            for (int col = 0; col < width; col++)
            {
                if (((currNum>>(width - 1 - col))  & 1) == 1)
                {
                    matrix[i, col] = 1;
                    bitsCount[i]++;
                } 
            }
        }



        string currLine = Console.ReadLine(); //read 1
        string nextline = null;
        while (currLine!="stop")
        {
            if (currLine == "left") //LEFT
            {
                nextline = Console.ReadLine(); //read 2
                if (nextline=="stop")
                {
                    break;
                }
                int line = int.Parse(nextline);
                nextline = Console.ReadLine(); //read 3
                if (nextline == "stop")
                {
                    break;
                }
                //magic
                int position = int.Parse(nextline);
                if (position < 0)
                {
                    goto here;
                }
                if (position > width - 1)
                {
                    position = width - 1;
                }
                int currBitCount = 0;
                
                for (int i = position; i >= 0; i--)
                {
                    if (matrix[line,i] == 1)
                    {
                        currBitCount++;
                    }
                }
                for (int col = 0; col <= position; col++)
                {
                    if (currBitCount > col)
                    {
                        matrix[line, col] = 1;
                    }
                    else
                    {
                        matrix[line, col] = 0;
                    }
                }

            }
            else if (currLine=="right") //RIGHT
            {
                nextline = Console.ReadLine(); //read 2
                if (nextline == "stop")
                {
                    break;
                }
                int line = int.Parse(nextline);
                nextline = Console.ReadLine(); //read 3
                if (nextline == "stop")
                {
                    break;
                }

                //magic
                int position = int.Parse(nextline);
                if (position > width - 1)
                {
                    goto here;
                }
                if (position < 0)
                {
                    position = 0;
                }
                int currBitCount = 0;
                for (int i = position; i < width; i++)
                {
                    if (matrix[line, i] == 1)
                    {
                        currBitCount++;
                    }
                }
                for (int col = width-1; col >= position; col--)
                {
                    if (currBitCount > width - 1 - col)
                    {
                        matrix[line, col] = 1;
                    }
                    else
                    {
                        matrix[line, col] = 0;
                    }
                }
            }
            else if (currLine=="reset")
            {
                
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        if (bitsCount[row] > col)
                        {
                            matrix[row, col] = 1;
                        }
                        else
                        {
                            matrix[row, col] = 0;
                        }
                    }
                }
            }
        here:
            currLine = Console.ReadLine();
        }

        int linesNoTopcheta = 0;

        for (int col = 0; col < width; col++)
        {
            bool empty = true;
            for (int row = 0; row < 8; row++)
            {
                if (matrix[row,col] == 1)
                {
                    empty = false;
                }
            }
            if (empty)
            {
                linesNoTopcheta++;
            }
        }
        ulong sum = 0;
        for (int i = 0; i < 8; i++)
        {
            string binarynums = null;
            for (int j = 0; j < width; j++)
            {
                binarynums = binarynums + matrix[i, j].ToString() ;
            }
            sum = sum + Convert.ToUInt64(binarynums, 2);
        }
        Console.WriteLine(sum * (ulong)linesNoTopcheta);


        
    }
}

