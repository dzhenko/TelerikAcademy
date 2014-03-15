//* Write a recursive program to solve the "8 Queens Puzzle" with backtracking. Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class QueensProblem
{
    const int BoardSize = 8;

    public static LinkedList<Tuple<int, int>> check = new LinkedList<Tuple<int, int>>();
    public static List<string> solutions = new List<string>();

    static int[,] board;

    static void Main()
    {
        board = new int[BoardSize, BoardSize];

        PlaceQueen(0);

        Console.WriteLine(solutions.Count);

        Console.WriteLine(solutions[0]);
    }

    //there can not be 2 queens on one row so we only search for a place for everyqueen only by changing col
    private static void PlaceQueen(int row)
    {
        if (row == BoardSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            foreach (var item in check)
            {
                sb.AppendFormat("( {0} {1} )", item.Item1, item.Item2);
            }

            sb.Append(" ]");

            solutions.Add(sb.ToString());

            return;
        }

        for (int col = 0; col < BoardSize; col++)
        {
            if (board[row,col] == 0)
            {
                MarkPlaced(row, col, 1);
                check.AddLast(new Tuple<int, int>(row, col));

                PlaceQueen(row + 1);

                check.RemoveLast();
                MarkPlaced(row, col, -1);
            }
        }
        
    }

    private static void MarkPlaced(int qRow, int QCol, int marker)
    {
        //rows and cols
        for (int i = 0; i < BoardSize; i++)
        {
            board[qRow, i] += marker;
            board[i, QCol] += marker;
        }

        //the placeOfTheQueenIsMarkedTwice - fix this:
        board[qRow, QCol] -= marker;

        //diagonals
        for (int i = 1; i < BoardSize; i++)
        {
            if (qRow+i < BoardSize && QCol + i < BoardSize)
            {
                board[qRow + i, QCol + i] += marker;
            }

            if (qRow - i >= 0 && QCol + i < BoardSize)
            {
                board[qRow - i, QCol + i] += marker;
            }

            if (qRow + i < BoardSize && QCol - i >= 0)
            {
                board[qRow + i, QCol - i] += marker;
            }

            if (qRow - i >= 0 && QCol - i >= 0)
            {
                board[qRow - i, QCol - i] += marker;
            }
        }
    }
}

