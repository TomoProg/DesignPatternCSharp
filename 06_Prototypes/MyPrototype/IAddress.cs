using System;
namespace Prototype.Framework
{
	public interface IAddress
	{
		string Zipcode { get; }
		string Address1 { get; }  // 都道府県、市町村
		string Address2 { get; set; }  // 番地
		string Address3 { get; set; }  // マンション名
		void Print();
		IAddress CreateClone();
	}
}

