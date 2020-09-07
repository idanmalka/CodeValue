using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class StuckException : Exception
    {
        public StuckException(string msg)
        {
            Message = "No more moves available";
        }

        public override string Message { get; }
    }
}
