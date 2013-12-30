using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class MainProgram
{
    const int consoleHeight = 54;// preferably dont change
    const int consoleWidth = 127;// preferably dont change

    const int enemiesCount = 10;
    const int enemiesPredictivness = 5;//the higher the more predictive

    const int bombTimer  = 5;//the lower the slower the bombs explode
    const int flameTimer = 4;//the lower the slower the flames disappear
    const int maximumAllowedBombs = 3;

    const int gameSpeed = 70; // max is 100

    static public List<Bomb> bombsPlaced = new List<Bomb>();
    static public int currentPlacedBombs = 0;

    static public List<Flame> flamesPlaced = new List<Flame>();

    static public List<Enemy> enemies = new List<Enemy>();

    static public List<Wall> wallz = new List<Wall>();

    static public Player player = new Player();

    static void Main()
    {
        ConsoleSetup();

        GenerateWalls();

        GenerateDestructibleWalls();

        GenerateEnemies();

        while (1 == 1)
        {
            System.Threading.Thread.Sleep(100 - gameSpeed);

            ReadConsoleKeys();

            player.DrawPlayer();

            ProcessGameObjects();
        }
    }

    private static void ProcessGameObjects()
    {
        List<Wall> tempWall = new List<Wall>();
        foreach (Wall wal in wallz)
        {
            if (wal.alive)
            {
                tempWall.Add(wal);
                wal.DrawWall();
            }
        }
        wallz = tempWall;
        List<Bomb> tempBombs = new List<Bomb>();
        foreach (var bom in bombsPlaced)
        {
            if (bom.alive)
            {
                bom.DrawBomb();
                bom.life -= bombTimer;

                if (bom.life <= 0)
                {
                    currentPlacedBombs--;
                    bom.alive = false;
                    CreateSuitableFlames(bom.x, bom.y);
                }
                else
                {
                    tempBombs.Add(bom);
                }
            }
        }
        bombsPlaced = tempBombs;

        List<Flame> tempFlames = new List<Flame>();
        foreach (var fla in flamesPlaced)
        {
            if (fla.alive)
            {
                fla.DrawSquareOfFlame(fla.x, fla.y, 'X');
                ExamineFlame(fla);
                fla.life -= flameTimer;
                if (fla.life <= 0)
                {
                    fla.alive = false;
                    fla.DrawSquareOfFlame(fla.x, fla.y, ' ');
                }
                else
                {
                    tempFlames.Add(fla);
                }
            }
        }
        flamesPlaced = tempFlames;

        List<Enemy> tempEnemies = new List<Enemy>();
        foreach (Enemy enem in enemies)
        {
            if (enem.alive)
            {
                tempEnemies.Add(enem);
                enem.ClearEnemy();
                MoveEnemy(enem);
                enem.DrawEnemy();

                if ((enem.x == player.x) && (enem.y == player.y))
                {
                    GameOver();
                }
            }
        }
        enemies = tempEnemies;
        if (enemies.Count == 0)
        {
            YouWin();
        }
    }


    private static void ConsoleSetup()
    {

        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();
        Console.SetWindowSize(consoleWidth, consoleHeight);

        Console.BufferHeight = Console.WindowHeight = consoleHeight;
        Console.BufferWidth = Console.WindowWidth = consoleWidth; 
    }

    private static void GenerateEnemies()
    {
        Random rnd = new Random();
        for (int i = 0; i < enemiesCount; i++)
        {
            Enemy argh = new Enemy(rnd.Next(3, 21) * 6, rnd.Next(3, 9) * 6);
            enemies.Add(argh);
        }
    }

    private static void MoveEnemy(Enemy enem)
    {
        Random rnd = new Random();
        Random rnd1 = new Random(124);
        Random rnd2 = new Random(552);
        Random rnd3 = new Random(234);
        Random rnd4 = new Random(314);

        if (rnd.Next(0, enemiesPredictivness) == 0)
        {
            int determiner = rnd.Next(0, 4);
            if (determiner == 0)
            {
                if ((enem.x % 6 == 0) && (enem.y % 6 ==0))
                {
                    enem.direction = rnd1.Next(0, 4);
                }
            }
            else if (determiner == 1)
            {
                if ((enem.x % 6 == 0) && (enem.y % 6 == 0))
                {
                    enem.direction = rnd2.Next(0, 4);
                }
            }
            else if (determiner == 2)
            {
                if ((enem.x % 6 == 0) && (enem.y % 6 == 0))
                {
                    enem.direction = rnd2.Next(0, 4);
                }
            }
            else
            {
                if ((enem.x % 6 == 0) && (enem.y % 6 == 0))
                {
                    enem.direction = rnd3.Next(0, 4);
                }
            }
        }

        if (enem.direction==0)//up
        {
            if (enem.y > 0)
            {
                foreach (var wal in wallz)
                {
                    if (wal.alive && (wal.x == enem.x) &&(wal.y +2 == enem.y-1))
                    {
                        enem.direction = 2;
                        return;
                    }
                }
                foreach (var bom in bombsPlaced)
                {
                    if (bom.alive && (bom.x == enem.x) && (bom.y + 2 == enem.y - 1))
                    {
                        enem.direction = 2;
                        return;
                    }
                }
                enem.y--;
            }
            else
            {
                enem.direction = 2;
            }
        }
        else if (enem.direction ==1)//right
        {
            if (enem.x < consoleWidth-4)
            {
                foreach (var wal in wallz)
                {
                    if (wal.alive && (wal.x == enem.x+3) && (wal.y == enem.y ))
                    {
                        enem.direction = 3;
                        return;
                    }
                }
                foreach (var bom in bombsPlaced)
                {
                    if (bom.alive && (bom.x == enem.x + 3) && (bom.y == enem.y))
                    {
                        enem.direction = 3;
                        return;
                    }
                }
                enem.x++;
            }
            else
            {
                enem.direction = 3;
            }
        }
        else if (enem.direction == 2)//down
        {
            if (enem.y < consoleHeight - 3)
            {
                foreach (var wal in wallz)
                {
                    if (wal.alive && (wal.x == enem.x) && (wal.y - 2 == enem.y + 1))
                    {
                        enem.direction = 0;
                        return;
                    }
                }
                foreach (var bom in bombsPlaced)
                {
                    if (bom.alive && (bom.x == enem.x) && (bom.y - 2 == enem.y + 1))
                    {
                        enem.direction = 0;
                        return;
                    }
                }
                enem.y++;
            }
            else
            {
                enem.direction = 0;
            }
        }
        else//left
        {
            if (enem.x > 0)
            {
                foreach (var wal in wallz)
                {
                    if (wal.alive && (wal.x + 2 == enem.x - 1) && (wal.y  == enem.y))
                    {
                        enem.direction = 1;
                        return;
                    }
                }
                foreach (var bom in bombsPlaced)
                {
                    if (bom.alive && (bom.x + 2 == enem.x - 1) && (bom.y == enem.y))
                    {
                        enem.direction = 1;
                        return;
                    }
                }
                enem.x--;
            }
            else
            {
                enem.direction = 1;
            }
        }
    }

    private static void ExamineFlame(Flame fla)
    {
        foreach (var wal in wallz)
        {
            if (wal.alive)
            {
                if ((wal.x == fla.x) || (wal.y == fla.y))
                {
                    wal.alive = false;
                }
            }
        }

        foreach (var ene in enemies)
        {
            if (ene.alive)
            {
                if ((ene.x==fla.x) && (ene.y == fla.y))
                {
                    ene.alive = false;
                }
            }
        }

        if ((player.x == fla.x) && (player.y==fla.y))
        {
            GameOver();
        }
    }

    private static void CreateSuitableFlames(int x, int y)
    {
        Flame centerFlame = new Flame(x, y);
        flamesPlaced.Add(centerFlame);
        if ((x > 0) && (y%6 < 3))
        {
            Flame leftFlame = new Flame(x-3, y);
            flamesPlaced.Add(leftFlame);
        }
        if ((x<consoleWidth - 6)&& (y%6 < 3))
        {
            Flame rightFlame = new Flame(x + 3, y);
            flamesPlaced.Add(rightFlame);
        }
        if ((y>0)&& (x%6 < 3))
        {
            Flame upFlame = new Flame(x, y - 3);
            flamesPlaced.Add(upFlame);
        }
        if ((y < consoleHeight - 6)&& (x%6 < 3))
        {
            Flame downFlame = new Flame(x, y + 3);
            flamesPlaced.Add(downFlame);
        }
    }

    public static void GenerateWalls()
    {
        for (int i = 3; i <= consoleWidth - 3; i = (i + 6))
        {
            for (int j = 3; j <= consoleHeight - 1; j = (j + 6))
            {
                Wall currWall = new Wall(i, j);
                currWall.destructable = false;
                currWall.DrawWall();
            }
        }
    }

    public static void GenerateDestructibleWalls()
    {
        Wall w1 = new Wall(36, 3);
        Wall w2 = new Wall(12, 9);
        Wall w3 = new Wall(18, 15);
        Wall w4 = new Wall(24, 9);
        Wall w5 = new Wall(30, 21);
        Wall w6 = new Wall(36, 3);
        Wall w7 = new Wall(42, 6);
        Wall w8 = new Wall(48, 21);
        Wall w9 = new Wall(66, 18);
        Wall w10 = new Wall(60, 15);
        Wall w11 = new Wall(66, 3);
        Wall w12 = new Wall(72, 6);
        Wall w13 = new Wall(78, 9);
        Wall w14 = new Wall(84, 21);
        Wall w15 = new Wall(90, 45);
        Wall w16 = new Wall(96, 9);
        Wall w17 = new Wall(102, 0);
        Wall w18 = new Wall(108, 45);
        Wall w19 = new Wall(114, 33);
        Wall w20 = new Wall(120, 15);

        wallz.Add(w1);
        wallz.Add(w2);
        wallz.Add(w3);
        wallz.Add(w4);
        wallz.Add(w5);
        wallz.Add(w6);
        wallz.Add(w7);
        wallz.Add(w8);
        wallz.Add(w9);
        wallz.Add(w10);
        wallz.Add(w11);
        wallz.Add(w12);
        wallz.Add(w13);
        wallz.Add(w14);
        wallz.Add(w15);
        wallz.Add(w16);
        wallz.Add(w17);
        wallz.Add(w18);
        wallz.Add(w19);
        wallz.Add(w20);

        foreach (Wall wal in wallz)
        {
            if (wal.alive)
            {
                wal.DrawWall();
            }
        }
    }

    public static void ReadConsoleKeys()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (player.y % 6 == 0)
                {
                    player.Move("Left",wallz);
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (player.y % 6 == 0)
                {
                    player.Move("Right",wallz);
                }
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (player.x % 6 == 0)
                {
                    player.Move("Up",wallz);
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (player.x % 6 == 0)
                {
                    player.Move("Down",wallz);
                }
            }
            else if (pressedKey.Key == ConsoleKey.Spacebar)
            {
                if (currentPlacedBombs <= maximumAllowedBombs)
                {
                    currentPlacedBombs++;
                    Bomb newBomb = new Bomb(player.x - player.x % 3, player.y - player.y % 3);
                    bombsPlaced.Add(newBomb);
                }
            }
        }
    }

    private static void YouWin()
    {
        Console.Beep();
        Console.Beep();
        Console.Beep();
        Console.Beep();
        Console.Beep();
        System.Threading.Thread.Sleep(3000);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("                ----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("                                                  Y   O   U         W   I   N   ");
        Console.WriteLine();
        Console.WriteLine("                ----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(); Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Environment.Exit(0);
    }
    
    public static void GameOver()
    {
        ClearSquare(player.x, player.y);
        Console.Beep();
        Console.Beep();
        Console.Beep();
        Console.Beep();
        Console.Beep();
        System.Threading.Thread.Sleep(3000);
        GameOverMessage();
    }

    static void ClearSquare(int x, int y)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(x, y);
        Console.Write("O");
        Console.SetCursorPosition(x + 1, y);
        Console.Write(" ");
        Console.SetCursorPosition(x + 2, y);
        Console.Write("O");
        Console.SetCursorPosition(x, y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(x + 1, y + 1);
        Console.Write("_");
        Console.SetCursorPosition(x + 2, y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(x, y + 2);
        Console.Write("/");
        Console.SetCursorPosition(x + 1, y + 2);
        Console.Write(" ");
        Console.SetCursorPosition(x + 2, y + 2);
        Console.Write("\\");
    }

    private static void GameOverMessage()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("                ----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("                                              G   A   M   E         O   V   E   R");
        Console.WriteLine();
        Console.WriteLine("                ----------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(); Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Environment.Exit(0);
    }
}

class Player
{
    public int x { get; set; }
    public int y { get; set; }

    public void DrawPlayer()
    {
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(this.x, this.y);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 1, this.y);
        Console.Write("O");
        Console.SetCursorPosition(this.x + 2, this.y);
        Console.Write(" ");
        Console.SetCursorPosition(this.x, this.y + 1);
        Console.Write("/");
        Console.SetCursorPosition(this.x + 1, this.y + 1);
        Console.Write((char)19);
        Console.SetCursorPosition(this.x + 2, this.y + 1);
        Console.Write("\\");
        Console.SetCursorPosition(this.x, this.y + 2);
        Console.Write("/");
        Console.SetCursorPosition(this.x + 1, this.y + 2);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 2, this.y + 2);
        Console.Write("\\");

    }

    public void Move(string direction, List<Wall> walz) 
    {
        if (direction == "Left")
        {
            if (this.x > 0)
            {
                foreach (var wal in walz)
                {
                    if (wal.alive)
	                {
		                if ((this.x - 1 == wal.x+2) && (this.y == wal.y))
                        {
                            return;
                        }
	                }
                }

                Console.SetCursorPosition(this.x+2, this.y);
                Console.Write(" ");
                Console.SetCursorPosition(this.x+2, this.y+1);
                Console.Write(" ");
                Console.SetCursorPosition(this.x+2, this.y+2);
                Console.Write(" ");
                this.x--;
            }
        }
        else if (direction == "Right")
        {
            if (this.x < Console.WindowWidth - 3)
            {
                foreach (var wal in walz)
                {
                    if (wal.alive)
                    {
                        if ((this.x + 1 == wal.x - 2) && (this.y == wal.y))
                        {
                            return;
                        }
                    }
                }

                Console.SetCursorPosition(this.x, this.y);
                Console.Write(" ");
                Console.SetCursorPosition(this.x, this.y + 1);
                Console.Write(" ");
                Console.SetCursorPosition(this.x, this.y + 2);
                Console.Write(" ");
                this.x++;
            }
        }
        else if (direction == "Up")
        {
            if (this.y > 0)
            {
                foreach (var wal in walz)
                {
                    if (wal.alive)
                    {
                        if ((this.x == wal.x) && (this.y - 1 == wal.y + 2))
                        {
                            return;
                        }
                    }
                }
                
                Console.SetCursorPosition(this.x , this.y+2);
                Console.Write(" ");
                Console.SetCursorPosition(this.x + 1, this.y +2);
                Console.Write(" ");
                Console.SetCursorPosition(this.x + 2, this.y + 2);
                Console.Write(" ");
                this.y--;
            }
        }
        else if (direction == "Down")
        {
            if (this.y < Console.WindowHeight - 3)
            {
                foreach (var wal in walz)
                {
                    if (wal.alive)
                    {
                        if ((this.x == wal.x) && (this.y + 1 == wal.y - 2))
                        {
                            return;
                        }
                    }
                }

                Console.SetCursorPosition(this.x, this.y);
                Console.Write(" ");
                Console.SetCursorPosition(this.x + 1, this.y);
                Console.Write(" ");
                Console.SetCursorPosition(this.x + 2, this.y);
                Console.Write(" ");
                this.y++;
            }
        }
        
    }

    
}

class Enemy
{
    public int x { get; set; }
    public int y { get; set; }

    public Enemy(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool alive = true;
    static Random rnd = new Random();
    public int direction = rnd.Next(0, 4);
    public void ClearEnemy()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.SetCursorPosition(this.x, this.y);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 1, this.y);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 2, this.y);
        Console.Write(" ");
        Console.SetCursorPosition(this.x, this.y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 1, this.y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 2, this.y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(this.x, this.y + 2);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 1, this.y + 2);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 2, this.y + 2);
        Console.Write(" ");
    }
    public void DrawEnemy()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.SetCursorPosition(this.x, this.y);
        Console.Write("0");
        Console.SetCursorPosition(this.x + 1, this.y);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 2, this.y);
        Console.Write("0");
        Console.SetCursorPosition(this.x, this.y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(this.x + 1, this.y + 1);
        Console.Write("|");
        Console.SetCursorPosition(this.x + 2, this.y + 1);
        Console.Write(" ");
        Console.SetCursorPosition(this.x, this.y + 2);
        Console.Write("=");
        Console.SetCursorPosition(this.x + 1, this.y + 2);
        Console.Write("=");
        Console.SetCursorPosition(this.x + 2, this.y + 2);
        Console.Write("=");
    }

    public void Move(string direction) // checking for wall in the main method
    {
        if (direction == "Left")
        {
            if (this.x > 0)
            {
                this.x--;
            }
        }
        else if (direction == "Right")
        {
            if (this.x < Console.WindowWidth - 3)
            {
                this.x++;
            }
        }
        else if (direction == "Up")
        {
            if (this.y > 0)
            {
                this.y--;
            }
        }
        else if (direction == "Down")
        {
            if (this.y < Console.WindowHeight - 3)
            {
                this.y++;
            }
        }

    }
}

