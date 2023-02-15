using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MyStrategy;

namespace MyStrategyTest
{
    class MyHttpClientDummy : IMyHttpClient
    {
        public string GetHTML(string url)
        {
            // 指定されたURLにはアクセスせず、固定のHTMLを返す
            var html = @"
<html>
  <head>
    <title>テストタイトル</title>
  </head>
  <body>
    <h1>テスト見出し1</h1>
  </body>
</html>
";
            return html;
        }
    }
}
