using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    // definition of enumerations used in library management system
    public enum BookFormat
    {
        HARDCOVER,
        PAPERBACK,
        AUDIOBOOK,
        EBOOK,
        NEWSPAPER,
        MAGAZINE,
        JOURNAL
    }

    public enum BookStatus
    {
        AVAILABLE,
        RESERVED,
        LOANED,
    }

    public enum ReservationStatus
    {
        WAITING,
        PENDING,
        CANCELED,
        NONE
    }

    public enum AccountStatus
    {
        ACTIVE,
        CLOSED,
        CANCELED,
        BLACKLISTED,
        NONE
    }

}
