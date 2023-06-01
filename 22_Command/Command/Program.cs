using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiceCookerApi;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var riceCooker = new RiceCooker();
            var commands = new List<ICommand>();

            while (true)
            {
                Console.WriteLine("コマンドを入力してください。");
                Console.WriteLine("c: 炊飯 m: 炊飯モード設定 r: 予約設定 p: プリセットから設定 -> ");
                var line = Console.ReadLine();
                //var command = ParseLine(riceCooker, line);
                //command.Execute();

                switch (line.Trim())
                {
                    case "c": Cook(); break;
                    case "m": SetCookMode(); break;
                    case "r": Reserve(); break;
                }
            }
        }

        private static ICommand ParseLine(RiceCooker riceCooker, string line)
        {
            // TODO: このifなんとかしたい Chain Of Responsibility か
            switch (line.Trim())
            {
                //case "c": return new CookCommand(riceCooker);
                //case "m": return new SetCookModeCommand(riceCooker);
                //case "r": return new ReserveCommand(riceCooker);
                //case "p": return new PresetCommand(riceCooker);
            }
            throw new Exception($"その入力はサポートされていません。[{line}]");
        }

        private static void Cook()
        {
            // 炊飯する
            Console.WriteLine("炊飯を開始します");

            // 予約時間と炊飯モードから炊飯を開始する時刻を決める
            // 釜を温める
            // 圧力かける
            // などなどいろいろやる想定
            RiceCookerA.Cook();
            System.Threading.Thread.Sleep(3000);

            // 炊飯する
            Console.WriteLine("炊飯しました。");
        }

        private static void SetCookMode()
        {
            Console.WriteLine("どのように炊きますか？");   // ここがUIになってしまっている

            // enumの扱いめっちゃめんどくさい・・・。
            foreach (RiceCooker.CookMode m in Enum.GetValues(typeof(RiceCooker.CookMode)))
            {
                Console.WriteLine($"[{(int)m}]: {m.ToString()}");
            }

            var num = Console.ReadLine();
            var enumValue = (RiceCooker.CookMode)Enum.ToObject(typeof(RiceCooker.CookMode), int.Parse(num));
            RiceCookerA.SetCookMode(enumValue);
            //new SetCookModeCommand(enumValue);

            Console.WriteLine($"{enumValue}で炊けるように設定しました");
        }

        private static void Reserve()
        {
            Console.WriteLine("何時に炊けるようにしますか？");

            var t = Console.ReadLine();
            var reserveTime = DateTime.Parse(t);
            RiceCookerA.Reserve(reserveTime);
            //new ReserveCommand(_reserveTime);

            Console.WriteLine($"{reserveTime}に炊けるように設定しました");
        }

    }
}
