using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICacheService _cacheService;

        public CustomerService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<GetCustomerResponse> GetCustomerById(int customerId)
        {
            var value=await _cacheService.GetOrCreateAsync("customer_" + customerId, factory: async (ct) =>
            {
                // You can call here dao layer method.
                return new GetCustomerResponse { ID = Guid.NewGuid(), CustomerName = "Customer " + customerId };
            });

            return value;
        }

        public async Task<List<GetCustomerResponse>> GetCustomers()
        {
            var customers = new List<GetCustomerResponse>()
            {
                new GetCustomerResponse { ID=Guid.NewGuid(), CustomerName="efdqfwef" },
                new GetCustomerResponse { ID=Guid.NewGuid(), CustomerName="fwfeef efef" },
                new GetCustomerResponse { ID=Guid.NewGuid(), CustomerName="ewewew ewewe" },
                new GetCustomerResponse { ID=Guid.NewGuid(), CustomerName="rrtrtr ioa" },
            };
            return customers;
        }
    }
}