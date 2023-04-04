using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // 正常パターン
            CreateUser(id: 1, name: "tomoprog", blood: "A");
            Console.WriteLine("=========================");

            // 名称不正のパターン
            CreateUser(id: 1, name: "", blood: "A");
            Console.WriteLine("=========================");

            // 血液型不正のパターン
            CreateUser(id: 1, name: "tomoprog", blood: "J");
            Console.WriteLine("=========================");


            UserValidator uv1 = new UserIdValidator();
            UserValidator uv2 = new UserNameValidator();
            UserValidator uv3 = new UserBloodValidator();
            uv1.SetNext(uv2).SetNext(uv3);
        }

        static void CreateUser(int id, string name, string blood)
        {
            try
            {
                var u = new User { Id = id, Name = name, Blood = blood };
                u.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }


    public class ValidatorBuilder
    {

    }

    // Client役
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blood { get; set; }

        public void Save()
        {
            // Validatorを呼び出す
            var v = CreateUserValidator();
            v.Validate(this);

            // 何かしらに保存する
            Console.WriteLine("Saved!");
        }

        private UserValidator CreateUserValidator()
        {
            UserValidator uv1 = new UserIdValidator();
            UserValidator uv2 = new UserNameValidator();
            UserValidator uv3 = new UserBloodValidator();
            uv1.SetNext(uv2).SetNext(uv3);
            return uv1;
        }
    }

    // Handler役
    public abstract class UserValidator
    {
        protected UserValidator _next;

        protected abstract void _Validate(User user);

        public void Validate(User user)
        {
            _Validate(user);
            if(_next != null)
            {
                _next.Validate(user);
            }
        }

        public UserValidator SetNext(UserValidator validator)
        {
            _next = validator;
            return _next;
        }
    }

    // ConcreateHandler役
    public class UserIdValidator : UserValidator
    {
        protected override void _Validate(User user)
        {
            // 特になし
        }
    }

    // ConcreateHandler役
    public class UserNameValidator : UserValidator
    {
        protected override void _Validate(User user)
        {
            if(string.IsNullOrWhiteSpace(user.Name))
            {
                throw new Exception("名前は必須です。");
            }
        }
    }

    // ConcreateHandler役
    public class UserBloodValidator : UserValidator
    {
        protected override void _Validate(User user)
        {
            var availableBloods = new Dictionary<string, bool>
            {
                { "A", true },
                { "B", true },
                { "O", true },
                { "AB", true },
            };

            if(!string.IsNullOrEmpty(user.Blood) && !availableBloods.TryGetValue(user.Blood, out bool tmp))
            {
                throw new Exception($"不正な血液型です。[{user.Blood}]");
            }
        }
    }

}
