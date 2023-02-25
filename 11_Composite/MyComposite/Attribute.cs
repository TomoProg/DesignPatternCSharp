using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Attribute : Entry
    {
        private string _key;
        private Entry _value; // 本当はobject型でもらいたいけど、ToStringをoverrideしないとまともに表示できないので、stringにしておく

        public Attribute(string key, Entry value)
        {
            _key = key;
            _value = value;
        }
    }
}
