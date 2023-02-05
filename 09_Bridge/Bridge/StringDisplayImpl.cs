using System;
using System.Text;

namespace Bridge
{
    public class StringDisplayImpl : DisplayImpl
    {
        private string _string;
        private int _width;

        public StringDisplayImpl(string s, string encName="Shift_JIS")
        {
            _string = s;
            var enc = Encoding.GetEncoding(encName);
            _width = enc.GetByteCount(s);
        }

        public override void RawOpen()
        {
            PrintLine();
        }

        public override void RawPrint()
        {
            Console.WriteLine($"|{_string}|");
        }

        public override void RawClose()
        {
            PrintLine();
        }

        private void PrintLine()
        {
            Console.Write("+");
            for(int i = 0; i < _width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }
    }
}