using System.Collections.Generic;

namespace DoDoHashCode
{
    internal class Library
    {
        public long BooksCount { get; internal set; }
        public long SignUpProcessTime { get; internal set; }
        public long BooksPerDay { get; internal set; }
        public List<Book> Books { get; internal set; }
    }
}