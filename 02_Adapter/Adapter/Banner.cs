using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Banner
    {
        private string _s;
        public Banner(string s)
        {
            _s = s;
        }

        public void ShowWithParen()
        {
            Console.WriteLine($"({_s})");
        }

        public void ShowWithAster()
        {
            Console.WriteLine($"*{_s}*");
        }

    }
}
