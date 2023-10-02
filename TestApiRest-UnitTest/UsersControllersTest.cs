using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestApiRest.Controllers;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Services.Interfaces;

namespace TestApiRest_UnitTest
{
    [TestFixture]
    public class UsersControllersTest
    {
        private Mock<IUsersService> _mockUserService;
        private UsersControllers _controller;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUsersService>();
            _controller = new UsersControllers(_mockUserService.Object);
        }

        [Test]
        public void GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<UserDTO>
            {
                new UserDTO { IdUser = 1, Name = "name 1", Surname = "surname 1", DateOfBirth = DateTime.Parse("19/9/1999"), DocumentNumber = 123456789, TypeOfDocument = 0 }, 
                new UserDTO { IdUser = 2, Name = "name 2", Surname = "surname 2", DateOfBirth = DateTime.Parse("11/11/1991"), DocumentNumber = 951159753, TypeOfDocument = 0 }
            };

            _mockUserService.Setup(service => service.GetAllUsers()).Returns(expectedUsers);

            // Act
            var result = _controller.GetAllUsers();

            // Assert
            Assert.IsInstanceOf<List<UserDTO>>(result);
            Assert.That(result.Count, Is.EqualTo(expectedUsers.Count));
        }

        [Test]
        public void GetUserById_ValidId_ReturnTrue()
        {
            // Arrange
            var id = 1;
            var user = new UserDTO { IdUser = 1, Name = "name 1", Surname = "surname 1", DateOfBirth = DateTime.Parse("19/9/1999"), DocumentNumber = 123456789, TypeOfDocument = 0 };
            _mockUserService.Setup(service => service.GetUserById(id)).Returns(user);

            // Act
            var result = _controller.GetUserById(id);

            // Assert
            Assert.IsInstanceOf<UserDTO>(result);
            Assert.That(result, Is.EqualTo(user));
        }

        [Test]
        public void CreateUser_IdNotRepeated_ReturnTrue()
        {
            // Arrange
            var user = new UserDTO { IdUser = 1, Name = "name 1", Surname = "surname 1", DateOfBirth = DateTime.Parse("19/9/1999"), DocumentNumber = 123456789, TypeOfDocument = 0 };
            _mockUserService.Setup(service => service.CreateUser(user)).Returns(user);

            // Act
            var result = _controller.CreateUser(user);

            // Assert
            Assert.IsInstanceOf<ActionResult<UserDTO>>(result);
            var okResult = result as ActionResult<UserDTO>;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);

            var userResult = (okResult.Result as OkObjectResult).Value as UserDTO;
            Assert.IsNotNull(userResult);
            Assert.That(userResult.IdUser, Is.EqualTo(user.IdUser));
            Assert.That(userResult.Name, Is.EqualTo(user.Name));
            Assert.That(userResult.DateOfBirth, Is.EqualTo(user.DateOfBirth));
            Assert.That(userResult.DocumentNumber, Is.EqualTo(user.DocumentNumber));
            Assert.That(userResult.TypeOfDocument, Is.EqualTo(user.TypeOfDocument));
        }

        [Test]
        public void CreateUser_RepeatedId_ReturnFalse()
        {
            // Arrange 
            var user = new UserDTO { IdUser = 1, Name = "name 1", Surname = "surname 1", DateOfBirth = DateTime.Parse("19/9/1999"), DocumentNumber = 123456789, TypeOfDocument = 0 };
            _mockUserService.Setup(service => service.CreateUser(user)).Throws(new Exception("Ya existe un usuario con el mismo DocumentNumber."));
            
            // Act
            var result = _controller.CreateUser(user);

            // Assert
            Assert.IsInstanceOf<ActionResult<UserDTO>>(result);
            var barRequestResult = result as ActionResult<UserDTO>;
            Assert.IsNotNull(barRequestResult);
            Assert.IsInstanceOf<BadRequestObjectResult>(barRequestResult.Result);
        }

        [Test]
        public void UpdateUser_UserExist_ReturnTrue()
        {
            // Arrange
            var user = new UserDTO { IdUser = 1, Name = "name 1", Surname = "surname 1", DateOfBirth = DateTime.Parse("19/9/1999"), DocumentNumber = 123456789, TypeOfDocument = 0 };
            var orderUpdate = new UserDTO { IdUser = 1, Name = "name 2", Surname = "surname 2", DateOfBirth = DateTime.Parse("10/11/1998"), DocumentNumber = 123456789, TypeOfDocument = 0 };
            _mockUserService.Setup(service => service.UpdateUser(orderUpdate)).Returns(orderUpdate);

            // Act
            var result = _controller.UpdateUser(orderUpdate);

            // Assert
            Assert.IsInstanceOf<UserDTO>(result);
            Assert.That(result, Is.EqualTo(orderUpdate));
        }

        [Test]
        public void DeleteUser_UserExists_ReturnTrue()
        {
            // Arrange
            var idUserToDelete = 1;
            var expectedUser = new UserDTO { IdUser = 1, Name = "name 1", Surname = "surname 1", DateOfBirth = DateTime.Parse("19/9/1999"), DocumentNumber = 123456789, TypeOfDocument = 0 };
            _mockUserService.Setup(service => service.DeleteUser(idUserToDelete)).Returns(expectedUser);

            // Act
            var result = _controller.DeleteUser(idUserToDelete);

            // Assert
            Assert.IsInstanceOf<ActionResult<UserDTO>>(result);
            var okResult = result as ActionResult<UserDTO>;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);

            var userResult = (okResult.Result as OkObjectResult).Value as UserDTO;
            Assert.IsNotNull(userResult);
            Assert.That(userResult.IdUser, Is.EqualTo(expectedUser.IdUser));
            Assert.That(userResult.Name, Is.EqualTo(expectedUser.Name));
            Assert.That(userResult.DateOfBirth, Is.EqualTo(expectedUser.DateOfBirth));
            Assert.That(userResult.DocumentNumber, Is.EqualTo(expectedUser.DocumentNumber));
            Assert.That(userResult.TypeOfDocument, Is.EqualTo(expectedUser.TypeOfDocument));
        }

        [Test]
        public void DeleteUser_UserNotFound_ReturnFalse()
        {
            // Arrange
            var idUserToDelete = 1;
            _mockUserService.Setup(service => service.DeleteUser(idUserToDelete)).Throws(new Exception("El usuario ingresado no fue encontrado."));

            // Act
            var result = _controller.DeleteUser(idUserToDelete);

            // Assert
            Assert.IsInstanceOf<ActionResult<UserDTO>>(result);
            var notFoundResult = result as ActionResult<UserDTO>;
            Assert.IsNotNull(notFoundResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(notFoundResult.Result);
        }
    }
}
