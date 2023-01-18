using System;
namespace Prototype.Framework
{
	public interface Product
	{
		void Use(string s);
		Product CreateClone();
	}
}

