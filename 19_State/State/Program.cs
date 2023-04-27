using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new FeeBoard();

            for(int i = 0; i < 24; i++)
            {
                var dt = new DateTime(2023, 4, 26, i, 0, 0);
                Console.WriteLine($"時刻：{dt}");
                app.SetClock(dt);
                app.Show();
                Console.WriteLine("------------------");
            }

            Console.WriteLine("------------------");
            Console.WriteLine("土曜日テスト");
            Console.WriteLine("------------------");

            for (int i = 0; i < 24; i++)
            {
                var dt = new DateTime(2023, 4, 22, i, 0, 0);    // 土曜日
                Console.WriteLine($"時刻：{dt}");
                app.SetClock(dt);
                app.Show();
                Console.WriteLine("------------------");
            }
        }
    }

    // 料金を表示する掲示板
    // Context役
    public class FeeBoard
    {
        // TODO: 作られたときの時間によるため、決め打ちはできないけど、とりあえず0時スタートと仮定して決め打ち
        private State _state = new FeeBoardNightState();

        public void SetClock(DateTime dt)
        {
            _state.DoClock(this, dt);
        }

        public void Show()
        {
            var msg = _state.BuildMessage();
            Console.WriteLine(msg);
        }

        public void ChangeState(State state)
        {
            _state = state;
            Console.WriteLine($"{state}に切り替えます。");
        }
    }

    // State役
    public abstract class State
    {
        public abstract int? Price { get; }

        // どういう条件のときにどの状態になるのかをDictionaryで表現する。
        protected abstract Dictionary<Func<bool>, State> CreateStateChangeConditions(DateTime dt);

        public virtual void DoClock(FeeBoard context, DateTime dt)
        {
            foreach(var kv in CreateStateChangeConditions(dt))
            {
                // TODO: Dictionaryだと順不同になりそう・・・。
                if (kv.Key.Invoke())
                {
                    context.ChangeState(kv.Value);
                    break;
                }
            }
        }

        public virtual string BuildMessage()
        {
            return $"現在の料金は{Price}です。";
        }
    }

    // 9時から19時までが昼時間
    // ConcreateState役
    public class FeeBoardDayState : State
    {
        public override int? Price { get; } = 100;

        protected override Dictionary<Func<bool>, State> CreateStateChangeConditions(DateTime dt)
        {
            return new Dictionary<Func<bool>, State>()
            {
                // TODO:ここが神メソッド化してしまう。
                // 土曜日だったら土曜日用のクラスでデコレートしてくれれるようなビルダーがいればいいのか
                { () => 19 <= dt.Hour || dt.Hour < 5,  new FeeBoardNightState() }
            };
        }
    }

    // TODO: デコレータパターン
    // 土曜日の昼時間用のやつ
    // デコレータパターンじゃなくて、単純に継承しただけになった。
    // 継承して、Priceだけoverrideすればよくね？
    public class FeeBoardDayStateForSaturday : FeeBoardDayState
    {
        public override int? Price => base.Price * 2;
    }

    // 19時から5時までが夜時間
    // ConcreateState役
    public class FeeBoardNightState : State
    {
        public override int? Price { get; } = 200;

        protected override Dictionary<Func<bool>, State> CreateStateChangeConditions(DateTime dt)
        {
            return new Dictionary<Func<bool>, State>()
            {
                // 夜 -> 閉店
                // 5時 ～ 9時までは閉店
                { () => 5 <= dt.Hour && dt.Hour < 9,  new FeeBoardCloseState() }
            };
        }
    }

    // 5時から9時までが閉店時間
    // ConcreateState役
    public class FeeBoardCloseState : State
    {
        public override int? Price { get; } = null;

        protected override Dictionary<Func<bool>, State> CreateStateChangeConditions(DateTime dt)
        {
            return new Dictionary<Func<bool>, State>()
            {
                // 閉店 -> 昼
                // 9時から開店
                // 土曜日の場合は土曜日ようのやつを使う
                { () => 9 <= dt.Hour && dt.Hour < 19 && dt.DayOfWeek == DayOfWeek.Saturday,  new FeeBoardDayStateForSaturday() },
                { () => 9 <= dt.Hour && dt.Hour < 19,  new FeeBoardDayState() }
            };
        }

        public override string BuildMessage()
        {
            return $"現在は営業しておりません。";
        }
    }
}
