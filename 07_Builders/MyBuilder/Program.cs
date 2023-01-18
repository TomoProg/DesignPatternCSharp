using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // 普通は会費1000円
            var m1 = GetBuildTarget(new DateTime(2022, 12, 31));
            var d1 = new DefaultBuilderDirector<UserModel>(m1);
            var u1 = d1.Construct();
            Console.WriteLine(u1.CreateTime);
            Console.WriteLine(u1.UpdateTime);
            Console.WriteLine(u1.MembershipFee);

            // こっちは会費500円
            var m2 = GetBuildTarget(new DateTime(2023, 1, 1));
            var d2 = new DefaultBuilderDirector<UserModel>(m2);
            var u2 = d2.Construct();
            Console.WriteLine(u2.CreateTime);
            Console.WriteLine(u2.UpdateTime);
            Console.WriteLine(u2.MembershipFee);
        }

        static DefaultBuilder<UserModel> GetBuildTarget(DateTime dt)
        {
            if(new DateTime(2023, 1, 1) <= dt && dt < new DateTime(2023, 2, 1))
            {
                return new SpecialUserModel();
            }
            return new UserModel();
        }
    }
}
