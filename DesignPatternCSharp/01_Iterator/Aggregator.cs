using System;

namespace _01_Iterator
{
    public interface Aggregator<T>
    {
        Iterable<T> GetIterator();

        // 男性だけを数え上げる
        Iterable<T> GetMaleIterator();

        // 条件を指定することで、その条件にあったものだけを数え上げるイテレータを返してくれる
        //Iterable<T> GetIterator(Func<T, bool> func);
    }
}
