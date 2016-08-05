using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class MoveEventArgs : EventArgs
    {
        public int[] MoveArgs { get; }
        public int[] DiceRes { get; }

        public MoveEventArgs(int[] moveArgs, int[] diceRes)
        {
            MoveArgs = moveArgs;
            DiceRes = diceRes;
        }
    }
}
