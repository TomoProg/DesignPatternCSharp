using System;

namespace _01_Iterator
{
    public interface Iterable<T>
    {
        bool HasNext();
        T Next();
    }
}
