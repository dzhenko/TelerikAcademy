using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bombin_Cuboids_08_02_2013
{
    class Program
    {
        public static int[] chars = new int[128];
        public static int destroyed = 0;
        public static char[,,] cube;
        static void Main()
        {
            ReadData();

            int numberOfBombs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBombs; i++)
            {
                int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
                ExplodeBomb(bomb);
            }

            PrintAnswer();


        }

        private static void PrintAnswer()
        {
            Console.WriteLine(destroyed);

            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (chars[(int)i] > 0)
                {
                    Console.WriteLine("{0} {1}",i,chars[(int)i]);
                }
            }
        }

        private static void ExplodeBomb(int[] bomb)
        {   //w h d p
            int power = bomb[3];

            int w1 = Math.Max(bomb[0] - power,0);
            int w2 = Math.Min(bomb[0] + power, cube.GetLength(0) - 1);

            int h1 = Math.Max(bomb[1] - power, 0);
            int h2 = Math.Min(bomb[1] + power, cube.GetLength(1) - 1);

            int d1 = Math.Max(bomb[2] - power, 0);
            int d2 = Math.Min(bomb[2] + power, cube.GetLength(2) - 1);

            for (int w = w1; w <= w2; w++)
            {
                for (int h = h1; h <= h2; h++)
                {
                    for (int d = d1; d <= d2; d++)
                    {
                        if ((Math.Sqrt((bomb[0]-w)*(bomb[0]-w)+(bomb[1]-h)*(bomb[1]-h)+(bomb[2]-d)*(bomb[2]-d)) <= power)
                            && (cube[w, h, d] != 'z'))
                        {
                            chars[(int)cube[w, h, d]]++;
                            cube[w, h, d] = 'z';
                            destroyed++;
                        }
                    }
                }
            }

            for (int w = w1; w <= w2; w++)
            {
                for (int d = d1; d <= d2; d++)
                {
                    int holes = 0;
                    for (int h = h1; h < cube.GetLength(1); h++)
                    {
                        if (cube[w,h,d] == 'z')
                        {
                            holes++;
                        }
                        else
                        {
                            if (holes != 0)
                            {
                                cube[w, h - holes, d] = cube[w, h, d];
                                cube[w, h, d] = 'z';
                            }
                        }
                    }
                }
            }
        }

        private static void ReadData()
        {
            int[] WHD = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            cube = new char[WHD[0], WHD[1], WHD[2]];

            for (int h = 0; h < WHD[1]; h++)
            {
                string currLine = Console.ReadLine();
                currLine = currLine.Replace(" ","");
                for (int d = 0; d < WHD[2]; d++)
                {
                    for (int w = 0; w < WHD[0]; w++)
                    {
                        cube[w, h, d] = currLine[d * WHD[0] + w];
                    }
                }
            }
        }
    }
}
