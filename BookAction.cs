using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookReservation
    {
        private DateTime creationDate;
        private ReservationStatus status;
        private String memberId;
        private String ItemId;

        public static BookReservation FetchReservationDetails(String bookItemId)
        {

        }
    }

    public class BookLending
    {
        private String ItemId;
        private DateTime creationDate;
        private DateTime dueDate;
        private DateTime returnDate;
        private String memberId;
        private BookReservation bookReservation;
        private User user;

        public static bool LendBook(Book book, User member)
        {
            if (member.totalBooksCheckedOut > LibrarySystem.MAXBORROWBOOKNUM)
            {
                Console.WriteLine(member.person.name + "MAXBORROWBOOKNUM reached!");
                return false;
            }
            // check out if there are avaialbe book items for the book in the library
            foreach (Rack rack in LibrarySystem.GetInstance().Library.Racks.Values)
            {
                foreach (var bookItem in rack.bookItems)
                {
                    if (bookItem.book.isbn == book.isbn)
                    {
                        if (bookItem.status == BookStatus.AVAILABLE)
                        {
                            bookItem.dueDate = LibrarySystem.TimeNow.AddDays(LibrarySystem.MAX_BORROW_BOOK_PERIOD);
                            member.CheckoutBookItem(bookItem);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine(bookItem.book.title + " not available !");
                            return false;
                        }
                    }
                }
            }
            return false;
        }
        public static BookLending FetchLendingDetails(String bookItemId);
    }

    public class Fine
    {
        private DateTime creationDate;
        private double bookItemBarcode;
        private String memberId;

        public static void CollectFine(String memberId, long days);
    }
}
