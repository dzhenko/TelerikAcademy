using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleGame
{
    struct Bonuses
    {
        public int X;
        public int Y;
        public char C;
        public ConsoleColor Color;
    }
    class ConsoleGame
    {
        static int score = 0;
        static int gameFieldWidth;
        static int gameFieldHeight;

        // 1 is wall; 0 is path; 2 is Player; 3 is path where can be generated bonus; 4 bonus; 5 is portal to next level
        static byte[,] gameField;

        static int torchLight = 5;

        static int[] playerCordinates = new int[2] { 0, 0 };
        static int[] exitCoordinates = new int[2];
        static char playerSymbol = (char)9787;

        static double gameFieldPercentWidth = 0.6;//original 0.6
        static double gameFieldPercentHeight = 0.9;//original 0.9

        static double time = 20.00;
        static bool gamePause = false;
        static int countMaxScorePeople = 10;

        static int level = 1;
        static double scoreMultiplier = 1.00;
        static int bonusToPassLevel = 5;
        static int bonusesGot = 0;

        static List<Bonuses> bonuses = new List<Bonuses>();
        static Random randomGen = new Random();

        static ThreadStart musicMethod = new ThreadStart(Music);
        static Thread musicThread = new Thread(musicMethod);
        static bool backgroundMusic = true;

        private static void SaveScore(int score, string name)
        {
            StreamWriter writer = new StreamWriter(@"..\..\result.txt", true);

            using (writer)
            {
                writer.WriteLine("{0}-{1}", name, score);
            }
        }

        static void CreateBonuses(int bonusCount = 1)
        {
            for (int i = 0; i < bonusCount; i++)
            {
                Bonuses newBonus = new Bonuses();
                newBonus.X = randomGen.Next(0, gameFieldHeight - 1);
                newBonus.Y = randomGen.Next(0, gameFieldWidth - 1);
                newBonus.C = '$';
                newBonus.Color = ConsoleColor.Red;

                while (gameField[newBonus.X, newBonus.Y] != 3)
                {
                    newBonus.X = randomGen.Next(0, gameFieldHeight);
                    newBonus.Y = randomGen.Next(0, gameFieldWidth);
                }
                bonuses.Add(newBonus);
                gameField[newBonus.X, newBonus.Y] = 4;
            }
            //PrintBonuses(bonuses);
        }

        //static void PrintBonuses(List<Bonuses> bonuses)
        //{
        //    foreach (var item in bonuses)
        //    {
        //        Console.BackgroundColor = ConsoleColor.White;
        //        Console.SetCursorPosition(item.Y, item.X);
        //        Console.ForegroundColor = item.Color;
        //        Console.Write(item.C);
        //    }
        //}

        private static void ConsoleWrite(int left, int top, string symbol, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(symbol);
        }

        private static void WelcomeScreen()
        {


            bool[,] logoSymbols = new bool[,]{{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false},
{true,true,false,false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false,false,false,true,true,false,false,false,false,false,false,false,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,true,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,false},
{true,true,true,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,true,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,false,false,false,false,true,true,true,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,true,true,false,false,false,false,true,true,true,true,true,false,false,false,false,false,false,false,false,true,true,true,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,true,true,true,false,false,true,true,true,true,true,true,false,false,false,false,false,false,false,true,true,true,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,false,true,true,true,true,true,true,false,true,true,true,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,false},
{true,true,true,false,false,true,true,true,true,false,false,true,true,true,false,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,false,false,false,true,true,false,false,false,true,true,true,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,false,false,false,false,false,false,false,false,true,true,true,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false},
{true,true,true,false,false,false,false,false,false,false,false,true,true,true,false,false,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,true,true,false,false,true,true,true,true,true,true,true,true,true,true,true,true,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,false}};
            bool[,] drawnSymbols = new bool[1000, 1000];
            bool animate = true;
            for (int row = 0; row < 11; row++)
            {
                for (int col = 0; col < 66; col++)
                {
                    if (Console.KeyAvailable)
                    {
                        animate = false;
                    }
                    bool sleep = false;
                    if (logoSymbols[row, col])
                    {
                        ConsoleWrite(6 + col, 1 + row, " ", ConsoleColor.Black, ConsoleColor.Gray);
                        drawnSymbols[1 + row, 6 + col] = true;
                        ConsoleWrite(8 + col, 1 + row, " ", ConsoleColor.Black, ConsoleColor.Gray);
                        drawnSymbols[1 + row, 8 + col] = true;
                        sleep = true;
                    }
                    if ((drawnSymbols[1 + row, 8 + col] && drawnSymbols[1 + row, 6 + col]))
                    {
                        ConsoleWrite(6 + col, 1 + row, " ", ConsoleColor.DarkRed, ConsoleColor.DarkCyan);
                    }
                    if (sleep && animate)
                    {
                        Thread.Sleep(7);
                        sleep = false;
                    }
                }
            }

            Console.ResetColor();
            ConsoleWrite(5, 17, "Press \"S\" to start the game!", ConsoleColor.Gray);
            ConsoleWrite(45, 17, "Press \"H\" to view high score!", ConsoleColor.Gray);
            bool correctKeyPressed = false;
            while (correctKeyPressed == false)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    SwitchMusic("off");
                    backgroundMusic = true;
                    StartGame();
                    correctKeyPressed = true;
                }
                else if (pressedKey.Key == ConsoleKey.H)
                {
                    Console.Clear();
                    try
                    {
                        PrintScore();
                    }
                    catch (FileNotFoundException)
                    {

                        Console.WriteLine("The Score file can't be found!");
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("The directory of the score file can't be found!");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Some error occured while trying to extract the score!");
                    }
                    correctKeyPressed = true;
                }
            }
        }

        static void StartGame()
        {
            if (backgroundMusic)
            {
                SwitchMusic("on");
            }
            RightSideBar();
            GenerateField();
            CreateBonuses(9);
            DrawGameField();

            while (time >= 0.1) // apply logic here
            {
                CheckForPressedKey();
                ConsoleWrite(gameFieldWidth + 2, 2, string.Format(" Score: {0}", score), ConsoleColor.Blue);
                ConsoleWrite(gameFieldWidth + 2, 0, string.Format(" Remaining Time: {0:0:00}", time), ConsoleColor.Blue);
                ConsoleWrite(gameFieldWidth + 2, 4, string.Format(" Level: {0}", level), ConsoleColor.Blue);
                ConsoleWrite(gameFieldWidth + 15, 4, string.Format(" Multiplier: {0}", scoreMultiplier), ConsoleColor.Blue);
                ConsoleWrite(gameFieldWidth + 2, 6, string.Format(" Bonuses to get: {0}    ", bonusToPassLevel - bonusesGot), ConsoleColor.Blue);
                time -= 0.1;
                Thread.Sleep(100);
            }
            Console.Clear();
            ConsoleWrite(30, 4, "!!!GAME OVER!!!", ConsoleColor.Red);
            ConsoleWrite(30, 5, "Enter your name: ", ConsoleColor.Gray);
            string usersName = Console.ReadLine();
            Console.SetCursorPosition(30, 6);
            SaveScore(score, usersName);
            try
            {
                PrintScore();
            }
            catch (FileNotFoundException)
            {

                Console.WriteLine("The Score file can't be found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory of the score file can't be found!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Some error occured while trying to extract the score!");
            }
            Environment.Exit(0);
        }

        private static void RightSideBar()
        {
            //Commands
            ConsoleWrite(gameFieldWidth + 2, 10, " Commands: ", ConsoleColor.Gray);
            ConsoleWrite(gameFieldWidth + 2, 12, " P - Pause", ConsoleColor.Gray);
            ConsoleWrite(gameFieldWidth + 2, 14, " E - Exit", ConsoleColor.Gray);
            ConsoleWrite(gameFieldWidth + 2, 16, " S - Save", ConsoleColor.Gray);
            ConsoleWrite(gameFieldWidth + 2, 18, " L - Load game", ConsoleColor.Gray);
            ConsoleWrite(gameFieldWidth + 2, 20, " M - Turn off music", ConsoleColor.Gray);
            //horizontal red line
            ConsoleWrite(gameFieldWidth + 1, 7, new string('\u2580', Console.WindowWidth - (gameFieldWidth + 1)), ConsoleColor.Red);
            //vertical red line
            for (int i = 0; i < gameFieldHeight; i++)
            {
                ConsoleWrite(gameFieldWidth + 1, i, '\u2588'.ToString(), ConsoleColor.Red);
            }
        }

        static void Main()
        {
            GameSettings();
            WelcomeScreen();
        }

        private static void SaveGame()
        {
            ConsoleWrite(0, 23, "Please enter the name of the file: ");
            string savedGameName = Console.ReadLine();
            StreamWriter writer = new StreamWriter(@"..\..\" + savedGameName + ".txt");

            using (writer)
            {
                writer.WriteLine(time);
                writer.WriteLine(score);
                writer.WriteLine(playerCordinates[0]);
                writer.WriteLine(playerCordinates[1]);
                writer.WriteLine(level);
                writer.WriteLine(scoreMultiplier);
                writer.WriteLine(bonusesGot);

                for (int loopRow = 0; loopRow < gameFieldHeight; loopRow++)
                {
                    for (int loopCol = 0; loopCol < gameFieldWidth; loopCol++)
                    {
                        writer.Write(gameField[loopRow, loopCol] + " ");
                    }
                    writer.WriteLine();
                }
            }

            //clear output text
            ConsoleWrite(0, 23, "                                                                ");
        }

        private static void LoadSavedGame()
        {
            try
            {
                Console.SetCursorPosition(0, 23);
                Console.Write("Please enter the name of the file with the saved game: ");
                string savedGame = Console.ReadLine();
                StreamReader reader = new StreamReader(@"..\..\" + savedGame + ".txt");

                using (reader)
                {
                    time = double.Parse(reader.ReadLine());
                    score = int.Parse(reader.ReadLine());
                    playerCordinates[0] = int.Parse(reader.ReadLine());
                    playerCordinates[1] = int.Parse(reader.ReadLine());
                    level = int.Parse(reader.ReadLine());
                    scoreMultiplier = double.Parse(reader.ReadLine());
                    bonusesGot = int.Parse(reader.ReadLine());


                    for (int loopRow = 0; loopRow < gameFieldHeight; loopRow++)
                    {
                        string[] currentLine = reader.ReadLine().Split(' ');

                        for (int loopCol = 0; loopCol < gameFieldWidth; loopCol++)
                        {
                            gameField[loopRow, loopCol] = byte.Parse(currentLine[loopCol]);
                        }
                    }
                }

                //clear output text
                ConsoleWrite(0, 23, "                                                                ");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("This file can not me found!");
            }
        }

        private static void CheckForPressedKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow && gamePause == false)
                {
                    MovePlayer(0, -1);
                    CleanBattleField("left");
                    DrawGameField();
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow && gamePause == false)
                {
                    MovePlayer(0, 1);
                    CleanBattleField("right");
                    DrawGameField();
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow && gamePause == false)
                {
                    MovePlayer(-1, 0);
                    CleanBattleField("up");
                    DrawGameField();

                }
                else if (pressedKey.Key == ConsoleKey.DownArrow && gamePause == false)
                {
                    MovePlayer(1, 0);
                    CleanBattleField("down");
                    DrawGameField();
                }
                else if (pressedKey.Key == ConsoleKey.E && gamePause == false)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Good bye!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Environment.Exit(0);
                }
                else if (pressedKey.Key == ConsoleKey.P)
                {
                    if (gamePause)
                    {
                        gamePause = false;
                    }
                    else
                    {
                        gamePause = true;
                        while (gamePause)
                        {
                            CheckForPressedKey();
                        }
                    }
                }
                else if (pressedKey.Key == ConsoleKey.S)
                {
                    SaveGame();
                }
                else if (pressedKey.Key == ConsoleKey.L)
                {

                    LoadSavedGame();
                    CleanBattleField();
                    DrawGameField();
                    //CreateBonuses();
                }
                else if (pressedKey.Key == ConsoleKey.B)
                {
                    time += 20;
                }
                else if (pressedKey.Key == ConsoleKey.N)
                {
                    time -= 20;
                }
                else if (pressedKey.Key == ConsoleKey.T)
                {
                    torchLight++;
                }
                else if (pressedKey.Key == ConsoleKey.R)
                {
                    torchLight--;
                    CleanBattleField();
                    DrawGameField();
                }
                else if (pressedKey.Key == ConsoleKey.M)
                {
                    if (backgroundMusic)
                    {
                        SwitchMusic("off");
                        backgroundMusic = false;
                        ConsoleWrite(gameFieldWidth + 2, 20, " M - Turn on music ", ConsoleColor.Gray);
                    }
                    else
                    {
                        SwitchMusic("on");
                        backgroundMusic = true;
                        ConsoleWrite(gameFieldWidth + 2, 20, " M - Turn off music ", ConsoleColor.Gray);
                    }
                }
            }
        }

        private static void CleanBattleField()
        {
            for (int i = 0; i < gameFieldHeight; i++)
            {
                for (int j = 0; j < gameFieldWidth; j++)
                {
                    ConsoleWrite(j, i, " ", ConsoleColor.Black);
                }

            }
        }

        private static void MovePlayer(int rowChange, int colChange)
        {
            int newRowAfterMove = playerCordinates[0] + rowChange;
            int newColAfterMove = playerCordinates[1] + colChange;
            bool bonusGot = false;
            if (newRowAfterMove >= 0 && newColAfterMove >= 0 && newRowAfterMove < gameFieldHeight && newColAfterMove < gameFieldWidth && gameField[newRowAfterMove, newColAfterMove] != 1)
            {
                if (gameField[newRowAfterMove, newColAfterMove] == 4)
                {
                    score += (int)(100 * scoreMultiplier);
                    time += 5;
                    gameField[newRowAfterMove, newColAfterMove] = 0;
                    bonusGot = true;
                    if (bonusesGot < bonusToPassLevel)
                    {
                        bonusesGot++;
                    }
                }
                if (gameField[newRowAfterMove, newColAfterMove] == 5)
                {
                    if (bonusesGot == bonusToPassLevel)
                    {
                        gameField[newRowAfterMove, newColAfterMove] = 0;
                        Console.Clear();
                        bonuses.Clear();
                        playerCordinates[0] = 0;
                        playerCordinates[1] = 0;
                        scoreMultiplier += 0.2;
                        level++;
                        bonusesGot = 0;
                        bonusToPassLevel += 5;
                        SwitchMusic("off");
                        backgroundMusic = true;
                        StartGame();
                    }
                    else
                    {
                        newRowAfterMove = playerCordinates[0];
                        newColAfterMove = playerCordinates[1];
                    }
                }
                ConsoleWrite(playerCordinates[1], playerCordinates[0], " ", ConsoleColor.White, ConsoleColor.White);
                playerCordinates[0] = newRowAfterMove;
                playerCordinates[1] = newColAfterMove;
                if (bonusGot)
                {
                    foreach (var item in bonuses)
                    {
                        if (item.X == playerCordinates[0] && item.Y == playerCordinates[1])
                        {
                            bonuses.Remove(item);
                            break;
                        }
                    }
                    CreateBonuses();
                    //PrintBonuses(bonuses);
                    gameField[newRowAfterMove, newColAfterMove] = 0;
                    bonusGot = false;
                }
                ConsoleWrite(playerCordinates[1], playerCordinates[0], playerSymbol.ToString(), ConsoleColor.Blue, ConsoleColor.White);
            }
        }

        private static void GameSettings()
        {
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            gameFieldWidth = (int)(Console.WindowWidth * gameFieldPercentWidth);
            gameFieldHeight = (int)(Console.WindowHeight * gameFieldPercentHeight);
            gameField = new byte[gameFieldHeight, gameFieldWidth];
            Console.CursorVisible = false;
            Console.Title = "-=MaZe Game=-";
        }

        private static void CleanBattleField(string direction)
        {
            if (direction == "left")
            {
                if (playerCordinates[1] + torchLight < gameFieldWidth)
                {
                    for (int i = 0; i < gameFieldHeight; i++)
                    {
                        ConsoleWrite(playerCordinates[1] + torchLight + 1, i, " ", ConsoleColor.Black);
                    }
                }
            }
            else if (direction == "right")
            {
                if (playerCordinates[1] - torchLight > 0)
                {
                    for (int i = 0; i < gameFieldHeight; i++)
                    {
                        ConsoleWrite(playerCordinates[1] - torchLight - 1, i, " ", ConsoleColor.Black);
                    }
                }
            }
            else if (direction == "up")
            {
                if (playerCordinates[0] + torchLight < gameFieldHeight)
                {
                    for (int i = 0; i < gameFieldWidth; i++)
                    {
                        ConsoleWrite(i, playerCordinates[0] + torchLight + 1, " ", ConsoleColor.Black);
                    }
                }
            }
            else if (direction == "down")
            {
                if (playerCordinates[0] - torchLight > 0)
                {
                    for (int i = 0; i < gameFieldWidth; i++)
                    {
                        ConsoleWrite(i, playerCordinates[0] - torchLight - 1, " ", ConsoleColor.Black);
                    }
                }
            }
        }

        private static void DrawGameField()
        {
            for (int a = -torchLight; a <= torchLight; a++)
            {
                for (int b = -torchLight; b <= torchLight; b++)
                {
                    if ((playerCordinates[0] + a) < 0 || (playerCordinates[1] + b) < 0 || (playerCordinates[1] + b) >= gameFieldWidth || (playerCordinates[0] + a) >= gameFieldHeight)
                    {
                        continue;
                    }
                    WriteSymbolOnGameFieldPosition(playerCordinates[0] + a, playerCordinates[1] + b);
                }
            }
            ConsoleWrite(playerCordinates[1], playerCordinates[0], playerSymbol.ToString(), ConsoleColor.Blue, ConsoleColor.White);
        }

        private static void WriteSymbolOnGameFieldPosition(int loopRow, int loopCol)
        {
            ConsoleColor backgroundColor = ConsoleColor.Black;
            ConsoleColor foregroundColor = ConsoleColor.White;
            string printedSymbol = " ";
            if (gameField[loopRow, loopCol] == 4)
            {
                backgroundColor = ConsoleColor.White;
                foregroundColor = ConsoleColor.Red;
                printedSymbol = "$";
            }
            else if (gameField[loopRow, loopCol] == 5)
            {
                //Teleport
                backgroundColor = ConsoleColor.Blue;
                foregroundColor = ConsoleColor.White;
                printedSymbol = "@";
            }
            else
            {
                if (gameField[loopRow, loopCol] == 0 || gameField[loopRow, loopCol] == 3)
                {
                    backgroundColor = ConsoleColor.White;
                }
                if (loopCol == 0 && loopRow == 0)
                {
                    backgroundColor = ConsoleColor.White;
                    printedSymbol = " ";
                }
            }
            ConsoleWrite(loopCol, loopRow, printedSymbol, foregroundColor, backgroundColor);
            //ConsoleWrite(playerCordinates[1], playerCordinates[0], playerSymbol.ToString(), ConsoleColor.Blue, ConsoleColor.White);
        }

        private static void GenerateField()
        {
            bool[,] visitedGameField = new bool[gameFieldHeight, gameFieldWidth];
            Random randomPicker = new Random();

            Stack<int> rowStack = new Stack<int>();
            Stack<int> colStack = new Stack<int>();

            int currentCelRow = 0;
            int currentCelCol = 0;
            int countVisits = 1;
            int pathEndX = 0;
            int pathEndY = 0;

            while (countVisits > 0)
            {

                if (!visitedGameField[currentCelRow, currentCelCol])
                {
                    visitedGameField[currentCelRow, currentCelCol] = true;
                    gameField[currentCelRow, currentCelCol] = 3;
                }
                List<int[]> neighbours = GetNeighbours(currentCelRow, currentCelCol, visitedGameField);
                if (neighbours.Count > 0)
                {
                    //Pushing random cell to the stack
                    int[] randomCell = neighbours[randomPicker.Next(0, neighbours.Count)];
                    rowStack.Push(randomCell[0]);
                    colStack.Push(randomCell[1]);
                    currentCelCol = randomCell[1];
                    currentCelRow = randomCell[0];
                    List<int[]> neighboursToMakeUnavailable = GetNeighbours(currentCelRow, currentCelCol, visitedGameField);
                    if (neighboursToMakeUnavailable.Count > 1)
                    {
                        int[] randomtoUnavailable = neighboursToMakeUnavailable[randomPicker.Next(0, neighboursToMakeUnavailable.Count)];
                        visitedGameField[randomtoUnavailable[0], randomtoUnavailable[1]] = true;
                        gameField[randomtoUnavailable[0], randomtoUnavailable[1]] = 1;
                    }
                    if (currentCelCol > (gameFieldWidth / 4) && currentCelRow > (gameFieldHeight / 4))
                    {
                        pathEndX = currentCelCol;
                        pathEndY = currentCelRow;
                    }
                }
                else if (rowStack.Count > 0)
                {
                    currentCelCol = colStack.Pop();
                    currentCelRow = rowStack.Pop();
                }
                else
                {
                    countVisits = 0;
                }
            }
            gameField[pathEndY, pathEndX] = 5;
        }

        private static List<int[]> GetNeighbours(int currentCelRow, int currentCelCol, bool[,] visitedGameField)
        {
            int[][] possibilities = new int[4][] { new int[2] { 0, -1 }, new int[2] { -1, 0 }, new int[2] { 0, 1 }, new int[2] { 1, 0 } };

            List<int[]> neighbours = new List<int[]>();

            foreach (var cell in possibilities)
            {
                if ((currentCelCol + cell[1]) >= 0 && (currentCelCol + cell[1]) < gameFieldWidth && (currentCelRow + cell[0]) >= 0 && (currentCelRow + cell[0]) < gameFieldHeight && !visitedGameField[currentCelRow + cell[0], currentCelCol + cell[1]])
                {
                    neighbours.Add(new int[] { currentCelRow + cell[0], currentCelCol + cell[1] });
                }
            }

            return neighbours;
        }

        private static void PrintScore()
        {

            StreamReader reader = new StreamReader(@"..\..\result.txt");

            var items = new List<KeyValuePair<string, int>>();

            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    int indexOfDash = line.IndexOf('-');
                    StringBuilder name = new StringBuilder();
                    StringBuilder scoreString = new StringBuilder();
                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        if (i < indexOfDash)
                        {
                            name.Append(line[i]);
                        }
                        else
                        {
                            scoreString.Append(line[i + 1]);
                        }
                    }
                    if (scoreString.ToString() != "")
                    {
                        int currentScore = int.Parse(scoreString.ToString());
                        items.Add(new KeyValuePair<string, int>(name.ToString(), currentScore));
                    }

                    line = reader.ReadLine();
                }
                var sortedList = items.OrderByDescending(x => x.Value).Take(countMaxScorePeople);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Top {0} Score:", countMaxScorePeople);
                foreach (var pair in sortedList)
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                }
            }
        }

        private static void SwitchMusic(string musicStatus)
        {
            if (musicStatus == "off")
            {
                musicThread.Abort();
                backgroundMusic = false;
                ConsoleWrite(gameFieldWidth + 2, 20, " M - Turn on music ", ConsoleColor.Gray);
            }
            else if (musicStatus == "on")
            {
                musicMethod = new ThreadStart(Music);
                musicThread = new Thread(musicMethod);
                musicThread.Start();
                backgroundMusic = true;
                ConsoleWrite(gameFieldWidth + 2, 20, " M - Turn off music ", ConsoleColor.Gray);
            }
        }

        private static void Music()
        {
            List<int[]> musicData = new List<int[]>() { new int[3] { 659, 125, 0 }, new int[3] { 659, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 523, 125, 0 }, new int[3] { 659, 125, 125 }, new int[3] { 784, 125, 375 }, new int[3] { 392, 125, 375 }, new int[3] { 523, 125, 250 }, new int[3] { 392, 125, 250 }, new int[3] { 330, 125, 250 }, new int[3] { 440, 125, 125 }, new int[3] { 494, 125, 125 }, new int[3] { 466, 125, 42 }, new int[3] { 440, 125, 125 }, new int[3] { 392, 125, 125 }, new int[3] { 659, 125, 125 }, new int[3] { 784, 125, 125 }, new int[3] { 880, 125, 125 }, new int[3] { 698, 125, 0 }, new int[3] { 784, 125, 125 }, new int[3] { 659, 125, 125 }, new int[3] { 523, 125, 125 }, new int[3] { 587, 125, 0 }, new int[3] { 494, 125, 125 }, new int[3] { 523, 125, 250 }, new int[3] { 392, 125, 250 }, new int[3] { 330, 125, 250 }, new int[3] { 440, 125, 125 }, new int[3] { 494, 125, 125 }, new int[3] { 466, 125, 42 }, new int[3] { 440, 125, 125 }, new int[3] { 392, 125, 125 }, new int[3] { 659, 125, 125 }, new int[3] { 784, 125, 125 }, new int[3] { 880, 125, 125 }, new int[3] { 698, 125, 0 }, new int[3] { 784, 125, 125 }, new int[3] { 659, 125, 125 }, new int[3] { 523, 125, 125 }, new int[3] { 587, 125, 0 }, new int[3] { 494, 125, 375 }, new int[3] { 784, 125, 0 }, new int[3] { 740, 125, 0 }, new int[3] { 698, 125, 42 }, new int[3] { 622, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 415, 125, 0 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 125 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 0 }, new int[3] { 587, 125, 250 }, new int[3] { 784, 125, 0 }, new int[3] { 740, 125, 0 }, new int[3] { 698, 125, 42 }, new int[3] { 622, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 698, 125, 125 }, new int[3] { 698, 125, 0 }, new int[3] { 698, 125, 625 }, new int[3] { 784, 125, 0 }, new int[3] { 740, 125, 0 }, new int[3] { 698, 125, 42 }, new int[3] { 622, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 415, 125, 0 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 125 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 0 }, new int[3] { 587, 125, 250 }, new int[3] { 622, 125, 250 }, new int[3] { 587, 125, 250 }, new int[3] { 523, 125, 1125 }, new int[3] { 784, 125, 0 }, new int[3] { 740, 125, 0 }, new int[3] { 698, 125, 42 }, new int[3] { 622, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 415, 125, 0 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 125 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 0 }, new int[3] { 587, 125, 250 }, new int[3] { 784, 125, 0 }, new int[3] { 740, 125, 0 }, new int[3] { 698, 125, 42 }, new int[3] { 622, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 698, 125, 125 }, new int[3] { 698, 125, 0 }, new int[3] { 698, 125, 625 }, new int[3] { 784, 125, 0 }, new int[3] { 740, 125, 0 }, new int[3] { 698, 125, 42 }, new int[3] { 622, 125, 125 }, new int[3] { 659, 125, 167 }, new int[3] { 415, 125, 0 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 125 }, new int[3] { 440, 125, 0 }, new int[3] { 523, 125, 0 }, new int[3] { 587, 125, 250 }, new int[3] { 622, 125, 250 }, new int[3] { 587, 125, 250 }, new int[3] { 523, 125, 625 } }; ;
            for (int i = 0; i < musicData.Count; i++)
            {
                Console.Beep(musicData[i][0], musicData[i][1]);
                if (musicData[i][2] > 0)
                {
                    Thread.Sleep(musicData[i][2]);
                }
            }
            Music();
        }
    }
}