namespace Iterator
{
    internal class BookShelfIterator : Iterator
    {
        private BookShelf bookShelf;
        private int index = 0;

        public BookShelfIterator(BookShelf bookShelf)
        {
            this.bookShelf = bookShelf;
        }

        /// <summary>
        /// 次に返す本があるかどうか
        /// </summary>
        /// <returns></returns>
        public bool hasNext()
        {
            return index < this.bookShelf.getLength();
        }

        public object next()
        {
            var book = this.bookShelf.getBookAt(index);
            index++;
            return book;
        }
    }
}