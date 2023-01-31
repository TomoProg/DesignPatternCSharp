using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFactory;

namespace MyAbstractFactoryUsingDll
{
    class Program
    {
        static void Main(string[] args)
        {
            // ファイル名およびdll名はコマンドライン引数で渡す想定
            var filename = "aaa.xlsx";
            var dllname = "UserFactoryUsingExcel.dll";
            //var filename = "bbb.csv";
            var factory = CreateUserFactory(dllname);

            // ここはFactoryの部品を使ってインターフェースに対して処理する
            var parser = factory.createParser();
            var rows = parser.Parse(filename);
            foreach (var row in rows)
            {
                var converter = factory.createRowConverter();
                var user = converter.Convert(row);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Blood);
                //...
            }
        }

        // どのファクトリを作るか
        // UserFactoryインターフェースが抽象クラスなら、このメソッドをUserFactoryに書けた...
        static UserFactory.UserFactory CreateUserFactory(string dllname)
        {
            // 指定されたdllからそのdll名と同じ名前のクラスを探す
            // 参考：https://rksoftware.hatenablog.com/entry/2020/04/16/025357
            var assembly = System.Reflection.Assembly.LoadFrom(dllname);
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t => t.Name ==  Path.GetFileNameWithoutExtension(dllname))
                .FirstOrDefault();

            if(type == null)
            {
                throw new Exception("not found factory...");
            }

            return (UserFactory.UserFactory)Activator.CreateInstance(type);
        }
    }
}
