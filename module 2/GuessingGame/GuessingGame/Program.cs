using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secret = new Random().Next(1, 101);
            int guess,guessingCount = 0;
            do
            {
                Console.WriteLine("Guess my number");
                int.TryParse(Console.ReadLine(),out guess);
                guessingCount++;
                if (guess < secret) Console.WriteLine("too small");
                else if (guess > secret) Console.WriteLine("too big");
                else
                {
                    Console.WriteLine($"you made {guessingCount} guesses");
                    guessingCount = 10;
                }
            } while (guessingCount < 8);
            if (guessingCount == 8) Console.WriteLine("you failed");
        }
    }
}
