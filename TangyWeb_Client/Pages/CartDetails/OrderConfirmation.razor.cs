using Tangy_Common;
using Tangy_Models;



namespace TangyWeb_Client.Pages.CartDetails
{
    public partial class OrderConfirmation
    {
        private bool IsProcessing { get; set; } = false;
        private OrderDTO Order { get; set; }
        private OrderHeaderDTO OrderHead { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsProcessing = true;
            Order = await _localStorage.GetItemAsync<OrderDTO>(SD.Local_OrderDetails);

            // Check if Order is not null and OrderHeader is not null
            if (Order != null && Order.OrderHeader != null)
            {
                OrderHead = Order.OrderHeader;


                if (OrderHead.SessionId == null)
                {
                    Order.OrderHeader.Status = SD.Status_Pending;
                    await _localStorage.RemoveItemAsync(SD.ShoppingCart);
                    await _localStorage.RemoveItemAsync(SD.Local_OrderDetails);
                }
                // else
                // {
                //     var updatedOrder = await _orderService.MarkPaymentSuccessful(Order.OrderHeader);
                //     if (updatedOrder.Status == SD.Status_Confirmed)
                //     {
                //         Order.OrderHeader.Status = updatedOrder.Status;
                //         await _localStorage.RemoveItemAsync(SD.ShoppingCart);
                //         await _localStorage.RemoveItemAsync(SD.Local_OrderDetails);
                //     }
                // }
            }

            IsProcessing = false;
        }

        private void ContinueShopping()
        {
            // Navigate to the "/" page
            _navigationManager.NavigateTo("/");

            // Refresh the page using JavaScript interop
            //_jSRuntime.InvokeVoidAsync("location.reload");
        }


        // var updatedOrder = await _orderService.MarkPaymentSuccessful(Order?.OrderHeader);

        // if (updatedOrder != null && updatedOrder.Status == SD.Status_Confirmed)
        // {
        //     if (Order?.OrderHeader != null)
        //     {
        //         Order.OrderHeader.Status = updatedOrder.Status;
        //     }

        //     if (_localStorage != null)
        //     {
        //         await _localStorage.RemoveItemAsync(SD.ShoppingCart);
        //         await _localStorage.RemoveItemAsync(SD.Local_OrderDetails);
        //     }
        // }
    }
}
