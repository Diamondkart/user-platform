using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUserRequest createUserRequest);

        Task<GetByUserNameResponse> GetByUserNameAsync(string userName);

        Task<GetByUserIdResponse> GetByUserByUserIdAsync(Guid userId);

        Task<IEnumerable<GetUsersResponse>> GetUsersAsync();

        Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest updateUserRequest);

        Task<bool> UpdatePhoneNumberAsync(UpdatePhoneNumberRequest updatePhoneNumberRequest);

        Task<bool> UpdateNameAsync(UpdateNameRequest updateNameRequest);
    }
}