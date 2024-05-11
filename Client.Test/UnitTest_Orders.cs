using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;
using TangyWeb_API.Controllers;

namespace TangyWeb_API.Tests.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IEmailSender> _mockEmailSender;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockEmailSender = new Mock<IEmailSender>();
            _controller = new OrderController(_mockOrderRepository.Object, _mockEmailSender.Object);
        }

        //[Fact]
        //public async Task GetAll_ReturnsOkResult()
        //{
        //    // Arrange
        //    var orders = new[] { new OrderHeader(), new OrderHeader() };
        //    _mockOrderRepository.Setup(x => x.GetAll()).ReturnsAsync(orders);

        //    // Act
        //    var result = await _controller.GetAll();

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        //    Assert.Equal(orders, okResult.Value);
        //}

        //[Fact]
        //public async Task Get_WithValidId_ReturnsOkResult()
        //{
        //    // Arrange
        //    var orderHeaderId = 1;
        //    var orderHeader = new OrderHeader { Id = orderHeaderId };
        //    _mockOrderRepository.Setup(x => x.Get(orderHeaderId)).ReturnsAsync(orderHeader);

        //    // Act
        //    var result = await _controller.Get(orderHeaderId);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        //    Assert.Equal(orderHeader, okResult.Value);
        //}

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public async Task Get_WithInvalidId_ReturnsBadRequest(int? orderHeaderId)
        {
            // Act
            var result = await _controller.Get(orderHeaderId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal("Invalid Id", errorModel.ErrorMessage);
        }

        // Add tests for other action methods similarly
        // You can follow a similar pattern to arrange, act, and assert for each action method
    }
}
