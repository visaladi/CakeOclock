using Tangy_Models;

namespace TangyWeb_Client.Service.IService
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAll(string? userId);

        public Task<IEnumerable<OrderDTO>> GetAllLoaded();

        public Task<IEnumerable<OrderDTO>> GetAllLoadedByEmail(string userEmail);

        public Task<IEnumerable<UserProfileDTO>> GetUserByEmail(string email);

        public Task<OrderDTO> Get(int orderId);

        public Task<OrderDTO> Create(StripePaymentDTO paymentDTO);

        public Task<OrderDTO> Make(OrderDTO orderDTO);

        public Task<OrderHeaderDTO> MarkPaymentSuccessful(OrderHeaderDTO orderHeader);
    }
}
