using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdapter
{
    public class MattermostNotifier
    {
        public void SendMessage(string msg)
        {
            // Mattermostにメッセージを送信する
            Console.WriteLine($"Mattermostに送信したよ [{msg}]");
        }
    }
}
