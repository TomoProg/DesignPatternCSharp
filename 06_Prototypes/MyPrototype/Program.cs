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
            var addressManager = new Dictionary<string, IAddress>();

            for(int i = 0; i < 3; i++)
            {
                var zipcode = Console.ReadLine();
                addressManager[zipcode] = new Address(zipcode);
                Console.WriteLine($"{zipcode}を登録したよ");
            }

            while(true)
            {
                var zipcode = Console.ReadLine();
                var a = addressManager[zipcode].CreateClone();
                // ここで、住所全部打ちこんで、クローンで作ったインスタンスに入れる

                a.Print();
            }
        }
    }
}
