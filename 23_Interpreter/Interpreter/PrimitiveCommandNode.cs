using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class PrimitiveCommandNode : Node
    {
        private string _name;

        public void Parse(Context context)
        {
            _name = context.CurrentToken();
            context.SkipToken(_name);
            if(_name == "Move")
            {
                // FIXME
            }
            else if(_name == "RightClick")
            {
                // FIXME
            }
            else if (_name == "LeftClick")
            {
                // FIXME
            }
            else
            {
                throw new Exception($"{_name} is undefined");
            }
        }
    }
}