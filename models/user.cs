using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}