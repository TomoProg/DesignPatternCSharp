using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Display b4 = 
                new SideBorder(
                    new FullBorder(
                        new FullBorder(
                            new SideBorder(
                                new FullBorder(
                                    new StringDisplay("こんにちは")
                                ),
                                '*'
                            )
                        )
                    ),
                    '/'
                );
            b4.Show();
        }
    }

    public abstract class Display
    {
        public abstract int GetColumns();
        public abstract int GetRows();
        public abstract string GetRowText(int row);
        public void Show()
        {
            for(int i = 0; i < GetRows(); i++)
            {
                Console.WriteLine(GetRowText(i));
            }
        }
    }

    public class StringDisplay : Display
    {
        private string _s;
        public StringDisplay(string s)
        {
            _s = s;
        }

        public override int GetColumns()
        {
            return _s.Length;
        }

        public override int GetRows()
        {
            return 1;
        }

        public override string GetRowText(int row)
        {
            if(row == 0)
            {
                return _s;
            }
            else
            {
                return null;
            }
        }
    }

    public abstract class Border : Display
    {
        protected Display _display;
        protected Border(Display display)  // 抽象クラスでコンストラクタも定義可能
        {
            _display = display;
        }

        // 抽象クラスだからDisplayのメソッドを実装する必要はない
    }

    public class SideBorder : Border
    {
        private char _borderChar;
        public SideBorder(Display display, char ch) : base(display)
        {
            _borderChar = ch;
        }

        // これはDisplayの実装
        public override int GetColumns()
        {
            return 1 + _display.GetColumns() + 1;
        }

        // これはDisplayの実装
        public override int GetRows()
        {
            return _display.GetRows();
        }

        // これはDisplayの実装
        public override string GetRowText(int row)
        {
            return _borderChar + _display.GetRowText(row) + _borderChar;
        }
    }


    public class FullBorder : Border
    {
        public FullBorder(Display display) : base(display)
        {
        }

        // これはDisplayの実装
        public override int GetColumns()
        {
            return 1 + _display.GetColumns() + 1;
        }

        // これはDisplayの実装
        public override int GetRows()
        {
            return 1 + _display.GetRows() + 1;
        }

        // これはDisplayの実装
        public override string GetRowText(int row)
        {
            throw new NotImplementedException();
        }
    }
}
