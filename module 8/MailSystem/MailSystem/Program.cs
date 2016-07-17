using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        private static MailManager _manager;

        public static void Main(string[] args)
        {
            _manager = new MailManager();
            var mailArgs = new MailArrivedEventArgs("Testing Mail Arrived Event", "TESTED");
            _manager.MailArrived += MailArrivedHandler;
            _manager.SimulateMailArrived(mailArgs);

            Timer timer = new Timer(Callback,mailArgs,1000,1000);
            Console.ReadLine();
        }

        public static void MailArrivedHandler(object sender, MailArrivedEventArgs args)
        {
            Console.WriteLine(args.Title);
            Console.WriteLine("\n"+args.Body);
        }

        public static void Callback(object state)
        {
          _manager.SimulateMailArrived((MailArrivedEventArgs)state);
        }
    }
}
