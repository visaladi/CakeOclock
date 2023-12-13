using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICustomOrderRepository
    {
        public Task<CustomOrderDTO> Get(int id);
        public Task<IEnumerable<CustomOrderDTO>> GetAll(string? userId = null, string? status = null);
        public Task<CustomOrderDTO> Create(CustomOrderDTO objDTO);
        public Task<int> Delete(int id);

        public Task<CustomOrderHeaderDTO> UpdateHeader(CustomOrderHeaderDTO objDTO);

        public Task<CustomOrderHeaderDTO> MarkPaymentSuccessful(int id, string paymentIntentId);
        public Task<bool> UpdateOrderStatus(int orderId, string status);

        public Task<CustomOrderHeaderDTO> CancelOrder(int id);
    }
}