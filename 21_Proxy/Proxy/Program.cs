using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //{
            //    Console.WriteLine("****************************************");
            //    Console.WriteLine("認証不要のAPIを使うパターン");
            //    Console.WriteLine("****************************************");
            //    RunUsecase(new BlogApi());
            //}
            //{
            //    Console.WriteLine("****************************************");
            //    Console.WriteLine("認証が必要なAPIを使うパターン");
            //    Console.WriteLine("****************************************");
            //    var authObj = new PasswordAuthentication("tomoprog", "p_tomoprog");
            //    RunUsecase(new SecureBlogApi(authObj));
            //}
            //{
            //    Console.WriteLine("****************************************");
            //    Console.WriteLine("パスワード間違いパターン");
            //    Console.WriteLine("****************************************");
            //    var authObj = new PasswordAuthentication("tomoprog", "p_xxx");
            //    RunUsecase(new SecureBlogApi(authObj));
            //}
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("早いパターン");
                Console.WriteLine("****************************************");
                var authObj = new PasswordAuthentication("tomoprog", "p_tomoprog");
                RunUsecase_MultiCreate(new SecureBlogApi(authObj));

                Console.WriteLine("****************************************");
                Console.WriteLine("遅いパターン");
                Console.WriteLine("****************************************");
                RunUsecase_MultiCreate(new BlogApi());
            }
        }

        //static void RunUsecase(IBlogApi api)
        //{
        //    var a1 = new Article()
        //    {
        //        Id = 1,
        //        Title = "タイトル1",
        //        Contents = "内容1"
        //    };

        //    // 記事の作成
        //    Console.WriteLine("---- 記事作成 ----");
        //    api.Create(a1);
        //    Console.WriteLine($"作成しました。");

        //    // 記事の件数確認
        //    Console.WriteLine("---- 記事の件数確認 ----");
        //    Console.WriteLine($"記事の件数: {api.GetArticles().Count}");

        //    // 記事の内容表示
        //    Console.WriteLine("---- 作成した記事の確認 ----");
        //    var article = api.GetArticles().First();
        //    Console.WriteLine(article.Inspect());

        //    // 記事を削除
        //    Console.WriteLine("---- 作成した記事を削除 ----");
        //    api.DeleteById(article.Id);
        //    Console.WriteLine($"削除しました。");

        //    // 記事の件数確認
        //    Console.WriteLine("---- 記事の件数確認 ----");
        //    Console.WriteLine($"記事の件数: {api.GetArticles().Count}");
        //}

        static void RunUsecase_MultiCreate(IBlogApi api)
        {
            var sw = new Stopwatch();
            sw.Start();

            var a1 = new Article() { Id = 1, Title = "タイトル1", Contents = "内容1" };
            var a2 = new Article() { Id = 2, Title = "タイトル2", Contents = "内容2" };
            var a3 = new Article() { Id = 3, Title = "タイトル3", Contents = "内容3" };

            // 記事の作成
            Console.WriteLine("---- 記事作成 ----");
            api.Create(a1);
            api.Create(a2);
            api.Create(a3);
            Console.WriteLine($"作成しました。");

            // 記事の件数確認
            Console.WriteLine("---- 記事の件数確認 ----");
            Console.WriteLine($"記事の件数: {api.GetArticles().Count}");

            // 記事の内容表示
            var articles = api.GetArticles();
            foreach (var article in articles)
            {
                Console.WriteLine("---- 作成した記事の確認 ----");
                Console.WriteLine(article.Inspect());
            }

            // 記事を削除
            Console.WriteLine("---- 作成した記事を削除 ----");
            api.DeleteById(articles.First().Id);
            Console.WriteLine($"削除しました。");

            // 記事の件数確認
            Console.WriteLine("---- 記事の件数確認 ----");
            Console.WriteLine($"記事の件数: {api.GetArticles().Count}");

            sw.Stop();
            Console.WriteLine($"経過時間: {sw.Elapsed}");
        }
    }

    // 認証機能外だし
    public interface IAuthenticatable
    {
        void Authenticate();
    }

    class PasswordAuthentication : IAuthenticatable
    {
        private readonly string _user;
        private readonly string _password;
        private readonly Dictionary<string, string> _authorizedUsers;

        public PasswordAuthentication(string user, string password)
        {
            _user = user;
            _password = password;
            _authorizedUsers = LoadAuthorizedUsers();
        }

        public void Authenticate()
        {
            var e = new Exception("認証エラー"); // ちゃんと認証エラー用のException用意したい
            if (!_authorizedUsers.ContainsKey(_user))
            {
                // 存在しないユーザの場合はエラー
                throw e;
            }
            if (_authorizedUsers[_user] != _password)
            {
                // パスワードが違う場合エラー
                throw e;
            }
        }

        private Dictionary<string, string> LoadAuthorizedUsers()
        {
            return new Dictionary<string, string>()
            {
                { "tomoprog",  "p_tomoprog" },
                { "saito",  "p_saito" },
                { "tanaka",  "p_tanaka" },
            };
        }

    }

    //
    // Subject役
    //
    public interface IBlogApi
    {
        List<Article> GetArticles();
        void Create(Article article);
        void DeleteById(int id);
        void CreateMulti(IEnumerable<Article> articles); // 追加
    }

    //
    // Proxy役
    // 宿題: これだとDecoratorみたいなイメージ。あくまでProxyとRealObjectは同じ
    // 認証機能を外出ししてみる
    // 外だししてみた。ただ、外だししただけだと結局機能追加しただけになる。
    // CreateしたときのやつをためておいてGetArticlesするときに全部
    //
    public class SecureBlogApi : IBlogApi
    {
        private BlogApi _api;
        private readonly IAuthenticatable _authObj;
        private List<Article> _pool;

        public SecureBlogApi(IAuthenticatable authObj)
        {
            _authObj = authObj;
            _pool = new List<Article>();
        }

        public List<Article> GetArticles()
        {
            return Realize().GetArticles();
        }

        public void Create(Article article)
        {
            // ここではAPI呼び出しせずに貯めておく
            _authObj.Authenticate();
            _pool.Add(article);
        }

        public void DeleteById(int id)
        {
            _authObj.Authenticate();
            Realize().DeleteById(id);
        }

        public void CreateMulti(IEnumerable<Article> articles)
        {
            // ここではAPI呼び出しせずに貯めておく
            _pool.AddRange(articles);
        }

        private BlogApi Realize()
        {
            if(_api == null)
            {
                _api = new BlogApi();
            }

            // Realizeするタイミングで貯めておいたものを一気に書き込む
            // ここでCreateするのに若干違和感があるけどすべてRealizeを呼ぶと考えると
            // ここに処理を書いておけば、全部のメソッドにこの処理を書く必要はない
            if (_pool.Count > 0)
            {
                _api.CreateMulti(_pool);
                _pool = new List<Article>();
            }
            return _api;
        }
    }

    //
    // RealObject役
    // BlogApiとか言いながら、DB役もしてる
    //
    public class BlogApi : IBlogApi
    {
        private Dictionary<int, Article> _pool; // IDとArticleのハッシュ
                                                // ホントはファイルとかに書きたいけど、Dictionaryで持ったほうが実装が手っ取り早いのでこうした

        public BlogApi()
        {
            _pool = new Dictionary<int, Article>();
        }

        public List<Article> GetArticles()
        {
            return _pool.Values.ToList();
        }

        public void Create(Article article)
        {
            System.Threading.Thread.Sleep(1000);  // 重たい処理
            if (_pool.ContainsKey(article.Id))
            {
                throw new Exception($"すでに指定されたIDの記事は存在しているため新規作成できません。 ID[{article.Id}]");
            }
            _pool[article.Id] = article;
        }

        public void DeleteById(int id)
        {
            _pool.Remove(id);
        }

        public void CreateMulti(IEnumerable<Article> articles)
        {
            System.Threading.Thread.Sleep(1000);  // 重たい処理

            // ただ、一気にかけば時間はそんなにかからない
            foreach (var article in articles)
            {
                if (_pool.ContainsKey(article.Id))
                {
                    throw new Exception($"すでに指定されたIDの記事は存在しているため新規作成できません。 ID[{article.Id}]");
                }
                _pool[article.Id] = article;
            }
        }
    }

    // その他
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }

        public string Inspect()
        {
            return $@"Id: {Id}
Title: {Title}
Contents: {Contents}";
        }
    }
}
