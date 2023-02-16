using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyStrategy
{
    class MyHttpClientFast : IMyHttpClient
    {
        public string GetHTML(string url)
        {
            // TODO: もっと高速なHttpClientを使う
            Console.WriteLine("MyHttpCilentFast");
            var c = new HttpClient();
            return c.GetStringAsync(url).Result;
        }
    }
}
