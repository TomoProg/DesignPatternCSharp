using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdapter
{
    public class SlackNotifier : INotify
    {
        public void Notify(string msg)
        {
            // Slackに通知する
            Console.WriteLine($"Slackに通知したよ [{msg}]");
        }
    }
}
