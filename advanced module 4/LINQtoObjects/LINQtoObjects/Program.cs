using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Good Work
            PrintPublicInterfacesAndNumberOfMethodsIn("mscorlib");
            PrintProccessesWithLessThan5Threads();
            PrintTotalOfRunningThreads();
            CopyPropertiesWithExtension();
        }

        private static void CopyPropertiesWithExtension()
        {
            var prop1 = new DummyProperties(1,"one",true);
            var prop2 = new DummyProperties(2 ,"two",false);
            Console.WriteLine($"Prop1: Writeables: {prop1.PropOne} , {prop1.PropTwo} , Readonly: {prop1.PropThree}");
            Console.WriteLine($"Prop2: Writeables: {prop2.PropOne} , {prop2.PropTwo} , Readonly: {prop2.PropThree}");
            prop1.CopyTo(prop2);
            Console.WriteLine("Activated prop1.CopyTo(prop2)");
            Console.WriteLine($"Prop2: Writeables: {prop2.PropOne} , {prop2.PropTwo} , Readonly: {prop2.PropThree}");
        }

        private static void PrintTotalOfRunningThreads()
        {
            var numOfThreadsToProcess = from proc in Process.GetProcesses()
                            select proc.Threads.Count;
            var sum = numOfThreadsToProcess.Sum();

            Console.WriteLine($"Total number of threads running in the system: {sum}");
        }

        private static void PrintPublicInterfacesAndNumberOfMethodsIn(string name)
        {
            var asm = Assembly.Load("mscorlib");
            var publicInterfaces = from type in asm.GetTypes()
                                   where type.IsPublic && type.IsInterface
                                   orderby type.Name
                                   select type;

            foreach (var inter in publicInterfaces)
                Console.WriteLine($"interface Name: {inter.Name}, number of methods: {inter.GetMethods().Length}");

            Console.WriteLine();
        }

        private static void PrintProccessesWithLessThan5Threads()
        {
            var filteredProcesses = from proc in Process.GetProcesses()
                                    where proc.Threads.Count <= 5
                                    orderby proc.Id
                                    select proc;
            var groupedFilteredProcesses = from proc in filteredProcesses
                                           group proc by proc.BasePriority;

            foreach (var processGroup in groupedFilteredProcesses)
            {
                Console.WriteLine($"BaseProirity group: {processGroup.Key}");
                
                foreach (var proc in processGroup)
                    PrintProc(proc);
                
            }
            Console.WriteLine();
        }
        
        private static void PrintProc(Process proc)
        {
            try
            {
                Console.WriteLine(
                    $"proc name: {proc.ProcessName}, proc id: {proc.Id}, proc start time: {proc.StartTime}");
            }
            catch (Win32Exception e)
            {
                Console.WriteLine($"Access denied to proc: {proc.ProcessName}");
            }
        }
    }

}
