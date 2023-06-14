using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class CommandListNode : Node
    {
        private List<Node> _list = new List<Node>();

        public void Parse(Context context)
        {
            while (true)
            {
                if (context.CurrentToken() == null)
                {
                    throw new Exception("Missing 'end'");
                }

                if(context.CurrentToken() == "end")
                {
                    context.SkipToken("end");
                    break;
                }

                Node commandNode = new CommandNode();
                commandNode.Parse(context);
                _list.Add(commandNode);
            }
        }

        public void Execute()
        {
            _list.ForEach(n => n.Execute());
        }
    }
}