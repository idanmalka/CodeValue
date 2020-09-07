using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // You should have used a seperate class and a seperate file for the logic.
    //Great job with the UnitTests.
    public class Calc
    {
        private static double Add(double x, double y)
        {
            //body of statements in the same line is not recommended in C#, at least it isn't the convention
            if (x == double.MaxValue && y > 0) throw new OverflowException();
            if (y == double.MaxValue && x > 0) throw new OverflowException();

            if (x == double.MinValue && y < 0) throw new OverflowException();
            if (y == double.MinValue && x < 0) throw new OverflowException();

            return x + y;
        }

        private static double Sub(double x, double y)
        {
            if (x == double.MinValue && y > 0) throw new OverflowException();
            if (x == double.MaxValue && y < 0) throw new OverflowException();
            return x - y;
        }

        private static double Mul(double x, double y)
        {
            if ((x == double.MaxValue || x == double.MinValue) && y > 0) throw new OverflowException();
            if ((y == double.MaxValue || y == double.MinValue) && x > 0) throw new OverflowException();

            return x*y;
        }

        private static double Div(double x, double y)
        {
            if (y==0)
                throw new DivideByZeroException();
            if ((x == Double.MaxValue || x == Double.MinValue) && y > 0 && y < 1) 
                throw new OverflowException();
            return x/y;
        }

        public static double Calculate(double firstNum, double secondNum, string op)
        {
            switch (op)
            {
                case "+":
                   return Add(firstNum,secondNum);
                case "-":
                    return Sub(firstNum, secondNum);
                case "*":
                    return Mul(firstNum, secondNum);
                case "/":
                    return Div(firstNum, secondNum);
                default:
                    Console.WriteLine("bad operator, try again");
                    return double.NaN;

            }
        }
        static void Main(string[] args)
        {
            //The conveintion in C# is to declare each variable in a seperate line.
            double firstNum, secondNum, res = double.NaN;
            string op;
            bool flag = true;
            do
            {
                Console.WriteLine("Please enter first number");
                double.TryParse(Console.ReadLine(), out firstNum);
                Console.WriteLine("Please enter second number");
                double.TryParse(Console.ReadLine(), out secondNum);
                Console.WriteLine("Please enter operator + or - or / or *");
                op = Console.ReadLine();
                try
                {
                    res = Calculate(firstNum, secondNum, op);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("Unable to divide by 0");
                    res = double.NaN;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Illegal operation");
                }
                if (!double.IsNaN(res))
                    Console.WriteLine($"Result: {res}");
            } while (double.IsNaN(res));
        }
    }
}
