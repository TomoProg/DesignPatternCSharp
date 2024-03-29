﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var textArea = new TextArea();
            var markdownViewArea = new MarkdownViewArea();
            textArea.AddObserver(markdownViewArea);

            while (true)
            {
                var k = Console.ReadKey(true).Key;
                if (k == ConsoleKey.Enter) break;
                Console.Clear();
                textArea.AddText(k);


                Console.WriteLine("------ TextArea -------");
                Console.WriteLine(textArea.Text);

                Console.WriteLine("------ MarkdownTextArea -------");
                Console.WriteLine(markdownViewArea.Text);
            }
        }
    }

    // Updateするときに、観察される側そのものを渡したいので、ジェネリクスにした。
    // INotifiableToObserverがGetTextみたいなメソッドを持ってればいいのか？
    // →これをしてしまうとSubjectが増えるたびにインターフェースが増える。
    //   ジェネリクスにしておけば増えることもなく共通で使える。
    interface IObserver<T> where T:class
    {
        void Update(T obj);
    }

    interface INotifableToObserver<T> where T : class
    {
        List<IObserver<T>> Observers { get; }
        void AddObserver(IObserver<T> observer);
        void NotifyObservers();
    }

    abstract class NotifyObject<T> : INotifableToObserver<T> where T : class
    {
        public List<IObserver<T>> Observers { get; } = new List<IObserver<T>>();

        public void AddObserver(IObserver<T> observer)
        {
            Observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var o in Observers)
            {
                // このクラスを継承した先のクラスを渡したいんだけどできない・・・？
                // (T)this と書いてキャストしてみたけどコンパイルエラーだった。
                // (T)((object)this) こんな感じで一回object型にキャストしてから、T型にキャストしたらいけた。
                o.Update((T)((object)this));
            }
        }
    }

    class TextArea : NotifyObject<TextArea>
    {
        public string Text { get; private set; }

        public void AddText(ConsoleKey key)
        {
            Text += key.ToString();
            NotifyObservers();

        }
    }

    class MarkdownViewArea : IObserver<TextArea>
    {
        public string Text { get; private set; }

        public void Update(TextArea obj)
        {
            // ここでマークダウンを解析して、画面に装飾後のテキストを表示する
            var converted = ConvertToMarkdownView(obj.Text);
            Text = converted;
        }

        private string ConvertToMarkdownView(string text)
        {
            return $@"{text}
markdown!!!";
        }
    }

}
