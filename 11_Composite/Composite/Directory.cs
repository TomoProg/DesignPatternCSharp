using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Directory : Entry
    {
        private string _name;
        private List<Entry> _directory = new List<Entry>();

        public Directory(string name)
        {
            _name = name;
        }

        public override string GetName()
        {
            return _name;
        }

        public override int GetSize()
        {
            return _directory.Sum(x => x.GetSize());
        }

        public override Entry Add(Entry entry)
        {
            _directory.Add(entry);
            return this;
        }

        public override void PrintList(string prefix)
        {
            Console.WriteLine($"{prefix}/{this}");
            _directory.ForEach(x => x.PrintList($"{prefix}/{_name}"));
        }
    }
}
