using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyStrategy
{
    class MyHttpClient
    {
        public virtual string GetHTML(string url)
        {
            var c = new HttpClient();
            return c.GetStringAsync(url).Result;
        }

        public virtual string Post(string url, HttpContent content)
        {
            var c = new HttpClient();

            // 合ってるかわからん。
            return c.PostAsync(url, content).Result
                .Content.ReadAsStringAsync().Result;
        }
    }
}
