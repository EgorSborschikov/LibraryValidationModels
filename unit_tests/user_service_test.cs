using System;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryApp.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService userService;

        [TestInitialize]
        public void Setup()
        {
            userService = new UserService();
        }

        [TestMethod]
        public void RegisterUser _ValidUser _ReturnsTrue()
        {
            var user = new User
            {
                Username = "testuser",
                Password = "password123",
                Name = "Test User",
                Email = "test@example.com"
            };

            var result = userService.RegisterUser (user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RegisterUser _DuplicateUser _ReturnsFalse()
        {
            var user = new User
            {
                Username = "testuser",
                Password = "password123",
                Name = "Test User",
                Email = "test@example.com"
            };

            userService.RegisterUser (user);
            var duplicateResult = userService.RegisterUser (user);
            Assert.IsFalse(duplicateResult);
        }

        [TestMethod]
        public void GetUser _ExistingUser _ReturnsUser ()
        {
            var user = new User
            {
                Username = "testuser",
                Password = "password123",
                Name = "Test User",
                Email = "test@example.com"
            };

            userService.RegisterUser (user);
            var retrievedUser  = userService.GetUser ("testuser");
            Assert.IsNotNull(retrievedUser );
            Assert.AreEqual("testuser", retrievedUser .Username);
        }

        [TestMethod]
        public void GetUser _NonExistingUser _ReturnsNull()
        {
            var retrievedUser  = userService.GetUser ("nonexistinguser");
            Assert.IsNull(retrievedUser );
        }
    }
}