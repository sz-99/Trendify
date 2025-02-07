using Backend.Controllers;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Tests.ControllerTests
{
    internal class LoginControllerTests
    {
        private Mock<ILoginService> _loginServiceMock;
        private LoginController _loginController;

        [SetUp]
        public void Setup()
        {
            _loginServiceMock = new Mock<ILoginService>();
            _loginController = new LoginController( _loginServiceMock.Object );
        }

        [Test]
        public void GetUserValidationResult_ValidUser_ReturnsOk()
        {
            // Arrange
            var validUser = new UserLogin { UserName = "testUser", Password = "securePassword" };

            _loginServiceMock
                .Setup(s => s.ValidateUser(validUser.UserName, validUser.Password))
                .Returns(true);

            // Act
            var result = _loginController.GetUserValidationResult(validUser);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetUserValidationResult_ValidUser_Returns_User()
        {
            // Arrange
            var validUser = new UserLogin { UserName = "testUser", Password = "securePassword" };

            _loginServiceMock
                .Setup(s => s.ValidateUser(validUser.UserName, validUser.Password))
                .Returns(true);

            // Act
            var result = _loginController.GetUserValidationResult(validUser);

            // Assert

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(validUser, okResult.Value);
        }

        [Test]
        public void GetUserValidationResult_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var invalidUser = new UserLogin { UserName = "wrongUser", Password = "wrongPass" };

            _loginServiceMock
                .Setup(s => s.ValidateUser(invalidUser.UserName, invalidUser.Password))
                .Returns(false);

            // Act
            var result = _loginController.GetUserValidationResult(invalidUser);

            // Assert
            Assert.IsInstanceOf<UnauthorizedResult>(result);
            var unauthorizedResult = result as UnauthorizedResult;
            Assert.IsNotNull(unauthorizedResult);
            Assert.AreEqual(401, unauthorizedResult.StatusCode);
        }

    }
}
