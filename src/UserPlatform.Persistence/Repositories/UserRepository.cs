using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserDetails> Create(UserDetails userDetails)
        {
            return userDetails;
        }
    }
}