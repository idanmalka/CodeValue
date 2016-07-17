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
