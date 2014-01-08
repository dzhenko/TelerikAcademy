using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[] WHD;

    public static string[, ,] cube;



    static void Main(string[] args)
    {
        WHD = Console.ReadLine().Split().Select(int.Parse).ToArray();

        cube = new string[WHD[0], WHD[1], WHD[2]];

        for (int h = 0; h < WHD[1]; h++)
        {
            string[] currLine = Console.ReadLine().Split(new char[] { '|'},StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < WHD[2]; d++)
            {
                string[] currItems = currLine[d].Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < WHD[0]; w++)
                {
                    cube[w, h, d] = currItems[w].TrimStart().TrimStart('(');
                }
            }
        }

        int[] ballStartCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] ball = new int[] { ballStartCoords[0], 0, ballStartCoords[1] };

        while (true)
        {
            if (cube[ball[0],ball[1],ball[2]] == "E")
            {
                ball[1]++;
            }
            else if (cube[ball[0],ball[1],ball[2]][0] == 'T')
            {
                int[] teleportCoords = cube[ball[0], ball[1], ball[2]].TrimStart('T').Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                ball[0] = teleportCoords[0];
                ball[2] = teleportCoords[1];
            }
            else if (cube[ball[0],ball[1],ball[2]] == "B")
            {
                GameOver(ball);
            }
            else
            {
                if (ball[1] == cube.GetLength(1) - 1)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine("{0} {1} {2}", ball[0], ball[1], ball[2]);
                    return;
                }
                else if (cube[ball[0],ball[1],ball[2]] == "S F")
                {
                    if (ball[2] == 0)
                    {
                        GameOver(ball);
                    }
                    ball[2]--;
                }
                else if (cube[ball[0],ball[1],ball[2]] == "S B")
                {
                    if (ball[2] == cube.GetLength(2) - 1)
                    {
                        GameOver(ball);
                    }
                    ball[2]++;
                }
                else if (cube[ball[0],ball[1],ball[2]] == "S R")
                {
                    if (ball[0] == cube.GetLength(0) - 1)
                    {
                        GameOver(ball);
                    }
                    ball[0]++;
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S L")
                {
                    if (ball[0] == 0)
                    {
                        GameOver(ball);
                    }
                    ball[0]--;
                }
                //W H D
                else if (cube[ball[0], ball[1], ball[2]] == "S FR")
                {
                    if (ball[2] == 0)
                    {
                        GameOver(ball);
                    }
                    if (ball[0] == cube.GetLength(0) - 1)
                    {
                        GameOver(ball);
                    }
                    ball[0]++;
                    ball[2]--;
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S BR")
                {
                    if (ball[2] == cube.GetLength(2) - 1)
                    {
                        GameOver(ball);
                    }
                    if (ball[0] == cube.GetLength(0) - 1)
                    {
                        GameOver(ball);
                    }
                    ball[0]++;
                    ball[2]++;
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S FL")
                {
                    if (ball[2] == 0)
                    {
                        GameOver(ball);
                    }
                    if (ball[0] == 0)
                    {
                        GameOver(ball);
                    }
                    ball[0]--;
                    ball[2]--;
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S BL")
                {
                    if (ball[2] == cube.GetLength(2) - 1)
                    {
                        GameOver(ball);
                    }
                    if (ball[0] == 0)
                    {
                        GameOver(ball);
                    }
                    ball[0]--;
                    ball[2]++;
                }
                ball[1]++;
            }

            if (ball[1] >= cube.GetLength(1))
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", ball[0], ball[1] - 1, ball[2]);
                break;
            }
        }
    }

    private static void GameOver(int[] ball)
    {
        Console.WriteLine("No");
        Console.WriteLine("{0} {1} {2}", ball[0], ball[1], ball[2]);
        Environment.Exit(0);
    }
}

