using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class Tool
    {

        public PlayerColor.Color Color { get; }
        public bool Eaten { private set; get; }
        public bool Excluded { private set; get; }
        public int Position { private set; get; }
        public event EventHandler MoveToEatenList;

        public Tool(PlayerColor.Color color, int position)
        {
            Color = color;
            Eaten = false;
            Excluded = false;
            Position = position;
        }

        public void Move(int dest)
        {
            Position = dest;
            if (dest != 0 && Color == PlayerColor.Color.White) Eaten = false;
            if (dest != 25 && Color == PlayerColor.Color.Black) Eaten = false;
        } //changes tool position number to dest


        public void Eat()
        {
            Move(Color == PlayerColor.Color.White ? 0 : 25); // 0 is the Eaten list of the white tools
            Eaten = true;                                    // and 25 is the Eaten list of the black tools
            MoveToEatenList?.Invoke(this,new EventArgs());
        }

        public void Exclude()
        {
            Move(Color == PlayerColor.Color.Black ? 0 : 25);    // 0 is the excluded list of the black tools
            Excluded = true;                                    // and 25 is the excluded list of the white tools
        }
    }
}
