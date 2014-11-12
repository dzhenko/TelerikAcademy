using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            var allTownsCount = int.Parse(Console.ReadLine());

            var towns = new int[allTownsCount];

            for (int i = 0; i < allTownsCount; i++)
            {
                towns[i] = int.Parse(Console.ReadLine().Split()[0]);
            }

            if (allTownsCount == 1)
            {
                Console.WriteLine(1);
                return;
            }

            if (allTownsCount == 2)
            {
                if (towns[0] != towns[1])
                {
                    Console.WriteLine(2);
                }
                else
                {
                    Console.WriteLine(1);
                }
                return;
            }

            var absoluteMax = 1;

            // t is the town we change - we start decreazing in population
            for (int t = 0; t < allTownsCount; t++)
            {
                var increazing = new int[allTownsCount];
                increazing[0] = 1;

                for (int i = 1; i < allTownsCount; i++)
                {
                    increazing[i] = 1;

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (increazing[j] + 1 > increazing[i])
                        {
                            // we are in the ascending part
                            if (i <= t && towns[j] < towns[i])
                            {
                                increazing[i] = increazing[j] + 1;
                                if (absoluteMax < increazing[j] + 1)
                                {
                                    absoluteMax = increazing[j] + 1;
                                }
                            }
                            // we are in the descending part
                            else if (i > t && towns[j] > towns[i])
                            {
                                increazing[i] = increazing[j] + 1;
                                if (absoluteMax < increazing[j] + 1)
                                {
                                    absoluteMax = increazing[j] + 1;
                                }
                            }
                            
                        }
                    }
                }
            }
            Console.WriteLine(absoluteMax == 0 ? -1 : absoluteMax);
        }
    }
}
