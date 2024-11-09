using System.Collections.Generic;
using LibraryApp.Models;
using LibraryApp.Validators;

namespace LibraryApp.Services
{
    public class BookService : IBookService
    {
        private List<Book> books = new List<Book>();
        private BookValidator validator = new BookValidator();

        public bool AddBook(Book book)
        {
            var validationResults = validator.Validate(book);
            if (validationResults.Count == 0)
            {
                books.Add(book);
                return true;
            }
            return false;
        }

        public Book GetBook(string title)
        {
            return books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}