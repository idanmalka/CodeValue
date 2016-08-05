using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackgammonLib;

namespace BackgammonWinformApp
{
    class GameMethods : IGameMethods
    {
        private Board _board;
        private BackGammon _game;

        public GameMethods(Board board, BackGammon game)
        {
            _board = board;
            _game = game;
            RegisterToEvents(_board);
        }

        public void NextTurn(object sender, EventArgs args)
        {
            _game.ClearLog();
            Board board = (Board)sender;
            DisableButtonsExcept(diceRoll: true);
            string outputMessage = $"{board.Turn}'s Turn!\n To play roll the dice!";
            DisplayMessage(outputMessage);
            WaitForDice();
            EnableAllButtons();
            var diceRes = Dice.RollDice();
            SetDiceResults(diceRes);
            var output = ((DiceEventArgs)args).DiceRes;
            output[0] = diceRes[0];
            output[1] = diceRes[1];
        }

        private void EnableAllButtons()
        {
            _game.Invoke((MethodInvoker)delegate {
                _game.FirstDiceButton.Enabled = true;
                _game.SecondDiceButton.Enabled = true;
                foreach (var button in _game.ButtonTools)
                    button.Enabled = true;
                _game.DiceRollButton.Enabled = true;
            });
        }

        private void DisableButtonsExcept(bool firstDice = false, bool secondDice = false, bool blackSteps = false, bool whiteSteps = false, bool diceRoll = false)
        {
            _game.Invoke((MethodInvoker)delegate {
                _game.FirstDiceButton.Enabled = firstDice;
                _game.SecondDiceButton.Enabled = secondDice;
                for (int i = 0; i < 26; i++)
                    _game.ButtonTools[i].Enabled = _board.Steps[i].Color ==
                                 PlayerColor.Color.White ? whiteSteps : _board.Steps[i].Color ==
                                 PlayerColor.Color.Black ? blackSteps : true;
                _game.DiceRollButton.Enabled = diceRoll;
            });
        }

        private void DisplayMessage(string str)
        {
            _game.Invoke((MethodInvoker)delegate {
                _game.TextArea.Text += ("\n" + str); // runs on UI thread
            });
        }

        private void WaitForDice()
        {
            while (!_game.DiceRolled) { }
            _game.DiceRolled = false;
        }

        private void SetDiceResults(int[] diceRes)
        {
            _game.FirstDiceButton.BackgroundImage = GetImage(diceRes[0]);
            _game.SecondDiceButton.BackgroundImage = GetImage(diceRes[1]);
        }

        private static Image GetImage(int i)
        {
            switch (i)
            {
                case 1:
                    return Properties.Resources._1;
                case 2:
                    return Properties.Resources._2;
                case 3:
                    return Properties.Resources._3;
                case 4:
                    return Properties.Resources._4;
                case 5:
                    return Properties.Resources._5;
                case 6:
                    return Properties.Resources._6;
                default:
                    return Properties.Resources._1;
            }
        }

        public void GetNextMove(object sender, MoveEventArgs moveArgs)
        {
            int src, steps;
            Board board = (Board)sender;
            if (board.Turn == "White")
                DisableButtonsExcept(whiteSteps: true);
            else DisableButtonsExcept(blackSteps: true);
            DisplayMessage("From which triangle to move?");
            src = GetSourceStep();
            EnableAllButtons();
            if (moveArgs.DiceRes[0] != 0 && moveArgs.DiceRes[1] != 0 && moveArgs.DiceRes[0] != moveArgs.DiceRes[1])
            {
                bool canContinue;
                do
                {
                    DisplayMessage("By what dice?");
                    DisableButtonsExcept(firstDice: true, secondDice: true);
                    steps = moveArgs.DiceRes[GetDice()];
                    EnableAllButtons();
                    canContinue = true;
                    if ((steps != moveArgs.DiceRes[0] && steps != moveArgs.DiceRes[1]) || steps < 1 || steps > 6)
                    {
                        DisplayMessage("Not a valid dice number");
                        canContinue = false;
                    }
                } while (!canContinue);
            }
            else
            {
                steps = moveArgs.DiceRes[0] == 0 ? moveArgs.DiceRes[1] : moveArgs.DiceRes[0];
                DisplayMessage($"Dice: {steps}");
            }

            moveArgs.MoveArgs[0] = src;
            moveArgs.MoveArgs[1] = steps;

        }

        private int GetSourceStep()
        {
            while (true)
            {
                if (!_game.IsStepSelected) continue;
                _game.IsStepSelected = false;
                return _game.StepSelected;
            }

        }

        private int GetDice()
        {
            while (true)
            {
                if (_game.FirstDiceSelected)
                {
                    _game.FirstDiceSelected = false;
                    return 0;
                }
                if (_game.SecondDiceSelected)
                {
                    _game.SecondDiceSelected = false;
                    return 1;
                }
            }
        }

        public void RefreshDisplay(object sender, EventArgs arg)
        {
            Board board = (Board)sender;
            for (int i = 0; i < 26; i++)
            {
                _game.Invoke((MethodInvoker)delegate {
                    _game.ButtonTools[i].Visible = !board.Steps[i].IsEmpty;
                    _game.ButtonTools[i].BackgroundImage = board.Steps[i].Color == PlayerColor.Color.Black
                        ? Properties.Resources.black
                        : Properties.Resources.white;
                    _game.ButtonTools[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    _game.ButtonTools[i].Text = board.Steps[i].ToolsNum.ToString();
                    _game.ButtonTools[i].ForeColor = Color.Red;
                });
            }
        }

        public void PrintMessage(object sender, string str)
        {
            DisplayMessage(str);
        }

        public void RegisterToEvents(Board board)
        {
            board.RefreshDisplay += RefreshDisplay;
            board.NextTurn += NextTurn;
            board.GetNextMove += GetNextMove;
            board.Message += PrintMessage;
        }

    }
}
