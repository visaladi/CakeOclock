using Tangy_Models;

namespace TangyWeb_Client.Serivce.IService
{
    public interface IAuthenticationService
    {
        Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequestDTO);
        Task<SignInResponseDTO> Login(SignInRequestDTO signInRequestDTO);
        Task Logout();
        Task<bool> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}
