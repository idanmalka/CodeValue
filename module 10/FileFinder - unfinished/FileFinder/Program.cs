using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
           DirectoryInfo info = new DirectoryInfo(@args[0]);
            var list = info.GetFileSystemInfos("*"+args[1]+"*");
            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}
