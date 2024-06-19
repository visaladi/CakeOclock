using Microsoft.AspNetCore.Components;
using Tangy_Common;
using Tangy_Models;
using TangyWeb_Server.Helper;

namespace TangyWeb_Server.Pages.Order
{
    public partial class OrderDetails
    {
        [Parameter]
        public int Id { get; set; } = 0;
        public bool IsLoading { get; set; } = true;
        public OrderDTO Order { get; set; } = new();

        private string DownloadUrl;

        protected override void OnInitialized()
        {
            // Fetch the download URL from the configuration
            DownloadUrl = _configuration["Download_URL"];
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

                await LoadOrder();
            }
        }

        private async Task LoadOrder()
        {
            IsLoading = true;
            StateHasChanged();
            Order = await _orderRepository.Get(Id);
            // Initialize ShippingDate with today's date
            Order.OrderHeader.ShippingDate = DateTime.Now.Date;
            IsLoading = false;
            StateHasChanged();
        }

        private async Task UpdateOrder()
        {
            var OrderHeaderDTO = await _orderRepository.UpdateHeader(Order.OrderHeader);
            Order.OrderHeader = OrderHeaderDTO;
            await _jsRuntime.ToastrSuccess("Order has been updated successfully");
        }

        private async Task ShipOrder()
        {
            if (string.IsNullOrEmpty(Order.OrderHeader.Carrier) || string.IsNullOrEmpty(Order.OrderHeader.Tracking))
            {
                await _jsRuntime.ToastrFailure("Please Enter Tracking and Carrier Information");
                return;
            }



            Order.OrderHeader.Status = SD.Status_Shipped;
            var OrderHeaderDTO = await _orderRepository.UpdateHeader(Order.OrderHeader);
            Order.OrderHeader = OrderHeaderDTO;
            await _jsRuntime.ToastrSuccess("Order has been Shipped!");
        }

        private async Task ConfirmOrder()
        {

            Order.OrderHeader.Status = SD.Status_Confirmed;
            var OrderHeaderDTO = await _orderRepository.UpdateHeader(Order.OrderHeader);
            Order.OrderHeader = OrderHeaderDTO;
            await _jsRuntime.ToastrSuccess("Order has been Confirmed!");
        }

        private async Task OrderRecived()
        {

            Order.OrderHeader.Status = SD.Status_Recived;
            var OrderHeaderDTO = await _orderRepository.UpdateHeader(Order.OrderHeader);
            Order.OrderHeader = OrderHeaderDTO;
            await _jsRuntime.ToastrSuccess("Order has been Recived by the Nearest Branch!");
        }

        private async Task OrderDelivered()
        {

            Order.OrderHeader.Status = SD.Status_Delivered;
            var OrderHeaderDTO = await _orderRepository.UpdateHeader(Order.OrderHeader);
            Order.OrderHeader = OrderHeaderDTO;
            await _jsRuntime.ToastrSuccess("Order has been Delivered to the Customer!");
        }

        private async Task OrderCancel()
        {

            Order.OrderHeader.Status = SD.Status_Cancelled;
            var OrderHeaderDTO = await _orderRepository.UpdateHeader(Order.OrderHeader);
            Order.OrderHeader = OrderHeaderDTO;
            await _jsRuntime.ToastrSuccess("Order has been Canceled Successfully!");
        }

        // private async Task CancelOrder()
        // {
        //     Order.OrderHeader = await _orderRepository.CancelOrder(Order.OrderHeader.Id);
        //     if (Order.OrderHeader.Status == SD.Status_Cancelled)
        //     {
        //         _jsRuntime.ToastrSuccess("Order has been cancelled successfully");
        //     }
        //     if (Order.OrderHeader.Status == SD.Status_Refunded)
        //     {
        //         _jsRuntime.ToastrSuccess("Order has been cancelled & refunded successfully");
        //     }

        // }
    }
}
