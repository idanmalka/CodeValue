using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class Dice
    {
        private static readonly Random Rand = new Random();
        public static int[] RollDice() => 
            new int[] { Rand.Next(1, 100)%6+1,Rand.Next(1,100)%6+1};

        //Returns the outcome of 2 dice roll:
        //RollDice[0] = first dice number roll
        //RollDice[1] = second dice number roll

    }
}
