using System;
namespace MyBuilder
{
	public class SpecialUserModel : UserModel
	{
        public override UserModel BuildDefault()
        {
			var m = base.BuildDefault();
			m.MembershipFee = 500;  // 特別に500円にする
			return m;
        }
    }
}

