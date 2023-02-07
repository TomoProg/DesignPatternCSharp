using System;
using System.Text;

namespace MyBridge
{
    public class Slack : IPost
    {
        public string ChannelName { get; }

        public Slack(string channelName)
        {
            ChannelName = channelName;
        }

        public void Post(string text)
        {
            // Slackへの投稿
            Console.WriteLine("--- SlackNotifier ---");
            Console.WriteLine($"Send to [{ChannelName}]");
            Console.WriteLine(text);
        }
    }
}