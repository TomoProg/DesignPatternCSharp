using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplateMethod
{
    internal class UserInfoCsvPrinter : UserInfoPrinterTemplate
    {
        IEnumerable<UserInfo> _userInfos;
        string _outputUserName;

        public UserInfoCsvPrinter(IEnumerable<UserInfo> userInfos, string outputUserName)
        {
            _userInfos = userInfos;
            _outputUserName = outputUserName;
        }

        public override string PrintOutputUserName()
        {
            return $"出力者,{_outputUserName}";
            throw new NotImplementedException();
        }

        public override string PrintTitle()
        {
            return "< ユーザ情報 >";
        }

        public override string PrintUserInfo()
        {
            var strings = new List<string>();
            strings.Add("ユーザ名,血液型");
            foreach(var userInfo in _userInfos)
            {
                strings.Add($"{userInfo.Name},{userInfo.Blood}");
            }
            return string.Join("\n", strings);
        }
    }
}
