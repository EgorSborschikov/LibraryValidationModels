using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryApp.Models;

namespace LibraryApp.Validators
{
    public class ReservationValidator
    {
        public List<ValidationResult> Validate(Reservation reservation)
        {
            var context = new ValidationContext(reservation);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(reservation, context, results, true);
            return results;
        }
    }
}