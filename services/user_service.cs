using System.Collections.Generic;
using LibraryApp.Models;
using LibraryApp.Validators;

namespace LibraryApp.Services
{
    public class UserService : IUserService
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
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
    }
}