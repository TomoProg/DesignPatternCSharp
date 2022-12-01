using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookShelf = new BookShelf(5);
            bookShelf.appendBook(new Book("book1"));
            bookShelf.appendBook(new Book("book2"));
            bookShelf.appendBook(new Book("book3"));
            bookShelf.appendBook(new Book("book4"));
            bookShelf.appendBook(new Book("book5"));
            bookShelf.appendBook(new Book("book6"));
            var it = bookShelf.iterator();

            while(it.hasNext())
            {
                var book = it.next() as Book;
                Console.WriteLine(book.GetName());
            }

        }
    }
}
