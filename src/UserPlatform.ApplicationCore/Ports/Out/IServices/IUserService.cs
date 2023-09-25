using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUserRequest createUserRequest);

        Task<GetByUserNameResponse> GetByUserNameAsync(string userName);

        Task<GetByUserIdResponse> GetByUserIdAsync(Guid userId);
    }
}