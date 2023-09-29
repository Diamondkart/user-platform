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
    }
}