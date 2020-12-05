using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TicTacToe
{
    public class Board
    {
        private string[,] board;

        public Board()
        {
            this.board = new string[3, 3];

            int count = 1;
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    this.board[i, j] = count.ToString();
                    count++;
                }
            }
        }

        public Board(string[,] board)
        {
            this.board = board;
        }

        public string[,] getBoard()
        {
            string[,] b = new string[3, 3];
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    b[i, j] = this.board[i, j];
                }
            }

            return b;
        }

        public double[] getBoardKey()
        {
            double[] b = new double[9];
            int index = 0;
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if(this.board[i, j] == "X")
                    {
                        b[index] =  1;
                    }
                    else if(this.board[i, j] == "O")
                    {
                        b[index] = -1;
                    }
                    else
                    {
                        b[index] = 0;
                    }
                    index++;
                }
            }

            return b;
        }

        public bool Move(int move, Player p)
        {
            int x = (move - 1) / 3;
            int y = (move - 1) % 3;

            if (this.board[x, y] != "X" && this.board[x, y] != "O")
            {
                this.board[x, y] = p.symbol;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> getEmptySquares()
        {
            List<int> moves = new List<int>();
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if (this.board[i, j] != "X" && this.board[i, j] != "O")
                    {
                        moves.Add(Convert.ToInt32(this.board[i, j]));
                    }
                }
            }

            return moves;
        }

        public override string ToString()
        {
            string s = "\n";
            string prefix = " ";
            string suffix = " ";

            for (int i = 0; i < (this.board.GetLength(0) * 2); i++)
            {
                prefix += "--";
            }

            prefix += "\n";
            suffix = prefix;

            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                s += " ";

                for (int j = 0; j < this.board.GetLength(1) - 1; j++)
                {
                    s += " " + this.board[i, j] + " |";
                }
                s += " " + this.board[i, this.board.GetLength(1) - 1];
                if (i < this.board.GetLength(0) - 1)
                {
                    s += " \n" + suffix;
                }
            }

            return s += "\n";
        }

        public bool CheckWin(out string winner)
        {
            winner = "";
            //vertical
            if (getLeft()) winner = this.board[0, 0];
            if (getRight()) winner = this.board[0, 2];
            if (getMiddleVertical()) winner = this.board[0, 1];

            //horizontal
            if (getTop()) winner = this.board[0, 0];
            if (getBottom()) winner = this.board[2, 0];
            if (getMiddleHorizontal()) winner = this.board[1, 0];

            //diagonal
            if (getDiagLeft()) winner = this.board[0, 0];
            if (getDiagRight()) winner = this.board[2, 0];

            if (winner != "") return true;
            return false;
        }

        public bool isFull()
        {
            for(int i = 0; i < this.board.GetLength(0); i++)
            {
                for(int j = 0; j < this.board.GetLength(1); j++)
                {
                    if(this.board[i, j] != "X" && this.board[i, j] != "O")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool getLeft()
        {
            return this.board[0, 0] == this.board[1, 0] && this.board[1, 0] ==  this.board[2, 0];
        }

        private bool getTop()
        {
            return this.board[0, 0] == this.board[0, 1] && this.board[0, 1] == this.board[0, 2];
        }

        private bool getBottom()
        {
            return this.board[2, 0] == this.board[2, 1] && this.board[2, 1] == this.board[2, 2];
        }

        private bool getRight()
        {
            return this.board[0, 2] == this.board[1, 2] && this.board[1, 2] == this.board[2, 2];
        }

        private bool getMiddleVertical()
        {
            return this.board[0, 1] == this.board[1, 1] && this.board[1, 1] == this.board[2, 1];
        }

        private bool getMiddleHorizontal()
        {
            return this.board[1, 0] == this.board[1, 1] && this.board[1, 1] == this.board[1, 2];
        }

        private bool getDiagLeft()
        {
            return this.board[0, 0] == this.board[1, 1] && this.board[1, 1] == this.board[2, 2];
        }

        private bool getDiagRight()
        {
            return this.board[0, 2] == this.board[1, 1] && this.board[1, 1] == this.board[2, 0];
        }
    }
}
