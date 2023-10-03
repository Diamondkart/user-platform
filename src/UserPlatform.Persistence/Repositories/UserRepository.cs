using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.Domain.Entities;
using UserPlatform.Persistence.DBStorage;

namespace UserPlatform.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserPlatformDBContex _dBContext;

        public UserRepository(UserPlatformDBContex context)
        {
            _dBContext = context;
        }

        public async Task<bool> CheckIfUserIsUnique(UserDetails userDetails)
        {
            var userExists = _dBContext.Users.Any(u => u.UserName == userDetails.UserName && u.FirstName == userDetails.FirstName && u.MobileNo == userDetails.MobileNo);
            return userExists;
        }

        public async Task<UserDetails> CreateAsync(UserDetails userDetails)
        {
            _dBContext.Users.Add(userDetails);
            await _dBContext.SaveChangesAsync();
            return userDetails;
        }

        public async Task<UserDetails> GetByUserNameAsync(string userName)
        {
            var result = _dBContext.Users.Where(w => w.UserName == userName).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task<UserDetails> GetUserByUserIdAsync(Guid userId)
        {
            var result = _dBContext.Users.Where(w => w.UserId == userId).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<UserDetails>> GetUsersAsync()
        {
            return await Task.FromResult(_dBContext.Users.ToList());
        }

        public async Task<UserDetails> UpdateAsync(UserDetails userDetails)
        {
            _dBContext.Users.Update(userDetails);
            await _dBContext.SaveChangesAsync();
            return userDetails;
        }
    }
}