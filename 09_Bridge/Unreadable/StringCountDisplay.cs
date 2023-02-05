using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unreadable
{
    public class StringCountDisplay : StringDisplay
    {
        public StringCountDisplay(string s, string encName = "Shift_JIS") : base(s, encName) { }

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
