namespace Task5ThirdTry
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();//matrix size

            int[] tXY = Console.ReadLine().Split().Select(int.Parse).ToArray();//target coords

            BigInteger[,] grid = new BigInteger[NM[0], NM[1]];

            int targetRow = tXY[0];
            int targetCol = tXY[1];

            int enemiesCount = int.Parse(Console.ReadLine());

            //setting the first row and first col to 1
            for (int i = 0; i <= targetRow; i++)
            {
                grid[i, 0] = 1;
            }

            for (int i = 0; i <= targetCol; i++)
            {
                grid[0, i] = 1;
            }
		
            //reading enemies
            for (int i = 0; i < enemiesCount; i++)
            {
                int[] enemyLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                //if the enemy is on the first row - we must mark all the cols ranging from the enemycol onward with 0
                if (enemyLine[0] == 0)//row
                {
                    for (int e = enemyLine[1]; e <= targetCol; e++)
                    {
                        grid[0, e] = 0;
                    }
                }

                //if the enemy is on the first col- we must mark all the rows ranging from the enemyrow onward with 0
                else if (enemyLine[1] == 0)
                {
                    for (int e = enemyLine[0]; e <= targetRow; e++)
                    {
                        grid[e, 0] = 0;
                    }
                }

                //mark the rest of the enemies with -1
                else
                {
                    grid[enemyLine[0], enemyLine[1]] = -1;
                }
            }
            
            //filling the grid
            for (int row = 1; row <= targetRow; row++)
            {
                for (int col = 1; col <= targetCol; col++)
                {   
                    //this is enemy - we can not reach that cell
                    if (grid[row,col] == -1)
                    {
                        grid[row, col] = 0;
                    }
                    //the possible ways to reach this cell is the sum of the possible ways to reach the top cell and the left cell
                    else
                    {
                        grid[row, col] = grid[row - 1, col] + grid[row, col - 1];
                    }
                }
            }
            Console.WriteLine(grid[targetRow,targetCol]);
        }
    }
}