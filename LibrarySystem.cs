using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class LibrarySystem
    {
        public Library Library { get; set; }
        public static DateTime TimeNow { get; set; } = DateTime.Now;
        private static int BookItemId { get; set; } = 0;
        public const int MAXBORROWBOOKNUM = 1;
        public const int MAX_BORROW_BOOK_PERIOD = 15;
        private static LibrarySystem Instance = null;
        private LibrarySystem() {
            Library = Library.GetInstance();
        }
        public static LibrarySystem GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LibrarySystem();
                BookItemId = 0;
            }
            return Instance;
        }
        public static int GenerateBookItemID()
        {
            return BookItemId++;
        }

        public static void AddBook(BookItem bookItem)
        {
            bookItem.placedAt.addBookItem(bookItem);
        }
    }
}
