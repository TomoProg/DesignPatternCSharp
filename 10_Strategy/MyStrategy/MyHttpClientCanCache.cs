using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyStrategy
{
    class MyHttpClientCanCache : MyHttpClient
    {
        private string _cache;
        public override string GetHTML(string url)
        {
            if (_cache != null) return _cache;
            _cache = base.GetHTML(url);
            return _cache;
        }

        private string _cachePost;
        public override string Post(string url, HttpContent content)
        {
            if (_cachePost != null) return _cachePost;
            _cachePost = base.Post(url, content);
            return _cachePost;
        }
    }
}
