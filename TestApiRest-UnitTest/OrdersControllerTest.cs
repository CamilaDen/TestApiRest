using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApiRest.Controllers;
using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;
using TestApiRest.Services.Interfaces;

namespace TestApiRest_UnitTest
{
    [TestFixture]
    public class OrdersControllerTest
    {
        private Mock<IOrdersService> _mockOrdersService;
        private OrdersController _controller;

        [SetUp]
        public void Setup()
        {
            _mockOrdersService = new Mock<IOrdersService>();
            _controller = new OrdersController(_mockOrdersService.Object);
        }

        [Test]
        public void GetAllOrders_ReturnsListOfOrders()
        {
            // Arrange
            var expectedOrders = new List<OrderDTO>
            {
                new OrderDTO { IdOrder = 1, IdUser = 1, DateOfOrder = DateTime.Parse("20/10/1990"), OrderDetailList = new List<OrderDetailDTO>()},
                new OrderDTO { IdOrder = 2, IdUser = 2, DateOfOrder = DateTime.Parse("21/11/1991"), OrderDetailList = new List<OrderDetailDTO>()}
            };

            _mockOrdersService.Setup(service => service.GetAllOrders()).Returns(expectedOrders);

            // Act
            var result = _controller.GetAllOrders();

            // Assert
            Assert.IsInstanceOf<List<OrderDTO>>(result);
            Assert.AreEqual(expectedOrders.Count, result.Count);
        }

        [Test]
        public void GetOrderById_ValidId_ReturnTrue()
        {
            // Arrange
            var id = 1;
            var order = new OrderDTO { IdOrder = 2, IdUser = 2, DateOfOrder = DateTime.Parse("21/11/1991"), OrderDetailList = new List<OrderDetailDTO>()};
            _mockOrdersService.Setup(service => service.GetOrderById(id)).Returns(order);

            // Act
            var result = _controller.GetOrderById(id);

            // Assert
            Assert.IsInstanceOf<OrderDTO>(result);
            Assert.AreEqual(order, result);
        }

        [Test]
        public void CreateOrder_ValidOrder_ReturnTrue()
        {
            // Arrange
            var order = new OrderDTO { IdOrder = 2, IdUser = 2, DateOfOrder = DateTime.Parse("21/11/1991"), OrderDetailList = new List<OrderDetailDTO>() };
            _mockOrdersService.Setup(service => service.CreateOrder(order)).Returns(order);

            // Act
            var result = _controller.CreateOrder(order);

            // Assert
            Assert.IsInstanceOf<OrderDTO>(result);
            Assert.AreEqual(order, result);
        }


        [Test]
        public void DeleteOrder_OrderExists_ReturnTrue()
        {
            // Arrange
            var idOrderToDelete = 1;
            var expectedOrder = new OrderDTO { IdOrder = 2, IdUser = 2, DateOfOrder = DateTime.Parse("21/11/1991"), OrderDetailList = new List<OrderDetailDTO>() };
            _mockOrdersService.Setup(service => service.DeleteOrder(idOrderToDelete)).Returns(expectedOrder);

            // Act
            var result = _controller.DeleteOrder(idOrderToDelete);

            // Assert
            Assert.IsInstanceOf<ActionResult<OrderDTO>>(result);
            var okResult = result as ActionResult<OrderDTO>;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);

            var orderResult = (okResult.Result as OkObjectResult).Value as OrderDTO;
            Assert.IsNotNull(orderResult);
            Assert.AreEqual(expectedOrder.IdOrder, orderResult.IdOrder);
            Assert.AreEqual(expectedOrder.IdUser, orderResult.IdUser);
            Assert.AreEqual(expectedOrder.DateOfOrder, orderResult.DateOfOrder);
            Assert.AreEqual(expectedOrder.OrderDetailList, orderResult.OrderDetailList);
        }

        [Test]
        public void DeleteOrder_OrderNotFound_ReturnFalse()
        {
            // Arrange
            var idOrderToDelete = 1;
            _mockOrdersService.Setup(service => service.DeleteOrder(idOrderToDelete)).Throws(new Exception("El pedido ingresado no fue encontrado."));

            // Act
            var result = _controller.DeleteOrder(idOrderToDelete);

            // Assert
            Assert.IsInstanceOf<ActionResult<OrderDTO>>(result);
            var notFoundResult = result as ActionResult<OrderDTO>;
            Assert.IsNotNull(notFoundResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(notFoundResult.Result);
        }
    }
}
