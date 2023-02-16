using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyStrategy
{
    class MyHttpClientSlow : IMyHttpClient
    {
        public string GetHTML(string url)
        {
            Console.WriteLine("MyHttpClientSlow");
            System.Threading.Thread.Sleep(1000);
            var c = new HttpClient();
            return c.GetStringAsync(url).Result;
        }
    }
}
