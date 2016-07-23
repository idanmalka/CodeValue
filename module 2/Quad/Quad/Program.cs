using System;

namespace Quad
{
    //It would have been better to create a seperate class for the logic.
    public class Program
    {

        public static double[] CalculateQuad(double[] coef)
        {
            double[] res = new double[2];
            if (coef[0] == 0)
            {
                res[0] = (-coef[2]) / coef[1];
                res[1] = double.NaN;
                return res;
            }
            if (Math.Pow(coef[1], 2) - 4 * coef[0] * coef[2] < 0)
            {
                res[0] = res[1] = double.NaN;
                return res;
            }

            res[0] = ((-coef[1]) + Math.Sqrt(Math.Pow(coef[1], 2) - 4 * coef[0] * coef[2])) / (2 * coef[0]);
            res[1] = ((-coef[1]) - Math.Sqrt(Math.Pow(coef[1], 2) - 4 * coef[0] * coef[2])) / (2 * coef[0]);

            return res;

        }

        public static bool CheckAndParseInput(string[] args,double[] coef)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("there are Less than 3 coefficients");
                return false;
            }
            if (args.Length > 3)
            {
                Console.WriteLine("there are more than 3 coefficients");
                return false;
            }

            for (int i = 0; i < args.Length; i++)
                if (!double.TryParse(args[i], out coef[i]))
                {
                    Console.WriteLine($"failed to tryParse on coefficient number {i + 1} AKA \"{args[i]}\"");
                    return false;
                }

            return true;
        }

        public static void Main(string[] args)
        {
            var coef = new double[3];

            if (!CheckAndParseInput(args,coef)) return;

            var res = CalculateQuad(coef);

            if (double.IsNaN(res[0]))
                Console.WriteLine("There are No solutions");
            else if (double.IsNaN(res[1]))
                Console.WriteLine($"X = {res[0]}");
                 else Console.WriteLine($"X1 = {res[0]} X2 = {res[1]}");

        }
    }
}
