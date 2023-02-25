using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class File : Entry
    {
        private string _name;
        private int _size;

        public File(string name, int size)
        {
            _name = name;
            _size = size;
        }

        public override string GetName()
        {
            return _name;
        }

        public override int GetSize()
        {
            return _size;
        }

        public override void PrintList(string prefix)
        {
            Console.WriteLine($"{prefix}/{this}");
        }
    }
}
