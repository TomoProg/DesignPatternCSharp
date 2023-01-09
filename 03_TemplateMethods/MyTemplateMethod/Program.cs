using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui1 = new UserInfo { Name = "tanaka", Blood = "A" };
            var ui2 = new UserInfo { Name = "sato", Blood = "B" };
            var ui3 = new UserInfo { Name = "suzuki", Blood = "O" };
            var userInfoList = new List<UserInfo>()
            {
                ui1, ui2, ui3,
            };
            //UserInfoPrinterTemplate template = new UserInfoCsvPrinter(userInfoList, "tomoprog");
            UserInfoPrinterTemplate template = new UserInfoMarkdownPrinter(userInfoList, "tomoprog");
            Console.WriteLine(template.Print());
        }
    }
}
