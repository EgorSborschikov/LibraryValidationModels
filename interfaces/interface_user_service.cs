using LibraryApp.Models;

namespace LibraryApp.Interfaces
{
    public interface InterfaceUserService
    {
        bool RegisterUser (User user);
        User GetUser (string username);
    }
}