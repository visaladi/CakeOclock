using Microsoft.JSInterop;

namespace TangyWeb_Client.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr",  "success", message);
        }

        public static async ValueTask ToastrFailure(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        private static async ValueTask SweetAlertSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowSwal", "success", "Task completed successfully!");
        }

        private static async ValueTask SweetAlertFailure(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowSwal", "error", "Task Faild!");
        }
    }
}
 