using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryApp.Models;

namespace LibraryApp.Validators
{
    public class BookValidator
    {
        public List<ValidationResult> Validate(Book book)
        {
            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(book, context, results, true);
            return results;
        }
    }
}