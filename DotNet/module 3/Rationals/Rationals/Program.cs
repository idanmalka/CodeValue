using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational 
    {
        //The conveintion in C# is to declear each variable in his own line
        private int numerator, denominator;
        
        public Rational(int numerator,int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }//constructor(int,int)

        //You could have called the other constructor:
        //Rational(int numerator) : this(numerator, 1) { }
        public Rational(int numerator)
        {
            this.numerator = numerator;
            denominator = 1;
        }//Constructor(int)

        public int Numerator
        {
            get
            {
                return numerator;
            }//get - Numerator
        }//Numerator property

        public int Denominator
        {
            get
            {
                return denominator;
            }//get - Denominator
        }//Denominator property

        public double RealVal
        {
            get
            {
                return (double)((double)numerator / denominator);
            }//get - RealVal
        }//RealVal property

        public Rational Add(Rational right)
        {
            Rational res;
            if (denominator == right.Denominator)
                res = new Rational(numerator + right.Numerator,denominator);
            else res = new Rational(numerator * right.Denominator + denominator * right.Numerator,denominator*right.Denominator);
            return res;
        }//Add

        public Rational Mul(Rational right)
        {
            Rational res = new Rational(numerator*right.Numerator,denominator*right.Denominator);
            return res;
        }// Mull

        public void Reduce()
        {
            int divider = gcd(numerator, denominator);
            numerator = numerator / divider;
            denominator = denominator / divider;
        }// Reduce

        private int gcd(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }// Greatest Common Divisor

        public override string ToString()
        {
            return string.Format($"{numerator}/{denominator}");
        }
        
        //Didn't check whether obj is of type Rational.
        public override bool Equals(object obj)
        {
            return (numerator == ((Rational)obj).Numerator && denominator == ((Rational)obj).Denominator);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rational num1 = new Rational(1, 2);
            Rational num2 = new Rational(1, 2);

            Rational num3 = num1.Add(num2);

            Rational num4 = num2.Mul(num2);

            Rational num6 = new Rational(2, 4);
            Rational num7 = new Rational(2, 4);
            num7.Reduce();


            Console.WriteLine($"{num1} + {num2} = {num3}");
            Console.WriteLine($"{num2} * {num2} = {num4}");
            Console.WriteLine($"{num6} reduced {num7}");
        }
    }
}
