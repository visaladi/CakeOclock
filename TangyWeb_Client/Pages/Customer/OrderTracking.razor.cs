using Tangy_Models;


namespace TangyWeb_Client.Pages.Customer
{
    public partial class OrderTracking
    {
        private IEnumerable<OrderHeaderDTO> OrderHeaders { get; set; } = new List<OrderHeaderDTO>();
        private IEnumerable<UserProfileDTO> userProfiles { get; set; } = new List<UserProfileDTO>();
        private bool IsLoading { get; set; } = false;

        private string LoggedInUserPhoneNumber { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadOrders();
            }
        }

        // private async Task LoadOrders()
        // {


        //     IsLoading = true;
        //     StateHasChanged();
        //     // var User = await _user.GetAuthenticationStateAsync();
        //     var Orders = await _orderService.GetAllLoaded();
        //     OrderHeaders = Orders.Select(u => u.OrderHeader);
        //     IsLoading = false;
        //     StateHasChanged();

        // }

        private async Task LoadOrders()
        {
            IsLoading = true;
            StateHasChanged();

            var userOrders = await _user.GetAuthenticationStateAsync();

            var Orders = await _orderService.GetAllLoadedByEmail(userOrders.User.Identity.Name);

            OrderHeaders = Orders.Select(u => u.OrderHeader);

            IsLoading = false;
            StateHasChanged();
        }
    }
}
