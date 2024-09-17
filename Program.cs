// See https://aka.ms/new-console-template for more information
using LibraryManagement;
using LibraryManagement.Factory;

Console.WriteLine("Hello, World!");
LibrarySystem system = LibrarySystem.GetInstance();
Author Daniel = new Author();
Book first = new Magazine("0001", "Top 10 Cars", Daniel);
Book second = new EBOOK("0002", "SDE 101", Daniel);

BookItem? firstBookItem = BookItemFactory.CreateBookItem(first);
BookItem? secondBookItem = BookItemFactory.CreateBookItem(second);
BookItem? thirdBookItem = BookItemFactory.CreateBookItem(first);

