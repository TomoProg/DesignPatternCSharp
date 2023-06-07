using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class CommandNode : Node
    {
        private Node _node;

        public void Parse(Context context)
        {
            if(context.CurrentToken() == "repeat")
            {
                _node = new RepeatCommandNode();
            }
            else
            {
                _node = new PrimitiveCommandNode();
            }
            _node.Parse(context);
        }
    }
}