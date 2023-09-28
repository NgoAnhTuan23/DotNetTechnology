using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int YearOfPublication { get; set; }
    public bool IsBorrowed { get; set; }

    public Book(string title, string author, string isbn, int yearOfPublication)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearOfPublication = yearOfPublication;
        IsBorrowed = false;
    }
}

class Library
{
    private List<Book> catalog = new List<Book>();

    public void AddBook(Book book)
    {
        catalog.Add(book);
    }

    public void RemoveBook(Book book)
    {
        catalog.Remove(book);
    }

    public Book FindBookByTitle(string title)
    {
        return catalog.Find(book => book.Title == title);
    }

    public void ListAllBooks()
    {
        Console.WriteLine("Library Catalog:");
        foreach (var book in catalog)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, " +
                $"Year of Publication: {book.YearOfPublication}, Borrowed: {book.IsBorrowed}");
        }
    }

    public void ListBorrowedBooks()
    {
        Console.WriteLine("Borrowed Books:");
        foreach (var book in catalog)
        {
            if (book.IsBorrowed)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        BorrowedBooks = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        if (!book.IsBorrowed)
        {
            book.IsBorrowed = true;
            BorrowedBooks.Add(book);
        }
    }

    public void ReturnBook(Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            book.IsBorrowed = false;
            BorrowedBooks.Remove(book);
        }
    }
}

class LibraryApp
{
    static void Main(string[] args)
    {
        Library library = new Library();

        Book book1 = new Book("Math", "Tuan", "978-0-123456-78-1", 2021);
        Book book2 = new Book("Music", "Kiet", "978-0-123456-78-2", 2012);
        Book book3 = new Book("Physics", "Phat", "978-0-123456-78-3", 2023);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        Person person1 = new Person("Anh Tuan", 20);
        Person person2 = new Person("Tran Phat", 19);

        person1.BorrowBook(book1);
        person2.BorrowBook(book2);

        library.ListAllBooks();
        library.ListBorrowedBooks();

        person1.ReturnBook(book1);

        library.ListAllBooks();
        library.ListBorrowedBooks();
    }
}
