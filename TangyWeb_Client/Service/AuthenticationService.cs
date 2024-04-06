using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Tangy_Common;
using Tangy_Models;
using TangyWeb_Client.Serivce.IService;

namespace TangyWeb_Client.Serivce
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        

        public async Task<SignInResponseDTO> Login(SignInRequestDTO signInRequest)
        {
            var content = JsonConvert.SerializeObject(signInRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signin", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignInResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync(SD.Local_Token, result.Token);
                await _localStorage.SetItemAsync(SD.Local_UserDetails, result.UserDTO);
                ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Token);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return new SignInResponseDTO() { IsAuthSuccessful = true };
            }
            else
            {
                return result;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(SD.Local_Token);
            await _localStorage.RemoveItemAsync(SD.Local_UserDetails);

            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequest)
        {
            var content = JsonConvert.SerializeObject(signUpRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signup", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignUpResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                return new SignUpResponseDTO { IsRegisterationSuccessful = true };
            }
            else
            {
                return new SignUpResponseDTO { IsRegisterationSuccessful = false, Errors = result.Errors };
            }
        }

        public async Task<LoginResultDTO> ForgotPassword(ResetPasswordDTO model)
        {
            var content = JsonConvert.SerializeObject(model);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/ForgotPassword", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResultDTO>(contentTemp);

            //var result = await _client.PostAsJsonAsync("api/account/ForgotPassword", model);


            //if (!result.IsSuccessStatusCode)
            if (!response.IsSuccessStatusCode)
                return new LoginResultDTO { Successful = false, Error = result.Error+"Something went wrong!" };
            return new LoginResultDTO
            { 
                Successful = true,
                Error = "Password reset link has been sent to your email, please check it out!",
                
            };
        }

        public async Task<LoginResultDTO> ResetForgotPassword(ResetPasswordDTO model)
        {
            var result = await _client.PostAsJsonAsync("api/account/ResetForgotPassword", model);
            if (!result.IsSuccessStatusCode)
                return new LoginResultDTO { Successful = false };
            return new LoginResultDTO { Successful = true };
        }

        //public async Task<LoginResultDTO> ResetForgotPassword(ResetPasswordDTO model)
        //{
        //    var content = JsonConvert.SerializeObject(model);
        //    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        //    var response = await _client.PostAsync("api/account/ResetForgotPassword", bodyContent);
        //    var contentTemp = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<LoginResultDTO>(contentTemp);

        //    //var result = await _client.PostAsJsonAsync("api/account/ResetForgotPassword", model);
        //    if (!response.IsSuccessStatusCode)
        //        return new LoginResultDTO { Successful = false , Error = result.Error};
        //    return new LoginResultDTO
        //    { 
        //        Successful = true,                
        //    };
        //}
                
    }
}
