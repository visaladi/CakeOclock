using Microsoft.JSInterop;
using Tangy_Models;

namespace TangyWeb_Client.Pages.Authentication
{
    public partial class ForgotPwd
    {
        private ResetPasswordDTO resetModel = new ResetPasswordDTO();
        private bool ShowErrors;
        private string Error = "";

        private async Task HandleForgotPassword()
        {
            ShowErrors = false;
            var result = await AuthService.ForgotPassword(resetModel);

            if (!result.Successful)
            {
                await JS.InvokeVoidAsync("ShowSwal", "error", "Task Faild!");
                Error = result.Error!;
                ShowErrors = true;
            }
            else
            {

                await JS.InvokeVoidAsync("ShowSwal", "success", "Password reset link has been sent to your email, please check it out!");
                Error = result.Error!;
                ShowErrors = true;
            }
        }
    }
}
