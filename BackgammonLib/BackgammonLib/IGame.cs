using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public interface IGameMethods
    {
        void RefreshDisplay(object sender, EventArgs arg);// Updates the board display in the UI
        void NextTurn(object sender, EventArgs args);// starts the next move of the white/black player from dice roll in the UI
        void GetNextMove(object sender, MoveEventArgs moveArgs);// retrieves the data for the next tool move from the UI if there are any left for the given player
        void PrintMessage(object sender, string e);// sends a message to the UI and needs to be displayed in the proper way
        void RegisterToEvents(Board board); // registers all the above given methods to the events in board
    }
}
