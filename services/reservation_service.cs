using System.Collections.Generic;
using LibraryApp.Models;
using LibraryApp.Validators;

namespace LibraryApp.Services
{
    public class ReservationService : IReservationService
    {
        public User User { get; set; }
        public Book Book { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private ReservationValidator validator = new ReservationValidator();

        public bool ReserveBook(Reservation reservation)
        {
            var validationResults = validator.Validate(reservation);
            if (validationResults.Count == 0)
            {
                reservations.Add(reservation);
                return true;
            }
            return false;
        }
    }
}