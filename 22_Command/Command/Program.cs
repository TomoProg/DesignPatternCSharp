using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var riceCooker = new RiceCooker();

            while (true)
            {
                Console.WriteLine("コマンドを入力してください。");
                Console.WriteLine("c: 炊飯 p: プリセット設定 i: 状態確認 -> ");  // 炊飯器ができることはそもそも何なのか。状態確認はデバッグようなので
                var line = Console.ReadLine();
                var command = ParseLine(riceCooker, line);
                command.Execute();
            }
        }

        private static Command ParseLine(RiceCooker riceCooker, string line)
        {
            // TODO: lineに応じて、Commandを作る
            return new CookCommand(riceCooker);
        }
    }

    public interface Command
    {
        void Execute();
    }

    public class CookCommand : Command
    {
        private RiceCooker _riceCooker;
        public CookCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }

        public void Execute()
        {
            // プリセットが設定されているか確認
            if(_riceCooker.Preset is null)
            {
                // 即炊飯
                Console.WriteLine("炊飯しました。");
            }

            // コマンドになってて逆にややこしいことになってる。
            // これらはコマンドではなく、炊飯器にそのまま設定してあげたほうがシンプル
            // 炊飯モードの設定
            new SetModeCommand(_riceCooker).Execute();

            // 予約設定
            new PresetCommand(_riceCooker).Execute();

            // 炊飯する
            Console.WriteLine("炊飯しました。");

            // プリセット登録する？
            if (_riceCooker.Preset != null)
            {
            }
        }
    }

    public class SetModeCommand : Command
    {
        private RiceCooker _riceCooker;
        public SetModeCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {

        }
    }

    public class ReserveCommand : Command
    {
        private RiceCooker _riceCooker;
        public ReserveCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {

        }
    }

    public class PresetCommand : Command
    {
        private RiceCooker _riceCooker;
        public PresetCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {

        }
    }

    public class InfoCommand : Command
    {
        private RiceCooker _riceCooker;
        public InfoCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {

        }
    }

    public class RiceCooker
    {
        enum Mode
        {
            Normal = 0,     // 普通
            Quick,          // 早炊き
            Extreamity,     // 極み炊き（美味しいけどちょっと時間かかるやつ）
        }

        private Mode _mode = Mode.Normal;
        private Dictionary<int, List<Command>> _preset = new Dictionary<int, List<Command>>();

        public RiceCooker()
        {
        }
    }
}
