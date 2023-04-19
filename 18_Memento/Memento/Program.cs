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

            Console.WriteLine("---- Text Editor App ----");
            while(true)
            {
                // TODO: Chain Of Responsibilityで書き直せないか？
                Console.WriteLine("1: 閲覧 2: 編集 3: 保存 4: 戻る 5: 進む ----"); 
                var ans = Console.ReadLine();
                if (ans == "1")
                {
                    Console.WriteLine(textState.Text);
                }
                else if (ans == "2")
                {
                    // TODO: 今の状態から編集したい
                    // これだと常に新規作成みたいになる
                    var l = Console.ReadLine();
                    textState.Text = l;
                    Console.WriteLine("編集しました。");
                }
                else if(ans == "3")
                {
                    var m = textState.CreateMemento();
                    mementoList.Add(m);
                    Console.WriteLine("保存しました。");
                }
                else if (ans == "4")
                {
                    // TODO: 2つ以上戻る
                    // これだと1つしか戻れない。2つ戻りたかったら、いまどのMementoを使っているのか
                    // Mementoのリストの位置を持っておいて、戻すたびにその位置を変えればいけそう
                    textState.RestoreMemento(mementoList.Last());  
                    Console.WriteLine("1つ前に戻しました");
                }
                else if (ans == "5")
                {
                    // TODO
                }
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
}
