using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyBackup
{
    class Program
    {
        static void Main2(string[] args)
        {
            //{
            //    Console.WriteLine("****************************************");
            //    Console.WriteLine("認証不要のAPIを使うパターン");
            //    Console.WriteLine("****************************************");
            //    RunUsecase(new BlogApi());
            //}
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("認証が必要なAPIを使うパターン");
                Console.WriteLine("****************************************");
                RunUsecase(new SecureBlogApi("tomoprog", "p_tomoprog"));
            }
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("パスワード間違いパターン");
                Console.WriteLine("****************************************");
                RunUsecase(new SecureBlogApi("tomoprog", "p_xxx"));
            }
        }

        static void RunUsecase(IBlogApi api)
        {
            var a1 = new Article()
            {
                Id = 1,
                Title = "タイトル1",
                Contents = "内容1"
            };

            // 記事の作成
            Console.WriteLine("---- 記事作成 ----");
            api.Create(a1);
            Console.WriteLine($"作成しました。");

            // 記事の件数確認
            Console.WriteLine("---- 記事の件数確認 ----");
            Console.WriteLine($"記事の件数: {api.GetArticles().Count}");

            // 記事の内容表示
            Console.WriteLine("---- 作成した記事の確認 ----");
            var article = api.GetArticles().First();
            Console.WriteLine(article.Inspect());

            // 記事を削除
            Console.WriteLine("---- 作成した記事を削除 ----");
            api.DeleteById(article.Id);
            Console.WriteLine($"削除しました。");

            // 記事の件数確認
            Console.WriteLine("---- 記事の件数確認 ----");
            Console.WriteLine($"記事の件数: {api.GetArticles().Count}");
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
    }

    //
    // Proxy役
    // 宿題: これだとDecoratorみたいなイメージ。あくまでProxyとRealObjectは同じ
    // 認証機能を外出ししてみる
    //
    public class SecureBlogApi : IBlogApi
    {
        private readonly BlogApi _api;
        private readonly string _user;
        private readonly string _password;
        private readonly Dictionary<string, string> _authorizedUsers;

        public SecureBlogApi(string user, string password)
        {
            _api = new BlogApi();
            _user = user;
            _password = password;
            _authorizedUsers = LoadAuthorizedUsers();
        }

        public List<Article> GetArticles()
        {
            return _api.GetArticles();
        }

        public void Create(Article article)
        {
            Authenticate();
            _api.Create(article);
        }

        public void DeleteById(int id)
        {
            Authenticate();
            _api.DeleteById(id);
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

        private void Authenticate()
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
