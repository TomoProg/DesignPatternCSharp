using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Display d1 = new Display(new StringDisplayImpl("Hello, Japan."));
            Display d2 = new CountDisplay(new StringDisplayImpl("Hello, World."));
            CountDisplay d3 = new CountDisplay(new StringDisplayImpl("Hello, Universe."));

            d1.DoDisplay();
            d2.DoDisplay();
            d3.DoDisplay();
            d3.MultiDisplay(3);

            Display d4 = new RandomCountDisplay(new StringDisplayImpl("Hello, World. random."));
            RandomCountDisplay d5 = new RandomCountDisplay(new StringDisplayImpl("Hello, Universe. random."));

            d4.DoDisplay();
            d5.RandomDisplay();
        }
    }
}
