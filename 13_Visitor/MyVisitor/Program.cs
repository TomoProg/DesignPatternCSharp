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
        public abstract void Visit(Model m);
        public virtual void Visit(ElementList elementList)
        {
            foreach (var e in elementList._elementList)
            {
                e.Accept(this);
            }
        }
    }

    // ConcreateVisitor
    public class CsvVisitor : Visitor
    {
        private bool _firstFlag = true;
        public override void Visit(Model m)
        {
            var properties = m.GetProperties();
            if (_firstFlag)
            {
                Console.WriteLine(string.Join(",", properties.Keys));
                _firstFlag = false;
            }
            Console.WriteLine(string.Join(",", properties.Values));
        }

    }

    // ConcreateVisitor
    public class JsonVisitor : Visitor
    {
        public override void Visit(Model m)
        {
            Console.WriteLine("{");
            foreach(var prop in m.GetProperties())
            {
                Console.WriteLine($"  {prop.Key}: {prop.Value}");
            }
            Console.WriteLine("}");
        }
    }

    // Element
    public interface Element
    {
        void Accept(Visitor v);
    }

    // 
    public abstract class Model : Element
    {
        public abstract Dictionary<string, string> GetProperties();
        public void Accept(Visitor v)
        {
            v.Visit(this);
        }
    }

    // ConcreateElement
    public class Busho : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override Dictionary<string, string> GetProperties()
        {
            return new Dictionary<string, string> {
                { "id", Id.ToString() },
                { "name", Name.ToString() }
            };
        }
    }

    // ConcreateElement
    public class User : Model
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override Dictionary<string, string> GetProperties()
        {
            return new Dictionary<string, string> {
                { "id", Id.ToString() },
                { "first_name", FirstName.ToString() },
                { "last_name", LastName.ToString() },
            };
        }
    }

    // ObjectStructure
    public class ElementList
    {
        public List<Element> _elementList;
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
            // ElementListの中ではループしない
            v.Visit(this);
        }
    }
}
