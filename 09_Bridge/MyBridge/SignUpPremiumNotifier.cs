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
        private SignUpThanksNotifier _thanks;
        public SignUpPremiumNotifier(IPost impl) : base(impl)
        {
            _thanks = new SignUpThanksNotifier(impl);
        }

        public void Send()
        {
            // 登録完了メールを送信
            _thanks.Send();

            // プレミアム会員の機能紹介メールを送信
            base.Post("プレミアム会員の機能紹介");
        }
    }
}
