using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBridge
{
    // プレミアム会員登録した際の通知をまとめたクラス
    public class SignUpPremiumNotifier : Notifier
    {
        public SignUpPremiumNotifier(IPost impl) : base(impl) { }

        public void Send()
        {
            // 登録完了メールを送信
            var a = new SignUpThanksNotifier(base._impl);
            a.Send();

            // プレミアム会員の機能紹介メールを送信
            base.Post("プレミアム会員の機能紹介");
        }
    }
}
