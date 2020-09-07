using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    static class MyXmlExtensions
    {
        // if you assosiate this all your methods to the same passed parameter... what is the idea of static class and static methods??
        //Create new class, pass him "IEnumerable<XElement> elements" threw the constructor...
        //Remeber: Use static only if you don't have any other way
        public static IEnumerable<string> TypesWithNoProperties(this IEnumerable<XElement> elements)
        {
            var filtered = from e in elements
                where e.Element("Properties") != null && e.Element("Properties").IsEmpty 
                orderby (string) e.Attribute("FullName")// without casting: e.Attribute("FullName").Value
                select (string) e.Attribute("FullName");

            return filtered;
        }

        public static int NumberOfMethods(this IEnumerable<XElement> elements)
        {
            return elements.Select(x => x.Elements("Methods").Descendants().Count()).Sum();
        }

        public static int NumberOfProperties(this IEnumerable<XElement> elements)
        {
            return elements.Select(x => x.Elements("Properties").Descendants().Count()).Sum();
        }

        public static string MostCommonParameterType(this IEnumerable<XElement> elements)
        {
            var groupParametersQuery = elements.Descendants("Parameter")
                .GroupBy(x => x.Attribute("Type"))
                .Select(x => new {type = x.Key, cnt = x.Count()}) // "cnt" bad name 
                .OrderBy(x => x.cnt)
                .Last();

            return groupParametersQuery.type.Value;
        }

        public static IEnumerable<XElement> SortTypesByMethods(this IEnumerable<XElement> elements)
        {
            var orderedByNumberOfMethods = from e in elements
                orderby e.Descendants("Method").Count() descending
                select e;

            var xe = from e in orderedByNumberOfMethods
                     select new XElement("Type",new XAttribute("FullName",e.FirstAttribute.Value),
                                       new XAttribute("NumberOfProperties",e.Descendants("Property").Count()),
                                       new XAttribute("NumberOfMethods",e.Descendants("Method").Count()));

            return xe;
        }

        public static IOrderedEnumerable<IGrouping<int, XElement>> GroupByMethods(this IEnumerable<XElement> elements)
        {
            var groupedByMethods = elements
                .OrderBy(x => (string) x.Attribute("FullName"))
                .GroupBy(x => x.Descendants("Method").Count())
                .OrderByDescending(x => x.Descendants("Method").Count());

            return groupedByMethods;
        }
    }
}
