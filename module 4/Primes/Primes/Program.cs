using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        public static int[] CalcPrimes(int a, int b)
        {
            var primes = new ArrayList();
            for(int i = a; i<= b; i++)
                if (IsPrime(i)) primes.Add(i);

            var primeInts = new int [primes.Count];
            primes.CopyTo(primeInts, 0);

            return primeInts;

        }

        private static bool IsPrime(int x)
        {
            if (x == 1) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x%i == 0) return false;
            return true;


        }
        static void Main(string[] args)
        {
            int a,b;
            Console.Write("Enter 2 numbers:\nfirst: ");
            int.TryParse(Console.ReadLine(), out a);
            Console.Write("second: ");
            int.TryParse(Console.ReadLine(), out b);
            int[] primes = CalcPrimes(a, b);
            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }
            ;
        }
    }
}
