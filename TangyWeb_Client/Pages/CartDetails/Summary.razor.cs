using Microsoft.JSInterop;
using Tangy_Common;
using Tangy_Models;
using TangyWeb_Client.Helper;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Pages.CartDetails
{
    public partial class Summary
    {
        private OrderDTO Order { get; set; } = null;
        public bool IsProcessing { get; set; } = false;
        private IEnumerable<ProductDTO> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsProcessing = true;

                List<ShoppingCart> cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
                // if (Products == null || Order == null)
                // {
                //     cart = new List<ShoppingCart>();
                // }
                Products = await _productService.GetAll();

                Order = new()
                {
                    OrderHeader = new()
                    {
                        OrderTotal = 0,
                        Status = SD.Status_Pending
                    },
                    OrderDetails = new List<OrderDetailDTO>()
                };

                foreach (var item in cart)
                {
                    ProductDTO product = Products?.FirstOrDefault(u => u.Id == item.ProductId);
                    ProductPriceDTO productPrice = product?.ProductPrices?.FirstOrDefault(u => u.Id == item.ProductPriceId);

                    if (product != null && productPrice != null)
                    {
                        OrderDetailDTO orderDetailDTO = new()
                        {
                            ProductId = item.ProductId,
                            Size = productPrice.Size,
                            Count = item.Count,
                            Price = productPrice.Price,
                            ProductName = product.Name,
                            Product = product,
                        };

                        Order.OrderDetails.Add(orderDetailDTO);
                        Order.OrderHeader.OrderTotal += (item.Count * productPrice.Price);
                    }
                }

                if (await _localStorage.GetItemAsync<UserDTO>(SD.Local_UserDetails) != null)
                {
                    var userInfo = await _localStorage.GetItemAsync<UserDTO>(SD.Local_UserDetails);
                    Order.OrderHeader.UserId = userInfo.Id;
                    Order.OrderHeader.Name = userInfo.Name;
                    Order.OrderHeader.Email = userInfo.Email;
                    Order.OrderHeader.PhoneNumber = userInfo.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                // Handle exception here, e.g., logging or displaying an error message
                // You can also rethrow the exception if you want it to be caught elsewhere
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                IsProcessing = false;
            }
        }


        private async Task ConfirmOrderNow()
        {
            try
            {
                IsProcessing = true;


                // Update the order details or any other logic as needed
                Order.OrderHeader.Status = SD.Status_Pending;

                // Create a DTO to represent the order details if needed
                var orderDTO = new OrderDTO
                {
                    OrderHeader = Order.OrderHeader,
                    OrderDetails = Order.OrderDetails.ToList()
                };

                var result = await _orderService.Make(orderDTO);

                await _localStorage.SetItemAsync(SD.Local_OrderDetails, result);

                // Additional logic if needed after confirming the order directly
                if (result.OrderHeader != null || result.OrderDetails != null)
                {
                    await _jsRuntime.ToastrSuccess("Order Placed successfully");
                    _navigationManager.NavigateTo("/orderconfirmation");
                }
                else
                {
                    await _jsRuntime.ToastrFailure("Faild to Place the Order! Please fill the nessary information...!");
                }


            }
            catch (Exception e)
            {
                await _jsRuntime.ToastrFailure(e.Message);
            }
            finally
            {
                IsProcessing = false;
            }
        }

        private async Task HandleCheckout()
        {
            try
            {


                IsProcessing = true;
                var paymentDto = new StripePaymentDTO()
                {
                    Order = Order
                };



                var result = await _paymentService.Checkout(paymentDto);

                Order.OrderHeader.SessionId = result.Data.ToString();

                var orderDTOSaved = await _orderService.Create(paymentDto);

                //     var StripeSessionAndPI = result.Data.ToString().Split(';');

                //     Order.OrderHeader.SessionId = StripeSessionAndPI[0];
                //     Order.OrderHeader.PaymentIntentId = StripeSessionAndPI[1];

                //

                await _localStorage.SetItemAsync(SD.Local_OrderDetails, orderDTOSaved);

                await _jsRuntime.InvokeVoidAsync("redirectToCheckout", result.Data.ToString());
            }
            catch (Exception e)
            {
                await _jsRuntime.ToastrFailure(e.Message);
            }
        }
    }
}
