using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface ICustomerService
    {
        Task<List<GetCustomerResponse>> GetCustomers();
        Task<GetCustomerResponse> GetCustomerById(int customerId);
    }
}