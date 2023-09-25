using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Ports.Out.IRepositories
{
    public interface IUserRepository
    {
        Task<UserDetails> CreateAsync(UserDetails userDetails);
    }
}