using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;
using Tangy_Models;

namespace TangyWeb_Client.Pages.Authentication
{
    public partial class ResetPwd
    {
        public string? Email;
        public string? Token;

        private string Message = string.Empty;
        ResetPasswordDTO resetPasswordDTO = new ResetPasswordDTO();
        private bool ShowErrors;
        private string? Errors;

        private async Task HandleResetPassword()
        {
            ShowErrors = false;
            Message = "Please Wait...";

            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            var queryStrings = QueryHelpers.ParseQuery(uri.Query);
            if (queryStrings.TryGetValue("email", out var email))
            {
                Email = email;
            }
            if (queryStrings.TryGetValue("token", out var token))
            {
                Token = token;
            }

            resetPasswordDTO.Email = email;
            resetPasswordDTO.Token = token;

            var result = await AuthService.ResetForgotPassword(resetPasswordDTO);

            if (result.Successful)
            {
                await JS.InvokeVoidAsync("ShowSwal", "success", "You Have Reset the Password Successfully!");
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                await JS.InvokeVoidAsync("ShowSwal", "error", "Task Faild!");
                Errors = "Something went wrong.";
                ShowErrors = true;
            }
        }
    }
}
