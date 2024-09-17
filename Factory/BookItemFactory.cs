using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Factory
{
    public class BookItemFactory
    {
        // flyweight design pattern 
        private static Dictionary<Book, BookItem> singletons = new Dictionary<Book, BookItem>();
        public static BookItem? CreateBookItem(Book book) {
            if (singletons.ContainsKey(book)) return singletons[book];
            BookItem? bookItem;
            switch (book.bookFormat)
            {
                case BookFormat.MAGAZINE:
                    bookItem = new BookItem() { id = LibrarySystem.GenerateBookItemID(), status = BookStatus.AVAILABLE, placedAt = Library.GetInstance().Racks[0], book = book};
                    singletons.Add(book, bookItem);
                    break;
                case BookFormat.EBOOK:
                    bookItem = new BookItem() { id = LibrarySystem.GenerateBookItemID(), status = BookStatus.AVAILABLE, placedAt = Library.GetInstance().Racks[1], book = book};
                    break;
                default:
                    bookItem = null;
                    break;
            }

            return bookItem;
        }
    }
}
