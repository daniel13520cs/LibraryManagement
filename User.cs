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
        protected int id;
        protected string password;
        protected AccountStatus status;
        public Person person;
        protected LibraryCard card;

        public abstract void ResetPassword(string password);
    }

    public class Librarian : User
    {
        public bool AddBookItem(BookItem bookItem) {
            Console.WriteLine("Librarian" + this.person.name + "added book " + bookItem.book.title);
            bookItem.placedAt.addBookItem(bookItem);
            return true;
        }

        public bool ReturnBook(BookItem bookItem, Member member)
        {
            BookItem? item = bookItem.placedAt.GetBookItem(bookItem);
            if (item.dueDate > LibrarySystem.TimeNow)
            {
                member.PayFine();
            }
            item.status = BookStatus.AVAILABLE;
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
        private DateTime dateOfMembership;
        public int totalBooksCheckedOut { get; private set; }
        public List<BookItem> bookItems { get; private set; } = new List<BookItem>();   

        public bool ReserveBookItem(BookItem bookItem) {
            
        }
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
