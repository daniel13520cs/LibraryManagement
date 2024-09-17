using System.Diagnostics.CodeAnalysis;

namespace LibraryManagement
{
    // User is an abstract class
    public abstract class Book
    {
        public string isbn { get; private set; }
        public string title { get; private set; }
        public BookFormat bookFormat { get; private set; }
        public Author author { get; private set; }

        public Book(string isbn, string title, BookFormat bookFormat, Author author)
        {
            this.isbn = isbn;
            this.title = title;
            this.bookFormat = bookFormat;
            this.author = author;
        }
    }

    public class Magazine : Book
    {
        public Magazine(string isbn, string title, Author author) : base(isbn, title, BookFormat.MAGAZINE, author) {

        }
    }
    public class EBOOK : Book
    {
        public EBOOK(string isbn, string title, Author author) : base(isbn, title, BookFormat.EBOOK, author)
        {
            

        }
    }

    public class BookItem
    {
        public int id;
        public DateTime borrowed;
        private DateTime _dueDate;
        public DateTime dueDate
        {
            get => _dueDate;
            set => _dueDate = value;
        }
        public BookStatus status;
        public Rack placedAt;
        public Book book;  // Aggregation: BookItem has a reference to a Book

        // Constructors, getters, and other existing methods...

        public bool Checkout(string memberId)
        {
            // Implementation for checkout logic
            // Update the status, set due date, etc.
            // Return true if checkout is successful, false otherwise
            return true;  // Placeholder, replace with actual logic
        }

        public void SetPlacedAt(Rack rack)
        {
            this.placedAt = rack;
            // Additional logic if needed
        }

        // Other methods...

        public Book GetBook()
        {
            return book;
        }
    }

    public class Rack
    {
        int id;
        public List<BookItem> bookItems { get; private set; } = new List<BookItem>();
        public void addBookItem(BookItem bookItem)
        {
            // definition
            bookItems.Add(bookItem);
        }
        public BookItem? GetBookItem(BookItem bookItem)
        {
            foreach (BookItem item in bookItems)
            {
                if (bookItem.id == item.id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
