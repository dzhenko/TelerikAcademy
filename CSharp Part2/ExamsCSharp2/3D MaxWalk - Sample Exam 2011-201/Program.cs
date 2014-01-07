using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3D_MaxWalk___Sample_Exam_2011_201
{
    class Program
    {
        public static int[, ,] cube;
        public static bool[, ,] visited;
        static void Main()
        {
            int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            cube = new int[whd[0], whd[1], whd[2]];
            visited = new bool[whd[0], whd[1], whd[2]];

            for (int h = 0; h < whd[1]; h++)
            {
                string[] currLine = Console.ReadLine().Split(new char[] {'|'}, 
                    StringSplitOptions.RemoveEmptyEntries);
                for (int d = 0; d < whd[2]; d++)
                {
                    int[] numbs = currLine[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();
                    for (int w = 0; w < whd[0]; w++)
                    {
                        cube[w, h, d] = numbs[w];
                    }
                }
            }

            long answer = 0;

            int[] WHD = new int[] { cube.GetLength(0) / 2 , cube.GetLength(1) / 2 , cube.GetLength(2) / 2  };
            int W = WHD[0];
            int H = WHD[1];
            int D = WHD[2];
            visited[W,H,D] = true;
            answer = cube[W,H,D];

            while (true)
            {
                int maxVal = int.MinValue;
                List<int> maxVals = new List<int>();
                int[] newCoords = new int[3];

                for (int w = 0; w < cube.GetLength(0); w++)
                {
                    if (w == W)
                    {
                        continue;
                    }
                    if (cube[w,H,D] >= maxVal)
                    {
                        maxVal = cube[w, H, D];
                        newCoords = new int[] {w,H,D};
                        maxVals.Add(cube[w, H, D]);
                    }
                }

                for (int h = 0; h < cube.GetLength(1); h++)
                {
                    if (h == H)
                    {
                        continue;
                    }
                    if (cube[W, h, D] >= maxVal)
                    {
                        maxVal = cube[W, h, D];
                        newCoords = new int[] { W, h, D };
                        maxVals.Add(cube[W, h, D]);
                    }
                }

                for (int d = 0; d < cube.GetLength(2); d++)
                {
                    if (d == D)
                    {
                        continue;
                    }
                    if (cube[W, H, d] >= maxVal)
                    {
                        maxVal = cube[W, H, d];
                        newCoords = new int[] { W, H, d };
                        maxVals.Add(cube[W, H, d]);
                    }
                }

                maxVals.Sort();

                if (maxVals.Count > 1 && maxVals[maxVals.Count-1] == maxVals[maxVals.Count-2])
                {
                    break;
                }

                if (visited[newCoords[0],newCoords[1],newCoords[2]])
                {
                    break;
                }
                else
                {
                    W = newCoords[0];
                    H = newCoords[1];
                    D = newCoords[2];
                    visited[W,H,D] = true;
                    answer += cube[W, H, D];
                }


            }

            Console.WriteLine(answer);
        }
    }
}
