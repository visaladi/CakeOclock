using Microsoft.AspNetCore.Components.Web;
using Tangy_Models;

namespace TangyWeb_Client.Pages.Products
{
    public partial class ProductsPage
    {
        public bool IsProcessing { get; set; } = false;
        public IEnumerable<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public IEnumerable<ProductDTO> FilteredProducts { get; set; } = new List<ProductDTO>();
        private string selectedCategory = null;
        private string searchTerm = "";

        protected override async Task OnInitializedAsync()
        {
            IsProcessing = true;
            Products = await _productService.GetAll();
            FilteredProducts = Products; // Initially display all products
            IsProcessing = false;
        }

        private async Task CategoryClicked(string categoryName)
        {
            selectedCategory = categoryName;
            await FilterProducts();
        }

        private async Task ShowAllProducts()
        {
            selectedCategory = null;
            await FilterProducts();
        }

        private async Task FilterProducts()
        {
            FilteredProducts = string.IsNullOrEmpty(searchTerm) ?
                (string.IsNullOrEmpty(selectedCategory) ? Products : Products.Where(p => p.Category.Name == selectedCategory)) :
                Products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        private async Task SearchKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await ShowAllProducts();
            }
        }

    }
}
