using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 宿題: CompanyInfoに詰め替える処理を移動したバージョン
namespace Flyweight2
{
    // Client役
    class Program
    {
        static void Main2(string[] args)
        {
            while(true)
            {
                Console.WriteLine("--- 上場企業調査アプリ ---");
                Console.Write("証券コードを入力してください ---> ");
                var code = Console.ReadLine();
                var ci = CompanyInfoFactory.GetInstance().Create(code);

                // 結果を表示する
                Console.WriteLine();
                Console.WriteLine("--- 調査結果 ---");
                Console.WriteLine($"証券コード: {ci.Code}");
                Console.WriteLine($"企業名: {ci.Name}");
                Console.WriteLine($"株価: {ci.StockPrice}");
                Console.WriteLine($"売上高: {ci.Sales}");
                Console.WriteLine();
            }
        }
    }

    // FlyweightFactory役
    // こいつの責務はFlyweight役を作ること
    // というより作ったFlyweight役をキャッシュしておく
    public class CompanyInfoFactory
    {
        private Dictionary<string, CompanyInfo> _pool = new Dictionary<string, CompanyInfo>();
        private static readonly CompanyInfoFactory _singleton = new CompanyInfoFactory();
        private CompanyInfoFactory()
        {
        }

        public static CompanyInfoFactory GetInstance()
        {
            return _singleton;
        }

        public CompanyInfo Create(string code)
        {
            if(!_pool.ContainsKey(code))
            {
                // 処理をCompanyInfoクラスに移動した
                var ci = CompanyInfo.CreateFromExternalData(code);
                _pool[code] = ci;
            }
            return _pool[code];
        }
    }

    // Flyweight役
    // 企業の情報を表現したクラス
    public class CompanyInfo
    {
        // 証券コード
        public string Code { get; set; }
        // 企業名
        public string Name { get; set; }
        // 株価
        public int StockPrice { get; set; }
        // 売上高
        public int Sales { get; set; }

        // ここに移動させた
        // こうすることで、他のクラスからでも使えるようになった。
        public static CompanyInfo CreateFromExternalData(string code)
        {
            // 企業の情報をどこかから取得する
            var response = YahooFinanceApi.Call(code);

            // Apiの結果をアプリで使える形に変換
            return new CompanyInfo()
            {
                Code = code,
                Name = response.Name,
                StockPrice = response.StockPrice,
                Sales = response.Sales

            };
        }
    }

    // その他
    // 企業の情報をYahooFinanceから取得する
    public class YahooFinanceApi
    {
        public static Response Call(string code)
        {
            var r = new Random();
            return new Response()
            {
                Name = $"企業{code}",
                StockPrice = r.Next(100, 500),
                Sales = r.Next(100000, 200000),
            };
        }

        public class Response
        {
            // 企業名
            public string Name { get; set; }
            // 株価
            public int StockPrice { get; set; }
            // 売上高
            public int Sales { get; set; }
        }
    }

}
