using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print p = new PrintBanner("test");
            Print2 p = new PrintBanner2(new Banner("test"));
            p.PrintWeek();
            p.PrintStrong();
        }
    }
}
