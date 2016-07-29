using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape , IPersist ,IComparable
    {
        private int _height;
        private int _width;

        public int Height
        {
            get {  return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        //+1 for using default values
        public Rectangle(int height, int width,ConsoleColor c = ConsoleColor.White) : base(c)
        {
            _height = height;
            _width = width;
        }

        public override double Area
        {
            get { return _height*_width; }
            set { }
        }

        public override void Dispaly()
        {
            base.Dispaly();
            Console.WriteLine($"Rectangle Height: {_height} \nRectangle Width: {_width}");
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine($"Rectangle Height: {_height} \nRectangle Width: {_width}\n");
        }

        public int CompareTo(object obj) //returns 2 if obj is not of Rectangle type ,return 1 if this < obj , return -1 if this > obj, return 0 if this == obj
        {
            var rec = obj as Shape;
            if (rec != null)
            {
                if (Area > rec.Area) return -1;
                if (Area < rec.Area) return 1;
                return 0;
            }
            return 2;
        }
    }
}