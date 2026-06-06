using Microsoft.AspNetCore.Mvc;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.ApplicationCore.Services;

namespace UserPlatform.Web.Controllers.v1
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            
            return Ok(await _customerService.GetCustomers());
        }
    }
}