using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList _list; //list of shapes

        public ShapeManager() { _list = new ArrayList(); } //Constructor

        public void Add(Shape s) { _list.Add(s); } //add shape method

        public void DisplayAll()    //display all elements in list
        {
            foreach (var item in _list) 
            {
                ((Shape)item).Dispaly();
                Console.WriteLine($"Area: {((Shape)item). Area}\n");
            }
        }

        public Shape this[int index]    //list indexer
        {
            get { return (Shape)_list[index]; }
            set { }
        }

        public int Count        //list size counter
        {
            get { return _list.Count; }
            set { }
        }

        public void Save(StringBuilder sb)
        {
            foreach (var item in _list)
                (item as IPersist)?.Write(sb);
            
        }


        static void Main(string[] args)
        {
            ShapeManager mngr = new ShapeManager();
            StringBuilder sb = new StringBuilder();

            mngr.Add(new Circle(5,ConsoleColor.Cyan));
            mngr.Add(new Rectangle(2,3,ConsoleColor.Blue));
            mngr.Add(new Ellipse(5,6,ConsoleColor.Green));

            //Console.WriteLine($"There are {mngr.Count} Shapes: \n");  //from lab5.1
            //mngr.DisplayAll();

            mngr.Save(sb);                          // from lab 5.2
            Console.WriteLine(sb.ToString());       //
            
            mngr.Add(new Circle(5,ConsoleColor.White));
            mngr.Add(new Rectangle(6,7,ConsoleColor.White));
            mngr.Add(new Ellipse(1,2,ConsoleColor.White));

            switch (((Circle) mngr[0]).CompareTo(mngr[3]))
            {
                case 1:
                    ((Circle)mngr[3]).Dispaly();
                    Console.WriteLine("is greater than");
                    ((Circle)mngr[0]).Dispaly();
                    break;
                case -1:
                    ((Circle)mngr[0]).Dispaly();
                    Console.WriteLine("is greater than");
                    ((Circle)mngr[3]).Dispaly();
                    break;
                case 0:
                    ((Circle)mngr[0]).Dispaly();
                    Console.WriteLine("is is equal to");
                    ((Circle)mngr[3]).Dispaly();
                    break;
            }
            
        }
        
           
        
    }
}
