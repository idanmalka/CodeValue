using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class MissMatchException: Exception
    {
        private readonly string _msg;

        public MissMatchException(string msg)
        {
            _msg = msg;
        }

        public override string Message => "Invalid Operation: " + _msg;

    }
}
