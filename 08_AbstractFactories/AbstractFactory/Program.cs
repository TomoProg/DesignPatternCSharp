using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Factory;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //if(args.Length != 1)
            //{
            //    Console.WriteLine("Args Error...");
            //    return;
            //}

            //var factory = Factory.Factory.GetFactory(args[0]);

            // test
            var factoryName = "AbstractFactory.ListFactory.ListFactory";
            var factory = Factory.Factory.GetFactory(factoryName);

            var asahiLink = factory.CreateLink("朝日新聞", "http://www.asahi.com/");
            var yomiuriLink = factory.CreateLink("読売新聞", "http://www.yomiuri.co.jp/");
            var newsTray = factory.CreateTray("新聞");
            newsTray.Add(asahiLink);
            newsTray.Add(yomiuriLink);

            var usYahooLink = factory.CreateLink("Yahoo!", "http://www.yahoo.com/");
            var jpYahooLink = factory.CreateLink("Yahoo! Japan", "http://www.yahoo.co.jp/");
            var yahooTray = factory.CreateTray("Yahoo!");
            yahooTray.Add(usYahooLink);
            yahooTray.Add(jpYahooLink);

            var exciteLink = factory.CreateLink("Excite", "http://www.excite.com/");
            var googleLink = factory.CreateLink("Google", "http://www.google.com/");
            var searchTray = factory.CreateTray("サーチエンジン");
            searchTray.Add(yahooTray);
            searchTray.Add(exciteLink);
            searchTray.Add(googleLink);

            var page = factory.CreatePage("LinkPage", "tomoprog");
            page.Add(newsTray);
            page.Add(searchTray);
            page.Output();
        }
    }
}
