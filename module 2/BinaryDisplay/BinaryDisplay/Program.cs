using System;

namespace BinaryDisplay
{
    public class Program
    {

        public static int CountOnes(int input)
        {
            var count = 0;
            if (input<0) throw new ArgumentOutOfRangeException();
            while (input != 0)
            {
                if ((input & 1) == 1) count++;
                input = input >> 1;
            }
            return count;
        }

        public static string GetBinaryRep(int input) => Convert.ToString(input, 2);
        
        public static void Main(string[] args)
        {
            int input;
            Console.WriteLine("enter a number");
            int.TryParse(Console.ReadLine(),out input);
            Console.WriteLine($"the binary represantation is { GetBinaryRep(input) }");
            try
            {
                Console.WriteLine($"there are {CountOnes(input)} 1's in the input");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("The number of 1's in a negative number is infinite, in some way");
            }
        }
    }
}
