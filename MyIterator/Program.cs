using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Purchase(1, new DateTime(2022, 1, 1));
            p.AddDetail(1, "apple");
            p.AddDetail(2, "banana");
            p.AddDetail(3, "grape");
            var it = p.CreateIterator();

            while(it.HasNext())
            {
                var d = it.Next();
                Console.WriteLine($"Id: {d.Id} PurchaseId: {d.PurchaseId} ProductName: {d.ProductName}");
            }
        }
    }
}
