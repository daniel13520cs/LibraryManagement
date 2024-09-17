using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        private string name;
        public Address Address { get; set; }
        public Dictionary<int, Rack> Racks { get; set; }

        // Private constructor to prevent external instantiation
        private Library() {
            Racks = new Dictionary<int, Rack>();
            Racks.Add(0, new Rack());
            Racks.Add(1, new Rack());
        }


        // The Library is a singleton class that ensures it will have only one active instance at a time
        private static Library library = null;

        // Created a static method to access the singleton instance of Library class
        public static Library GetInstance()
        {
            if (library == null)
            {
                library = new Library();
            }
            return library;
        }
    }
}
