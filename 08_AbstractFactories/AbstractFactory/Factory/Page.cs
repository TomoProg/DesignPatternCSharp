using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AbstractFactory.Factory
{
    public abstract class Page
    {
        protected string _title;
        protected string _author;
        protected List<Item> _content = new List<Item>();

        public Page(string title, string author)
        {
            _title = title;
            _author = author;
        }

        public void Add(Item item)
        {
            _content.Add(item);
        }

        public void Output()
        {
            try
            {
                // Template Methodになっている
                string filename = $"{_title}.html";
                File.WriteAllText(filename, MakeHTML());
                Console.WriteLine($"{filename}を作成しました。");
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public abstract string MakeHTML();
    }
}
