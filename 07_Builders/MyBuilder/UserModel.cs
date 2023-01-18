using System;
namespace MyBuilder
{
	public class UserModel : DefaultBuilder<UserModel>
	{
		public DateTime CreateTime { get; set; }
		public DateTime UpdateTime { get; set; }
		public int MembershipFee { get; set; }

        public virtual UserModel BuildDefault()
        {
			var dt = DateTime.Now;
			var m = new UserModel();
			m.CreateTime = dt;
			m.UpdateTime = dt;
			m.MembershipFee = 1000;
			return m;
        }
    }
}

