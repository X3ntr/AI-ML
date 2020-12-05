using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player one = new Player("one", "X");
            //MinMaxAI two = new MinMaxAI("O");
            KNNAI three = new KNNAI("O");

            int turn = 0;
            string winner = "";

            while (turn < 9)
            {
                Console.WriteLine(board.ToString());

                if(turn % 2 == 0)
                {
                    Console.WriteLine("Make your next move:");
                    int move = Convert.ToInt32(Console.ReadLine());

                    board.Move(move, one);

                    if (board.CheckWin(out winner))
                    {
                        break;
                    }
                }
                else
                {
                    //board.Move(two.PlayMove(board), two);
                    board.Move(three.PlayMove(board), three);
                    Console.WriteLine("Super Computer played a move!");

                    if (board.CheckWin(out winner))
                    {
                        break;
                    }
                }
                turn++;
            }

            Console.WriteLine(board.ToString());

            if (winner != "")
            {
                Console.WriteLine(String.Format("Player {0} has won the game!", winner));
            }
            else
            {
                Console.WriteLine("Stalemate!");
            }
            Console.WriteLine("Game Over");
        }
    }
}
