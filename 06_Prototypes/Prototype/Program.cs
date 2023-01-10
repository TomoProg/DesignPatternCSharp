using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Framework;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            var upen = new UnderlinePen('~');
            var mbox = new MessageBox('*');
            var sbox = new MessageBox('/');
            manager.Register("strong message", upen);
            manager.Register("warning box", mbox);
            manager.Register("slash box", sbox);

            Product p1 = manager.Create("strong message");
            p1.Use("Hello, world.");
            Product p2 = manager.Create("warning box");
            p2.Use("Hello world.");
            Product p3 = manager.Create("slash box");
            p3.Use("Hello world.");

        }
    }
}
