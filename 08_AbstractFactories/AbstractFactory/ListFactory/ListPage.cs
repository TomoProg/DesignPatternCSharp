using AbstractFactory.Factory;
using System.Text;
using System.Linq;

namespace AbstractFactory.ListFactory
{
    class ListPage : Page
    {
        public ListPage(string title, string author) : base(title, author)
        {
        }

        public override string MakeHTML()
        {
            var sb = new StringBuilder();

            sb.Append($"Start --- ListPage {_title} ---\n");
            foreach (var item in _content)
            {
                sb.Append($"{item.MakeHTML()}");
            }
            sb.Append($"End --- ListPage {_title} ---\n");

            // format
            return Format(sb.ToString());
            //return sb.ToString();
        }

        private string Format(string html)
        {
            var ss = html.Split('\n');
            var indent = 0;
            var spaceWidth = 2;
            var indentedStrings = ss.Select(s =>
            {
                if (s.StartsWith("End") && indent > 0)
                {
                    indent -= 1;
                }
                var space = new string(' ', spaceWidth * indent);
                var tmp = s.Insert(0, space);
                if (s.StartsWith("Start"))
                {
                    indent += 1;
                }
                return tmp;
            });
            return string.Join("\n", indentedStrings);
        }
    }
}