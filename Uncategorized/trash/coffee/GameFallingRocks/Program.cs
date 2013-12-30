using System;
using System.Threading;
using System.Text;
using System.Collections.Generic;

struct Rock
{
    public int x;
    public int y;
    public char symbolRock;
    public ConsoleColor colorRock;
}
struct Dwarf
{
    public int x;
    public int y;
    public string dwarfDraw;
    public ConsoleColor colorDwarf;
}
class FallingRocks
{
    static void PrintOnPositionRock(int x, int y, char symbolRock, ConsoleColor colorRock = ConsoleColor.Green)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = colorRock;
        Console.WriteLine(symbolRock);
    }

    static void PrintOnPositionString(int x, int y, string text, ConsoleColor color = ConsoleColor.Green)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    static void Main()
    {
        Random randomGenerator = new Random();
        char[] typesOfRocks = new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        int result = 0;
        int lives = 5;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;

        Dwarf dwarf = new Dwarf();
        dwarf.x = ((Console.WindowWidth / 2) - 2);
        dwarf.y = (Console.WindowHeight - 1);
        dwarf.dwarfDraw = "(0)";
        dwarf.colorDwarf = ConsoleColor.White;

        List<Rock> rocks = new List<Rock>();
        while (true)
        {
            int typeOfRock = randomGenerator.Next(0, 12);
            bool hit = false;
            Rock newrock = new Rock();
            newrock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
            newrock.y = 0;
            newrock.symbolRock = typesOfRocks[typeOfRock];
            newrock.colorRock = (ConsoleColor)randomGenerator.Next(10, 16);
            rocks.Add(newrock);

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x - 1 >= 0)
                    {
                        dwarf.x = dwarf.x - 1;

                    }
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 1 < Console.WindowWidth - 3)
                    {
                        dwarf.x = dwarf.x + 1;
                    }
                }
            }
            List<Rock> newList = new List<Rock>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                Rock newRock = new Rock();

                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.symbolRock = oldRock.symbolRock;
                newRock.colorRock = oldRock.colorRock;
                if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }

                if (((newRock.x == dwarf.x) || (newRock.x == dwarf.x + 1) || (newRock.x == dwarf.x + 2)) && (newRock.y == dwarf.y))
                {
                    hit = true;
                    lives--;
                    if (lives <= 0)
                    {
                        PrintOnPositionString(9, 8, "Game Over", ConsoleColor.Red);
                        Console.ReadLine();
                        return;
                    }
                }
            }
            rocks = newList;

            Console.Clear();

            if (hit)
            {
                PrintOnPositionString(dwarf.x, dwarf.y, "X", ConsoleColor.Red);
                rocks.Clear();
            }
            else
            {
                PrintOnPositionString(dwarf.x, dwarf.y, dwarf.dwarfDraw, dwarf.colorDwarf);
            }
            foreach (Rock rock in rocks)
            {
                PrintOnPositionRock(rock.x, rock.y, rock.symbolRock, rock.colorRock);
            }
            PrintOnPositionString(8, 4, "Lives:" + lives, ConsoleColor.White);
            PrintOnPositionString(8, 5, "Points:" + result, ConsoleColor.White);

            Thread.Sleep(250);
            result++;
        }
    }
}