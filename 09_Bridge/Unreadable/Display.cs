using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unreadable
{
    public abstract class Display
    {
        public abstract void Open();
        public abstract void Print();
        public abstract void Close();
        public void DoDisplay()
        {
            Open();
            Print();
            Close();
        }
    }
}
