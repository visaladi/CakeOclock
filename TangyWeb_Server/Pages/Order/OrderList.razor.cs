using Microsoft.JSInterop;
using Tangy_Models;

namespace TangyWeb_Server.Pages.Order
{
    public partial class OrderList
    {
        private string roleAdmin = Tangy_Common.SD.Role_Admin;

        private IEnumerable<OrderHeaderDTO> OrderHeaders { get; set; } = new List<OrderHeaderDTO>();
        private bool IsLoading { get; set; } = false;

        private int DeleteOrderId { get; set; } = 0;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadOrders();
            }
        }

        private async Task LoadOrders()
        {
            IsLoading = true;
            StateHasChanged();
            var Orders = await _orderRepository.GetAll();
            OrderHeaders = Orders.Select(u => u.OrderHeader);
            IsLoading = false;
            StateHasChanged();
        }

        private void OrderDetails(int id)
        {
            _navigationManager.NavigateTo("/order/details/" + id);
        }

        private void HandleDelete(int id)
        {
            DeleteOrderId = id;
            _jsRuntime.InvokeVoidAsync("ShowDeleteConfiremationModel");
        }

        private async Task DeleteOrder(bool isConfirmed)
        {
            IsLoading = true;
            if (isConfirmed && DeleteOrderId != 0)
            {
                //delete
                //await Task.Delay(5000);
                await _orderRepository.Delete(DeleteOrderId);
                await LoadOrders(); ;
                await _jsRuntime.InvokeVoidAsync("HideDeleteConfiremationModel");
            }
            IsLoading = false;
        }

    }
}
