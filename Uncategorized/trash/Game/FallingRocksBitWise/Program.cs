using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace testBitScr
{
    class MyGAME
    {
        static void Main(string[] args)
        {
            Console.Title = "FALLING SKIES";
            Console.SetWindowSize(40, 25);
            Console.OutputEncoding = Encoding.UTF8;
            string[] rocks = { "\u2591", "\u2592", "\u2593" };
            int Min = -100; // lower negative value = bigger chance for empty rows
            int Max = 16;
            int baseShip = 36194370; // now add some levels!
            int meteors = 0;
            int spaceship = 65536;
            int gameover = 5;
            int score = 0;
            Random randNum = new Random();
            int[] masiv = Enumerable
                .Repeat(0, 20)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();                               // This makes the randomisation
            do
            {
                Console.WriteLine("╒════════════════════════════════╕");

                foreach (int i in masiv)//............................................................//
                {                                                                                     //
                    meteors = baseShip * (int)Math.Pow(2, i);                                         //
                    string bit = Convert.ToString(meteors, 2).PadLeft(32, '0').Replace('0', ' ').     //
                        Replace("1", rocks[new Random().Next(0, rocks.Length)]);                      //
                    Console.WriteLine("\u2502{0}\u2502", bit);                                        //
                }                                                                                     // Enemies
                for (int a = 19; a > 0; a--)                                                          //
                {                                                                                     //
                    masiv[a] = masiv[a - 1];                                                          //
                }                                                                                     //
                masiv[0] = randNum.Next(Min, Max);//..................................................//
                Console.Write("\u2502");
                Console.ForegroundColor = ConsoleColor.Yellow; //.......................//
                string ship = Convert.ToString(spaceship, 2).PadLeft(32, '0').          //
                    Replace("010", "\u2553\u2588\u2556").Replace('0', ' ');             // Our Ship
                Console.Write(ship); //.................................................//
                Console.ResetColor();
                Console.WriteLine("\u2502");
                Console.WriteLine("╘════════════════════════════════╛");

                int colusion = spaceship & meteors; // ......................................//
                if (meteors > 0)                                                             //
                    score++;                                                                 //
                if (colusion != 0)                                                           //
                {                                                                            // Colusion effects
                    Console.BackgroundColor = ConsoleColor.Red;                              //
                    Console.Beep(10000, 30);                                                  //
                    gameover--;                                                              //
                    score--;                                                                 //
                } // ........................................................................//
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  Scores: {0,-5}        Lives: {1}", score, gameover);
                Console.ResetColor();
                for (int sleeptime = 1; sleeptime <= 150; sleeptime++)
                {
                    if (Console.KeyAvailable) //................................................//
                    {                                                                           //
                        ConsoleKeyInfo move = Console.ReadKey(true);                            //
                        if ((move.Key == ConsoleKey.RightArrow) & (spaceship > 2))              //
                            spaceship = spaceship / 2;                                          //
                        if ((move.Key == ConsoleKey.LeftArrow) & (spaceship < 2147483648 / 2))  // Ship Movement
                            spaceship = spaceship * 2;                                          //
                        if (move.Key == ConsoleKey.Escape)                                      //
                            return;                                                             //
                    } //........................................................................//

                    Thread.Sleep(1);
                }
                Console.Clear();
            } while (gameover > 0);
            Console.ResetColor();
            Console.WriteLine(@"
 
 
  __   _  _   _ ___    _  _ _ ___ ___
 / _| / \| \_/ | __|  / \| | | __| o \
( |_n| o | \_/ | _|  ( o ) V | _||   /
 \__/|_n_|_| |_|___|  \_/ \_/|___|_|\\
         
         
        YOUR SCORES: " + score + "\n");
            Thread.Sleep(3000);
        }
    }
}