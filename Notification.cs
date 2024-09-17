namespace LibraryManagement
{
    // User is an abstract class
    public abstract class Notification
    {
        public static Dictionary<Book, Notification> Notifications { get; set; } = new();

        protected int notificationId;
        protected DateTime creationDate;
        protected String content;
        protected BookLending bookLending;
        protected BookReservation bookReservation;

        public Notification(int notificationId, DateTime creationDate, string content, BookLending bookLending, BookReservation bookReservation)
        {
            this.notificationId = notificationId;
            this.creationDate = creationDate;
            this.content = content;
            this.bookLending = bookLending;
            this.bookReservation = bookReservation;
        }

        public abstract bool SendNotification(Book book);
    }

    public class PostalNotification : Notification
    {
        private Address address;

        public PostalNotification(int notificationId, DateTime creationDate, string content, BookLending bookLending, BookReservation bookReservation) : base( notificationId,  creationDate,  content,  bookLending,  bookReservation)
        {

        }
        public override bool SendNotification(Book book)
        {
            Console.WriteLine("Postal:" + this.content + " sent to member " + this.bookReservation.memberId);
            return true;
        }
    }

}
