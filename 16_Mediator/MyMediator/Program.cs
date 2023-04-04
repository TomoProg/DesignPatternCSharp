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
            var p1 = new ManualPlayer(m, "Sato");
            var p2 = new ManualPlayer(m, "Yamamoto");
            var p3 = new ManualPlayer(m, "Nagata");

            m.AddPlayer(p1);
            m.AddPlayer(p2);
            m.AddPlayer(p3);
            m.Run();
        }
    }

    // Mediator役がいない
    // Mediatorに必要なメソッドだけをinterfaceで定義するんだろうけど
    // 今回の例だと、GameMasterからinterfaceを分離したとしても、そのinterfaceから他になにか作るという状況が思い浮かばない...。
    // interfaceは仕様なので、なにか別のものを作るという状況がなければ作らないという想定が違うのか。

    // ConcrateMediator役
    public class GameMaster
    {
        private List<BasePlayer> playerList = new List<BasePlayer>();
        private int playerTurn = 0;

        public void AddPlayer(BasePlayer p)
        {
            playerList.Add(p);
        }

        public void Run()
        {
            Console.WriteLine($"■■■ ゲーム開始 ■■■");
            var p = playerList[0];
            p.DoAction();
        }

        public void PlayerChanged(string command)
        {
            if (command == "p")
            {
                // passコマンド
                // 何もせずに次の人のターンになる
                playerTurn = (playerTurn + 1) % playerList.Count;
                playerList[playerTurn].DoAction();
            }
            else if (command == "s")
            {
                // skipコマンド
                // 次の人をスキップして、その次の人のターンになる
                playerTurn = (playerTurn + 2) % playerList.Count;
                playerList[playerTurn].DoAction();
            }
            else
            {
                // 上記以外のコマンドの場合は無効なので、もう一度同じプレイヤーのターンになる
                playerList[playerTurn].DoAction();
            }
        }
    }

    // Colleague役
    public abstract class BasePlayer
    {
        private GameMaster _master;
        public string Name { get; private set; }

        public BasePlayer(GameMaster master, string name)
        {
            _master = master;
            Name = name;
        }

        public void DoAction()
        {
            Console.WriteLine($"--- {Name}のターンです ---");
            var command = Think();
            _master.PlayerChanged(command);
        }

        public virtual string Think()
        {
            throw new NotImplementedException();
        }
    }

    // ConcreateColleague役
    public class ManualPlayer : BasePlayer
    {
        public ManualPlayer(GameMaster master, string name) : base(master, name)
        {
        }

        public override string Think()
        {
            return Console.ReadLine();
        }
    }
}
