using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class A
    {
        public string Hello(string str)
        {
            return "hello " + str;
        }
    }

    class B
    {
        public string Hello(string str)
        {
            return "Bonjour " + str;
        }
    }

    class C
    {
        public string Hello(string str)
        {
            return "Nihau " + str;
        }
    }

    class Program
    {

        static string InvokeHello(object obj, string str)
        {
            string[] param = new string[1];
            param[0] = str;
            Type type = obj.GetType();
            return (string)type.GetMethod("Hello").Invoke(obj, param);
        }


        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine(InvokeHello(a,"A"));
            B b = new B();
            Console.WriteLine(InvokeHello(b,"B"));
            C c = new C();
            Console.WriteLine(InvokeHello(c,"C"));
        }
    }
}
