using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittrisLast
{
    class Program
    {
        static int totalscore = 0;
        static int[,] playfield = {{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0} };

        static int Action (string[] input)
        {
            int pieceNumber = (int.Parse(input[0]));
            int bitsInNumberTotal = 0;
            string pieceBinary = Convert.ToString(pieceNumber, 2).PadLeft(32, '0');
            for (int i = 0; i < 32; i++)
			{
			     if (pieceBinary[i] == '1')
                     {
                         bitsInNumberTotal++;
                     }
			}

            pieceNumber = pieceNumber & 255;
            pieceBinary = Convert.ToString(pieceNumber, 2).PadLeft(8,'0');
            for (int zzz = 0; zzz < 8; zzz++)
            {
                playfield[0, zzz] = pieceBinary[zzz] - 48;
            }
            int currRow = 0;
            for (int i = 1; i <= 3; i++)
            {
                if (input[i] == "R")
                {
                    if (pieceBinary[7] != '1')
                    {
                        pieceNumber = pieceNumber >> 1;
                        pieceBinary = Convert.ToString(pieceNumber, 2).PadLeft(8, '0');
                        for (int zzz = 0; zzz < 8; zzz++)
                        {
                            playfield[currRow, zzz] = pieceBinary[zzz] - 48;
                        }

                    }
                }
                if (input[i] == "L")
                {
                    if (pieceBinary[0] != '1')
                    {
                        pieceNumber = pieceNumber << 1;
                        pieceBinary = Convert.ToString(pieceNumber, 2).PadLeft(8, '0');
                        for (int zzz = 0; zzz < 8; zzz++)
                        {
                            playfield[currRow, zzz] = pieceBinary[zzz] - 48;
                        }
                    }
                }

                if (input[i] == "D")
                {
                    List<int> onesPositions = new List<int>();
                    for (int xx = 0; xx < 8; xx++)
                    {
                        if (pieceBinary[xx] == '1')
                        {
                            onesPositions.Add(xx);
                            playfield[currRow, xx] = 0;
                        }
                    }
                    currRow++;
                    foreach (int item in onesPositions)
                    {
                        if (playfield[currRow,item] == 1)
                        {
                            foreach (int pos in onesPositions)
                            {
                                playfield[currRow - 1, pos] = 1;
                            }
                            int gameender = 0;
                            for (int rrr = 0; rrr < 8; rrr++)
                            {
                                gameender += playfield[currRow - 1, rrr];
                            }
                            if (gameender == 8)
                            {
                                return bitsInNumberTotal * 10;
                            }
                            else
                            {
                                return bitsInNumberTotal;
                            }
                        }
                    }
                    foreach (int item in onesPositions)
                    {
                        playfield[currRow, item] = 1;
                    }
                }
            }
            return bitsInNumberTotal;
        }
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());
            string[,] splitedInputs = new string[(total/4),4];
            for (int i = 0; i < total/4; i++)
			{
                splitedInputs[i, 0] = Console.ReadLine();
                splitedInputs[i, 1] = Console.ReadLine();
                splitedInputs[i, 2] = Console.ReadLine();
                splitedInputs[i, 3] = Console.ReadLine();
			}


            
            for (int i = 0; i < total/4; i++)
            {
                
                string[] toUseString = new string[4];
                toUseString[0] = splitedInputs[i, 0];
                toUseString[1] = splitedInputs[i, 1];
                toUseString[2] = splitedInputs[i, 2];
                toUseString[3] = splitedInputs[i, 3];
                totalscore = totalscore + Action(toUseString);
            }

            Console.WriteLine(totalscore);
        }
    }
}
