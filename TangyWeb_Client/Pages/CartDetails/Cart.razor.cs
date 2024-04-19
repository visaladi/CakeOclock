using Tangy_Common;
using Tangy_Models;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Pages.CartDetails
{
    public partial class Cart
    {
    public bool IsProcessing { get; set; } = false;
	private List<ShoppingCart> ShoppingCart = new List<ShoppingCart>();
	private IEnumerable<ProductDTO> Products { get; set; }
	private double OrderTotal { get; set; }


	protected override async Task OnInitializedAsync()
	{
		IsProcessing = true;
		ShoppingCart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
		Products = await _productService.GetAll();
		await LoadCart();
		IsProcessing = false;
	}

	private async Task LoadCart()
	{
		OrderTotal = 0;
		ShoppingCart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);

		if (ShoppingCart != null && Products != null)
		{
			foreach (var cart in ShoppingCart)
			{
				cart.Product = Products.FirstOrDefault(u => u.Id == cart.ProductId);
				if (cart.Product != null && cart.Product.ProductPrices != null)
				{
					cart.ProductPrice = cart.Product.ProductPrices.FirstOrDefault(u => u.Id == cart.ProductPriceId);
					if (cart.ProductPrice != null)
					{
						OrderTotal += (cart.ProductPrice.Price * cart.Count);
					}
				}
			}
		}
	}

	private async Task Increment(int ProductId, int ProductPriceId, int Count)
	{
		IsProcessing = true;
		await _cartService.IncrementCart(new()
			{
				Count = Count,
				ProductId = ProductId,
				ProductPriceId = ProductPriceId
			});

		await LoadCart();
		IsProcessing = false;
	}

	private async Task Decrement(int ProductId, int ProductPriceId, int Count)
	{
		IsProcessing = true;
		await _cartService.DecrementCart(new()
			{
				Count = Count,
				ProductId = ProductId,
				ProductPriceId = ProductPriceId
			});

		await LoadCart();
		IsProcessing = false;
	}
    }
}
