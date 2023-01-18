using System;
using System.Collections.Generic;

namespace Prototype.Framework
{
	public class Manager
	{
		private Dictionary<string, Product> _showcase = new Dictionary<string, Product>();

		public void Register(string name, Product proto)
        {
			_showcase[name] = proto;
        }

		public Product Create(string protoname)
        {
			Product p = _showcase[protoname];
			return p.CreateClone();
        }
	}
}

