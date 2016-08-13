using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement xml = new XElement("XmlMscorlib");

            var tree = createTree();
            xml.Add(tree);
            xml.Save("mscorlibGeneretedXml.xml");

            PrintTypesWithNoProperties(tree);
            PrintNumberOfMethods(tree);
            PrintNumberOfProperties(tree);
            PrintMostCommonParameterType(tree);
            ExportXmlSortedTypesByMethodNumber(tree);
            PrintGroupedByMethods(tree);

        }

        private static void PrintGroupedByMethods(IEnumerable<XElement> tree)
        {
            var grouped = tree.GroupByMethods();

            foreach (var group in grouped)
            {
                foreach (var element in group)
                {
                    Console.WriteLine(
                        $"Type: {element.Attribute("FullName")} , Number of methods: {element.Descendants("Method").Count()}");
                }
            }
        }

        private static void ExportXmlSortedTypesByMethodNumber(IEnumerable<XElement> tree)
        {
            var xe = tree.SortTypesByMethods();
            new XElement("TypesSortedByMethodsXml",xe).Save("TypesSortedByMethodsXml.xml");
        }

        private static void PrintMostCommonParameterType(IEnumerable<XElement> tree)
        {
            Console.WriteLine($"The most common type is: {tree.MostCommonParameterType()}");
            Console.WriteLine();
        }

        private static void PrintNumberOfProperties(IEnumerable<XElement> tree)
        {
            Console.WriteLine($"Number of Properties: {tree.NumberOfProperties()}");
            Console.WriteLine();
        }

        private static void PrintNumberOfMethods(IEnumerable<XElement> tree)
        {
            Console.WriteLine($"Number of methods: {tree.NumberOfMethods()}");
            Console.WriteLine();
        }

        private static void PrintTypesWithNoProperties(IEnumerable<XElement> tree)
        {
            var typesWithNoProperties = tree.TypesWithNoProperties();

            var withNoProperties = typesWithNoProperties as string[] ?? typesWithNoProperties.ToArray();
            Console.WriteLine(withNoProperties.Count());

            foreach (var e in withNoProperties)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
        }

        private static IEnumerable<XElement> createTree()
        {
            Assembly mscorlib = Assembly.Load("mscorlib");
            var tree = from member in mscorlib.GetExportedTypes()
                       where member.IsClass && member.IsPublic
                       select new XElement("Type", new XAttribute("FullName", member.FullName),
                                  new XElement("Properties",
                                        from prop in member.GetProperties()
                                        where prop.CanRead
                                        select new XElement("Property", new XAttribute("Name", prop.Name), new XAttribute("Type", prop.PropertyType))),
                                  new XElement("Methods",
                                        from method in member.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                        select new XElement("Method", new XAttribute("Name", method.Name), new XAttribute("ReturnType", method.ReturnType),
                                                   new XElement("Parameters",
                                                        from param in method.GetParameters()
                                                        select new XElement("Parameter", new XAttribute("Name", param.Name), new XAttribute("Type", param.GetType()))))));
            return tree;
        }
    }
}
