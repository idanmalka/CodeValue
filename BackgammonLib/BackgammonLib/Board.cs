using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    /*To Use this backgammon Library the programmer must implement the IGameMethods interface that includes
      5 methods that include 4 events and register to them. 
     Meaning the programmer needs to implement the following methods:
     void RefreshDisplay(object sender,EventArgs arg): Updates the board display in the UI
     void NextTurn(object sender, EventArgs args): starts the next move of the white/black player from dice roll in the UI
     void GetNextMove(object sender, MoveEventArgs moveArgs): retrieves the data for the next tool move from the UI if there are any left for the given player
     void PrintMessage(object sender, string e): sends a message to the UI and needs to be displayed in the proper way
     void RegisterToEvents(Board board): registers all the above given methods to the events in board.

     after the implementation of the GameMethods:IGameMethods, in Main, all that is needed is to :
     create a board instance
     create a GameMethods instance and send it the board and other requierments (eg. UI instance, etc.)
     call board.play() in the appropriate Thread (in the given console App its in the only thread, 
     in the WinForm App it is a seperate Thread that runs the logic via the library in parallel to the UI Thread)
     */

    public class Board
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private Player _turn;
        private bool IsGameOver => _player1.IsVictorious || _player2.IsVictorious;
        private Player Winner => (_player1.IsVictorious ? _player1 : (_player2.IsVictorious ? _player2 : null));

        public TriangleStep[] Steps { get; }
        public string Turn => _turn.Color.ToString();
        public event EventHandler NextTurn;
        public event EventHandler<MoveEventArgs> GetNextMove;
        public event EventHandler RefreshDisplay;
        public event EventHandler<string> Message;

        public Board()
        {
            int[] initialPositions = {1, 1, 12, 12, 12, 12, 12, 17, 17, 17, 19, 19, 19, 19, 19};

            var player1Tools = new Tool[15];
            var player2Tools = new Tool[15];

            Steps = new TriangleStep[26];
            for(int i=0; i<26; i++)
                Steps[i] = new TriangleStep(i);

            try
            {
                int index = 0;
                foreach (int pos in initialPositions)
                {
                    Tool whiteTool = new Tool(PlayerColor.Color.White, Steps[pos].StepPosition);
                    whiteTool.MoveToEatenList += MoveToolToEatenList;
                    Steps[pos].Add(whiteTool);
                    player1Tools[index] = whiteTool;

                    Tool blackTool = new Tool(PlayerColor.Color.Black, Steps[pos].StepPosition);
                    blackTool.MoveToEatenList += MoveToolToEatenList;
                    Steps[25 - pos].Add(blackTool);
                    player2Tools[index] = blackTool;

                    ++index;
                }
            }
            catch (MissMatchException e)
            {
               throw new Exception("Board initialization Error");
            }

            _player1 = new Player(1,PlayerColor.Color.White, player1Tools);
            _player2 = new Player(2,PlayerColor.Color.Black, player2Tools);
            _turn = GetStarter();
        }

        private Player GetStarter()
        {
            var diceRes1 = Dice.RollDice();
            var diceRes2 = Dice.RollDice();

            int player1Res = diceRes1[0] + diceRes1[1];
            int player2Res = diceRes2[0] + diceRes2[1];

            if (player1Res > player2Res)
                return _player1;
            if (player1Res < player2Res)
                return _player2;

            return GetStarter();
        }

        public void Play()
        {
            while (!IsGameOver)
            {
                RefreshDisplay?.Invoke(this,null);
                var diceRes = new int[2];
                NextTurn?.Invoke(this, new DiceEventArgs(diceRes));
                PlayNewTurn(diceRes);
            }
            Message?.Invoke(this, $"The Winner is the {Winner.Color} player!");
        }

        public void PlayNewTurn(int[] diceRes)
        {
            if (diceRes[0] == diceRes[1])
            {
                Message?.Invoke(this,"Double! you have 4 turns!");
                PlayDoubleTurn(diceRes);
            }
            else
            {
                PlayRegularTurn(diceRes);
            }
        }

        private void PlayRegularTurn(int[] diceRes)
        {
            var movesRemain = 2;
            var moveArgs = new int[2];
            do
            {
                GetNextMove?.Invoke(this, new MoveEventArgs(moveArgs,diceRes));
                var src = moveArgs[0];
                var steps = moveArgs[1];
                try
                {
                    PlayTurn(steps, src, ref movesRemain);
                    if (steps == diceRes[0])
                        diceRes[0] = 0;
                    else diceRes[1] = 0;

                    if (!(diceRes[0] == 0 && diceRes[1] == 0))
                    {
                        Message?.Invoke(this, "First turn Complete");
                        RefreshDisplay?.Invoke(this,new DiceEventArgs(diceRes));
                    }

                }
                catch (MissMatchException e)
                {
                    Message?.Invoke(this,e.Message);
                    RefreshDisplay?.Invoke(this, new DiceEventArgs(diceRes));
                }
                catch (StuckException e)
                {
                    Message?.Invoke(this,e.Message);
                    movesRemain--;
                    if (steps == diceRes[0])
                        diceRes[0] = 0;
                    else diceRes[1] = 0;
                }
                
            } while (movesRemain>0 && !IsGameOver);
        }

        private void PlayDoubleTurn(int[] diceRes)
        {
            int movesRemain = 4;
            var moveArgs = new int[2];
            do
            {
                GetNextMove?.Invoke(this, new MoveEventArgs(moveArgs, diceRes));
                var src = moveArgs[0];
                var steps = moveArgs[1];
                try
                {
                    PlayTurn(steps, src, ref movesRemain);

                    if (movesRemain > 0)
                    {
                        Message?.Invoke(this, $"Turn number {4-movesRemain} Complete");
                        RefreshDisplay?.Invoke(this, null);
                    }

                }
                catch (MissMatchException e)
                {
                    Message?.Invoke(this,e.Message);
                    RefreshDisplay?.Invoke(this, new DiceEventArgs(diceRes));
                }
                catch (StuckException e)
                {
                    Message?.Invoke(this,e.Message);
                    movesRemain = 0;
                }
            } while (movesRemain > 0 && !IsGameOver);
        }

        public void PlayTurn(int dice, int src, ref int movesRemain)
        {
            IsMoveLegal(src, dice);
            if (_turn == _player1)
                {
                    MoveWhiteTools(dice, src,ref movesRemain);
                    if (movesRemain == 0) _turn = _player2;
                }
                else
                {
                    MoveBlackTools(dice, src,ref movesRemain);
                    if (movesRemain == 0) _turn = _player1;
                }
        }

        private void MoveWhiteTools(int dice, int src,ref int movesRemain)
        {
            Tool temp = null;
            if (src + dice > 25) dice = 25 - src;
            try
            {
                temp = Steps[src].GetTool(_turn);
                Steps[src + dice].Add(temp);
                Steps[src].Remove(temp);
                movesRemain--;
            }
            catch (MissMatchException e)
            {
                if (temp != null)
                    Steps[src+dice].Remove(temp);
                throw;
            }

        }

        private void MoveBlackTools(int dice, int src,ref int movesRemain)
        {
            Tool temp = null;
            if (src - dice < 0) dice = src;
            try
            {
                temp = Steps[src].GetTool(_turn);
                Steps[src - dice].Add(temp);
                Steps[src].Remove(temp);
                movesRemain--;
            }
            catch (MissMatchException e)
            {
                if (temp != null)
                    Steps[src - dice].Remove(temp);
                throw;
            }
        }

        private void IsMoveLegal(int src, int dice)
        {
            CheckEatenList(src,dice);
            CheckStepForTools(src);
            CheckDiceUsability(dice);
            CheckValidToolChoice(src);
            CheckDestination(src, dice);
        }

        private void CheckEatenList(int src,int dice)
        {
            if (_turn.Color == PlayerColor.Color.Black && PlayerHasEatenTools(_turn) && src != 25)
            {
                if (IsDiceUseable(dice))
                    throw new MissMatchException("Must move Eaten tools first");
                throw new StuckException("unable to move anywhere with this dice");
            }
            if (_turn.Color == PlayerColor.Color.White && PlayerHasEatenTools(_turn) && src != 0)
            {
                if (IsDiceUseable(dice))
                    throw new MissMatchException("Must move Eaten tools first");
                throw new StuckException("unable to move anywhere with this dice");
            }
        }

        private void CheckStepForTools(int src)
        {
            if (!Steps[src].ContainToolsInColor(_turn.Color))
                throw new MissMatchException("You have no tools in that step");
        }

        private void CheckDiceUsability(int dice)
        {
            if (!IsDiceUseable(dice))
                throw new StuckException("unable to move anywhere with this dice");
            if (dice == 0)
                throw new MissMatchException("Already used that dice");
        }

        private void CheckValidToolChoice(int src)
        {
            if (Steps[src].Color != PlayerColor.Color.Empty && Steps[src].Color != _turn.Color)
                throw new MissMatchException("Unable to move opponent's tools");
        }

        private void CheckDestination(int src, int dice)
        {
            if ((_turn == _player1 && dice + src > 24 && !_turn.ReadyToExclude) || (_turn == _player2 && src - dice < 1 && !_turn.ReadyToExclude))
                throw new MissMatchException("Unable to move to that step");
        }

        private bool IsDiceUseable(int dice)
        {
            foreach (var step in Steps)
            {
                var dest = step.StepPosition + dice;
                if (dest > 24) return false;
                if (Steps[dest].Color == _turn.Color || Steps[dest].Color == PlayerColor.Color.Empty || Steps[dest].ToolsNum < 2)
                    return true;
            }
            return false;
        }

        private static bool PlayerHasEatenTools(Player p)=> p.Tools.Any(tool => tool.Eaten);
        
        private void MoveToolToEatenList(object sender, EventArgs e)
        {
            Tool tool = (Tool) sender;
            if (tool.Color == PlayerColor.Color.White)
                Steps[0].Add(tool);
            else Steps[25].Add(tool);
        }
    }
}
