namespace Iterator
{
    internal class Book
    {
        private string name;
        public Book(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }
    }
}