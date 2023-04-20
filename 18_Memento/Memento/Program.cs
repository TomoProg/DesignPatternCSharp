using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    //-----------------------------------
    // Caretaker役
    //-----------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            var textState = new TextState();
            var mementoList = new List<TextStateMemento>();

            // 数字じゃなくて、Showだったらs、Editだったらeとかにしておけば、順番とか気にする必要ない...
            var chain = new ShowAction(1, textState, mementoList);
            chain
                .SetNext(new EditAction(2, textState, mementoList))
                .SetNext(new SaveAction(3, textState, mementoList))
                .SetNext(new UndoAction(4, textState, mementoList))
                .SetNext(new RedoAction(5, textState, mementoList));

            Console.WriteLine("---- Text Editor App ----");
            while(true)
            {
                Console.WriteLine(chain.BuildMenu());
                var ans = Console.ReadLine();
                chain.Run(ans);
            }
        }
    }

    //-----------------------------------
    // Originator役
    //-----------------------------------
    public class TextState
    {
        public string Text { get; set; }
        public int FontSize { get; set; }   // 使ってない

        public TextStateMemento CreateMemento()
        {
            return new TextStateMemento(Text, FontSize);
        }

        public void RestoreMemento(TextStateMemento m)
        {
            Text = m.Text;
            FontSize = m.FontSize;
        }
    }

    //-----------------------------------
    // Memento役
    //-----------------------------------
    public class TextStateMemento
    {
        public string Text { get; private set; }
        public int FontSize { get; private set; }    // 使ってない

        // NOTE: Caretakerから作れてしまう
        // TextStateとTextStateMementoを別のプロジェクトに持っていけばCaretaker役からは見えない。
        internal TextStateMemento(string text, int fontSize)
        {
            Text = text;
            FontSize = fontSize;
        }
    }

    //-----------------------------------
    // Chain Of ResponsibilityのHandler役
    //-----------------------------------
    public abstract class BaseAction
    {
        protected int _no;
        protected TextState _textState;
        protected List<TextStateMemento> _mementoList;
        protected BaseAction _next;

        public BaseAction(int no, TextState textState, List<TextStateMemento> mementoList)
        {
            _no = no;
            _textState = textState;
            _mementoList = mementoList;
        }

        public BaseAction SetNext(BaseAction action)
        {
            _next = action;
            return _next;
        }

        public void Run(string input)
        {
            if(input != _no.ToString())
            {
                _next.Run(input);
                return;
            }
            _Run();
        }

        // TODO: suffixやら区切り文字やらを指定してあげれると柔軟。
        public string BuildMenu(string prefix="")
        {
            var result = prefix;
            result += (ToString() + " ");
            if (_next == null)
            {
                return result;
            }
            return _next.BuildMenu(result);
        }

        public override string ToString()
        {
            return $"{_no}: {Name}";
        }

        // サブクラスで実装してね
        abstract protected string Name { get; }
        abstract protected void _Run();
    }

    //-----------------------------------
    // 閲覧
    // Chain Of ResponsibilityのConcreateHandler役
    //-----------------------------------
    public class ShowAction : BaseAction
    {
        public ShowAction(int no, TextState textState, List<TextStateMemento> mementoList) : base(no, textState, mementoList)
        {
        }

        protected override string Name
        {
            get { return "閲覧"; }
        }

        protected override void _Run()
        {
            Console.WriteLine(_textState.Text);
        }
    }

    //-----------------------------------
    // 編集
    // Chain Of ResponsibilityのConcreateHandler役
    //-----------------------------------
    public class EditAction : BaseAction
    {
        public EditAction(int no, TextState textState, List<TextStateMemento> mementoList) : base(no, textState, mementoList)
        {
        }

        protected override string Name
        {
            get { return "編集"; }
        }

        protected override void _Run()
        {
            // TODO: 今の状態から編集したい
            // これだと常に新規作成みたいになる
            var l = Console.ReadLine();
            _textState.Text = l;
            Console.WriteLine("編集しました。");
        }
    }

    //-----------------------------------
    // 保存
    // Chain Of ResponsibilityのConcreateHandler役
    //-----------------------------------
    public class SaveAction : BaseAction
    {
        public SaveAction(int no, TextState textState, List<TextStateMemento> mementoList) : base(no, textState, mementoList)
        {
        }

        protected override string Name
        {
            get { return "保存"; }
        }

        protected override void _Run()
        {
            var m = _textState.CreateMemento();
            _mementoList.Add(m);
            Console.WriteLine("保存しました。");
        }
    }

    //-----------------------------------
    // 戻る
    // Chain Of ResponsibilityのConcreateHandler役
    //-----------------------------------
    public class UndoAction : BaseAction
    {
        public UndoAction(int no, TextState textState, List<TextStateMemento> mementoList) : base(no, textState, mementoList)
        {
        }

        protected override string Name
        {
            get { return "戻る"; }
        }

        protected override void _Run()
        {
            // TODO: 2つ以上戻る
            // これだと1つしか戻れない。2つ戻りたかったら、いまどのMementoを使っているのか
            // Mementoのリストの位置を持っておいて、戻すたびにその位置を変えればいけそう
            _textState.RestoreMemento(_mementoList.Last());
            Console.WriteLine("1つ前に戻しました");
        }
    }

    //-----------------------------------
    // 進む
    // Chain Of ResponsibilityのConcreateHandler役
    //-----------------------------------
    public class RedoAction : BaseAction
    {
        public RedoAction(int no, TextState textState, List<TextStateMemento> mementoList) : base(no, textState, mementoList)
        {
        }

        protected override string Name
        {
            get { return "進む"; }
        }

        protected override void _Run()
        {
            // TODO
        }
    }
}
