using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Element> elements = new List<Element>();  // TODO: こいつをクラス化（ObjectStructure
            elements.Add(new User() { Id = 1, FirstName = "tomoki", LastName = "yamamoto" });
            elements.Add(new Busho() { Id = 1, Name = "総務" });
        }
    }

    public abstract class Visitor
    {
        public abstract void Visit(User user);
        public abstract void Visit(Busho busho);
    }

    //TODO: Visitor役 2つ作りたい
    public class CsvVisitor : Visitor
    {
        public override void Visit(User user)
        {
            Console.WriteLine($"{user.Id},{user.FirstName},{user.LastName}");
        }

        public override void Visit(Busho busho)
        {
            Console.WriteLine($"{busho.Id},{busho.Name}");
        }
    }

    public interface Element
    {
        void Accept(Visitor v);
    }

    public class Busho : Element
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Accept(Visitor v)
        {
            v.Visit(this);
        }
    }

    public class User : Element
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Accept(Visitor v)
        {
            v.Visit(this);
        }
    }
}
