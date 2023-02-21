using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyStrategy
{
    class MyHttpClientCanDelay : MyHttpClient
    {
        public override string GetHTML(string url)
        {
            System.Threading.Thread.Sleep(1000);  // 1秒遅延
            return base.GetHTML(url);
        }

        public override string Post(string url, HttpContent content)
        {
            System.Threading.Thread.Sleep(1000);  // 1秒遅延
            return base.Post(url, content);
        }
    }
}
