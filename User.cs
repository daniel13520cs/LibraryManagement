using LibraryManagement.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement
{
    // User is an abstract class
    public abstract class User
    {
        public int id { get; set; }
        protected string password;
        protected AccountStatus status;
        public Person person { get; set; }
        protected LibraryCard card;

        public User(int id, string password, AccountStatus status, Person person, LibraryCard card)
        {
            this.id = id;
            this.password = password;
            this.status = status;
            this.person = person;
            this.card = card;
        }

        public abstract void ResetPassword(string password);
    }

    public class Librarian : User
    {

        public Librarian(int id, string password, AccountStatus status, Person person, LibraryCard card) : base(id,password,status,person,card)
        {
        }


        public bool ReturnBook(BookItem bookItem, Member member)
        {
            BookItem? item = bookItem.placedAt.GetBookItem(bookItem);
            if (item.dueDate > LibrarySystem.TimeNow)
            {
                member.PayFine();
            }
            item.status = BookStatus.AVAILABLE;
            Queue<BookReservation>? reservations = BookReservation.FetchReservationDetails(bookItem.book);
            foreach (var reservation in reservations)
            {
                PostalNotification notification = new PostalNotification(0, DateTime.Now, "book item " + bookItem + " available", BookLending.FetchLendingDetails(bookItem.id), reservation);
                Notification.Notifications.Enqueue(notification);
            }
            return true;
        }

        public bool RenewBookItem(BookItem bookItem, Member member) {
            BookItem? item = bookItem.placedAt.GetBookItem(bookItem);
            item.dueDate = LibrarySystem.TimeNow.AddDays(LibrarySystem.MAX_BORROW_BOOK_PERIOD);
            return true;
        }

        public override void ResetPassword(string password) {
            this.password = password;
        }
        
    }

    public class Member : User
    {

        public Member(int id, string password, AccountStatus status, Person person, LibraryCard card) : base(id, password, status, person, card)
        {
        }

        private DateTime dateOfMembership;
        public int totalBooksCheckedOut { get; private set; }
        public List<BookItem> bookItems { get; private set; } = new List<BookItem>();   


        private void IncrementTotalBooksCheckedout() {
            this.totalBooksCheckedOut++;
        }
        public bool CheckoutBookItem(BookItem bookItem) {
            IncrementTotalBooksCheckedout();
            bookItems.Add(bookItem);
            return true;
        }
        private void CheckForFine(String bookItemBarcode) { }

        public void PayFine()
        {
            Console.WriteLine("member " + this.person.name + " paied fine");
        }
        public override void ResetPassword(string password) {
            this.password=password;
        }
        
    }
}
