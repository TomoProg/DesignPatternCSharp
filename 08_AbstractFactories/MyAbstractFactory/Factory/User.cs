using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstractFactory.Factory
{
    public class User
    {
        public string Name { get; }
        public string Blood { get; }
        public User(string name, string blood)
        {
            Name = name;
            Blood = blood;
        }
    }
}
