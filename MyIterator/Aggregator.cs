namespace MyIterator
{
    internal interface Aggregator<T>
    {
        Iterator<T> CreateIterator();
    }
}