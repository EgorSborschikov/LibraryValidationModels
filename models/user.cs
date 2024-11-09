using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public User(string username, string password, string name, string email)
        {
            Username = username;
            Password = password;
            Name = name;
            Email = email;
        }
    }
}