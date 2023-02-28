using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var j = new JsonObject();
        //    var item1 = new Attribute("name", new StringObject("yamamoto"));
        //    var item2 = new Attribute("blood", new StringObject("A"));

        //    var otherInfo = new JsonObject();
        //    otherInfo.Add(new Attribute("hobby", new StringObject("tennis")));
        //    otherInfo.Add(new Attribute("sex", new StringObject("male")));
        //    var item3 = new Attribute("other", otherInfo);

        //    /*
        //    {
        //        name: "yamamoto",
        //        blood: "A",
        //        other: {
        //          hobby: "tennis",
        //          sex: "male",
        //        }
        //    }
        //    */
        //    j.Add(item1);
        //    j.Add(item2);
        //    j.Add(item3);

        //    Console.WriteLine(j.ToString());
        //}


        static void Main(string[] args)
        {
            var u = new Dictionary<string, object>()
            {
                { "name", "yamamoto" },
                { "blood", "A" },
                { "height", 160 },
                { "other", new Dictionary<string, object>() {
                    { "hobby", new string[] { "tennis", "soccer" } },
                    { "sex", "male" }}
                }
            };

            //var s = new JsonSerializer(u);
            Console.WriteLine(JsonSerializer.Serialize(u));
        }
    }

    public class JsonSerializer
    {
        public static string Serialize(IReadOnlyDictionary<string, object> obj)
        {
            var result = new RootAttribute() { Key = null };
            Serialize2(result, obj);
            return result.ToJsonString();
        }

        private static Attribute2 Serialize2(RootAttribute result, IReadOnlyDictionary<string, object> obj)
        {
            foreach (var kv in obj)
            {
                var attr = AttributeCreator.Create(kv.Key, kv.Value);
                result.Add(attr);
            }

            return result;
        }

    }

    public abstract class Attribute2
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public abstract string ToJsonString();
    }

    public class AttributeCreator
    {
        public static Attribute2 Create(string k, object v)
        {
            var t = v.GetType();

            if(t == typeof(string))
            {
                return new StringAttribute() { Key = k, Value = v };
            }

            if(t == typeof(int))
            {
                return new NumberAttribute() { Key = k, Value = v };
            }

            if (t == typeof(Dictionary<string, object>))
            {
                var a = new RootAttribute() { Key = k };
                foreach (var kv in (Dictionary<string, object>)v)
                {
                    a.Add(Create(kv.Key, kv.Value));
                }
                return a;
            }

            throw new NotImplementedException();
        }
    }

    public class StringAttribute : Attribute2
    {
        public override string ToJsonString()
        {
            return $"{Key}: \"{Value}\"";
        }
    }

    public class NumberAttribute : Attribute2
    {
        public override string ToJsonString()
        {
            return $"{Key}: {Value}";
        }
    }

    public class RootAttribute : Attribute2
    {
        public RootAttribute()
        {
            Value = new List<Attribute2>();
        }

        public void Add(Attribute2 attr)
        {
            CastedValue().Add(attr);
        }

        public override string ToJsonString()
        {
            var result = string.IsNullOrWhiteSpace(Key) ? "{\n" : $"{Key}: {{\n";
            foreach(var attr in CastedValue())
            {
                result += $"{attr.ToJsonString()}\n";
            }
            result += "}\n";
            return result;
        }

        private List<Attribute2> CastedValue()
        {
            return (List<Attribute2>)Value;
        }
    }
}
