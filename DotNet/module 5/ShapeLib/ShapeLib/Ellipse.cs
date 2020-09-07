using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape , IPersist , IComparable
    {
        private int _shortRadius;
        private int _longRadius;


        public Ellipse(int shortRadius, int longRadius, ConsoleColor c= ConsoleColor.White) :base(c)
        {
            _shortRadius = shortRadius;
            _longRadius = longRadius;
        }

        public int ShortRadius
        {
            get { return _shortRadius; }
            set { _shortRadius = value; }
        }

        public int LongRadius
        {
            get { return _longRadius; }
            set { _longRadius = value; }
        }

        public override double Area
        {
            get { return Math.PI*_shortRadius*_longRadius; }
            set { }
        }

        public override void Dispaly()
        {
            ChangeColor();
            Console.WriteLine($"Ellipse short radius: {ShortRadius} \nEllipse long radius: {LongRadius}");
        }

        //Very good!
        protected void ChangeColor()
        {
            base.Dispaly();
        }

        public void Write(StringBuilder sb)
        {
            Append(sb);
        }

        protected virtual void Append(StringBuilder sb)
        {
            sb.AppendLine($"Ellipse short radius: {ShortRadius} \nEllipse long radius: {LongRadius}\n");
        }

        /**
         Buggy implementation of compare to
         Read the interface implementation and return values as expected
         If an invalid argument has been passed, consider throwing ArgumentNullException or ArgumentException
             */
        public int CompareTo(object obj) //returns 2 if obj is not of ellipse type ,return 1 if this < obj , return -1 if this > obj, return 0 if this == obj
        {
            var ellipse = obj as Shape;
            if (ellipse != null){
              if (Area > ellipse.Area) return -1;
              if (Area < ellipse.Area) return 1;
              return 0;
            }
            return 2;
        }
    }
}
