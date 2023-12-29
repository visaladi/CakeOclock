using Microsoft.AspNetCore.Mvc;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;

namespace TangyWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomProductController : ControllerBase
    {
        private readonly ICustomProductRepository _customProductRepository;

        public CustomProductController(ICustomProductRepository customProductRepository)
        {
            _customProductRepository = customProductRepository;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customProductRepository.GetAll());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int? productId)
        {
            if(productId == null || productId == 0) 
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage="Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var product = await _customProductRepository.Get(productId.Value);

            if(product == null)
            {

                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(product);
        }
    }
}
