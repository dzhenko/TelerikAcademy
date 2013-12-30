using System;
using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<int[]> combos = new List<int[]>();
            for (int z1 = 1; z1 < 20; z1++)
            {
                for (int z2 = 2; z2 < 21; z2++)
                {
                    for (int z3 = 3; z3 < 22; z3++)
                    {
                        for (int z4 = 4; z4 < 23; z4++)
                        {
                            for (int z5 = 5; z5 < 24; z5++)
                            {
                                combos.Add(new int[5] { z1, z2, z3, z4, z5 });
                            }
                        }
                    }
                }
            }
            Console.WriteLine(combos.Count);
        }
    }

