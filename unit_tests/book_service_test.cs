using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryApp.Tests
{
    [TestClass]
    public class BookServiceTests
    {
        private BookService bookService;

        [TestInitialize]
        public void Setup()
        {
            bookService = new BookService();
        }

        [TestMethod]
        public void AddBook_ValidBook_ReturnsTrue()
        {
            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                Pages = 100
            };

            var result = bookService.AddBook(book);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBook_InvalidBook_ReturnsFalse()
        {
            var book = new Book
            {
                Title = null, // Invalid title
                Author = "Test Author",
                Pages = 100
            };

            var result = bookService.AddBook(book);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetBook_ExistingBook_ReturnsBook()
        {
            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                Pages = 100
            };

            bookService.AddBook(book);
            var retrievedBook = bookService.GetBook("Test Book");
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual("Test Book", retrievedBook.Title);
        }

        [TestMethod]
        public void GetBook_NonExistingBook_ReturnsNull()
        {
            var retrievedBook = bookService.GetBook("Non Existing Book");
            Assert.IsNull(retrievedBook);
        }
    }
}