namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        public static void Main(string[] args)
        {
            const int MAXIMUM_CELLS_TO_OPEN = 35;

            string currentCommand = string.Empty;
            char[,] playfieldMatrix = GeneratePlayfield();
            char[,] bombsMatrix = GenerateBombs();
            int openedPositionsCounter = 0;
            bool openedMine = false;
            List<Score> topPlayers = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool noGameActive = true;
            bool reachedMaximumOpenedCells = false;

            do
            {
                if (noGameActive)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    ShowPlayfieldOnConsole(playfieldMatrix);
                    noGameActive = false;
                }

                Console.Write("Daj red i kolona : ");
                currentCommand = Console.ReadLine().Trim();

                if (currentCommand.Length >= 3)
                {
                    if (int.TryParse(currentCommand[0].ToString(), out row) &&
                    int.TryParse(currentCommand[2].ToString(), out col) &&
                        row <= playfieldMatrix.GetLength(0) && col <= playfieldMatrix.GetLength(1))
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        ShowTopScores(topPlayers);
                        break;
                    case "restart":
                        playfieldMatrix = GeneratePlayfield();
                        bombsMatrix = GenerateBombs();
                        ShowPlayfieldOnConsole(playfieldMatrix);
                        openedMine = false;
                        noGameActive = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombsMatrix[row, col] != '*')
                        {
                            if (bombsMatrix[row, col] == '-')
                            {
                                OpenPositionOnPlayfield(playfieldMatrix, bombsMatrix, row, col);
                                openedPositionsCounter++;
                            }

                            if (MAXIMUM_CELLS_TO_OPEN == openedPositionsCounter)
                            {
                                reachedMaximumOpenedCells = true;
                            }
                            else
                            {
                                ShowPlayfieldOnConsole(playfieldMatrix);
                            }
                        }
                        else
                        {
                            openedMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (openedMine)
                {
                    ShowPlayfieldOnConsole(bombsMatrix);

                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ", openedPositionsCounter);
                    string currentName = Console.ReadLine();
                    Score currentScore = new Score(currentName, openedPositionsCounter);

                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < currentScore.Points)
                            {
                                topPlayers.Insert(i, currentScore);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    ShowTopScores(topPlayers);

                    playfieldMatrix = GeneratePlayfield();
                    bombsMatrix = GenerateBombs();
                    openedPositionsCounter = 0;
                    openedMine = false;
                    noGameActive = true;
                }

                if (reachedMaximumOpenedCells)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    ShowPlayfieldOnConsole(bombsMatrix);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Score to4kii = new Score(imeee, openedPositionsCounter);
                    topPlayers.Add(to4kii);
                    ShowTopScores(topPlayers);
                    playfieldMatrix = GeneratePlayfield();
                    bombsMatrix = GenerateBombs();
                    openedPositionsCounter = 0;
                    reachedMaximumOpenedCells = false;
                    noGameActive = true;
                }
            }
            while (currentCommand != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowTopScores(List<Score> listOfTopScores)
        {
            Console.WriteLine("\nTo4KI:");
            if (listOfTopScores.Count > 0)
            {
                for (int i = 0; i < listOfTopScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, listOfTopScores[i].Name, listOfTopScores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void OpenPositionOnPlayfield(
                                                    char[,] playfieldMatrix,
                                                    char[,] bombsMatrix,
                                                    int openedRow,
                                                    int openedCol)
        {
            char kolkoBombi = CheckNumberOfNeighbourBombs(bombsMatrix, openedRow, openedCol);
            bombsMatrix[openedRow, openedCol] = kolkoBombi;
            playfieldMatrix[openedRow, openedCol] = kolkoBombi;
        }

        private static void ShowPlayfieldOnConsole(char[,] playfieldMatrix)
        {
            int playfieldRows = playfieldMatrix.GetLength(0);
            int playfieldCols = playfieldMatrix.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < playfieldRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < playfieldCols; j++)
                {
                    Console.Write(string.Format("{0} ", playfieldMatrix[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GeneratePlayfield()
        {
            const int PLAYFIELD_ROWS = 5;
            const int PLAYFIELD_COLS = 10;
            const char UNOPENED_FIELD = '?';

            char[,] playfieldMatrix = new char[PLAYFIELD_ROWS, PLAYFIELD_COLS];

            for (int i = 0; i < PLAYFIELD_ROWS; i++)
            {
                for (int j = 0; j < PLAYFIELD_COLS; j++)
                {
                    playfieldMatrix[i, j] = UNOPENED_FIELD;
                }
            }

            return playfieldMatrix;
        }

        private static char[,] GenerateBombs()
        {
            const int PLAYFIELD_ROWS = 5;
            const int PLAYFIELD_COLS = 10;

            char[,] playfieldMatrix = new char[PLAYFIELD_ROWS, PLAYFIELD_COLS];

            for (int i = 0; i < PLAYFIELD_ROWS; i++)
            {
                for (int j = 0; j < PLAYFIELD_COLS; j++)
                {
                    playfieldMatrix[i, j] = '-';
                }
            }

            List<int> bombsLocations = new List<int>();
            while (bombsLocations.Count < 15)
            {
                Random random = new Random();

                int currentGeneratedLocation = random.Next(50);
                if (!bombsLocations.Contains(currentGeneratedLocation))
                {
                    bombsLocations.Add(currentGeneratedLocation);
                }
            }

            foreach (int bombLocation in bombsLocations)
            {
                int currentCol = bombLocation / PLAYFIELD_COLS;
                int currentRow = bombLocation % PLAYFIELD_COLS;
                if (currentRow == 0 && bombLocation != 0)
                {
                    currentCol--;
                    currentRow = PLAYFIELD_COLS;
                }
                else
                {
                    currentRow++;
                }

                playfieldMatrix[currentCol, currentRow - 1] = '*';
            }

            return playfieldMatrix;
        }

        private static void CheckNumberOfNeighbourBombs(char[,] playfieldMatrix)
        {
            int playfieldRows = playfieldMatrix.GetLength(0);
            int playfieldCols = playfieldMatrix.GetLength(1);

            for (int i = 0; i < playfieldRows; i++)
            {
                for (int j = 0; j < playfieldCols; j++)
                {
                    if (playfieldMatrix[i, j] != '*')
                    {
                        char numberOfNeighbourBombs = CheckNumberOfNeighbourBombs(playfieldMatrix, i, j);
                        playfieldMatrix[i, j] = numberOfNeighbourBombs;
                    }
                }
            }
        }

        private static char CheckNumberOfNeighbourBombs(char[,] playfieldMatrix, int currentRow, int currentCol)
        {
            int neighbourBombsCount = 0;
            int playfieldRows = playfieldMatrix.GetLength(0);
            int playfieldCols = playfieldMatrix.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (playfieldMatrix[currentRow - 1, currentCol] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if (currentRow + 1 < playfieldRows)
            {
                if (playfieldMatrix[currentRow + 1, currentCol] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if (currentCol - 1 >= 0)
            {
                if (playfieldMatrix[currentRow, currentCol - 1] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if (currentCol + 1 < playfieldCols)
            {
                if (playfieldMatrix[currentRow, currentCol + 1] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
            {
                if (playfieldMatrix[currentRow - 1, currentCol - 1] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCol + 1 < playfieldCols))
            {
                if (playfieldMatrix[currentRow - 1, currentCol + 1] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if ((currentRow + 1 < playfieldRows) && (currentCol - 1 >= 0))
            {
                if (playfieldMatrix[currentRow + 1, currentCol - 1] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            if ((currentRow + 1 < playfieldRows) && (currentCol + 1 < playfieldCols))
            {
                if (playfieldMatrix[currentRow + 1, currentCol + 1] == '*')
                {
                    neighbourBombsCount++;
                }
            }

            return char.Parse(neighbourBombsCount.ToString());
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)
