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
        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
           
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrderController(mockRepository.Object, null);

            
            var result = await controller.GetAll();

            
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task Get_WithInvalidId_ReturnsBadRequestResult()
        {
            
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrderController(mockRepository.Object, null);

           
            var result = await controller.Get(null);

            
            Assert.IsType<BadRequestObjectResult>(result);
        }         


        [Fact]
        public async Task Create_WithInvalidOrderDTO_ReturnsBadRequestResult()
        {
            
            var mockRepository = new Mock<IOrderRepository>();
            var mockEmailSender = new Mock<IEmailSender>();
            var controller = new OrderController(mockRepository.Object, mockEmailSender.Object);

            // passing null to trigger validation error
            var result = await controller.Create(null); 
            
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetOrdersByEmail_ReturnsOkResult()
        {
           
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrderController(mockRepository.Object, null);
            var userEmail = "test@example.com";

            
            var result = await controller.GetOrdersByEmail(userEmail);

            
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_ReturnsBadRequest_WhenIdIsNull()
        {
            
            int? id = null;
            var controller = new OrderController(null, null);

            
            var result = await controller.Get(id);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Invalid Id", errorModel.ErrorMessage);
        }

 
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenOrderDTOIsNull()
        {
            
            var controller = new OrderController(null, null);

           
            var result = await controller.Create(null);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("OrderDTO or OrderHeader is null", errorModel.ErrorMessage);
        }

        

        [Fact]
        public async Task Get_ReturnsOk_WhenOrderFound()
        {
            
            int id = 1; 
            var order = new OrderDTO { OrderHeader = new OrderHeaderDTO { Id = id } };
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository.Setup(repo => repo.Get(id)).ReturnsAsync(order);

            var controller = new OrderController(mockRepository.Object, null);

            
            var result = await controller.Get(id);

           
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<OrderDTO>(okResult.Value);
            Assert.Equal(id, model.OrderHeader.Id);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenOrderCreationFails()
        {
           
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository.Setup(repo => repo.Create(It.IsAny<OrderDTO>()))
                          .ReturnsAsync((OrderDTO)null);

            var controller = new OrderController(mockRepository.Object, null);
            var orderDTO = new OrderDTO { OrderHeader = new OrderHeaderDTO() };

          
            var result = await controller.Create(orderDTO);

           
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal("Failed to create the order", errorModel.ErrorMessage);
        }

        [Fact]
        public async Task GetOrdersByEmail_ReturnsEmptyList_WhenNoOrdersFound()
        {
            
            var mockRepository = new Mock<IOrderRepository>();
            mockRepository.Setup(repo => repo.GetAllLoadedByEmail(It.IsAny<string>())).ReturnsAsync(new List<OrderDTO>()); // Simulating no orders found
            var controller = new OrderController(mockRepository.Object, null);
            var userEmail = "nonexistent@example.com";

            
            var result = await controller.GetOrdersByEmail(userEmail);

          
            var okResult = Assert.IsType<OkObjectResult>(result);
            var orders = Assert.IsType<List<OrderDTO>>(okResult.Value);
            Assert.Empty(orders);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenOrderHeaderIsNull()
        {
            
            var controller = new OrderController(null, null);
            var orderDTO = new OrderDTO(); // OrderDTO with null OrderHeader

            
            var result = await controller.Create(orderDTO);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var errorModel = Assert.IsType<ErrorModelDTO>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("OrderDTO or OrderHeader is null", errorModel.ErrorMessage);
        }

        //[Fact]
        //public async Task Create_WithValidOrderDTO_ReturnsOkResult()
        //{
        //    // Arrange
        //    var mockRepository = new Mock<IOrderRepository>();
        //    mockRepository.Setup(repo => repo.Create(It.IsAny<OrderDTO>())).ReturnsAsync(new OrderDTO());

        //    var mockEmailSender = new Mock<IEmailSender>();
        //    var controller = new OrderController(mockRepository.Object, mockEmailSender.Object);

        //    var orderDTO = new OrderDTO
        //    {
        //        OrderHeader = new OrderHeaderDTO
        //        {
        //            UserId = "user123",
        //            OrderTotal = 100.0,
        //            OrderDate = DateTime.Now,
        //            ShippingDate = DateTime.Now.AddDays(1),
        //            Status = "Pending",
        //            Name = "John Doe",
        //            PhoneNumber = "1234567890",
        //            StreetAddress = "123 Main St",
        //            State = "California",
        //            City = "Los Angeles",
        //            PostalCode = "90001",
        //            Email = "john@example.com"
        //        },
        //        OrderDetails = new List<OrderDetailDTO>
        //        {
        //            new OrderDetailDTO
        //            {
        //                OrderHeaderId = 1, // Assuming OrderHeaderId value
        //                ProductId = 1, // Assuming ProductId value
        //                Count = 1, // Assuming Count value
        //                Price = 10.0, // Assuming Price value
        //                Size = "Medium", // Assuming Size value
        //                ProductName = "Product 1", // Assuming ProductName value
        //                CustomerImage = "image.jpg" // Assuming CustomerImage value
        //            },
        //            // Add more OrderDetailDTO as needed
        //        },
        //        // Other properties of OrderDTO
        //    };

        //    // Act
        //    var result = await controller.Create(orderDTO);


        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}


        //[Fact]
        //public async Task Create_SendsEmails_WhenOrderCreated()
        //{
        //    // Arrange
        //    var mockRepository = new Mock<IOrderRepository>();
        //    mockRepository.Setup(repo => repo.Create(It.IsAny<OrderDTO>()))
        //                  .ReturnsAsync(new OrderDTO { OrderHeader = new OrderHeaderDTO { Id = 1, Email = "test@example.com" } });

        //    var mockEmailSender = new Mock<IEmailSender>();

        //    var controller = new OrderController(mockRepository.Object, mockEmailSender.Object);
        //    var orderDTO = new OrderDTO { OrderHeader = new OrderHeaderDTO { Email = "test@example.com" } };

        //    // Act
        //    var result = await controller.Create(orderDTO);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    // Verify that SendEmailAsync is called twice
        //    mockEmailSender.Verify(sender => sender.SendEmailAsync("test@example.com", It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        //    // Verify the second email sending
        //    mockEmailSender.Verify(sender => sender.SendEmailAsync("cakeoclockbakery123@gmail.com", "New Order Cake'O Clock", It.IsAny<string>()), Times.Once);


        //}





    }
}
