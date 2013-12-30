using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBit1
{
    class Program
    {
        static int CurrRow = 0;
        static int CurrCol = 7;
        static int turns = 0;
        static int track = 1;
        static void MoveSouth(int[,] matrix,bool deadend)
        {
            while ((CurrRow + 1 < 8)&&(matrix[CurrRow + 1 ,CurrCol] != 1))
            {
                CurrRow = CurrRow + 1;
                CurrCol = CurrCol + 0;
                track++;
            }
            
        }

        static void MoveWest(int[,] matrix, bool deadend)
        {
            while ((CurrCol - 1 > -1) && (matrix[CurrRow, CurrCol - 1] != 1))
            {
                CurrRow = CurrRow + 0;
                CurrCol = CurrCol - 1;
                track++;
            }

        }

        static void MoveNorth(int[,] matrix, bool deadend)
        {
            while ((CurrRow - 1 > -1) && (matrix[CurrRow - 1, CurrCol] != 1))
            {
                CurrRow = CurrRow - 1;
                CurrCol = CurrCol + 0;
                track++;
            }

        }
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8];
            for (int row = 0; row < 8; row++)
            {
                int currNumber = int.Parse(Console.ReadLine());
                for (int col = 0; col < 8; col++)
                {
                    if (((currNumber>>col)&1)==1)
                    {
                        matrix[row, 7 - col] = 1;
                    }
                }
            }
            
            if (matrix[0,7] == 1)
            {
                Console.WriteLine("No 0");
                return;
            }
            bool deadend = false;
            if (matrix[7,0] == 1)
            {
                deadend = true;
            }
            
            while (true)
            {
                if ((matrix[1,7] == 1) && (matrix[0,6]==1))
                {
                    Console.WriteLine("No " +1);
                }

                MoveSouth(matrix, deadend);
                if ((CurrCol-1 > -1)&&(matrix[CurrRow,CurrCol -1] == 1))
                {
                    Console.WriteLine("No "+track);
                    break;
                }
                if ((CurrRow == 7) && (CurrCol == 0))
                {
                    Console.WriteLine(track + " " + turns);
                    break;
                }
                if ((deadend) && (CurrCol == 0) && (CurrRow == 6))
                {
                    Console.WriteLine("No "+track);
                    break;
                }
                turns++;


                MoveWest(matrix, deadend);
                if ((CurrRow - 1 > -1) && (matrix[CurrRow - 1, CurrCol] == 1))
                {
                    Console.WriteLine("No " + track);
                    break;
                }
                if ((CurrRow==7) && (CurrCol==0))
                {
                    Console.WriteLine(track+" "+turns);
                    break;
                }
                if ((deadend) && (CurrCol == 1) && (CurrRow == 7))
                {
                    Console.WriteLine("No " + track);
                    break;
                }
                turns++;


                MoveNorth(matrix, deadend);
                if ((CurrCol - 1 > -1) && (matrix[CurrRow, CurrCol - 1] == 1))
                {
                    Console.WriteLine("No " + track);
                    break;
                }
                turns++;


                MoveWest(matrix, deadend);
                if ((CurrRow + 1 < 8) && (matrix[CurrRow + 1, CurrCol] == 1))
                {
                    Console.WriteLine("No " + track);
                    break;
                }
                if ((CurrRow == 7) && (CurrCol == 0))
                {
                    Console.WriteLine(track + " " + turns);
                    break;
                }
                if ((deadend) && (CurrCol == 1) && (CurrRow == 7))
                {
                    Console.WriteLine("No " + track);
                    break;
                }
                turns++;
            }
        }
    }
}
