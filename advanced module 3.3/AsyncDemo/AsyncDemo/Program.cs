using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    // bad name for the delegate
    public delegate IEnumerable<int> Del(int first, int second);
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
        public static IEnumerable<int> CalcPrimes(int first, int second)
        {
            return Enumerable.Range(first,second).Where(IsPrime);
        }
        // "x" bad parameter name 
        private static bool IsPrime(int x)
        {
            if (x == 1) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }
    }
}
