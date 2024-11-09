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

        public Reservation(User user, Book book, DateTime reservationDate)
        {
            User = user;
            Book = book;
            ReservationDate = reservationDate;
        }
    }
}