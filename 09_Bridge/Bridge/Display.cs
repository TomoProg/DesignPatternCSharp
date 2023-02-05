using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Display
    {
        private DisplayImpl _impl;
        public Display(DisplayImpl impl)
        {
            _impl = impl;
        }

        public void Open()
        {
            _impl.RawOpen();
        }

        public void Print()
        {
            _impl.RawPrint();
        }

        public void Close()
        {
            _impl.RawClose();
        }

        // 書籍のサンプルではfinalを付けて、オーバーライド不可であることを明示している
        // C#ではfinalに相当するものにsealedがあるが、sealedは基底クラスのメソッドには使用できない
        // C#ではvirtualを付けなければ、overrideできないため、付けてなければsealedされているのと同じ
        // ただし、overrideではなく、newを使って継承先で同じメソッド名でメソッドを作ることは可能
        // サンプル：https://paiza.io/projects/-PCGwQwhserWVcVhmnWGhQ
        public void DoDisplay()
        {
            Open();
            Print();
            Close();
        }
    }
}
