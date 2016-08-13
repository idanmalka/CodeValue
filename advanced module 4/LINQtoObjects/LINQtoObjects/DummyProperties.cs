using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjects
{
    class DummyProperties
    {
        public int PropOne { set; get; }
        public string PropTwo { set; get; }
        public bool PropThree { get; }
        public DummyProperties(int one,string two,bool three)
        {
            PropOne = one;
            PropTwo = two;
            PropThree = three;
        }
    }
}
