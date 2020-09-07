using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackgammonLib;

namespace BackgammonWinformApp
{
    static class Game
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var board = new Board();
            var game = new BackGammon();

            GameMethods methods = new GameMethods(board,game);

            Task.Run(new Action(() =>
            {
                Thread.Sleep(100);
                board.Play();
            }));
            Application.Run(game);
        }


    }
}
