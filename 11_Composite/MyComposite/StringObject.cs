using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class StringObject : Entry
    {
        public string Value { get; }

        public StringObject(string value)
        {
            Value = value;
        }
    }
}
