using System;
using System.Collections.Generic;
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

        public virtual void DoClock(FeeBoard context, DateTime dt)
        {
            // TODO: この処理、値が変わるところを取り出せれば、いい感じにテンプレートメソッドにできそう。
            //if (19 <= dt.Hour)
            //{
            //    context.ChangeState(new FeeBoardNightState());
            //}
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

        public override void DoClock(FeeBoard context, DateTime dt)
        {
            // 昼 -> 夜
            // 19時からは夜に変わる
            if(19 <= dt.Hour || dt.Hour < 5)
            {
                context.ChangeState(new FeeBoardNightState());
            }
        }
    }

    // TODO: デコレータパターン
    // 9時から19時までが昼時間
    // ConcreateState役
    //public class 土曜日用のFeeBoardDayState
    //{
    //    FeeBoardDayState state;
    //    public int? Price => state.Price * 2;
    //}

    // 19時から5時までが夜時間
    // ConcreateState役
    public class FeeBoardNightState : State
    {
        public override int? Price { get; } = 200;

        public override void DoClock(FeeBoard context, DateTime dt)
        {
            // 夜 -> 閉店
            // 5時 ～ 9時までは閉店
            if (5 <= dt.Hour && dt.Hour < 9)
            {
                context.ChangeState(new FeeBoardCloseState());
            }
        }
    }

    // 5時から9時までが閉店時間
    // ConcreateState役
    public class FeeBoardCloseState : State
    {
        public override int? Price { get; } = null;

        public override void DoClock(FeeBoard context, DateTime dt)
        {
            // 閉店 -> 昼
            // 9時から開店
            if (9 <= dt.Hour && dt.Hour < 19)
            {
                context.ChangeState(new FeeBoardDayState());
            }
        }

        public override string BuildMessage()
        {
            return $"現在は営業しておりません。";
        }
    }
}
