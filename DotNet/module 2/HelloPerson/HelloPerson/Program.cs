using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    //No input validatoin.
    //Print space at the first line - it is ok though.
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int num;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            //Nice, C#'s 6 feature.
            Console.WriteLine($"Hello {name}");
            Console.WriteLine("enter a number from 1 to 10");

            //Consider using int.TryParse
            num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                //The convention in C# is use a seperate line for the body, and also to add curly bracets, even if it isnly for a one liner.
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(name);
            }
        }
    }
}
