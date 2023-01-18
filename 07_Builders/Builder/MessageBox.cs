using System;
using Prototype.Framework;

namespace Prototype
{
	public class MessageBox : Product, ICloneable
	{
        private char _decochar;

		public MessageBox(char decochar)
		{
            _decochar = decochar;
		}

        public void Use(string s)
        {
            int length = System.Text.Encoding.UTF8.GetBytes(s).Length;
            for(int i = 0; i < length + 4; i++)
            {
                Console.Write(_decochar);
            }
            Console.WriteLine();
            Console.WriteLine($"{_decochar} {s} {_decochar}");
            for (int i = 0; i < length + 4; i++)
            {
                Console.Write(_decochar);
            }
            Console.WriteLine();
        }

        public Product CreateClone()
        {
            Product p = null;
            try
            {
                p = (Product)MemberwiseClone();
            }
            catch(Exception e) // 書籍ではCloneNotSupportedExceptionだが、C#で対応するやつがどれか探すの面倒なので、とりあえずExceptionで受ける
            {
                Console.WriteLine(e.StackTrace);
            }
            return p;
        }
    }
}

