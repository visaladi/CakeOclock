﻿using Tangy_Models;

namespace TangyWeb_Client.Serivce.IService
{
    public interface IAuthenticationService
    {
        Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequestDTO);
        Task<SignInResponseDTO> Login(SignInRequestDTO signInRequestDTO);
        Task Logout();
        Task<LoginResultDTO> ForgotPassword(ResetPasswordDTO model);
        Task<LoginResultDTO> ResetForgotPassword(ResetPasswordDTO model);
    }
}
