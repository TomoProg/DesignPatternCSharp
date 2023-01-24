using AbstractFactory.Factory;

namespace AbstractFactory.ListFactory
{
    public class ListLink : Link
    {
        public ListLink(string caption, string url) : base(caption, url)
        {
        }

        public override string MakeHTML()
        {
            return $"ListLink {_caption}\n";
        }
    }
}