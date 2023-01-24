using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory
{
    public abstract class Link : Item
    {
        protected string _url;
        public Link(string caption, string url) : base(caption)
        {
            _url = url;
        }
    }
}
