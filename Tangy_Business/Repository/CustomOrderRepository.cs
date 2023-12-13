using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_Common;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_DataAccess.ViewModel;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CustomOrderRepository : ICustomOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomOrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CustomOrderHeaderDTO> CancelOrder(int id)
        {
            var customOrderHeader = await _db.CustomOrderHeaders.FindAsync(id);
            if (customOrderHeader == null)
            {
                return new CustomOrderHeaderDTO();
            }

            if (customOrderHeader.Status == SD.Status_Pending)
            {
                customOrderHeader.Status = SD.Status_Cancelled;
                await _db.SaveChangesAsync();
            }
            if (customOrderHeader.Status == SD.Status_Confirmed)
            {
                //refund
                var options = new Stripe.RefundCreateOptions
                {
                    Reason = Stripe.RefundReasons.RequestedByCustomer,
                    PaymentIntent = customOrderHeader.PaymentIntentId
                };

                var service = new Stripe.RefundService();
                Stripe.Refund refund = service.Create(options);

                customOrderHeader.Status = SD.Status_Refunded;
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<CustomOrderHeader, CustomOrderHeaderDTO>(customOrderHeader);
        }

        public async Task<CustomOrderDTO> Create(CustomOrderDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<CustomOrderDTO, CustomOrder>(objDTO);
                _db.CustomOrderHeaders.Add(obj.CustomOrderHeader);
                await _db.SaveChangesAsync();

                foreach (var details in obj.CustomOrderDetails)
                {
                    details.CustomOrderHeaderId = obj.CustomOrderHeader.Id;                  
                    
                }
                _db.CustomOrderDetails.AddRange(obj.CustomOrderDetails);
                await _db.SaveChangesAsync();

                return new CustomOrderDTO()
                {
                    CustomOrderHeader = _mapper.Map<CustomOrderHeader, CustomOrderHeaderDTO>(obj.CustomOrderHeader),
                    CustomOrderDetails = _mapper.Map<IEnumerable<CustomOrderDetail>, IEnumerable<CustomOrderDetailDTO>>(obj.CustomOrderDetails).ToList()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDTO;
        }

        public async Task<int> Delete(int id)
        {
            var objHeader = await _db.CustomOrderHeaders.FirstOrDefaultAsync(u => u.Id == id);
            if (objHeader != null)
            {
                IEnumerable<CustomOrderDetail> objDetail = _db.CustomOrderDetails.Where(u => u.CustomOrderHeaderId == id);

                _db.CustomOrderDetails.RemoveRange(objDetail);
                _db.CustomOrderHeaders.Remove(objHeader);
                return _db.SaveChanges();
            }
            return 0;
        }

        public async Task<CustomOrderDTO> Get(int id)
        {
            CustomOrder order = new()
            {
                CustomOrderHeader = _db.CustomOrderHeaders.FirstOrDefault(u => u.Id == id),
                CustomOrderDetails = _db.CustomOrderDetails.Where(u => u.CustomOrderHeaderId == id),
            };
            if(order != null)
            {
                return _mapper.Map<CustomOrder, CustomOrderDTO>(order);
            }
            return new CustomOrderDTO();
        }

        public async Task<IEnumerable<CustomOrderDTO>> GetAll(string? userId = null, string? status = null)
        {
            List<CustomOrder> CustomOrderFromDb = new List<CustomOrder>();
            IEnumerable<CustomOrderHeader> customOrderHeaderList = _db.CustomOrderHeaders;
            IEnumerable<CustomOrderDetail> customOrderDetailsList = _db.CustomOrderDetails;

            foreach (CustomOrderHeader header in customOrderHeaderList)
            {
                CustomOrder customOrder = new()
                {
                    CustomOrderHeader = header,
                    CustomOrderDetails = customOrderDetailsList.Where(u => u.CustomOrderHeaderId == header.Id),
                };
                CustomOrderFromDb.Add(customOrder);
            }
            // do some filtering # TODO
            return _mapper.Map<IEnumerable<CustomOrder>, IEnumerable<CustomOrderDTO>>(CustomOrderFromDb);
        }

        public async Task<CustomOrderHeaderDTO> MarkPaymentSuccessful(int id, string paymentIntentId)
        {
            var data = await _db.CustomOrderHeaders.FindAsync(id);
            if(data == null) 
            {
                return new CustomOrderHeaderDTO();
            }
            if(data.Status == SD.Status_Pending)
            {
                data.PaymentIntentId = paymentIntentId;
                data.Status = SD.Status_Confirmed;
                await _db.SaveChangesAsync();
                return _mapper.Map<CustomOrderHeader,CustomOrderHeaderDTO>(data);
            }
            return new CustomOrderHeaderDTO();
        }

        public async Task<CustomOrderHeaderDTO> UpdateHeader(CustomOrderHeaderDTO objDTO)
        {
            if(objDTO != null)
            {
                var customOrderHeaderFromDb = _db.CustomOrderHeaders.FirstOrDefault(u => u.Id == objDTO.Id);
                customOrderHeaderFromDb.Name = objDTO.Name;
                customOrderHeaderFromDb.PhoneNumber = objDTO.PhoneNumber;
                customOrderHeaderFromDb.Carrier = objDTO.Carrier;
                customOrderHeaderFromDb.Tracking = objDTO.Tracking;
                customOrderHeaderFromDb.StreetAddress = objDTO.StreetAddress;
                customOrderHeaderFromDb.City = objDTO.City;
                customOrderHeaderFromDb.State = objDTO.State;
                customOrderHeaderFromDb.PostalCode = objDTO.PostalCode;
                customOrderHeaderFromDb.Status = objDTO.Status;

                await _db.SaveChangesAsync();
                return _mapper.Map<CustomOrderHeader, CustomOrderHeaderDTO>(customOrderHeaderFromDb);
            }
            return new CustomOrderHeaderDTO();
        }

        public async Task<bool> UpdateOrderStatus(int orderId, string status)
        {
            var data = await _db.CustomOrderHeaders.FindAsync(orderId);
            if (data == null)
            {
                return false;
            }
            
            data.Status = status;

            if (status == SD.Status_Shipped) 
            { 
                data.ShippingDate = DateTime.Now;
            }

            await _db.SaveChangesAsync();
                return true;
            
        }
    }
}
