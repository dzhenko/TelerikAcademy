using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne_11_02_2013
{
    class Program
    {
        static void Main()
        {
            BlackJack();

            CakeProblem();

            RPGProblem();
        }

        static int[] iHaveGSB = new int[3];
        static int[] iNeedGSB = new int[3];
        static int operations = 0;

        private static void RPGProblem()
        {
            string[] coinsTotalInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < 3; i++)
            {
                iHaveGSB[i] = int.Parse(coinsTotalInput[i]);
                iNeedGSB[i] = int.Parse(coinsTotalInput[i + 3]);
            }
            AmIDone();
            IsItPossible();
            silver:
            if (iHaveGSB[1] > iNeedGSB[1])
            {
                if (iHaveGSB[2] < iNeedGSB[2])
                {
                    iHaveGSB[1]--;      //one silver for 9 bronze
                    iHaveGSB[2] += 9;
                    operations++;
                    AmIDone();
                }
                else if (iHaveGSB[0] < iNeedGSB[0] && iHaveGSB[1] - 11 >= iNeedGSB[1])
                {
                    iHaveGSB[0]++;  //11 silver for 1 gold
                    iHaveGSB[1] -= 11;
                    operations++;
                    AmIDone();
                }
                goto silver;
            }
            if (iHaveGSB[0] > iNeedGSB[0])
            {
                iHaveGSB[0]--;  //1 gold for 9 silver
                iHaveGSB[1] += 9;
                operations++;
                AmIDone();
                goto silver;
            }
            if (iHaveGSB[2] - 11 >= iNeedGSB[2])
            {
                iHaveGSB[1]++;
                iHaveGSB[2] -= 11;
                operations++;
                AmIDone();
                goto silver;
            }

            Console.WriteLine(-1);
        }

        private static void IsItPossible()
        {
            int goldDiff = iHaveGSB[0] - iNeedGSB[0];
            int silvDiff = iHaveGSB[1] - iNeedGSB[1];
            int brnzDiff = iHaveGSB[2] - iNeedGSB[2];

            if (goldDiff < 0)
            {
                if (silvDiff < 0) //silver < 0
                {
                    if (brnzDiff < 0)
                    {
                        Console.WriteLine(-1);
                        Environment.Exit(0);
                    }
                    int needed = ((goldDiff * (-1) * 11) + silvDiff*(-1)) * 11;
                    if (needed > brnzDiff)
                    {
                        Console.WriteLine(-1);
                        Environment.Exit(0);
                    }
                }
                else if (brnzDiff < 0) //silver > 0
                {
                    int neededS = (goldDiff * (-1) * 11) + (brnzDiff + 8) / 9;
                    if (neededS > silvDiff)
                    {
                        Console.WriteLine(-1);
                        Environment.Exit(0);
                    }
                }
                else //silver and bronze > 0
                {
                    int neededG = goldDiff * (-1) * 11;
                    if (silvDiff + (brnzDiff+10) / 11 < neededG)
                    {
                        Console.WriteLine(-1);
                        Environment.Exit(0);
                    }
                }
            }
            else // i have gold
            {
                if (silvDiff < 0)
                {
                    if (brnzDiff < 0)
                    {
                        int needForSilver = (silvDiff * (-1) + 8) / 9;
                        int needForBronze = (brnzDiff * (-1) + 80) / 81;
                        if (goldDiff < needForBronze + needForSilver)
                        {
                            Console.WriteLine(-1);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        int silverFromBronze = (brnzDiff + 10) / 11;
                        int silverFromGold = goldDiff * 9;
                        if (silvDiff*(-1) > silverFromBronze+silverFromGold)
                        {
                            Console.WriteLine(-1);
                            Environment.Exit(0);
                        }
                    }
                }
                else // i have silver and gold
                {
                    if (brnzDiff < 0)
                    {
                        int HaveBronze = goldDiff * 81 + silvDiff * 9;
                        if (HaveBronze < brnzDiff * (-1))
                        {
                            Console.WriteLine(-1);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private static void AmIDone()
        {
            if (iHaveGSB[0] >= iNeedGSB[0] && iHaveGSB[1] >= iNeedGSB[1] && iHaveGSB[2] >= iNeedGSB[2])
            {
                Console.WriteLine(operations);
                Environment.Exit(0);
            }
        }

        private static void CakeProblem()
        {
            int[] cakes = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int persons = int.Parse(Console.ReadLine()) + 1;

            Array.Sort(cakes);
            int total = 0;

            for (int i = cakes.Length - 1; i >= 0; i = (i - persons))
            {
                total += cakes[i];
            }

            Console.WriteLine(total);
        }

        private static void BlackJack()
        {
            int[] points = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int index = 0;
            bool one = false;
            for (int i = 21; i >= 0; i--)
            {
                for (int p = 0; p < points.Length; p++)
                {
                    if (points[p] == i)
                    {
                        if (one)
                        {
                            Console.WriteLine(-1);
                            return;
                        }
                        else
                        {
                            one = true;
                            index = p;
                        }
                    }
                }
                if (one)
                {
                    Console.WriteLine(index);
                    return;
                }
            }
            Console.WriteLine(-1);
        }
    }
}
