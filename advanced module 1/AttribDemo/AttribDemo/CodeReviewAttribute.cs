using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple = true)]
    public class CodeReviewAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public bool Approved { get; set; }

        public CodeReviewAttribute(string name, string date, bool approved)
        {
            Name = name;
            Date = date;
            Approved = approved;
        }
    }
}
