using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                SignUpThanksNotifier d1 = new SignUpThanksNotifier(new Slack("general"));
                d1.Send();
                Console.WriteLine();

                SignUpPremiumNotifier d2 = new SignUpPremiumNotifier(new Slack("general"));
                d2.Send();
                Console.WriteLine();
            }
            {
                SignUpThanksNotifier d1 = new SignUpThanksNotifier(new Mail("sample@sample.com"));
                d1.Send();
                Console.WriteLine();

                SignUpPremiumNotifier d2 = new SignUpPremiumNotifier(new Mail("sample@sample.com"));
                d2.Send();
                Console.WriteLine();
            }
        }
    }
}
