using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class Player
    {

        public int ID { get; }
        public PlayerColor.Color Color { get; }
        public Tool[] Tools { get; }
        public bool IsVictorious => Tools.All(tool => tool.Excluded);
        public bool ReadyToExclude => 
            Color == PlayerColor.Color.White? 
                Tools.All(tool => tool.Position >= 19)  : Tools.All(tool => tool.Position <= 6);
        
        public Player(int id, PlayerColor.Color color, Tool[] tools)
        {
            ID = id;
            Color = color;
            Tools = tools;
        }
    }
}
