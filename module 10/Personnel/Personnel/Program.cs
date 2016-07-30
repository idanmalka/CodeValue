using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {

        /**
         * You are not handling exceptions at all, which is expected at this point in the course.
         * Consider this:
         * https://msdn.microsoft.com/en-us/library/ms164917.aspx
         */


        /**Bug: you are not disposing of the string reader
                  * Consider this:
                  * https://msdn.microsoft.com/en-us/library/3bwa4xa9(v=vs.110).aspx
                  */
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            FileStream stream = new FileStream("Names.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader reader = new StreamReader(stream);
            while(!reader.EndOfStream) names.Add(reader.ReadLine());
            foreach (var name in names)
                Console.WriteLine(name);
        }
    }
}
