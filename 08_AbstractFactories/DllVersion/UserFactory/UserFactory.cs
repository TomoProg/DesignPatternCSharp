namespace UserFactory
{
    public interface UserFactory
    {
        Parser createParser();
        RowConverter createRowConverter();
    }
}