class Bomb
{
    public int x { get; set; }
    public int y { get; set; }
    public int life = 250;
    public bool alive = true;

    public Bomb(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void DrawBomb()
    {
        char symb = '@';
        Console.ForegroundColor = ConsoleColor.Red;

        //Console.SetCursorPosition(this.x, this.y);
        //Console.Write(symb);
        Console.SetCursorPosition(this.x + 1, this.y);
        Console.Write(symb);
        //Console.SetCursorPosition(this.x + 2, this.y);
        //Console.Write(symb);
        Console.SetCursorPosition(this.x, this.y + 1);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 1, this.y + 1);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 2, this.y + 1);
        Console.Write(symb);
        //Console.SetCursorPosition(this.x, this.y + 2);
        //Console.Write(symb);
        Console.SetCursorPosition(this.x + 1, this.y + 2);
        Console.Write(symb);
        //Console.SetCursorPosition(this.x + 2, this.y + 2);
        //Console.Write(symb);
    }
}

class Flame
{
    public int x { get; set; }
    public int y { get; set; }

    public Flame(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int life = 50;
    public bool alive = true;

    public void DrawSquareOfFlame(int zx, int zy, char symb)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.SetCursorPosition(zx, zy);
        Console.Write(symb);
        Console.SetCursorPosition(zx + 1, zy);
        Console.Write(symb);
        Console.SetCursorPosition(zx + 2, zy);
        Console.Write(symb);
        Console.SetCursorPosition(zx, zy + 1);
        Console.Write(symb);      
        Console.SetCursorPosition(zx + 1, zy + 1);
        Console.Write(symb);      
        Console.SetCursorPosition(zx + 2, zy + 1);
        Console.Write(symb);      
        Console.SetCursorPosition(zx, zy + 2);
        Console.Write(symb);      
        Console.SetCursorPosition(zx + 1, zy + 2);
        Console.Write(symb);      
        Console.SetCursorPosition(zx + 2, zy + 2);
        Console.Write(symb);
    }
}

class Wall
{
    public int x { get; set; }
    public int y { get; set; }
    public bool destructable = true;
    public bool alive = true;

    public Wall(int wx, int wy)
    {
        this.x = wx;
        this.y = wy;
    }

    public void DrawWall()
    {
        char symb = (char)15;      
        Console.ForegroundColor = ConsoleColor.Black;
        if (destructable)
        {
            symb = '#';
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        Console.SetCursorPosition(this.x, this.y);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 1, this.y);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 2, this.y);
        Console.Write(symb);
        Console.SetCursorPosition(this.x, this.y + 1);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 1, this.y + 1);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 2, this.y + 1);
        Console.Write(symb);
        Console.SetCursorPosition(this.x, this.y + 2);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 1, this.y + 2);
        Console.Write(symb);
        Console.SetCursorPosition(this.x + 2, this.y + 2);
        Console.Write(symb);
    }

}