using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Tangy_Models;
using TangyWeb_Server.Helper;

namespace TangyWeb_Server.Pages.Product
{
    public partial class ProductList
    {
        private IEnumerable<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public bool IsLoading { get; set; }
        private int DeleteProductId { get; set; } = 0;

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationState;
            if (!authState.User.Identity.IsAuthenticated)
            {
                var uri = new Uri(_navigationManager.Uri);
                _navigationManager.NavigateTo($"identity/account/login?returnUrl={uri.LocalPath}", forceLoad: true);
            }
            else
            {
                if (!authState.User.IsInRole(Tangy_Common.SD.Role_Admin))
                {
                    _navigationManager.NavigateTo("/ErrorPage");
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadProducts();
            }
        }

        private async Task LoadProducts()
        {
            IsLoading = true;
            StateHasChanged();
            Products = await _productRepository.GetAll();
            IsLoading = false;
            StateHasChanged();
        }

        private void HandleDelete(int id)
        {
            DeleteProductId = id;
            _jsRuntime.InvokeVoidAsync("ShowDeleteConfiremationModel");
        }

        public async Task ConfirmDeleteClick(bool isConfirmed)
        {
            IsLoading = true;
            if (isConfirmed && DeleteProductId != 0)
            {
                //delete
                //await Task.Delay(5000);
                ProductDTO product = await _productRepository.Get(DeleteProductId);
                if (!product.ImageUrl.Contains("default.png"))
                {
                    _fileUpload.DeleteFile(product.ImageUrl);
                }
                await _productRepository.Delete(DeleteProductId);
                await _jsRuntime.ToastrSuccess("Product Deleted Successfully");
                await LoadProducts(); ;
                await _jsRuntime.InvokeVoidAsync("HideDeleteConfiremationModel");
            }
            IsLoading = false;
        }
    }
}
