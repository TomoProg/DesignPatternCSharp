using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                throw new Exception("実行するファイルを指定してください。");
            }
            var filepath = args[0];
            foreach(var line in System.IO.File.ReadLines(filepath))
            {
                Node node = new ProgramNode();
                node.Parse(new Context(line));
            }

            // 構文解析と処理実行は分けるか？
            // 分けないならこんなイメージか
            //   node.Execute();
            //
            // 分けるならこんなイメージか
            //   var executor = new Executor(node)
            //   executor.Run();
        }
    }
}
