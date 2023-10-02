using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TestApiRest.Controllers;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Services.Interfaces;

namespace TestApiRest.Tests.Controllers
{
    [TestFixture]
    public class BooksControllerTests
    {
        private Mock<IBooksService> _mockBooksService;
        private BooksController _controller;

        [SetUp]
        public void Setup()
        {
            _mockBooksService = new Mock<IBooksService>();
            _controller = new BooksController(_mockBooksService.Object);
        }

        [Test]
        public void GetAllBooks_ReturnsListOfBooks()
        {
            // Arrange
            var expectedBooks = new List<BookDTO>
            {
                new BookDTO { IdBook = 1, Tittle = "Book 1", Publisher = "Publisher 1" },
                new BookDTO { IdBook = 2, Tittle = "Book 2", Publisher = "Publisher 2" }
            };

            _mockBooksService.Setup(service => service.GetAllBooks()).Returns(expectedBooks);

            // Act
            var result = _controller.GetAllBooks();

            // Assert
            Assert.IsInstanceOf<List<BookDTO>>(result); 
            Assert.AreEqual(expectedBooks.Count, result.Count);
        }

        [Test]
        public void GetBookById_ValidId_ReturnTrue()
        {
            // Arrange
            var id = 1;
            var book = new BookDTO { IdBook = id, Tittle = "Book 1", Publisher = "Publisher 1" };
            _mockBooksService.Setup(service => service.GetBookById(id)).Returns(book);
            
            // Act
            var result = _controller.GetBookById(id);
            
            // Assert
            Assert.IsInstanceOf<BookDTO>(result);
            Assert.AreEqual(book, result);
        }

        [Test]
        public void CreateBook_ValidDto_ReturnTrue()
        {
            // Arrange
            var book = new BookDTO { IdBook = 1, Tittle = "Book 1", Publisher = "Publisher 1" };
            _mockBooksService.Setup(service => service.CreateBook(book)).Returns(book);
            
            // Act
            var result = _controller.CreateBook(book);
            
            // Assert
            Assert.IsInstanceOf<BookDTO>(result);
            Assert.AreEqual(book, result);
        }

        [Test]
        public void UpdateBook_BookExist_ReturnTrue()
        {
            // Arrange
            var book = new BookDTO { IdBook = 1, Tittle = "Book 1", Publisher = "Publisher 1" };
            var bookUpdate = new BookDTO { IdBook = 1, Tittle = "BookModified 1", Publisher = "PublisherModified 1" };
            _mockBooksService.Setup(service => service.UpdateBook(bookUpdate)).Returns(bookUpdate);
            
            // Act
            var result = _controller.UpdateBook(bookUpdate);

            // Assert
            Assert.IsInstanceOf<BookDTO>(result);
            Assert.AreEqual(bookUpdate, result);
        }

        [Test]
        public void DeleteBook_BookExists_ReturnTrue()
        {
            // Arrange
            var idBookToDelete = 1;
            var expectedBook = new BookDTO { IdBook = idBookToDelete, Tittle = "Book 1", Publisher = "Publisher 1" };
            _mockBooksService.Setup(service => service.DeleteBook(idBookToDelete)).Returns(expectedBook);

            // Act
            var result = _controller.DeleteBook(idBookToDelete);

            // Assert
            Assert.IsInstanceOf<ActionResult<BookDTO>>(result);
            var okResult = result as ActionResult<BookDTO>;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);

            var bookResult = (okResult.Result as OkObjectResult).Value as BookDTO;
            Assert.IsNotNull(bookResult);
            Assert.AreEqual(expectedBook.IdBook, bookResult.IdBook);
            Assert.AreEqual(expectedBook.Tittle, bookResult.Tittle);
            Assert.AreEqual(expectedBook.Publisher, bookResult.Publisher);
        }

        [Test]
        public void DeleteBook_BookNotFound_ReturnFalse()
        {
            // Arrange
            var idBookToDelete = 1;
            _mockBooksService.Setup(service => service.DeleteBook(idBookToDelete)).Throws(new Exception("El libro ingresado no fue encontrado."));
            
            // Act
            var result = _controller.DeleteBook(idBookToDelete);

            // Assert
            Assert.IsInstanceOf<ActionResult<BookDTO>>(result);
            var notFoundResult = result as ActionResult<BookDTO>;
            Assert.IsNotNull(notFoundResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(notFoundResult.Result);
        }
    }
}
