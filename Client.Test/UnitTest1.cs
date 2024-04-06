using Blazored.LocalStorage;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Tangy_Models;
using TangyWeb_Client.Pages.CartDetails;
using TangyWeb_Client.Service.IService;
using TangyWeb_Client.ViewModels;

namespace Client.Test
{
    public class CartTests : TestContext
    {
        [Fact]
        public void RendersEmptyCartMessageWhenShoppingCartIsEmpty()
        {
            // Arrange
            Services.AddSingleton(Mock.Of<ILocalStorageService>());
            Services.AddSingleton(Mock.Of<IProductService>());
            Services.AddSingleton(Mock.Of<ICartService>());

            // Act
            var cut = RenderComponent<Cart>();

            // Assert
            cut.MarkupMatches("<div>Please add items to Shopping Cart...</div>");
        }


        [Fact]
        public async Task IncrementButtonShouldCallIncrementMethod()
        {
            // Arrange
            var cartServiceMock = new Mock<ICartService>();
            var productServiceMock = new Mock<IProductService>();

            // Mock the shopping cart data with at least one item
            var mockShoppingCart = new List<ShoppingCart>
                {
                    new ShoppingCart()
                };

            // Setup the mock to return the mock shopping cart data
            productServiceMock.Setup(mock => mock.GetAll()).ReturnsAsync(new List<ProductDTO>());

            Services.AddSingleton(Mock.Of<ILocalStorageService>());
            Services.AddSingleton(productServiceMock.Object); // Add productServiceMock to the services
            Services.AddSingleton(cartServiceMock.Object);

            var cut = RenderComponent<Cart>();

            // Act
            await cut.Find("button.btn-primary").ClickAsync(new MouseEventArgs()); // Provide MouseEventArgs

            // Assert
            cartServiceMock.Verify(mock => mock.IncrementCart(It.IsAny<ShoppingCart>()), Times.Once);
        }



        // Similarly, write tests for DecrementButtonShouldCallDecrementMethod and DeleteButtonShouldCallDecrementMethod
        [Fact]
        public async Task DecrementButtonShouldCallDecrementMethod()
        {
            // Arrange
            var cartServiceMock = new Mock<ICartService>();
            var productServiceMock = new Mock<IProductService>();

            // Mock the shopping cart data with at least one item
            var mockShoppingCart = new List<ShoppingCart>
                {
                    new ShoppingCart()
                };

            // Setup the mock to return the mock shopping cart data
            productServiceMock.Setup(mock => mock.GetAll()).ReturnsAsync(new List<ProductDTO>());

            Services.AddSingleton(Mock.Of<ILocalStorageService>());
            Services.AddSingleton(productServiceMock.Object); // Add productServiceMock to the services
            Services.AddSingleton(cartServiceMock.Object);

            var cut = RenderComponent<Cart>();

            // Act
            await cut.Find("button.btn-warning").ClickAsync(new MouseEventArgs()); // Provide MouseEventArgs

            // Assert
            cartServiceMock.Verify(mock => mock.DecrementCart(It.IsAny<ShoppingCart>()), Times.Once);
        }


        [Fact]
        public async Task OnInitializedAsyncShouldLoadCart()
        {
            // Arrange
            var localStorageMock = new Mock<ILocalStorageService>();
            var productServiceMock = new Mock<IProductService>();
            var cartServiceMock = new Mock<ICartService>();

            Services.AddSingleton(localStorageMock.Object);
            Services.AddSingleton(productServiceMock.Object);
            Services.AddSingleton(cartServiceMock.Object);

            // Act
            var cut = RenderComponent<Cart>();

            // Assert
            await Task.Delay(500); // Delay to let OnInitializedAsync complete
            productServiceMock.Verify(mock => mock.GetAll(), Times.Once);
        }
    }
}
