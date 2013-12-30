using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CardWars
{
    class Program
    {
        static int WhatIsTheCard(string card)
        {
            int score = 0;
            switch (card)
            {
                case "2": score = 10; break;
                case "3": score = 9; break;
                case "4": score = 8; break;
                case "5": score = 7; break;
                case "6": score = 6; break;
                case "7": score = 5; break;
                case "8": score = 4; break;
                case "9": score = 3; break;
                case "10": score = 2; break;
                case "J": score = 11; break;
                case "Q": score = 12; break;
                case "K": score = 13; break;
                case "A": score = 1; break;
                case "X": score = 0; break;
                case "Y": score = 999; break;
                case "Z": score = 222; break;
            }
            return score;
        }
        static void Main(string[] args)
        {
            int rounds = int.Parse(Console.ReadLine());
            string a1, a2, a3, b1, b2, b3;
            int scoreA = 0;
            int scoreB = 0;
            int gamesA = 0;
            int gamesB = 0;
            BigInteger finalscoreA = 0;
            BigInteger finalscoreB = 0;
            for (int round = 0; round < rounds; round++)
            {
                a1 = Console.ReadLine();
                a2 = Console.ReadLine();
                a3 = Console.ReadLine();
                b1 = Console.ReadLine();
                b2 = Console.ReadLine();
                b3 = Console.ReadLine();

                if (a1 == "X" || a2 == "X" || a3 == "X" || b1 == "X" || b2 == "X" || b3 == "X")
                {
                    if ((a1 == "X" || a2 == "X" || a3 == "X") && (b1 != "X" && b2 != "X" && b3 != "X"))
                    {
                        Console.WriteLine("X card drawn! Player one wins the match!");
                        Environment.Exit(0);
                    }
                    else if ((a1 != "X" && a2 != "X" && a3 != "X") && (b1 == "X" || b2 == "X" || b3 == "X"))
                    {
                        Console.WriteLine("X card drawn! Player two wins the match!");//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        Environment.Exit(0);
                    }
                    else
                    {
                        finalscoreA += 50;
                        finalscoreB += 50;
                    }
                }
                //A 1
                if (WhatIsTheCard(a1) == 222)
                {
                    finalscoreA = finalscoreA * 2;
                }
                else if (WhatIsTheCard(a1) == 999)
                {
                    finalscoreA = finalscoreA - 200;
                }
                else
                {
                    scoreA = scoreA + WhatIsTheCard(a1);
                }
                //A 2
                if (WhatIsTheCard(a2) == 222)
                {
                    finalscoreA = finalscoreA * 2;
                }
                else if (WhatIsTheCard(a2) == 999)
                {
                    finalscoreA = finalscoreA - 200;
                }
                else
                {
                    scoreA = scoreA + WhatIsTheCard(a2);
                }
                //A 3
                if (WhatIsTheCard(a3) == 222)
                {
                    finalscoreA = finalscoreA * 2;
                }
                else if (WhatIsTheCard(a3) == 999)
                {
                    finalscoreA = finalscoreA - 200;
                }
                else
                {
                    scoreA = scoreA + WhatIsTheCard(a3);
                }

                //B 1
                if (WhatIsTheCard(b1) == 222)
                {
                    finalscoreB = finalscoreB * 2;
                }
                else if (WhatIsTheCard(b1) == 999)
                {
                    finalscoreB = finalscoreB - 200;
                }
                else
                {
                    scoreB = scoreB + WhatIsTheCard(b1);
                }
                //B 2
                if (WhatIsTheCard(b2) == 222)
                {
                    finalscoreB = finalscoreB * 2;
                }
                else if (WhatIsTheCard(b2) == 999)
                {
                    finalscoreB = finalscoreB - 200;
                }
                else
                {
                    scoreB = scoreB + WhatIsTheCard(b2);
                }
                //B 3
                if (WhatIsTheCard(b3) == 222)
                {
                    finalscoreB = finalscoreB * 2;
                }
                else if (WhatIsTheCard(b3) == 999)
                {
                    finalscoreB = finalscoreB - 200;
                }
                else
                {
                    scoreB = scoreB + WhatIsTheCard(b3);
                }


                //FINAL
                if (scoreA > scoreB)
                {
                    finalscoreA = finalscoreA + scoreA;
                    gamesA++;
                }
                else if (scoreA < scoreB)
                {
                    finalscoreB = finalscoreB + scoreB;
                    gamesB++;
                }
                scoreA = 0;
                scoreB = 0;
            }
            if (finalscoreA > finalscoreB)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: " + finalscoreA);
                Console.WriteLine("Games won: " + gamesA);
            }
            else if (finalscoreA < finalscoreB)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: " + finalscoreB);
                Console.WriteLine("Games won: " + gamesB);
            }
            else if (finalscoreA == finalscoreB)
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: " + finalscoreA);
            }
        }
    }
}