using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;
using TangyWeb_API.Controllers;

namespace TangyWeb_API.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _controller = new ProductController(_mockProductRepository.Object);
        }

        //[Fact]
        //public async Task GetAll_ReturnsOkResult()
        //{
        //    // Arrange
        //    var products = new[] { new Product(), new Product() };
        //    _mockProductRepository.Setup(x => x.GetAll()).ReturnsAsync(products);

        //    // Act
        //    var result = await _controller.GetAll();

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        //    Assert.Equal(products, okResult.Value);
        //}

        //[Fact]
        //public async Task Get_WithValidId_ReturnsOkResult()
        //{
        //    // Arrange
        //    var productId = 1;
        //    var product = new Product { Id = productId };
        //    _mockProductRepository.Setup(x => x.Get(productId)).ReturnsAsync(product);

        //    // Act
        //    var result = await _controller.Get(productId);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        //    Assert.Equal(product, okResult.Value);
        //}

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        public async Task Get_WithInvalidId_ReturnsBadRequest(int? productId)
        {
            // Act
            var result = await _controller.Get(productId);

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
