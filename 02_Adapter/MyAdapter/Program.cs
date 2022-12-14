using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //INotify notifier = new SlackNotifier();
            INotify notifier = new MattermostNotifierAdapter(new MattermostNotifier());
            notifier.Notify("test");
        }
    }
}
