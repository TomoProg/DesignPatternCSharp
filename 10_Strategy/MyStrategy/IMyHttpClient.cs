using System.Net.Http;

namespace MyStrategy
{
    public interface IMyHttpClient
    {
        string GetHTML(string url);
        string Post(string url, HttpContent content);
    }
}