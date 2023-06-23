using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    internal class Program
    {
        // Initialize collections for books, authors, and borrowers
        static List<Book> books = new List<Book>();
        static List<Author> authors = new List<Author>();
        static List<Borrower> borrowers = new List<Borrower>();

        static void Main(string[] args)
        {
           
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
                        //add author
                        AddAuthor();
                        break;
                    case 6:
                        //update author
                        UpdateAuthor();
                        break;
                    case 7:
                        //delete author
                        DeleteAuthor();
                        break;

                    case 8:
                        // Display all authors
                        DisplayAllAuthors(authors);
                        break;

                    case 9:
                        //add borrower
                        AddBorrower();
                        break;

                    case 10:
                        //Update borrowe
                        UpdateBorrower();
                        break;

                    case 11:
                        //delete borrower
                        DeleteBorrower();
                        break;

                    case 12:
                        // Display all borrowers
                        DisplayAllBorrowers();
                        break;

                    case 13:
                        //register book to a borrower
                        BorrowBook();
                        break;


                    case 14:
                        //list all borrowed books
                        DisplayAllBorrowedBooks();
                        break;

                    case 15:
                        // Search for books
                        SearchBooks(books,authors, borrowers);
                        break;

                    case 16:
                        // Filter books by status
                        FilterBooksByStatus();
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
            Console.WriteLine("5. Add a author");
            Console.WriteLine("6. Update a author");
            Console.WriteLine("7. Delete a author");
            Console.WriteLine("8. Display all authors");
            Console.WriteLine("9. Add a borrower");
            Console.WriteLine("10. Update a borrower");
            Console.WriteLine("11. Delete a borrower");
            Console.WriteLine("12. Display all borrowers");
            Console.WriteLine("13. Borrow a book");
            Console.WriteLine("14. Display all borrowed books");
            Console.WriteLine("15. Search books");
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }


        // Add Book
        static void AddBook(List<Book> books, List<Author> authors)
        {
            Console.WriteLine("Adding a new book:\n");

            Console.Write("Enter the book title: ");
            string title = Console.ReadLine();
            if (books.Any(book => book.Title == title))
            {
                Console.WriteLine("A book with the given title already exists in the library.");
                return;
            }

            Console.Write("Enter the author's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the author's last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Ener the author's date of birth (YYY--MM-DD): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the publication year: ");
            int publicationYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Is the book available? (yes/no): ");
            bool isAvailable = Console.ReadLine().ToLower() == "yes" ? true : false;

            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            Book book = new Book
            {
                Title = title,
                Author = author,
                PublicationYear = publicationYear,
                IsAvailable = isAvailable
            };

            books.Add(book);

            Console.WriteLine("\nBook added successfully!");


        }



        // Update Book
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



        // Delete Book
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



        // List all Books
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


        // Add Author

        static void AddAuthor()
        {
            Console.WriteLine("Enter author's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter author's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ener author's date of birth (YYY--MM-DD): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            if (authors.Any(a => a.FirstName == firstName && a.LastName == lastName && a.DateOfBirth == dateOfBirth))
            {
                Console.WriteLine("Author already exists..!");
                return;
            }
            Author author = new Author { FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth };
            authors.Add(author);
            Console.WriteLine("author added succesfuly..!");
        }


        // Update Author
        static void UpdateAuthor()
        {

            Console.WriteLine("Write a first name of author that you want to update: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write a last name of author that you want to udpate: ");
            string lName = Console.ReadLine();

            var author = authors.Find(a => a.FirstName == fName && a.LastName == lName);
            if (author != null)
            {
                Console.WriteLine("Enter the updated author's first name (or press enter to keep the existing first name):");
                string updatedFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedFirstName))
                {
                    author.FirstName = updatedFirstName;
                }

                Console.WriteLine("Enter the updated author's last name (or press enter to keep the existing last name):");
                string updatedLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedLastName))
                {
                    author.LastName = updatedLastName;
                }
                Console.WriteLine("Author updated successfully!");
            }
            else
            {
                Console.WriteLine("Author doesn't exists..!");
            }


        }

        //Delete author
        static void DeleteAuthor()
        {
            Console.WriteLine("Write first name of author that you want to delete: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write last name of author that you want to delete: ");
            string lName = Console.ReadLine();


            var author = authors.Find(a => a.FirstName == fName && a.LastName == lName);

            if (author != null)
            {
                authors.Remove(author);
                Console.WriteLine($"{fName} {lName} remove from authors list..!");
            }
            else
            {
                Console.WriteLine("author with this name doesn't exists..!");
            }

        }


        // Display All Author
        static void DisplayAllAuthors(List<Author> authors)
        {
            Console.WriteLine("Displaying all authors:\n");

            foreach (var author in authors)
            {
                Console.WriteLine("Author: {0} {1}", author.FirstName, author.LastName);
                Console.WriteLine("Date of Birth: {0}", author.DateOfBirth);
                
            }
        }

        // Add Borrower
        static void AddBorrower()
        {
            Console.WriteLine("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Borrower borrower = new Borrower { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber };
            borrowers.Add(borrower);
            Console.WriteLine("borrower added succesfuly..!");
        }
        //update borrower
        static void UpdateBorrower()
        {
            Console.WriteLine("Write a first name of borrower that you want to update: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write a last name of borrower that you want to udpate: ");
            string lName = Console.ReadLine();

            var borrower = borrowers.Find(b => b.FirstName == fName && b.LastName == lName);

            if (borrower != null)
            {
                Console.WriteLine("Enter the updated borrower's first name (or press enter to keep the existing first name):");
                string updatedFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedFirstName))
                {
                    borrower.FirstName = updatedFirstName;
                }

                Console.WriteLine("Enter the updated borrower's last name (or press enter to keep the existing last name):");
                string updatedLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedLastName))
                {
                    borrower.LastName = updatedLastName;
                }
                Console.WriteLine("Enter the updated borrower's email (or press enter to keep the existing email):");
                string updatedEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedEmail))
                {
                    borrower.Email = updatedEmail;
                }
                Console.WriteLine("Enter the updated borrower's phone number (or press enter to keep the existing phone number):");
                string updatedPhoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedPhoneNumber))
                {
                    borrower.PhoneNumber = updatedEmail;
                }
                Console.WriteLine("Borrower updated successfully!");
            }
            else
            {
                Console.WriteLine("Borrower doesn't exists..");
            }


        }
        //delete borrower
        static void DeleteBorrower()
        {

            Console.WriteLine("Write first name of borrower that you want to delete: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write last name of borrower that you want to delete: ");
            string lName = Console.ReadLine();


            var borrower = borrowers.Find(b => b.FirstName == fName && b.LastName == lName);

            if (borrower != null)
            {
                borrowers.Remove(borrower);
                Console.WriteLine($"{fName} {lName} remove from borrowers list..!");
            }
            else
            {
                Console.WriteLine("borrower with this name doesn't exists..!");
            }
        }


        // Display All Borrower
        static void DisplayAllBorrowers()
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

        static void BorrowBook()
        {
            Console.WriteLine("Enter the title of book that you want to borrow: ");
            string title = Console.ReadLine();
            var book = books.Find(b => b.Title == title);
            if (book != null)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine("Enter your first name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter your last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter your phone number: ");
                    string phoneNumber = Console.ReadLine();
                    Borrower borrower = new Borrower { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber };
                    book.IsAvailable = false;
                    Console.WriteLine("Book borrowed succesfully..!");
                    borrowers.Add(borrower);
                }
                else
                {
                    Console.WriteLine("The book you want is not available..!");
                }
            }
        }


            static void DisplayAllBorrowedBooks()
            {
                var borrowedBooks = books.Where(b => b.IsAvailable == false);
                if (borrowedBooks != null)
                {
                    foreach (var b in borrowedBooks)
                    {
                        Console.WriteLine(b.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No books is borrowed..!");
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



            static void FilterBooksByStatus()
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

