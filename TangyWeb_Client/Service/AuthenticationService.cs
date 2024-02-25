using Blazored.LocalStorage;
using Newtonsoft.Json;
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

        public AuthenticationService(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
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

        public async Task<bool> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var content = JsonConvert.SerializeObject(forgotPasswordDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/forgotpassword", bodyContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var content = JsonConvert.SerializeObject(resetPasswordDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/resetpassword", bodyContent);
            return response.IsSuccessStatusCode;
        }
    }
}
