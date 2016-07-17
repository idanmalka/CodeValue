using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    public class DynamicXElement : DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement element)
        {
            _element = element;
        }

        public static dynamic Create(XElement e) => new DynamicXElement(e);

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result =new DynamicXElement(_element.Element(binder.Name));
            return result != null;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            result = null;

            if (indexes.Length == 2 && indexes[0].GetType() == typeof(string) && indexes[1].GetType() == typeof(int))
            {
                var res = _element.Elements((string)indexes[0]).ElementAt((int)indexes[1]);
                result = new DynamicXElement(res);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return _element.Value.ToString();
        }
    }
}
