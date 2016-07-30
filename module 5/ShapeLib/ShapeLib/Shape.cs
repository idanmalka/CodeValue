using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        private ConsoleColor _color;

        public ConsoleColor Color
        {
            get { return _color;  }
            set { _color = value; }
        }

        protected Shape(ConsoleColor c)
        {
            _color = c;
        }

        protected Shape()
        {
            _color = ConsoleColor.White;
        }

        public virtual void Dispaly()
        {
            Console.ForegroundColor = _color;
        }

        /**
         
             Setter is redundant, and causes you to implement a 'dummy' setter is all derived classes.
             Consider:
             public abstract double Area { get;}
             */
        public abstract double Area { get; set; }
    }
}
