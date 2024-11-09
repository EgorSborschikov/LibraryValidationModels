using LibraryApp.Models;

namespace LibraryApp.Interfaces
{
    public interface InterfaceBookService
    {
        bool AddBook(Book book);
        Book GetBook(string Title);
    }
}