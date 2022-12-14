using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdapter
{
    public class MattermostNotifierAdapter : INotify
    {
        MattermostNotifier _mattermostNotifier;
        public MattermostNotifierAdapter(MattermostNotifier mattermostNotifier)
        {
            _mattermostNotifier = mattermostNotifier;
        }

        public void Notify(string msg)
        {
            _mattermostNotifier.SendMessage(msg);
        }
    }
}
