using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class Entry
    {
        public abstract string GetName();
        public abstract int GetSize();

        public virtual Entry Add(Entry entry)
        {
            // 書籍ではFileTreatmentExceptionというのを使っているが
            // Java専用？なのか良く分からんので、とりあえずNotImplementedExceptionにしておく
            throw new NotImplementedException();
        }

        public void PrintList()
        {
            PrintList("");
        }

        // 書籍ではprotectedだけど、C#だと派生先で呼べない？？？
        public abstract void PrintList(string prefix);

        public override string ToString()
        {
            // テンプレートメソッドになってる
            return $"{GetName()} ({GetSize()})";
        }
    }
}
