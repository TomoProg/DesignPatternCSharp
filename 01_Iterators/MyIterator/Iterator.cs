namespace MyIterator
{
    public interface Iterator<T>
    {
        bool HasNext();
        T Next();
    }
}