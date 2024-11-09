using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var bookService = new BookService();
            var reservationService = new ReservationService();

            Console.WriteLine("Welcome to the Library System");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Reserve Book");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterUser (userService);
                        break;
                    case "2":
                        AddBook(bookService);
                        break;
                    case "3":
                        ReserveBook(reservationService, userService, bookService);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void RegisterUser (UserService userService)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            var user = new User { Username = username, Password = password };
            userService.Register(user);
            Console.WriteLine("User  registered successfully!");
        }

        static void AddBook(BookService bookService)
        {
            Console.Write("Enter book title: ");
            var title = Console.ReadLine();
            Console.Write("Enter author: ");
            var author = Console.ReadLine();

            var book = new Book { Title = title, Author = author };
            bookService.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }

        static void ReserveBook(ReservationService reservationService, UserService userService, BookService bookService)
        {
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            var user = userService.GetUser (username);

            if (user == null)
            {
                Console.WriteLine("User  not found.");
                return;
            }

            Console.Write("Enter book title to reserve: ");
            var title = Console.ReadLine();
            var book = bookService.GetBook(title);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            var reservation = new Reservation { User = user, Book = book };
            reservationService.Reserve(reservation);
            Console.WriteLine("Book reserved successfully!");
        }
    }
}