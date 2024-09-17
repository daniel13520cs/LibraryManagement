using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    // User is an abstract class
    public abstract class Notification
    {
        private String notificationId;
        private DateTime creationDate;
        private String content;
        private BookLending bookLending;
        private BookReservation bookReservation;

        public abstract bool SendNotification();
    }

    public class PostalNotification : Notification
    {
        private Address address;

        public override bool SendNotification()
        {
            // definition
            return true;
        }
    }

    public class EmailNotification : Notification
    {
        private String email;

        public override bool SendNotification()
        {
            // definition
            Console.WriteLine("email notification sent");
            return true;
        }
    }
}
