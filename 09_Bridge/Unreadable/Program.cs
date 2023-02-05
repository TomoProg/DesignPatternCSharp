using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unreadable
{
    class Program
    {
        static void Main(string[] args)
        {
            Display d1 = new StringDisplay("Hello, Japan.");
            StringCountDisplay d2 = new StringCountDisplay("Hello, Universe.");
            StringCountAndQuestionDisplay d3 = new StringCountAndQuestionDisplay("Hello, Question.");

            d1.DoDisplay();
            Console.WriteLine();

            d2.MultiDisplay(3);
            Console.WriteLine();

            d3.MultiDisplay(5);
            Console.WriteLine();
        }
    }
}
