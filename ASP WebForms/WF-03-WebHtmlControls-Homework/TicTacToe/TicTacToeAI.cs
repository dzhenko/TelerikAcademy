using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class Move
    {
        public int iCol;
        public int iRow;
        public int iRank;
        public Move(int col, int row)
        {
            iCol = col;
            iRow = row;
            iRank = 0;
        }
    }

    public class TicTacToeAI
    {
        private int FromMatrixToIndex(int row, int col)
        {
            return row * 3 + col;
        }

        public Move GetBestMove(char[] board, int boardSize, int CurrentPlayer, int alpha, int beta, GameLogic logic)
        {
            Move BestMove = null;
            int iPossibleMoves = board.Count(b => b == '-');

            //Start at a random square, so that if two or more moves
            //are of equal rank, one of them will be chosen at random.
            Random rand = new Random();
            int i = rand.Next(boardSize);
            int j = rand.Next(boardSize);

            while (iPossibleMoves > 0)
            {
                //Loop through board.aiBoard to find next available move
                do
                {
                    if (i < boardSize - 1)
                    {
                        i++;
                    }
                    else if (j < boardSize - 1)
                    {
                        i = 0; j++;
                    }
                    else
                    {
                        i = 0; j = 0;
                    }
                } while (board[FromMatrixToIndex(i,j)] != '-');

                Move NewMove = new Move(i, j);
                iPossibleMoves--;

                //Make Move
                char[] NewBoard = (new string(board)).ToCharArray();

                NewBoard[FromMatrixToIndex(NewMove.iRow, NewMove.iCol)] = 'O';
                var result = logic.GetResult(NewBoard);

                if (result == GameResult.NotFinished)
                {
                    Move tempMove = GetBestMove(NewBoard, 3, -CurrentPlayer, alpha, beta, logic);
                    NewMove.iRank = tempMove.iRank;
                }
                else
                {
                    //Assign a rank
                    if (result == GameResult.NotFinished)
                        NewMove.iRank = 0;
                    else
                    {
                        if (result == GameResult.WonByO)
                            NewMove.iRank = -1;
                        else
                        {
                            if (result == GameResult.WonByX)
                                NewMove.iRank = 1;
                        }
                    }
                }

                //Is NewMove the best move encountered at this level so far?
                if (BestMove == null ||
                    (CurrentPlayer == 1 && NewMove.iRank < BestMove.iRank) ||
                    (CurrentPlayer == -1 && NewMove.iRank > BestMove.iRank))
                {
                    BestMove = NewMove;
                }


                //Update alpha and beta, if necessary.
                if (CurrentPlayer == 1 && BestMove.iRank < beta)
                    beta = BestMove.iRank;
                if (CurrentPlayer == -1 && BestMove.iRank > alpha)
                    alpha = BestMove.iRank;


                //Check for pruning condition.
                if (alpha > beta)
                {
                    //prune this branch
                    iPossibleMoves = 0;
                }
            }
            return BestMove;
        }
    }
}