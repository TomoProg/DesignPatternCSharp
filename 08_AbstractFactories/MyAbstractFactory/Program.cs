using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAbstractFactory.Factory;
using MyAbstractFactory.XlsxFactory;

namespace MyAbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // ファイル名はコマンドライン引数で渡す想定
            var filename = "aaa.xlsx";
            //var filename = "bbb.csv";
            var factory = CreateUserFactory(filename);

            // ここはFactoryの部品を使ってインターフェースに対して処理する
            var parser = factory.createParser();
            var rows = parser.Parse(filename);
            foreach(var row in rows)
            {
                var converter = factory.createRowConverter();
                var user = converter.Convert(row);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Blood);
                //...
            }
        }

        // どのファクトリを作るか
        static UserFactory CreateUserFactory(string filename)
        {
            switch(filename.extention)
            {
                case "xlsx":
                    return new UserFactoryUsingExcel();
                case "csv":
                    return new UserFactoryUsingCsv();
                default:
                    throw new Exception();
            }
        }
    }
    }
}
