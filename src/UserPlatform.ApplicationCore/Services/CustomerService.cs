using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
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