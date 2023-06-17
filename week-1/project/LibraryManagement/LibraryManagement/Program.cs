using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize collections for books, authors, and borrowers
            List<Book> books = new List<Book>();
            List<Author> authors = new List<Author>();
            List<Borrower> borrowers = new List<Borrower>();

            // Main program loop
            while (true)
            {
                DisplayMenu();

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    // Add cases for each menu option
                    case 1:
                        // Add a book
                        AddBook(books, authors);
                        break;
                    case 2:
                        // Update a book
                        UpdateBook(books);
                        break;
                    case 3:
                        // Delete a book
                        DeleteBook(books);
                        break;
                    case 4:
                        // List all books
                        ListAllBooks(books);
                        break;
                    case 5:
                        // Register a book to a borrower
                        RegisterBookToBorrower(books, borrowers);
                        break;
                    case 6:
                        // Display all authors
                        DisplayAllAuthors(authors);
                        break;
                    case 7:
                        // Display all borrowers
                        DisplayAllBorrowers(borrowers);
                        break;
                    case 8:
                        // Search for books
                        SearchBooks(books, authors, borrowers);
                        break;
                    case 9:
                        // Filter books by status
                        FilterBooksByStatus(books);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            // Display the menu options
            Console.WriteLine("Welcome to the Library Management System!\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. Register a book to a borrower");
            Console.WriteLine("6. Display all authors");
            Console.WriteLine("7. Display all borrowers");
            Console.WriteLine("8. Search for books");
            Console.WriteLine("9. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }

        static void AddBook(List<Book> books, List<Author> authors)
        {
            Console.WriteLine("Adding a new book:\n");

            Console.Write("Enter the book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the author's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the author's last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the publication year: ");
            int publicationYear;
            int.TryParse(Console.ReadLine(), out publicationYear);

            Author author = FindOrCreateAuthor(authors, firstName, lastName);

            Book book = new Book
            {
                Title = title,
                Author = author,
                PublicationYear = publicationYear,
                IsAvailable = true
            };

            books.Add(book);

            Console.WriteLine("\nBook added successfully!");
        }

        static Author FindOrCreateAuthor(List<Author> authors, string firstName, string lastName)
        {
            Author author = authors.Find(a => a.FirstName == firstName && a.LastName == lastName);

            if (author == null)
            {
                author = new Author
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                authors.Add(author);
            }

            return author;
        }

        static void UpdateBook(List<Book> books)
        {
            Console.WriteLine("Updating a book:\n");

            Console.Write("Enter the title of the book to update: ");
            string title = Console.ReadLine();

            Book book = books.Find(b => b.Title == title);

            if (book != null)
            {
                Console.WriteLine("Enter the updated information:");

                Console.Write("Enter the new title (leave empty to keep the existing title): ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    book.Title = newTitle;
                }

                Console.Write("Enter the new publication year (leave empty to keep the existing year): ");
                string publicationYearInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(publicationYearInput))
                {
                    int newPublicationYear;
                    if (int.TryParse(publicationYearInput, out newPublicationYear))
                    {
                        book.PublicationYear = newPublicationYear;
                    }
                }

                Console.WriteLine("\nBook updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void DeleteBook(List<Book> books)
        {
            Console.WriteLine("Deleting a book:\n");

            Console.Write("Enter the title of the book to delete: ");
            string title = Console.ReadLine();

            Book book = books.Find(b => b.Title == title);

            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("\nBook deleted successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void ListAllBooks(List<Book> books)
        {
            Console.WriteLine("Listing all books:\n");

            foreach (var book in books)
            {
                Console.WriteLine("Title: {0}", book.Title);
                Console.WriteLine("Author: {0} {1}", book.Author.FirstName, book.Author.LastName);
                Console.WriteLine("Publication Year: {0}", book.PublicationYear);
                Console.WriteLine("Availability: {0}", book.IsAvailable ? "Available" : "Not Available");
                Console.WriteLine();
            }
        }

        static void RegisterBookToBorrower(List<Book> books, List<Borrower> borrowers)
        {
            Console.WriteLine("Registering a book to a borrower:\n");

            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();

            Book book = books.Find(b => b.Title == title);

            if (book != null)
            {
                Console.Write("Enter the borrower's first name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter the borrower's last name: ");
                string lastName = Console.ReadLine();

                Borrower borrower = FindOrCreateBorrower(borrowers, firstName, lastName);

                book.Borrower = borrower;
                book.IsAvailable = false;

                Console.WriteLine("\nBook registered to borrower successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static Borrower FindOrCreateBorrower(List<Borrower> borrowers, string firstName, string lastName)
        {
            Borrower borrower = borrowers.Find(b => b.FirstName == firstName && b.LastName == lastName);

            if (borrower == null)
            {
                borrower = new Borrower
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                borrowers.Add(borrower);
            }

            return borrower;
        }

        static void DisplayAllAuthors(List<Author> authors)
        {
            Console.WriteLine("Displaying all authors:\n");

            foreach (var author in authors)
            {
                Console.WriteLine("Author: {0} {1}", author.FirstName, author.LastName);
                Console.WriteLine("Date of Birth: {0}", author.DateOfBirth);
                Console.WriteLine();
            }
        }

        static void DisplayAllBorrowers(List<Borrower> borrowers)
        {
            Console.WriteLine("Displaying all borrowers:\n");

            foreach (var borrower in borrowers)
            {
                Console.WriteLine("Borrower: {0} {1}", borrower.FirstName, borrower.LastName);
                Console.WriteLine("Email: {0}", borrower.Email);
                Console.WriteLine("Phone Number: {0}", borrower.PhoneNumber);
                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();
            }
        }

        static void SearchBooks(List<Book> books, List<Author> authors, List<Borrower> borrowers)
        {
            Console.WriteLine("Searching for books:\n");

            Console.Write("Enter the search keyword: ");
            string keyword = Console.ReadLine();

            var results = books.FindAll(b =>
                b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Author.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Author.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                (b.Borrower != null &&
                 (b.Borrower.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                  b.Borrower.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase))));

            if (results.Count > 0)
            {
                Console.WriteLine("\nSearch results:\n");

                foreach (var book in results)
                {
                    Console.WriteLine("Title: {0}", book.Title);
                    Console.WriteLine("Author: {0} {1}", book.Author.FirstName, book.Author.LastName);
                    Console.WriteLine("Publication Year: {0}", book.PublicationYear);
                    Console.WriteLine("Availability: {0}", book.IsAvailable ? "Available" : "Not Available");
                    if (!book.IsAvailable)
                    {
                        Console.WriteLine("Borrower: {0} {1}", book.Borrower.FirstName, book.Borrower.LastName);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No books found matching the search criteria.");
            }
        }

        static void FilterBooksByStatus(List<Book> books)
        {
            Console.WriteLine("Filtering books by status:\n");

            Console.Write("Enter the book availability status (available or not available): ");
            string statusInput = Console.ReadLine();

            bool isAvailable = statusInput.Equals("available", StringComparison.OrdinalIgnoreCase);

            var filteredBooks = books.FindAll(b => b.IsAvailable == isAvailable);

            Console.WriteLine("\nFiltered books:\n");

            foreach (var book in filteredBooks)
            {
                Console.WriteLine("Title: {0}", book.Title);
                Console.WriteLine("Author: {0} {1}", book.Author.FirstName, book.Author.LastName);
                Console.WriteLine("Publication Year: {0}", book.PublicationYear);
                Console.WriteLine();
            }
        }
    }

    // Class definitions
    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public Borrower Borrower { get; set; }
    }

    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
