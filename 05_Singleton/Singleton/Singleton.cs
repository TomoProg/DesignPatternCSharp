using System;
namespace Singleton
{
	public class Singleton
	{
		private static Singleton singleton = new Singleton();
		public Singleton()
		{
			Console.WriteLine("create instance.");
		}

		public static Singleton GetInstance()
        {
			return singleton;
        }
	}
}

