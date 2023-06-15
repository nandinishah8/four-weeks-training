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
                    // ...
                    case 16:
                        // Filter books by status
                        FilterBooksByStatus(books);
                        break;
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
            // ...Add Other options here
            Console.WriteLine("16. Filter books by status");
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

        static void FilterBooksByStatus(List<Book> books)
        {
            Console.WriteLine("Filtering books by status:\n");

            Console.Write("Enter the book availability status (available or not available): ");
            string statusInput = Console.ReadLine();

            bool isAvailable = statusInput.Equals("available", StringComparison.OrdinalIgnoreCase);

            var filteredBooks = books.Where(b => b.IsAvailable == isAvailable);

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