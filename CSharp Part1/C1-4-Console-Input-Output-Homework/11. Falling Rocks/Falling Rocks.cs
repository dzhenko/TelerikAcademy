//* Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move 
//left and right (by the arrows keys). A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
//Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
//The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).



using System;
using System.Collections.Generic;
using System.Threading;

struct Object
{
    public int x;
    public int y;
    public string str;
    public ConsoleColor color;
}

class FallingRocks
{
    static void PrintOnScreen(int x, int y, string str, ConsoleColor color)
    {
        Console.SetCursorPosition(x,y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
    static void Main(string[] args)
    {
        //screen setup
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 60;
        //playerobject
        int score = 0;
        Object Player = new Object();
        Player.x = (int)Console.WindowWidth/3 - 1;
        Player.y = Console.WindowHeight - 1;
        Player.str = "(0)";
        Player.color = ConsoleColor.Yellow;
        //rocks
        List<Object> rocks = new List<Object>();
        Random Random = new Random();
        //all the types for rocks
        string[] allTypes = new string [12];
            allTypes[0] = "^";
            allTypes[1] = "@";
            allTypes[2] = "*";
            allTypes[3] = "&";
            allTypes[4] = "+";
            allTypes[5] = "%";
            allTypes[6] = "$";
            allTypes[7] = "#";
            allTypes[8] = "!";
            allTypes[9] = ".";
            allTypes[10] = ";";
            allTypes[11] = "-";
        //all the colors
        ConsoleColor[] allColors = new ConsoleColor [5];
            allColors[0] = ConsoleColor.Cyan;
            allColors[1] = ConsoleColor.Blue;
            allColors[2] = ConsoleColor.Magenta;
            allColors[3] = ConsoleColor.Green;
            allColors[4] = ConsoleColor.White;
        //game settings
        int lives = 0;       
        //game core
        while (true)
        {
            bool hitted = false;
           //player movement 
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (Player.x -1 > 0)
                    {
                        Player.x = Player.x - 1;
                    }
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (Player.x + 3 < 40)
                    {
                        Player.x = Player.x + 1;
                    }
                }
            } 
            //rocks                   
            for (int i = 1; i < Random.Next(1,4); i++)
            {
                Object newRock = new Object();
                newRock.x = Random.Next(1, 40);
                newRock.y = 0;
                newRock.str = allTypes[Random.Next(0,12)];
                newRock.color = allColors[Random.Next(0, 5)];
                rocks.Add(newRock);
            }
            //moving rocks
            List<Object> newRocks = new List<Object>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Object oldRock = rocks[i];
                Object newRock = new Object();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.str = oldRock.str;
                newRock.color = oldRock.color;                
                //are they hiiting us
                if (newRock.y == Player.y)
                {
                    if (newRock.x == Player.x || newRock.x == Player.x+1 || newRock.x == Player.x+2)
                    {
                        hitted = true;
                    }
                }
                if (newRock.y < Console.WindowHeight)
                {
                    newRocks.Add(newRock);
                }
            }
            
            //refresh
            Console.Clear();
            rocks = newRocks;
            //redraw
            PrintOnScreen(Player.x,Player.y,Player.str,Player.color);
            foreach (Object rock in rocks)
            {
                PrintOnScreen(rock.x,rock.y,rock.str,rock.color);
            }
            if (hitted)
            {
                Console.Beep();
                score = score - 25;
                lives--;
                rocks.Clear();
                PrintOnScreen(Player.x, Player.y, "XXX", ConsoleColor.Red); 
            }
            //game over
            if (lives == -1)
            {
                Console.Beep();
                for (int i = 0; i < 8; i++)
                {
                    Console.Beep();
                    for (int j = 0; j < Console.WindowWidth; j++)
                    {
                        PrintOnScreen(j, i, "X", ConsoleColor.Red);
                    }
                    for (int j = 0; j < Console.WindowWidth; j++)
                    {
                        PrintOnScreen(j, 19 - i, "X", ConsoleColor.Red);
                    }
                }
                PrintOnScreen(18, 9, "G  A  M  E      O  V  E  R", ConsoleColor.Yellow);
                PrintOnScreen(20, 10, "YOUR SCORE : "+score, ConsoleColor.Yellow);
                Console.ReadKey();
                Environment.Exit(0);
            }
            //borders
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                PrintOnScreen(0, i, "|", ConsoleColor.Gray);
                PrintOnScreen(Console.WindowWidth-20, i, "|", ConsoleColor.Gray);
            }
            //info           
            PrintOnScreen(44, 0, "-------------", ConsoleColor.Yellow);
            PrintOnScreen(44, 1, "FALLING ROCKS", ConsoleColor.Yellow);
            PrintOnScreen(44, 2, "-------------", ConsoleColor.Yellow);
            PrintOnScreen(43, 5, "Your lives : "+lives, ConsoleColor.Green);
            PrintOnScreen(43, 7, "Your score : "+score, ConsoleColor.Green);
            score = score++;
            //speed
            System.Threading.Thread.Sleep(150);         
        }
    }
}

