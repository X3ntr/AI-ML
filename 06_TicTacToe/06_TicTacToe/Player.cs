using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TicTacToe
{
    public class Player
    {
        public string name { get; set; }

        public string symbol { get; set; }

        public Player(string name, string symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }
    }
}
