using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var s1 = Singleton.GetInstance();
            var s2 = Singleton.GetInstance();
            Console.WriteLine(s1 == s2);
            Console.WriteLine("End");
        }
    }
}
