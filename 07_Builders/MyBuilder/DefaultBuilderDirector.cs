using System;
namespace MyBuilder
{
	public class DefaultBuilderDirector<T>
	{
		private DefaultBuilder<T> _builder;
		public DefaultBuilderDirector(DefaultBuilder<T> builder)
		{
			_builder = builder;
		}

		public T Construct()
        {
			// ここがテンプレートメソッドになるイメージ
			return _builder.BuildDefault();
        }
	}
}

