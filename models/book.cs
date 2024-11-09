using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Range(1, 1000, ErrorMessage = "Pages must be between 1 and 1000.")]
        public int Pages { get; set; }

        static void AddBook(BookService bookService)
        {
            Console.Write("Enter book title: ");
            var title = Console.ReadLine();
            Console.Write("Enter author: ");
            var author = Console.ReadLine();
            Console.Write("Enter number of pages: ");
            var pages = int.Parse(Console.ReadLine());

            var book = new Book { Title = title, Author = author, Pages = pages };
            bookService.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }
    }
}