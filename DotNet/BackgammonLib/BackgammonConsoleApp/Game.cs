using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BackgammonLib;

namespace BackgammonConsoleApp
{

    class Game 
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            GameMethods methods = new GameMethods(board);
            board.Play();
        }

       
    }
}
