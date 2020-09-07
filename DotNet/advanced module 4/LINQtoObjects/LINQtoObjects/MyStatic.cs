using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoObjects
{
    static class MyStatic
    {

        public static void CopyTo(this object obj,object dest)
        {
            var props = from prop in obj.GetType().GetProperties()
                        where prop.CanRead
                        select prop;

            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    dest.GetType().GetProperty(prop.Name).SetValue(dest,prop.GetValue(obj,null));
            }
        }
    }
}
