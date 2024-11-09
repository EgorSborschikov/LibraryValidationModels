using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Reservation
    {
        [Required]
        public User User { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

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

            var reservation = new Reservation { User = user, Book = book, ReservationDate = DateTime.Now };
            reservationService.Reserve(reservation);
            Console.WriteLine("Book reserved successfully!");
        }
    }
}