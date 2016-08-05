using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackgammonLib;

namespace BackgammonConsoleApp
{
    class GameMethods : IGameMethods
    {
        public GameMethods(Board board)
        {
            RegisterToEvents(board);
        }

        public void PrintMessage(object sender, string e) => Console.WriteLine(e);

        public void NextTurn(object sender, EventArgs args)
        {
            Board board = (Board)sender;
            Console.WriteLine($"{board.Turn}'s Turn!");
            Console.WriteLine("press any key to roll the dice:");
            Console.ReadKey(true);
            var diceRes = Dice.RollDice();
            Console.WriteLine($"Your numbers are: {diceRes[0]} , {diceRes[1]}");
            var output = ((DiceEventArgs)args).DiceRes;
            output[0] = diceRes[0];
            output[1] = diceRes[1];
        }

        public void GetNextMove(object sender, MoveEventArgs moveArgs)
        {
            int src, steps;
            Console.WriteLine("From which triangle to move?");
            int.TryParse(Console.ReadLine(), out src);

            if (moveArgs.DiceRes[0] != 0 && moveArgs.DiceRes[1] != 0 && moveArgs.DiceRes[0] != moveArgs.DiceRes[1])
            {
                bool canContinue;
                do
                {
                    Console.WriteLine("By what dice?");
                    int.TryParse(Console.ReadLine(), out steps);
                    canContinue = true;
                    if ((steps != moveArgs.DiceRes[0] && steps != moveArgs.DiceRes[1]) || steps < 1 || steps > 6)
                    {
                        Console.WriteLine("Not a valid dice number");
                        canContinue = false;
                    }
                } while (!canContinue);
            }
            else
            {
                steps = moveArgs.DiceRes[0] == 0 ? moveArgs.DiceRes[1] : moveArgs.DiceRes[0];
                Console.WriteLine($"Dice: {steps}");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            }

            moveArgs.MoveArgs[0] = src;
            moveArgs.MoveArgs[1] = steps;

        }

        public void RefreshDisplay(object sender, EventArgs arg)
        {
            Board board = (Board)sender;
            Console.WriteLine("Board:");
            foreach (var step in board.Steps)
            {
                if (step.ToolsNum > 0) Console.WriteLine(step.StepPosition + ": " + step.ToolsNum + " " + step.Color);
            }
            if (arg != null)
            {
                int[] diceRes = ((DiceEventArgs)arg).DiceRes;
                Console.WriteLine($"Your numbers are: {diceRes[0]} , {diceRes[1]}");
            }
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
