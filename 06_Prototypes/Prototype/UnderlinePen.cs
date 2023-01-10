using System;
using Prototype.Framework;

namespace Prototype
{
    public class UnderlinePen : Product
    {
        private char _ulchar;

        public UnderlinePen(char ulchar)
        {
            _ulchar = ulchar;
        }

        public void Use(string s)
        {
            Console.WriteLine($"\"{s}\"");
            Console.Write(" ");
            int length = System.Text.Encoding.UTF8.GetBytes(s).Length;
            for (int i = 0; i < length; i++)
            {
                Console.Write(_ulchar);
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
            catch (Exception e) // 書籍ではCloneNotSupportedExceptionだが、C#で対応するやつがどれか探すの面倒なので、とりあえずExceptionで受ける
            {
                Console.WriteLine(e.StackTrace);
            }
            return p;
        }
    }
}

