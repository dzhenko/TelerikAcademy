using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int[,] field = new int[9, 9];
    static int solved = 0;

    static void Main()
    {
        ReadData();

        SolveMe(0,0);


        
    }

    private static void SolveMe(int row,int col)
    {
        if (row > 8 || col > 8)
        {
            PrintField();
            Environment.Exit(0);
        }

        if (field[row, col] == 0)
        {
            List<int> possibleNumbers = GeneratePossibleNumbers(row, col);
            if (possibleNumbers.Count == 0)
            {
                return;
            }
            foreach (int item in possibleNumbers)
            {
                field[row, col] = item;
                solved++;

                SolveMe(NextRow(row,col),NextCol(col));

                solved--;
                field[row, col] = 0;
            }
        }
        else
        {
            SolveMe(NextRow(row, col), NextCol(col));
        }
    }

    private static int NextCol(int col)
    {
        col++;
        if (col > 8)
        {
            return 0;
        }
        return col;
    }

    private static int NextRow(int row, int col)
    {
        col++;
        if (col > 8)
        {
            return row + 1;
        }
        return row;
    }

    private static List<int> GeneratePossibleNumbers(int inI, int inJ)
    {
        List<int> possibleNums = new List<int>();
        int rowQ = inI / 3;
        int colQ = inJ / 3;
        bool[] used = new bool[9];
        //check quadrant
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (field[rowQ*3 + i,colQ*3 + j] != 0)
                {
                    used[field[rowQ * 3 + i, colQ * 3 + j] - 1] = true;
                }
            }
        }
        //lines
        for (int i = 0; i < 9; i++)
        {
            if (field[inI,i] != 0)
            {
                used[field[inI, i] - 1] = true;
            }
        }
        //verts
        for (int i = 0; i < 9; i++)
        {
            if (field[i, inJ] != 0)
            {
                used[field[i, inJ] - 1] = true;
            }
        }
        //adding
        for (int i = 0; i < 9; i++)
        {
            if (!used[i])
            {
                possibleNums.Add(i + 1);
            }
        }
        return possibleNums;
    }

    private static void PrintField()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }
    
    private static void ReadData()
    {
        for (int i = 0; i < 9; i++)
        {
            string currLine = Console.ReadLine();
            for (int j = 0; j < 9; j++)
            {
                if (currLine[j] != '-')
                {
                    field[i, j] = int.Parse(currLine[j].ToString());
                    solved++;
                }
            }
        }
    }
}

