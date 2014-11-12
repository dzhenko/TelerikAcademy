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

            var absoluteMax = 0;

            for (int i = 0; i < allTownsCount; i++)
            {
                towns[i] = int.Parse(Console.ReadLine().Split()[0]);
            }

            var increazing = new int[allTownsCount];

            increazing[0] = 1;

            for (int i = 1; i < allTownsCount; i++)
            {
                increazing[i] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (increazing[j] + 1 > increazing[i] && towns[j] < towns[i])
                    {
                        increazing[i] = increazing[j] + 1;
                    }
                }
            }

            for (int t = 0; t < allTownsCount; t++)
            {
                var pot = increazing[t];

                if (pot > absoluteMax)
                {
                    absoluteMax = pot;
                }

                // check max decreazing sequence from this pos
                var decreazing = new int[allTownsCount];
                decreazing[t] = 1;
                var maxDec = 1;

                for (int i = t + 1; i < allTownsCount; i++)
                {
                    decreazing[i] = 1;

                    for (int j = i - 1; j >= t; j--)
                    {
                        if (decreazing[j] + 1 > decreazing[i] && towns[j] > towns[i])
                        {
                            decreazing[i] = decreazing[j] + 1;
                            if (maxDec < decreazing[i])
                            {
                                maxDec = decreazing[i];
                            }
                        }
                    }
                }

                if (pot + maxDec - 1 > absoluteMax)
                {
                    absoluteMax = pot + maxDec - 1;
                }
            }

            Console.WriteLine(absoluteMax);
        }

        static int FindMaxIndex(int[] arr, int[] startsDecreazing, int startIndex)
        {
            var max = 1;
            for (int i = startIndex; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    var sourceDecreazing = i;

                    while (startsDecreazing[sourceDecreazing] != -1)
                    {
                        sourceDecreazing = startsDecreazing[sourceDecreazing];
                    }

                    if (sourceDecreazing == startIndex)
                    {
                        max = arr[i];
                    }
                }
            }

            return max;
        }
    }
}
