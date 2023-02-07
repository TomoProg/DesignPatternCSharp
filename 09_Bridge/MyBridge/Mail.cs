using System;
using System.Text;

namespace MyBridge
{
    public class Mail : IPost
    {
        public string Email { get; }
        public Mail(string email)
        {
            Email = email;
        }

        public void Post(string text)
        {
            // メール送信
            Console.WriteLine("--- MailNotifier ---");
            Console.WriteLine($"Send to [{Email}]");
            Console.WriteLine(text);
        }
    }
}