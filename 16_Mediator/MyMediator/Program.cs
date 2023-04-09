using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new GameMaster();
            m.Run();
        }
    }

    // Mediator役
    // GameMasterからMediatorとして必要なものだけを分離
    // Colleague役はこれだけ知っていればいい。
    public interface GameMasterMediator
    {
        void CreatePlayer();
        void PlayerChanged(string command);
    }

    // ConcrateMediator役
    public class GameMaster : GameMasterMediator
    {
        private List<BasePlayer> _playerList = new List<BasePlayer>();
        private int _playerTurn = 0;

        public void Run()
        {
            // プレイヤーの作成
            CreatePlayer();

            Console.WriteLine($"■■■ ゲーム開始 ■■■");
            var p = _playerList[0];
            p.DoAction();
            PlayerChanged()
        }

        // ここが同僚役（Colleague）を作成するところ
        // 今後、このGameMasterを継承してプレイヤーの作成のやり方を変える
        // 実際に名前を入力させたり、なんらかのシュミレーション用でランダムにプレイヤー選んだりとか
        public virtual void CreatePlayer()
        {
            _playerList.Add(new ManualPlayer(this, "Sato"));
            _playerList.Add(new ManualPlayer(this, "Yamamoto"));
            _playerList.Add(new ManualPlayer(this, "Nagata"));
        }

        public void PlayerChanged(string command)
        {
            if (command == "p")
            {
                // passコマンド
                // 何もせずに次の人のターンになる
                _playerTurn = (_playerTurn + 1) % _playerList.Count;
                _playerList[_playerTurn].DoAction();
            }
            else if (command == "s")
            {
                // skipコマンド
                // 次の人をスキップして、その次の人のターンになる
                _playerTurn = (_playerTurn + 2) % _playerList.Count;
                _playerList[_playerTurn].DoAction();
            }
            else if (command == "d2")
            {
                // Draw2コマンド
                // 次の人のカードを2枚増やす
                _playerTurn = (_playerTurn + 1) % _playerList.Count;
                _playerList[_playerTurn].CardNum += 2;
                _playerList[_playerTurn].DoAction();
            }
            else
            {
                // 上記以外のコマンドの場合は無効なので、もう一度同じプレイヤーのターンになる
                _playerList[_playerTurn].DoAction();
            }
        }
    }

    // Colleague役
    public abstract class BasePlayer
    {
        private GameMasterMediator _mediator;
        public string Name { get; private set; }
        public int CardNum { get; set; } = 5;

        public BasePlayer(GameMasterMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
        }

        public void DoAction()
        {
            // テンプレートメソッド
            Console.WriteLine($"--- {Name}のターンです ---");
            ShowState();
            var command = Think();

            // 考えたこと
            // Playerが変わったというかターンを変えてと命令しているイメージ。
            // Playerのなにかしらの属性が変わったことによるイベントではないので違和感がある。
            _mediator.PlayerChanged(command);
        }

        protected virtual string Think()
        {
            throw new NotImplementedException();
        }

        protected void ShowState()
        {
            Console.WriteLine($"CardNum: {CardNum}");
        }

    }

    // ConcreateColleague役
    public class ManualPlayer : BasePlayer
    {
        public ManualPlayer(GameMasterMediator mediator, string name) : base(mediator, name)
        {
        }

        protected override string Think()
        {
            return Console.ReadLine();
        }
    }
}
