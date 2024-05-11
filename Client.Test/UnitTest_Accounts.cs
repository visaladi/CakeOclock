using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Tangy_DataAccess;
using Tangy_Models;
using TangyWeb_API.Controllers;
using TangyWeb_API.Helper;
using TangyWeb_API.RepositoriesService.IRepositoryService;

namespace TangyWeb_API.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;
        private readonly Mock<SignInManager<ApplicationUser>> _mockSignInManager;
        private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly IConfiguration _mockConfiguration;
        private readonly IOptions<APISettings> _mockOptions;

        public AccountControllerTests()
        {
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            _mockSignInManager = new Mock<SignInManager<ApplicationUser>>(_mockUserManager.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(), null, null, null, null);
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            _mockEmailService = new Mock<IEmailService>();
            _mockConfiguration = Mock.Of<IConfiguration>();
            _mockOptions = Options.Create(new APISettings());

            // Ensure the SignInManager returns success for default setup
            _mockSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
        }

        [Fact]
        public async Task SignUp_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);

            // Ensure model state is invalid
            controller.ModelState.AddModelError("Test", "Test error");

            // Act
            var result = await controller.SignUp(signUpRequestDTO: null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task SignUp_ReturnsBadRequest_WhenUserCreationFails()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var signUpRequestDTO = new SignUpRequestDTO();

            // Mock user creation failure
            _mockUserManager.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Test error" }));

            // Act
            var result = await controller.SignUp(signUpRequestDTO);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var signUpResponseDTO = Assert.IsType<SignUpResponseDTO>(badRequestResult.Value);
            Assert.False(signUpResponseDTO.IsRegisterationSuccessful);
            Assert.Single(signUpResponseDTO.Errors);
        }

        // Similar tests can be added for other action methods
        // Testing SignIn, ForgotPassword, ResetForgotPassword, GetUserProfile...
    }
}
