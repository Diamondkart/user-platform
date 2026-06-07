using Microsoft.AspNetCore.Mvc;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.ApplicationCore.Services;

namespace UserPlatform.Web.Controllers.v1
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICacheService _cacheService;

        public CustomersController(ICustomerService customerService, ICacheService cacheService)
        {
            _customerService = customerService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customerService.GetCustomers());
        }

        [HttpGet]
        [Route("{customerId:Guid}", Name = "GetByCustomerId")]
        public async Task<IActionResult> GetCustomers(Guid customerId)
        {
            var value = await _customerService.GetCustomerName(customerId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] GetCustomerRequest getCustomerRequest)
        {
            var responseBody = new GetCustomerResponse
            {
                ID = Guid.NewGuid(),
                CustomerName = getCustomerRequest.Name
            };
            await _cacheService.SetAsync($"customer:{responseBody.ID}", getCustomerRequest.Name);
            return Created("/", responseBody);
        }
    }
}