using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class InvalidKeyException : System.Exception
    {
        InvalidKeyException(string msg):base(msg)
        {

        }
    }
}
