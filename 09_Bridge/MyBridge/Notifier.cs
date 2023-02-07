using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBridge
{
    public class Notifier
    {
        protected IPost _impl;
        public Notifier(IPost impl)
        {
            _impl = impl;
        }

        public void Post(string text)
        {
            _impl.Post(text);
        }
    }
}
