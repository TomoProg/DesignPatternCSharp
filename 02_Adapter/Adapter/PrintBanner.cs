using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class PrintBanner : Banner, Print
    {
        public PrintBanner(string s) : base(s) { }

        public void PrintWeek()
        {
            ShowWithParen();
        }

        public void PrintStrong()
        {
            ShowWithAster();
        }
    }
}
