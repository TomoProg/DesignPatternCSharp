namespace MyAbstractFactory.Factory
{
    public interface RowConverter
    {
        User Convert(object row);
    }
}