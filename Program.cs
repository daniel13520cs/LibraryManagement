// See https://aka.ms/new-console-template for more information
using LibraryManagement;
using LibraryManagement.Factory;

Console.WriteLine("Hello, World!");
LibrarySystem system = LibrarySystem.GetInstance();
Author Daniel = new("Daniel");
Book first = new Magazine("0001", "Top 10 Cars", Daniel);
Book second = new EBOOK("0002", "SDE 101", Daniel);

BookItem? firstBookItem = BookItemFactory.CreateBookItem(first);
BookItem? secondBookItem = BookItemFactory.CreateBookItem(second);
BookItem? thirdBookItem = BookItemFactory.CreateBookItem(first);
LibrarySystem.AddBook(firstBookItem);
LibrarySystem.AddBook(secondBookItem);
LibrarySystem.AddBook(thirdBookItem);



Person Tracy = new Person("Tracy");
Member m1 = new Member(0, "aaa", AccountStatus.ACTIVE, Tracy, new LibraryCard());
Member m2 = new Member(1, "bbb", AccountStatus.ACTIVE, Daniel, new LibraryCard());

BookItem b1 = BookLending.LendBook(first, m1);
BookReservation.ReserveBookItem(first, m1.id);
BookReservation.ReserveBookItem(first, m2.id);
Librarian l1 = new Librarian(0, "aaa", AccountStatus.ACTIVE, new Person("Amy"), new LibraryCard());
l1.ReturnBook(b1, m1);
