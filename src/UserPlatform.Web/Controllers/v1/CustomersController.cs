using Microsoft.AspNetCore.Mvc;
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
        [Route("{customerId:int}", Name = "GetByCustomerId")]
        public async Task<IActionResult> GetCustomers(int customerId)
        {
            var value = await _customerService.GetCustomerById(customerId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers()
        {
            var customer = new GetCustomerResponse
            {
                ID = Guid.NewGuid(),
                CustomerName = "John Doe",
            };


            await _cacheService.SetAsync("customer_100", customer);
            return Created();
        }
    }
}