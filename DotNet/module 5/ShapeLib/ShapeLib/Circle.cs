using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse 
    {
        private int _radius;

        public Circle(int radius,ConsoleColor c=ConsoleColor.White) : base(radius, radius,c)
        {
            _radius = radius;
        }


        public int Radius//You allow changing the raidus value, bit do not update elipses values as well, which will cause inconsistent Area to be computed
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Dispaly()
        {
            ChangeColor();
            Console.WriteLine($"Circle radius: {Radius}");
        }

        protected override void Append(StringBuilder sb)
        {
            sb.AppendLine($"Circle radius: {Radius}\n");
        }
    }
}
