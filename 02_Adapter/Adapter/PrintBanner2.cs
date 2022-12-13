using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class PrintBanner2 : Print2
    {
        private Banner _b;
        public PrintBanner2(Banner b)
        {
            _b = b;
        }

        public override void PrintWeek()
        {
            _b.ShowWithParen();
        }

        public override void PrintStrong()
        {
            _b.ShowWithAster();
        }
    }
}
