using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                UserBase u =
                    new UsStockFeature(
                        new NewsLetterFeature(
                            new User("sato")
                        )
                    );

                Console.WriteLine(u.CalcFee());  // 3100円
                Console.WriteLine(u.GetName());
            }
            {
                UserBase u =
                    new NewsLetterFeature(
                        new User("tomoprog")
                    );

                Console.WriteLine(u.CalcFee());　// 100円
                Console.WriteLine(u.GetName());
            }
        }
    }

    // Component役
    public abstract class UserBase
    {
        protected string _name;
        public abstract int GetFee();
        public virtual string GetName()
        {
            return _name;
        }

        public virtual int CalcFee()
        {
            return GetFee();
        }
    }

    // ConcreteComponent役
    public class User : UserBase
    {
        public User(string name)
        {
            _name = name;
        }

        public override int GetFee()
        {
            return 0;
        }
    }

    // Decorator役
    public abstract class UserFeature : UserBase
    {
        protected UserBase _user;
        protected UserFeature(UserBase user)  // 抽象クラスでコンストラクタも定義可能
        {
            _user = user;
        }
        
        public override string GetName()
        {
            return _user.GetName();
        }

        public override int CalcFee()
        {
            return _user.GetFee() + GetFee();
        }

        // 抽象クラスだからUserBaseのメソッドを実装する必要はない
    }

    // ConcreateDecortor役
    public class NewsLetterFeature : UserFeature
    {
        public NewsLetterFeature(UserBase user) : base(user)
        {
        }

        public override int GetFee()
        {
            return 100;
        }

    }

    // ConcreateDecortor役
    public class UsStockFeature : UserFeature
    {
        public UsStockFeature(UserBase user) : base(user)
        {
        }

        public override int GetFee()
        {
            return 3000;
        }
    }
}
