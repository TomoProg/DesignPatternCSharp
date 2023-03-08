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
            var elements = new ElementList();
            elements.Add(new User() { Id = 1, FirstName = "tomoki", LastName = "yamamoto" });
            elements.Add(new Busho() { Id = 1, Name = "総務" });
            elements.Accept(new CsvVisitor());
            elements.Accept(new JsonVisitor());
        }
    }

    // Visitor
    public abstract class Visitor
    {
        public abstract void Visit(User user);
        public abstract void Visit(Busho busho);
    }

    // ConcreateVisitor
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

    // ConcreateVisitor
    public class JsonVisitor : Visitor
    {
        public override void Visit(User user)
        {
            Console.WriteLine($@"{{
  id: {user.Id},
  first_name: {user.FirstName},
  last_name: {user.LastName}
}}");
        }

        public override void Visit(Busho busho)
        {
            Console.WriteLine($@"{{
  id: {busho.Id},
  name: {busho.Name}
}}");
        }
    }

    // Element
    public interface Element
    {
        void Accept(Visitor v);
    }

    // ConcreateElement
    public class Busho : Element
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Accept(Visitor v)
        {
            v.Visit(this);
        }
    }

    // ConcreateElement
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

    // ObjectStructure
    public class ElementList
    {
        private List<Element> _elementList;
        public ElementList()
        {
            _elementList = new List<Element>();
        }

        public void Add(Element e)
        {
            _elementList.Add(e);
        }

        public void Accept(Visitor v)
        {
            foreach (var e in _elementList)
            {
                e.Accept(v);
            }
        }
    }
}
