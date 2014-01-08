using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program
{

    public static string[, ,] cube;

    public static int[] ball;



    static void Main(string[] args)
    {
        if (File.Exists(@"input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        CreateCube();

        GetBallInitialPosition();

        MoveTheBall();
    }

    private static void MoveTheBall()
    {
        while (true)
        {
            //Fall trough - just increaze hight
            if (cube[ball[0], ball[1], ball[2]] == "E")
            {
                MoveTroughHoleE();
            }

            //teleport
            else if (cube[ball[0], ball[1], ball[2]][0] == 'T')
            {
                TeleportTheBall();
            }
            else if (cube[ball[0], ball[1], ball[2]] == "B")
            {
                GameOver(ball);
            }
            else
            {
                //we are sliding

                //if we are sliding on the last row (height) => we win
                if (ball[1] == cube.GetLength(1) - 1)
                {
                    LastHeightSlideWin();
                }

                else if (cube[ball[0], ball[1], ball[2]] == "S F")
                {
                    MoveForward();
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S B")
                {
                    MoveBackwards();
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S R")
                {
                    MoveRight();
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S L")
                {
                    MoveLeft();
                }
                //W H D
                else if (cube[ball[0], ball[1], ball[2]] == "S FR")
                {
                    MoveForwardRight();
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S BR")
                {
                    MoveBackwardsRight();
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S FL")
                {
                    MoveForwardLeft();
                }
                else if (cube[ball[0], ball[1], ball[2]] == "S BL")
                {
                    MoveBackwardsLeft();
                }

                //the ball always increazes it's height
                ball[1]++;
            }
        }
    }

    private static void LastHeightSlideWin()
    {
        Console.WriteLine("Yes");
        Console.WriteLine("{0} {1} {2}", ball[0], ball[1], ball[2]);
        Environment.Exit(0);
    }

    private static void MoveTroughHoleE()
    {
        ball[1]++;

        //check if we are out of the cube (if this was a hole at the last row of the cube)
        if (ball[1] >= cube.GetLength(1))
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0} {1} {2}", ball[0], ball[1] - 1, ball[2]);
            Environment.Exit(0);
        }
    }

    private static void MoveBackwardsLeft()
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

    private static void MoveForwardLeft()
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

    private static void MoveBackwardsRight()
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

    private static void MoveForwardRight()
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

    private static void MoveLeft()
    {
        if (ball[0] == 0)
        {
            GameOver(ball);
        }
        ball[0]--;
    }

    private static void MoveRight()
    {
        if (ball[0] == cube.GetLength(0) - 1)
        {
            GameOver(ball);
        }
        ball[0]++;
    }

    private static void MoveBackwards()
    {
        if (ball[2] == cube.GetLength(2) - 1)
        {
            GameOver(ball);
        }
        ball[2]++;
    }

    private static void MoveForward()
    {
        if (ball[2] == 0)
        {
            GameOver(ball);
        }
        ball[2]--;
    }

    private static void TeleportTheBall()
    {
        int[] teleportCoords = cube[ball[0], ball[1], ball[2]].TrimStart('T').Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        ball[0] = teleportCoords[0];
        ball[2] = teleportCoords[1];
    }

    private static void GetBallInitialPosition()
    {
        int[] ballStartCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();

        ball = new int[] { ballStartCoords[0], 0, ballStartCoords[1] };
    }

    private static void CreateCube()
    {
        int[] WHD = Console.ReadLine().Split().Select(int.Parse).ToArray();

        cube = new string[WHD[0], WHD[1], WHD[2]];

        ReadCubeFromConsole(WHD);
    }

    private static void ReadCubeFromConsole(int[] WHD)
    {
        for (int h = 0; h < WHD[1]; h++)
        {
            string[] currLine = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < WHD[2]; d++)
            {
                string[] currItems = currLine[d].Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < WHD[0]; w++)
                {
                    cube[w, h, d] = currItems[w].TrimStart().TrimStart('(');
                }
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

