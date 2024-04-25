using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Tangy_Models;

namespace TangyWeb_Server.Pages.Product
{
    public partial class ProductPrice
    {
        [Parameter]
        public int Id { get; set; }
        private ProductDTO Product { get; set; } = new();
        private IEnumerable<ProductPriceDTO> ProductPrices { get; set; } = new List<ProductPriceDTO>();
        private bool IsLoading { get; set; } = true;
        public SfGrid<ProductPriceDTO> productPriceGrid;

        IEnumerable<String> SizeList = new List<String>()
    {
        "250g","750g","500g","1kg","1.5kg","2kg"
    };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                IsLoading = true;
                StateHasChanged();
                Product = await _productRepository.Get(Id);
                ProductPrices = await _productPriceRepository.GetAll(Id);
                IsLoading = false;
                StateHasChanged();
            }
        }

        public async void ActionHandler(ActionEventArgs<ProductPriceDTO> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                args.Data.ProductId = Id;
                if (args.Action == "Add")
                {
                    await _productPriceRepository.Create(args.Data);
                    ProductPrices = await _productPriceRepository.GetAll(Id);
                    productPriceGrid.Refresh();
                }
                if (args.Action == "Edit")
                {
                    await _productPriceRepository.Update(args.Data);
                }
            }
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                await _productPriceRepository.Delete(args.Data.Id);
                productPriceGrid.Refresh();

            }
        }
    }
}
