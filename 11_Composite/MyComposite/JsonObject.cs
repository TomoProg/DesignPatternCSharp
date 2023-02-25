using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class JsonObject : Entry
    {
        private List<Entry> _jsonObject = new List<Entry>();

        public Entry Add(Entry entry)
        {
            _jsonObject.Add(entry);
            return this;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
