using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Ports.Out.IRepositories
{
    public interface IUserRepository
    {
        Task<UserDetails> CreateAsync(UserDetails userDetails);

        Task<IEnumerable<UserDetails>> GetUsersAsync();

        Task<bool> CheckIfUserIsUnique(UserDetails userDetails);

        Task<UserDetails> GetUserByUserIdAsync(Guid userId);

        Task<UserDetails> GetByUserNameAsync(string userName);

        Task<UserDetails> UpdateAsync(UserDetails updateUserRequest);

        Task<bool> UpdatePhoneNumberAsync(UserDetails updateUserRequest);

        Task<bool> UpdateNameAsync(UserDetails updateUserRequest);

        Task<UserDetails> GetUserByEmailAsync(string email);
        Task<bool> VerifyUserCredAsync(UserDetails userDetails);

    }
}