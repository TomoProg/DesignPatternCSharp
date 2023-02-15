using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new MyHtmlParser(new MyHttpClient());
            var title = c.GetTitle("https://www.neogenia.co.jp");
            Console.WriteLine(title);
        }
    }
}
