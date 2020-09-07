using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs : EventArgs
    {
        public string Title { get; }
        public string Body { get; }

        public MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
