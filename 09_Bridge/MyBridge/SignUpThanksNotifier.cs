using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBridge
{
    public class SignUpThanksNotifier : Notifier
    {
        public SignUpThanksNotifier(IPost impl) : base(impl) { }

        public void Send()
        {
            var msg = "登録ありがとうございます。";
            base.Post(msg);
        }
    }
}
