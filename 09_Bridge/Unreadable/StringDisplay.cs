using System;
using System.Text;

namespace Unreadable
{
    public class StringDisplay : Display
    {
        protected string _string;
        protected int _width;

        public StringDisplay(string s, string encName="Shift_JIS")
        {
            _string = s;
            var enc = Encoding.GetEncoding(encName);
            _width = enc.GetByteCount(s);
        }

        public override void Open()
        {
            PrintLine();
        }

        public override void Print()
        {
            Console.WriteLine($"|{_string}|");
        }

        public override void Close()
        {
            PrintLine();
        }

        protected virtual string Corner => "+";

        private void PrintLine()
        {
            Console.Write(Corner);
            for(int i = 0; i < _width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine(Corner);
        }
    }
}