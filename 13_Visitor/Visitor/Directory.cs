using System.Collections.Generic;

namespace Visitor
{
    public class Directory : Entry
    {
        private string _name;
        private List<Entry> _dir = new List<Entry>();

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
            int size = 0;
            foreach(Entry e in _dir)
            {
                size += e.GetSize();
            }
            return size;
        }

        public override Entry Add(Entry entry)
        {
            _dir.Add(entry);
            return this;
        }

        public override void Accept(Visitor v)
        {
            v.Visit(this);
        }
    }
}