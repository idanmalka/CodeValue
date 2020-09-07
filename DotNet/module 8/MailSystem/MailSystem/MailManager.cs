using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{

    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(MailArrivedEventArgs args)
        {
            //Nice.
            MailArrived?.Invoke(this, args);
        }

        public void SimulateMailArrived(MailArrivedEventArgs args)
        {
            OnMailArrived(args);
        }
    }
}
