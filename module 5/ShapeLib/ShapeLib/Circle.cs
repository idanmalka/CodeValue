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


        public int Radius
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
