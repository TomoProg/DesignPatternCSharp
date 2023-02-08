using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBridge
{
    // プレミアム会員登録した際の通知をまとめたクラス
    public class SignUpPremiumNotifier : SignUpNotifier
    {
        public SignUpPremiumNotifier(IPost impl) : base(impl) { }
        public new void Send()
        {
            // 登録完了メールを送信
            base.Send();

            // プレミアム会員の機能紹介メールを送信
            base.Post("プレミアム会員の機能紹介");
        }
    }
}
