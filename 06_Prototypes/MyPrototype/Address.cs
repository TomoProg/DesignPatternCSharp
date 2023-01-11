using System;
using Prototype.Framework;

namespace Prototype
{
	public class Address : IAddress
	{
        public string Zipcode { get; }
        public string Address1 { get; }  // 都道府県、市町村
        public string Address2 { get; set; }  // 番地
        public string Address3 { get; set; }  // マンション名

        public Address(string zipcode)
		{
            Zipcode = zipcode;
            // 郵便番号から住所を特定するためになんか処理を呼ぶ
            // この処理がもし重たかったり、API制限があったりするとクローンできないと辛い。
            // var address = ZipcodeConverter.Convert(zipcode);
            Address1 = "〇〇県〇〇市〇〇";
        }

        public void Print()
        {
            Console.WriteLine(Zipcode);
            Console.WriteLine($"{Address1}{Address2} {Address3}");
        }

        IAddress CreateClone()
        {
            throw new NotImplementedException();
        }
    }
}

