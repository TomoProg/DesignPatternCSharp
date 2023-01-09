using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplateMethod
{
    internal abstract class UserInfoPrinterTemplate
    {
        public abstract string PrintTitle();
        public abstract string PrintUserInfo();
        public abstract string PrintOutputUserName();

        public string Print()
        {
            var contents = new string[]
            {
                PrintTitle(),
                PrintUserInfo(),
                PrintOutputUserName(),
            };
            return string.Join("\n", contents);
        }
    }
}
