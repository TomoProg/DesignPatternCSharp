using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class CountDisplay : Display
    {
        public CountDisplay(DisplayImpl impl) : base(impl) { }
        public void MultiDisplay(int times)
        {
            base.Open();
            for(int i = 0; i < times; i++)
            {
                base.Print();
            }
            base.Close();
        }
    }
}
