namespace MyAbstractFactory.Factory
{
    public interface UserFactory
    {
        Parser createParser();
        RowConverter createRowConverter();
    }
}