using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_Models;
using TangyWeb_API.Controllers;

namespace TangyWeb_API.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductController _controller;
        private readonly IMapper _mapper;


        public ProductControllerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _controller = new ProductController(_productRepositoryMock.Object);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<ProductPriceDTO, ProductPrice>();
            });
            _mapper = config.CreateMapper();
        }

        
        [Fact]
        public async Task Get_WithValidId_ReturnsOkWithProduct()
        {
            
            var productId = 1; // checking a valid id
            var expectedProduct = new ProductDTO {
                Id = 1,
                Name = "Product 1",
                Description = "Description of Product 1",
                ShopFavourites = true,
                CustomerFavourites = false,
                Color = "Red",
                ImageUrl = "https://example.com/product1.jpg",
                CategoryId = 1,
                Category = new CategoryDTO { Id = 1, Name = "Category 1" }, 
                ProductPrices = new List<ProductPriceDTO>
                    {
                        new ProductPriceDTO {
                            Id = 1,
                            ProductId = 1, 
                            Size = "Small",
                            Price = 10.99
                        }
                    }

            };
            _productRepositoryMock.Setup(repo => repo.Get(productId)).ReturnsAsync(expectedProduct);

            
            var result = await _controller.Get(productId);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualProduct = Assert.IsAssignableFrom<ProductDTO>(okResult.Value);
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public async Task Get_WithInValidId_ReturnBadRequestWithProduct()
        {
           
            var productId = -21; // Change to a invalid product id
            var expectedProduct = new ProductDTO
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description of Product 1",
                ShopFavourites = true,
                CustomerFavourites = false,
                Color = "Red",
                ImageUrl = "https://example.com/product1.jpg",
                CategoryId = 1,
                Category = new CategoryDTO { Id = 1, Name = "Category 1" }, 
                ProductPrices = new List<ProductPriceDTO>
                    {
                        new ProductPriceDTO {
                            Id = 1,
                            ProductId = -21,
                            Size = "Small",
                            Price = 10.99
                        }
                    }

            };
            _productRepositoryMock.Setup(repo => repo.Get(productId)).ReturnsAsync(expectedProduct);

            
            var result = await _controller.Get(productId);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualProduct = Assert.IsAssignableFrom<ProductDTO>(okResult.Value);
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public async Task Get_WithInvalidId_ReturnsBadRequest()
        {
            
            var invalidProductId = 0; 

            
            var result = await _controller.Get(invalidProductId);

           
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
           
        }

        [Fact]
        public async Task Get_WithInvalidIdMinus_ReturnsBadRequest()
        {
            
            var invalidProductId = -23; 

            
            var result = await _controller.Get(invalidProductId);

           
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
           
        }

        [Fact]
        public async Task Get_WithValidId_ReturnsOKRequest()
        {
            
            var invalidProductId = 12; 

            
            var result = await _controller.Get(invalidProductId);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            
        }

        [Fact]
        public async Task Get_WithValidIdLargeNum_ReturnsOKRequest()
        {
            
            var invalidProductId = 1568435654;

            
            var result = await _controller.Get(invalidProductId);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);

        }

        //[Fact]
        //public async Task GetAll_ReturnsOkWithProducts()
        //{
        //    // Arrange
        //    var expectedProducts = new List<ProductDTO> {
        //        new ProductDTO
        //        {
        //            Id = 1,
        //            Name = "Product 1",
        //            Description = "Description of Product 1",
        //            ShopFavourites = true,
        //            CustomerFavourites = false,
        //            Color = "Red",
        //            ImageUrl = "https://example.com/product1.jpg",
        //            CategoryId = 1,
        //            Category = new CategoryDTO { Id = 1, Name = "Category 1"}, // Assuming you have a Category class
        //            ProductPrices = new List<ProductPriceDTO>
        //            {
        //                new ProductPriceDTO {
        //                    Id = 1,
        //                    ProductId = 1, // Assuming this corresponds to the Id of the associated product
        //                    Size = "Small",
        //                    Price = 10.99
        //                }
        //            }
        //        },
        //    };
        //    var expectedProductsMapped = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<Product>>(expectedProducts);
        //    _productRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedProducts);

        //    // Act
        //    var result = await _controller.GetAll();

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var actualProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
        //    Assert.Equal(expectedProductsMapped, actualProducts);
        //}

    }
}
