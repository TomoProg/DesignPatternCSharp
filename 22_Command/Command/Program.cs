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
                Console.WriteLine("c: 炊飯 m: 炊飯モード設定 r: 予約設定 p: プリセットから設定 -> ");
                var line = Console.ReadLine();
                var command = ParseLine(riceCooker, line);
                command.Execute();
            }
        }

        private static ICommand ParseLine(RiceCooker riceCooker, string line)
        {
            // TODO: このifなんとかしたい Chain Of Responsibility か
            switch (line.Trim())
            {
                case "c": return new CookCommand(riceCooker);
                case "m": return new SetCookModeCommand(riceCooker);
                case "r": return new ReserveCommand(riceCooker);
                case "p": return new PresetCommand(riceCooker);
            }
            throw new Exception($"その入力はサポートされていません。[{line}]");
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class CookCommand : ICommand
    {
        private RiceCooker _riceCooker;
        public CookCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }

        public void Execute()
        {
            _riceCooker.Cook();
            _riceCooker.Save();
        }
    }

    public class SetCookModeCommand : ICommand
    {
        private RiceCooker _riceCooker;
        public SetCookModeCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {
            _riceCooker.SetMode();
        }
    }

    public class ReserveCommand : ICommand
    {
        private RiceCooker _riceCooker;
        public ReserveCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {
            _riceCooker.Reserve();
        }
    }

    public class PresetCommand : ICommand
    {
        private RiceCooker _riceCooker;
        public PresetCommand(RiceCooker riceCooker)
        {
            _riceCooker = riceCooker;
        }
        public void Execute()
        {
            _riceCooker.Restore();
        }
    }

    //UIと機能の切り離し
    // コマンドのリストを貰えればいいんじゃないか？？？
    public class RiceCooker
    {
        enum CookMode
        {
            Normal = 0,     // 普通
            Quick,          // 早炊き
            Extreamity,     // 極み炊き（美味しいけどちょっと時間かかるやつ）
        }

        // こんなの作らなくても、RiceCooker自体を保存していければいけると思うんだけどなぁ・・・。
        private class Preset
        {
            public CookMode Mode { get; private set; }
            public DateTime? ReserveTime { get; private set; }
            public Preset(CookMode mode, DateTime? reserveTime)
            {
                Mode = mode;
                ReserveTime = reserveTime;
            }

            public override string ToString()
            {
                return $"炊飯モード: {Mode} 予約時刻: {ReserveTime}";
            }
        }

        private CookMode _mode = CookMode.Normal;
        private DateTime? _reserveTime = null;
        private List<Preset> _presets = new List<Preset>();

        // 炊飯する
        public void Cook()
        {
            // 炊飯する
            Console.WriteLine("炊飯を開始します");

            // 予約時間と炊飯モードから炊飯を開始する時刻を決める
            // 釜を温める
            // 圧力かける
            // などなどいろいろやる想定
            System.Threading.Thread.Sleep(3000);

            // 炊飯する
            Console.WriteLine("炊飯しました。");
        }

        // 炊飯モードを設定する
        public void SetMode()
        {
            Console.WriteLine("どのように炊きますか？");   // ここがUIになってしまっている

            // enumの扱いめっちゃめんどくさい・・・。
            foreach (CookMode m in Enum.GetValues(typeof(CookMode)))
            {
                Console.WriteLine($"[{(int)m}]: {m.ToString()}");
            }
            var num = Console.ReadLine();
            var enumValue = (CookMode)Enum.ToObject(typeof(CookMode), int.Parse(num));
            _mode = enumValue;

            Console.WriteLine($"{_mode}で炊けるように設定しました");
        }

        // 予約する
        public void Reserve()
        {
            Console.WriteLine("何時に炊けるようにしますか？");

            var t = Console.ReadLine();
            _reserveTime = DateTime.Parse(t);

            Console.WriteLine($"{_reserveTime}に炊けるように設定しました");
        }

        // 炊飯方法を保存する
        public void Save()
        {
            Console.WriteLine("プリセットに登録しますか？(y/n)");
            if(Console.ReadLine() == "y")
            {
                _presets.Add(new Preset(_mode, _reserveTime));
                Console.WriteLine($"登録しました。");
            }
        }

        // 保存した炊飯方法を復元する
        public void Restore()
        {
            if(_presets.Count < 1)
            {
                Console.WriteLine("プリセットがありません。");
                return;
            }

            Console.WriteLine("設定するプリセットを選択してください。");
            foreach(var p in _presets.Select((item, index) => new { item, index }))
            {
                Console.WriteLine($"[{p.index}] {p.item.ToString()}");
            }
            var num = Console.ReadLine();
            var selected = _presets[int.Parse(num)];

            _mode = selected.Mode;
            _reserveTime = selected.ReserveTime;

            Console.WriteLine("設定しました。");
        }
    }
}
