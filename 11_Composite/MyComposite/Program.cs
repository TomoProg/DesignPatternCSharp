using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var j = new JsonObject();
            var item1 = new Attribute("name", new StringObject("yamamoto"));
            var item2 = new Attribute("blood", new StringObject("A"));

            var otherInfo = new JsonObject();
            otherInfo.Add(new Attribute("hobby", new StringObject("tennis")));
            otherInfo.Add(new Attribute("sex", new StringObject("male")));
            var item3 = new Attribute("other", otherInfo);

            /*
            {
                name: "yamamoto",
                blood: "A",
                other: {
                  hobby: "tennis",
                  sex: "male",
                }
            }
            */
            j.Add(item1);
            j.Add(item2);
            j.Add(item3);

            Console.WriteLine(j.ToString());
        }
    }
}
