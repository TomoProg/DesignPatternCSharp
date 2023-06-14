using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public interface Node : Executor
    {
        void Parse(Context context);
    }

    public interface Executor
    {
        void Execute();
    }
}