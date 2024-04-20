using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tangy_Models;
using TangyWeb_Client.Helper;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Pages.Products
{
    public partial class Details
    {
        [Parameter]
        public int ProductId { get; set; }

        public ProductDTO Product { get; set; } = new();
        public bool IsProcessing { get; set; } = false;
        public DetailsVM DetailsVM { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsProcessing = true;
            Product = await _productService.Get(ProductId);
            IsProcessing = false;
        }

        private async Task SelectedProductPrice(MouseEventArgs e, int productPriceId)
        {
            DetailsVM.ProductPrice = Product.ProductPrices.FirstOrDefault(u => u.Id == productPriceId);
            DetailsVM.SelectedProductPriceId = productPriceId;
        }

        private async Task AddToCart()
        {
            ShoppingCart shoppingCart = new()
            {
                Count = DetailsVM.Count,
                ProductId = ProductId,
                ProductPriceId = DetailsVM.SelectedProductPriceId
            };

            await _cartService.IncrementCart(shoppingCart);
            _navigationManager.NavigateTo("/ProductsPage");
            await _jsRuntime.ToastrSuccess("Product added to cart successfully!");
        }
    }
}
