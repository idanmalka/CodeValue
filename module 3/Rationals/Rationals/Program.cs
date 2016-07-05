using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational 
    {
        private int numerator, denominator;
        
        public Rational(int numerator,int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }//constructor(int,int)

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
        
        public override bool Equals(object obj)
        {
            return (numerator == ((Rational)obj).Numerator && denominator == ((Rational)obj).Denominator);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(4, 8);
            Rational r2 = new Rational(31);
            Rational temp;
            Console.WriteLine($"new rationals created: \n1: {r1} , {r1.RealVal}\n2: {r2} , {r2.RealVal}");
            temp = r1.Add(r2);
            Console.Write($"Add: {temp}");
            temp.Reduce();
            Console.WriteLine($" Simplified: {temp}");
            temp = r1.Mul(r2);
            Console.Write($"Mul: {temp}");
            temp.Reduce();
            Console.WriteLine($" Simplified: {temp}");
            r1.Reduce();
            Console.WriteLine($"r1 Simplified: {r1}");
        }
    }
}
