using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class RepeatCommandNode : Node
    {
        private int _number;
        private Node _commandListNode;

        public void Parse(Context context)
        {
            context.SkipToken("repeat");
            _number = context.CurrentNumber();
            context.NextToken();
            _commandListNode = new CommandListNode();
            _commandListNode.Parse(context);
        }

        public void Execute()
        {
            for(int i = 0; i < _number; i++)
            {
                _commandListNode.Execute();
            }
        }
    }
}