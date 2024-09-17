using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookReservation
    {
        private static Dictionary<Book, Queue<BookReservation>> reservations = new Dictionary<Book, Queue<BookReservation>>();

        private DateTime creationDate;
        private ReservationStatus status;
        public int memberId;

        public BookReservation(DateTime creationDate, ReservationStatus status, int memberId) {
            this.creationDate = creationDate;
            this.status = status;
            this.memberId = memberId;
        }

        public static Queue<BookReservation>? FetchReservationDetails(Book book)
        {
            if (!reservations.ContainsKey(book))
            {
                return null;
            }
            return reservations[book];
        }
        public static void ReserveBookItem(Book book, int memberID)
        {
            if (!reservations.ContainsKey(book))
            {
                reservations.Add(book, new Queue<BookReservation>());
            }
            BookReservation res = new BookReservation(LibrarySystem.TimeNow, ReservationStatus.WAITING, memberID);
            reservations[book].Enqueue(res);
        }
    }

    public class BookLending
    {
        private static Dictionary<int, BookLending> lendings = new Dictionary<int, BookLending>();

        private int ItemId;
        private DateTime creationDate;
        private DateTime dueDate;
        private DateTime returnDate;
        private int memberId;
        private BookReservation bookReservation;
        private User user;

        public static BookItem? LendBook(Book book, Member member)
        {
            if (member.totalBooksCheckedOut > LibrarySystem.MAXBORROWBOOKNUM)
            {
                Console.WriteLine(member.person.name + "MAXBORROWBOOKNUM reached!");
                return null;
            }
            // check out if there are avaialbe book items for the book in the library
            var library = LibrarySystem.GetInstance().Library;
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
                            return bookItem;
                        }
                        else
                        {
                            Console.WriteLine(bookItem.book.title + " not available !");
                            return null;
                        }
                    }
                }
            }
            return null;
        }
        public static BookLending FetchLendingDetails(int bookItemId)
        {
            // Retrieve lending details for the specified book item ID
            if (lendings.ContainsKey(bookItemId))
            {
                return lendings[bookItemId];
            }
            else
            {
                Console.WriteLine("No lending details found for item ID: " + bookItemId);
                return null;
            }
        }
    }

    public class Fine
    {
        private DateTime creationDate;
        private double bookItemBarcode;
        private String memberId;

        public static void CollectFine(String memberId, long days) { }
    }
}
