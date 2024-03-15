using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;

namespace TangyWeb_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailSender _emailSender;

        public OrderController(IOrderRepository orderRepository, IEmailSender emailSender)
        {
            _orderRepository = orderRepository;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderRepository.GetAll());
        }

        [HttpGet("{orderHeaderId}")]
        public async Task<IActionResult> Get(int? orderHeaderId)
        {
            if (orderHeaderId == null || orderHeaderId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var orderHeader = await _orderRepository.Get(orderHeaderId.Value);
            if (orderHeader == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(orderHeader);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] OrderDTO orderDTO)
        {
            // Assuming that the orderDTO is already validated and contains necessary information
            orderDTO.OrderHeader.OrderDate = DateTime.Now;

            var result = await _orderRepository.Create(orderDTO);

            if (result != null)
            {
                await _emailSender.SendEmailAsync(orderDTO.OrderHeader.Email, "Cake'O Clock Order Confirmation",
                    "New Order has been created: " + orderDTO.OrderHeader.Id); // + 

                return Ok(result);
            }

            return BadRequest(new ErrorModelDTO()
            {
                ErrorMessage = "Failed to create the order"
            });
        }

        [HttpPost]
        [ActionName("paymentsuccessful")]
        public async Task<IActionResult> PaymentSuccessful([FromBody] OrderHeaderDTO orderHeaderDTO)
        {
            var service = new SessionService();
            var sessionDetails = service.Get(orderHeaderDTO.SessionId);

            if (sessionDetails.PaymentStatus == "paid")
            {
                var result = await _orderRepository.MarkPaymentSuccessful(orderHeaderDTO.Id, sessionDetails.PaymentIntentId);

                if (result != null)
                {
                    await _emailSender.SendEmailAsync(orderHeaderDTO.Email, "Cake'O Clock Order Confirmation",
                        "New Order has been created: " + result.Id);

                    return Ok(result);
                }

                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Can not mark payment as successful"
                });
            }

            return BadRequest();
        }
    }
}
