using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [CodeReview("idan", "17/07/16", true)]
    class A
    { }

    [CodeReview("adir", "16/07/16", true)]
    class B
    { }

    [CodeReview("gil", "15/07/16", false)]
    class c
    { }

    class Program
    {

        public static bool AnalayzeAssembly(Assembly asm)
        {
            bool aproval = true;
            var asmObjs = asm.GetTypes();
            foreach (var obj in asmObjs)
            {
                var attrs = obj.GetCustomAttributes(typeof(CodeReviewAttribute), false);
                foreach (CodeReviewAttribute att in attrs)
                {
                    if (!att.Approved) aproval = false;
                    Console.WriteLine($"Name: {att.Name}, Date: {att.Date}, Aproval: {att.Approved}");
                }
            }
            return aproval;
        }

        public static void Main(string[] args)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            AnalayzeAssembly(asm);

            //  asm = Assembly.GetAssembly(typeof(AssemblyFlagsAttribute));
            // AnalayzeAssembly(asm);
            // if there are no attributes of codeReview nothing will happen but iterating on all 
            //attributes of the given assembly and looking for codeReview attributes
        }
    }
}
