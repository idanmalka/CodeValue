using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class DiceEventArgs : EventArgs
    {
        public int[] DiceRes { get; }

        public DiceEventArgs(int[] diceRes)
        {
            DiceRes = diceRes;
        }
    }
}
