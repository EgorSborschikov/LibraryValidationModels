using System.Collections.Generic;
using LibraryApp.Models;
using LibraryApp.Validators;

namespace LibraryApp.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>();
        private UserValidator validator = new UserValidator();

        public bool RegisterUser (User user)
        {
            var validationResults = validator.Validate(user);
            if (validationResults.Count == 0)
            {
                users.Add(user);
                return true;
            }
            return false;
        }

        public User GetUser (string username)
        {
            return users.Find(u => u.Username == username);
        }
    }
}