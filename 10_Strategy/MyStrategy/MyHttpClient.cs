using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyStrategy
{
    class MyHttpClient : IMyHttpClient
    {
        public string GetHTML(string url)
        {
            var c = new HttpClient();
            return c.GetStringAsync(url).Result;
        }
    }
}
