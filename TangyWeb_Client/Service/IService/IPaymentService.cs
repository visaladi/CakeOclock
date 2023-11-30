using Tangy_Models;

namespace TangyWeb_Client.Serivce.IService
{
    public interface IPaymentService
    {
        public Task<SuccessModelDTO> Checkout(StripePaymentDTO model);
        
    }
}