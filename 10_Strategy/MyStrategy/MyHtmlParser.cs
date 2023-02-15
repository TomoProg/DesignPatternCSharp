using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace MyStrategy
{
    public class MyHtmlParser
    {
        private IMyHttpClient _client;

        public MyHtmlParser(IMyHttpClient client)
        {
            _client = client;
        }

        public string GetTitle(string url)
        {
            // HtmlパーサーがWebアクセスまでするのはどやねんとも思うが、サンプルなのでとりあえずこれで・・・。
            var html = _client.GetHTML(url);
            var r = Regex.Match(html, "<title>(.*)</title>");
            return r.Groups[1].Value;
        }
    }
}
