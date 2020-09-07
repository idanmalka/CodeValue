using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGame
    {
        public enum Pawns { E, X, O, }
        private Pawns[,] _board;
        private Pawns _winner ;
        private bool _gameOver;
        private Pawns _turn;

        TicTacToeGame()
        {
            _board = new Pawns[3, 3];
            _turn = Pawns.X;
        }

        public Pawns Winner => _winner;

        public Pawns Turn => _turn;

        public bool IsGameOver
        {
            set { _gameOver = value; }
            get { return _gameOver; }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for(int j=0;j<3;j++)
                    Console.Write($"{_board[i,j]} ");
                Console.WriteLine();
            }
        }

        public void Play(int i, int j)
        {
            if (i >= 3 || j >= 3)
            {
                Console.WriteLine("Illegal Move, trey again");
                return;
            }

            if (_board[i, j] == Pawns.E && i<3 && j<3)
                _board[i, j] = _turn;
            else{
                Console.WriteLine("Spot taken, try again");
                return;
            }

            _winner = CheckBoard();
            if (_winner != Pawns.E)
            {
                IsGameOver = true;
                return;
            }

            _turn = _turn == Pawns.X? Pawns.O : Pawns.X;
        }

        private Pawns CheckBoard()
        {
            for(int i=0; i<3 ; i++)                                                  //check rows
                if (_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2])    //
                     return _board[i, 0];                                            //

            for (int i = 0; i < 3; i++)                                              //check columns
                if (_board[0,i] == _board[1,i] && _board[1,i] == _board[2,2])        //
                    return _board[0,i];                                              //

            if (_board[0,0] == _board[1,1] && _board[1,1]== _board[2,2])             //check diagonals
                return _board[0, 0];                                                 //
                                                                                     //
            if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0])        //
                return _board[0, 0];                                                 //

            return Pawns.E;
            

        }

        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            int row, col;
            do
            {
                Console.WriteLine("Your Board:");
                game.DisplayBoard();
                Console.WriteLine($"{game.Turn}'s turn");
                Console.WriteLine("Where would you like to place your next tool:");
                Console.Write("Row: ");
                int.TryParse(Console.ReadLine(), out row);
                Console.Write("Column: ");
                int.TryParse(Console.ReadLine(),out col);

                game.Play(row,col);
            } while (!game.IsGameOver);

            game.DisplayBoard();
            Console.WriteLine($"Game over! {game.Winner} is the winner!");
        }
    }
}
