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

            
            _mockSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
            // Ensure the SignInManager returns success for default setup
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
            
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var signUpRequestDTO = new SignUpRequestDTO();

            // Mock user creation failure
            _mockUserManager.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Test error" }));

            var result = await controller.SignUp(signUpRequestDTO);

           
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var signUpResponseDTO = Assert.IsType<SignUpResponseDTO>(badRequestResult.Value);
            Assert.False(signUpResponseDTO.IsRegisterationSuccessful);
            Assert.Single(signUpResponseDTO.Errors);
        }

        

        [Fact]
        public async Task SignUp_ReturnsStatusCode201_WhenSignUpSuccessful()
        {
            
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var signUpRequestDTO = new SignUpRequestDTO();

            // Mock user creation and role assignment success
            _mockUserManager.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await controller.SignUp(signUpRequestDTO);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        // Similar tests can be added for SignIn, ForgotPassword, ResetForgotPassword, GetUserProfile...

        [Fact]
        public async Task SignIn_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);

            // Ensure model state is invalid
            controller.ModelState.AddModelError("Test", "Test error");

            // Act
            var result = await controller.SignIn(signInRequestDTO: null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task SignIn_ReturnsUnauthorized_WhenSignInFails()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var signInRequestDTO = new SignInRequestDTO();

            // Mock sign-in failure
            _mockSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            // Act
            var result = await controller.SignIn(signInRequestDTO);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var signInResponseDTO = Assert.IsType<SignInResponseDTO>(unauthorizedResult.Value);
            Assert.False(signInResponseDTO.IsAuthSuccessful);
            Assert.Equal("Invalid Authentication", signInResponseDTO.ErrorMessage);
        }

        [Fact]
        public async Task ForgotPassword_ReturnsBadRequest_WhenEmailIsNullOrEmpty()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO();

            // Act
            var result = await controller.ForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ForgotPassword_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = "test@example.com" };

            // Mock user not found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await controller.ForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // You can add more tests for other scenarios in ForgotPassword, ResetForgotPassword, and GetUserProfile methods

        [Fact]
        public async Task ResetForgotPassword_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO();

            // Act
            var result = await controller.ResetForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ResetForgotPassword_ReturnsBadRequest_WhenTokenIsInvalid()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = "test@example.com", Token = "invalidToken" };

            // Act
            var result = await controller.ResetForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ResetForgotPassword_ReturnsBadRequest_WhenResetPasswordFails()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = "test@example.com", Token = "validToken", NewPassword = "newPassword" };

            // Mock resetting password failure
            _mockUserManager.Setup(m => m.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed());

            // Act
            var result = await controller.ResetForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetUserProfile_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var userEmail = "nonexistent@example.com";

            // Mock user not found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await controller.GetUserProfile(userEmail);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetUserProfile_ReturnsUserProfile_WhenUserFound()
        {
            // Arrange
            var user = new ApplicationUser { Email = "test@example.com", Name = "Test User", PhoneNumber = "1234567890" };
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var userEmail = "test@example.com";

            // Mock user found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            // Act
            var result = await controller.GetUserProfile(userEmail);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var userProfile = Assert.IsType<UserProfileDTO>(okResult.Value);
            Assert.Equal(user.Name, userProfile.Name);
            Assert.Equal(user.Email, userProfile.Email);
            Assert.Equal(user.PhoneNumber, userProfile.PhoneNumber);
        }

        [Fact]
        public async Task ForgotPassword_ReturnsBadRequest_WhenEmailIsNull()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = null };

            // Act
            var result = await controller.ForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ResetForgotPassword_ReturnsBadRequest_WhenEmailOrTokenIsNull()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = null, Token = null };

            // Act
            var result = await controller.ResetForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ResetForgotPassword_ReturnsBadRequest_WhenUserNotFound()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = "nonexistent@example.com", Token = "validToken", NewPassword = "newPassword" };

            // Mock user not found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await controller.ResetForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task SignIn_ReturnsUnauthorized_WhenSignInFailsWithLockout()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var signInRequestDTO = new SignInRequestDTO { UserName = "test@example.com", Password = "password" };

            // Mock sign-in failure with lockout
            _mockSignInManager.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.LockedOut);

            // Act
            var result = await controller.SignIn(signInRequestDTO);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var signInResponseDTO = Assert.IsType<SignInResponseDTO>(unauthorizedResult.Value);
            Assert.False(signInResponseDTO.IsAuthSuccessful);
            Assert.Equal("Invalid Authentication", signInResponseDTO.ErrorMessage);
        }

        [Fact]
        public async Task SignUp_ReturnsBadRequest_WhenSignUpRequestIsNull()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);

            // Act
            var result = await controller.SignUp(signUpRequestDTO: null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetUserProfile_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);

            // Mock user not found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await controller.GetUserProfile("nonexistent@example.com");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetUserProfile_ReturnsOk_WhenUserExists()
        {
            // Arrange
            var user = new ApplicationUser { Email = "test@example.com", Name = "Test User", PhoneNumber = "1234567890" };
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);

            // Mock user found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            // Act
            var result = await controller.GetUserProfile("test@example.com");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var userProfile = Assert.IsType<UserProfileDTO>(okResult.Value);
            Assert.Equal(user.Name, userProfile.Name);
            Assert.Equal(user.Email, userProfile.Email);
            Assert.Equal(user.PhoneNumber, userProfile.PhoneNumber);
        }

        [Fact]
        public async Task ResetForgotPassword_ReturnsOk_WhenPasswordResetSuccessfully()
        {
            // Arrange
            var user = new ApplicationUser { Email = "test@example.com" };
            var controller = new AccountController(_mockConfiguration, _mockEmailService.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockRoleManager.Object, _mockOptions);
            var resetPasswordDTO = new ResetPasswordDTO { Email = "test@example.com", Token = "validToken", NewPassword = "newPassword" };

            // Mock user found
            _mockUserManager.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            // Mock password reset success
            _mockUserManager.Setup(m => m.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await controller.ResetForgotPassword(resetPasswordDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


    }
}
