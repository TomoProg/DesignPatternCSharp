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
        private Executor _executor;

        public void Parse(Context context)
        {
            _name = context.CurrentToken();
            context.SkipToken(_name);
            var args = new List<string>();

            // 呼び出すメソッドに応じて引数を確認する
            // ここのif無くしたい
            // ExecutorがそれぞれFromContextみたいなメソッドを持っていれば、ExecuteFactoryの中でそれを呼べばいけそうか。
            if (_name == "Move")
            {
                var arg = context.CurrentToken();
                args.Add(arg);
                context.SkipToken(arg);

                arg = context.CurrentToken();
                args.Add(arg);
                context.SkipToken(arg);
            }

            _executor = ExecutorFactory.Create(_name, args);
        }

        public void Execute()
        {
            _executor.Execute();
        }
    }

    public class ExecutorFactory
    {
        public static Executor Create(string name, IEnumerable<string> args)
        {
            var className = $"{name}Executor";
            try
            {
                return Activator.CreateInstance(Type.GetType(className), args) as Executor;
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"Failed Instance className: {className}");
                throw;
            }
        }
    }

    public abstract class BaseExecutor : Executor
    {
        protected IEnumerable<string> _args;
        public BaseExecutor(IEnumerable<string> args)
        {
            _args = args;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class MoveExecutor : BaseExecutor
    {
        private readonly int _x;
        private readonly int _y;

        public MoveExecutor(IEnumerable<string> args) : base(args)
        {
            // バリデーション
            var argsArray = _args.ToArray();
            if (!int.TryParse(argsArray[0], out int _x))
            {
                new Exception($"Invalid first argument for Move method. [{argsArray[0]}]");
            }
            if (!int.TryParse(argsArray[1], out int _y))
            {
                new Exception($"Invalid second argument for Move method. [{argsArray[1]}]");
            }
        }

        public override void Execute()
        {
            // TODO: 実際に動かす処理
            System.Diagnostics.Debug.WriteLine($"Called MoveExecutor args[_x:{_x}, _y: {_y}]");
        }
    }

    public class RightClickExecutor : BaseExecutor
    {
        public RightClickExecutor(IEnumerable<string> args) : base(args)
        {
        }

        public override void Execute()
        {
            // TODO: 実際に動かす処理
            System.Diagnostics.Debug.WriteLine($"Called RightClickExecutor");
        }

    }

    public class LeftClickExecutor : BaseExecutor
    {
        public LeftClickExecutor(IEnumerable<string> args) : base(args)
        {
        }

        public override void Execute()
        {
            // TODO: 実際に動かす処理
            System.Diagnostics.Debug.WriteLine($"Called LeftClickExecutor");
        }
    }
}