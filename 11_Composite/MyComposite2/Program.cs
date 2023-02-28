using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite2
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new Dictionary<string, object>()
            {
                { "name", "yamamoto" },
                { "blood", "A" },
                { "height", 160 },
                { "other", new Dictionary<string, object>() {
                    //{ "hobby", new string[] { "tennis", "soccer" } }, //TODO
                    { "sex", "male" }}
                }
            };

            Console.WriteLine(JsonSerializer.Serialize(u));
        }
    }

    public class JsonSerializer
    {
        public static string Serialize(IReadOnlyDictionary<string, object> obj)
        {
            var result = new RootAttribute() { Key = null };
            foreach (var kv in obj)
            {
                var attr = AttributeCreator.Create(kv.Key, kv.Value);
                result.Add(attr);
            }
            return result.ToJsonString();
        }

        private class AttributeCreator
        {
            public static Attribute Create(string k, object v)
            {
                var t = v.GetType();

                if (t == typeof(string))
                {
                    return new StringAttribute() { Key = k, Value = v };
                }

                if (t == typeof(int))
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

        private abstract class Attribute
        {
            public string Key { get; set; }
            public object Value { get; set; }

            public abstract string ToJsonString();
        }

        private class StringAttribute : Attribute
        {
            public override string ToJsonString()
            {
                return $"{Key}: \"{Value}\"";
            }
        }

        private class NumberAttribute : Attribute
        {
            public override string ToJsonString()
            {
                return $"{Key}: {Value}";
            }
        }

        private class RootAttribute : Attribute
        {
            public RootAttribute()
            {
                Value = new List<Attribute>();
            }

            public void Add(Attribute attr)
            {
                CastedValue().Add(attr);
            }

            public override string ToJsonString()
            {
                var result = string.IsNullOrWhiteSpace(Key) ? "{\n" : $"{Key}: {{\n";
                foreach (var attr in CastedValue())
                {
                    result += $"{attr.ToJsonString()}\n";
                }
                result += "}\n";
                return result;
            }

            private List<Attribute> CastedValue()
            {
                return (List<Attribute>)Value;
            }
        }
    }

}
