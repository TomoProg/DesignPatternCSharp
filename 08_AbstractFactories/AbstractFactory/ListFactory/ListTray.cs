using System.Text;
using AbstractFactory.Factory;

namespace AbstractFactory.ListFactory
{
    class ListTray : Tray
    {
        public ListTray(string caption) : base(caption)
        {
        }

        public override string MakeHTML()
        {
            var sb = new StringBuilder();

            sb.Append($"Start --- ListTray {_caption} ---\n");
            foreach (var item in _tray)
            {
                sb.Append($"{item.MakeHTML()}");
            }
            sb.Append($"End --- ListTray {_caption} ---\n");

            return sb.ToString();
        }
    }
}