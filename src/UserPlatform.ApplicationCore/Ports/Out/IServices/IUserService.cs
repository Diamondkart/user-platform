using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface IUserService
    {
        Task<CreateUserResponse> Create(CreateUserRequest createUserRequest);

        Task<GetByUserNameResponse> GetByUserName(string userName);

        Task<GetByUserIdResponse> GetByUserId(Guid userId);
    }
}