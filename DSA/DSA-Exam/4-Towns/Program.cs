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

            var increazing = new int[allTownsCount];
            var decreazing = new int[allTownsCount];

            increazing[0] = 1;
            decreazing[0] = 1;

            var startsDecreazing = new int[allTownsCount];
            startsDecreazing[0] = -1;

            for (int i = 1; i < allTownsCount; i++)
            {
                increazing[i] = 1;
                decreazing[i] = 1;

                startsDecreazing[i] = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (increazing[j] + 1 > increazing[i] && towns[j] < towns[i])
                    {
                        increazing[i] = increazing[j] + 1;
                    }
                    if (decreazing[j] + 1 > decreazing[i] && towns[j] > towns[i])
                    {
                        decreazing[i] = decreazing[j] + 1;
                        startsDecreazing[i] = j;
                    }
                }
            }

            // build max decreazing from every index
            var indexDecreazing = new int[allTownsCount];

            for (int t = 0; t < allTownsCount; t++)
            {
                var help = new int[allTownsCount];
                help[t] = 1;
                var currMax = 0;

                for (int i = t + 1; i < allTownsCount; i++)
                {
                    help[i] = 1;

                    for (int j = i - 1; j >= t; j--)
                    {
                        if (help[j] + 1 > help[i] && towns[j] > towns[i])
                        {
                            help[i] = help[j] + 1;
                            if (help[i] > currMax)
                            {
                                currMax = help[i];
                            }
                        }
                    }
                }

                indexDecreazing[t] = currMax;
            }

            var absoluteMax = Math.Max(increazing.Max(), decreazing.Max());

            for (int t = 0; t < allTownsCount; t++)
            {
                var pot = increazing[t];

                if (pot > absoluteMax)
                {
                    absoluteMax = pot;
                }

                if (pot + indexDecreazing[t] - 1 > absoluteMax)
                {
                    absoluteMax = pot + indexDecreazing[t] - 1;
                }
            }

            Console.WriteLine(absoluteMax);
        }
    }
}
