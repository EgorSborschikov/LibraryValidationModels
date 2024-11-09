using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryApp.Tests
{
    [TestClass]
    public class ReservationServiceTests
    {
        private ReservationService reservationService;
        private UserService userService;
        private BookService bookService;

        [TestInitialize]
        public void Setup()
        {
            reservationService = new ReservationService();
            userService = new UserService();
            bookService = new BookService();

            // Создаем пользователя и книгу для тестирования резервирования
            var user = new User
            {
                Username = "testuser",
                Password = "password123",
                Name = "Test User",
                Email = "test@example.com"
            };

            userService.RegisterUser (user);

            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                Pages = 100
            };

            bookService.AddBook(book);
        }

        [TestMethod]
        public void ReserveBook_ValidReservation_ReturnsTrue()
        {
            var user = userService.GetUser ("testuser");
            var book = bookService.GetBook("Test Book");

            var reservation = new Reservation
            {
                User = user,
                Book = book,
                ReservationDate = DateTime.Now
            };

            var result = reservationService.ReserveBook(reservation);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReserveBook_InvalidReservation_ReturnsFalse()
        {
            var reservation = new Reservation
            {
                User = null, // Неверный пользователь
                Book = null, // Неверная книга
                ReservationDate = DateTime.Now
            };

            var result = reservationService.ReserveBook(reservation);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReserveBook_DuplicateReservation_ReturnsFalse()
        {
            var user = userService.GetUser ("testuser");
            var book = bookService.GetBook("Test Book");

            var reservation1 = new Reservation
            {
                User = user,
                Book = book,
                ReservationDate = DateTime.Now
            };

            reservationService.ReserveBook(reservation1);

            // Пытаемся зарезервировать ту же книгу снова
            var reservation2 = new Reservation
            {
                User = user,
                Book = book,
                ReservationDate = DateTime.Now
            };

            var result = reservationService.ReserveBook(reservation2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReserveBook_NonExistingUser _ReturnsFalse()
        {
            var book = bookService.GetBook("Test Book");

            var reservation = new Reservation
            {
                User = null, // Не существующий пользователь
                Book = book,
                ReservationDate = DateTime.Now
            };

            var result = reservationService.ReserveBook(reservation);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReserveBook_NonExistingBook_ReturnsFalse()
        {
            var user = userService.GetUser ("testuser");

            var reservation = new Reservation
            {
                User = user,
                Book = null, // Не существующая книга
                ReservationDate = DateTime.Now
            };

            var result = reservationService.ReserveBook(reservation);
            Assert.IsFalse(result);
        }
    }
}