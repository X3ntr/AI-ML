using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TicTacToe
{
    public class MinMaxAI : Player
    {
        public MinMaxAI(string symbol) : base("MinMax-AI", symbol) {}

        public int PlayMove(Board board)
        {
            int max = Int32.MinValue;
            int bestMove = board.getEmptySquares()[0];

            foreach(int emptySquare in board.getEmptySquares())
            {
                Board b = new Board(board.getBoard());
                b.Move(emptySquare, this);
                int result = MinMax(b, false);

                if(result > max)
                {
                    max = result;
                    bestMove = emptySquare;
                }
            }

            return bestMove;
        }

        private int MinMax(Board board, bool isMax)
        {
            //base case
            string winner = "";
            if(board.CheckWin(out winner) || board.isFull())
            {
                if(winner == "X")
                {
                    return -1;
                }
                else if(winner == "O")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            if (isMax)
            {
                //maximaliseren
                int best = Int32.MinValue;

                foreach (int emptySquare in board.getEmptySquares())
                {
                    Board b = new Board(board.getBoard());
                    b.Move(emptySquare, this);

                    best = Math.Max(best, MinMax(b, !isMax));
                }
                return best;
            }
            else
            {
                //minimaliseren
                int best = Int32.MaxValue;

                foreach(int emptySquare in board.getEmptySquares())
                {
                    Board b = new Board(board.getBoard());
                    b.Move(emptySquare, new Player("ai", "X"));

                    best = Math.Min(best, MinMax(b, !isMax));
                }
                return best;
            }
        }
    }
}
