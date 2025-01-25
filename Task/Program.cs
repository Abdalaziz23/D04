using static System.Reflection.Metadata.BlobBuilder;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBooks(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBooks(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBooks(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed


        }
    }

    class Book
    {
        string title;
        string author;
        string iSBN;
        public bool Availability { get; set; }

        public Book(string title, string author, string iSBN)
        {
            this.title = title;
            this.author = author;
            this.iSBN = iSBN;
            Availability = true;
        }

        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }

        public string GetAuthor()
        {
            return author;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public string GetISBN()
        {
            return iSBN;
        }
        public void SetISBN(string iSBN)
        {
            this.iSBN = iSBN;
        }

    }
    class Library
    {
        public List<Book> books = new List<Book>();

        public void AddBooks(Book book)
        {

            books.Add(book);
        }

        public void SearchBook(string titleOrAuthor)
        {
            bool found = false;
            foreach (Book book in books)
            {
                if (book.GetTitle() == titleOrAuthor || book.GetAuthor() == titleOrAuthor)
                {
                    Console.WriteLine("This book in the library");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("This book is not in the library");
            }
        }


        public void BorrowBook(string title)
        {
            foreach (Book book in books)
            {
                if (book.GetTitle() == title)
                {
                    if (book.Availability)
                    {
                        book.Availability = false;
                        Console.WriteLine($"Book '{title}' has been borrowed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{title}' is already borrowed.");
                    }

                }
            }
            Console.WriteLine($"Book '{title}' not found in the library.");
        }

        public void ReturnBook(string title)
        {
            foreach (Book book in books)
            {
                if (book.GetTitle() == title)
                {
                    if (!book.Availability)
                    {
                        book.Availability = true;
                        Console.WriteLine($"Book '{title}' has been returned successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{title}' was not borrowed.");
                    }

                }
            }
            Console.WriteLine($"Book '{title}' not found in the library.");
        }
    }
}

