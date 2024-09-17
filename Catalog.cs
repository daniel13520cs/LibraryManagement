using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public interface ISearch
    {
        // Interface method (does not have a body)
        public List<Book> SearchByTitle(String title);
    }

    public class Catalog : ISearch
    {
        private Dictionary<String, List<Book>> bookTitles;

        public List<Book> SearchByTitle(String title)
        {
            // definition
            return bookTitles[title] ?? new List<Book>();
        }
        public void AddByTitle(String title, Book book)
        {
            if (!bookTitles.ContainsKey(title))
            {
                bookTitles.Add(title, new List<Book>());
            }
            bookTitles[title].Add(book);
        }
    }
}
