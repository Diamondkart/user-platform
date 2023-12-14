using Microsoft.EntityFrameworkCore;
using UserPlatform.ApplicationCore.Models.Request;
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
            var result = _dBContext.Users.AsNoTracking()
                .Where(w => w.UserName == userName).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task<UserDetails> GetUserByUserIdAsync(Guid userId)
        {
            var result = _dBContext.Users.AsNoTracking()
                .Where(w => w.UserId == userId)?.FirstOrDefault();
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

        public async Task<bool> UpdateNameAsync(UserDetails updateUserRequest)
        {
            _dBContext.Attach(updateUserRequest);
            _dBContext.Entry(updateUserRequest).Property(e => e.FirstName).IsModified = true;
            _dBContext.Entry(updateUserRequest).Property(e => e.LastName).IsModified = true;
            _dBContext.Entry(updateUserRequest).Property(e => e.MiddleName).IsModified = true;
            var isUpdated = await _dBContext.SaveChangesAsync();
            return isUpdated == 1;
        }

        public async Task<bool> UpdatePhoneNumberAsync(UserDetails updateUserRequest)
        {
            _dBContext.Users.Attach(updateUserRequest);
            _dBContext.Entry(updateUserRequest).Property(e => e.MobileNo).IsModified = true;
            var isUpdated = await _dBContext.SaveChangesAsync();
            return isUpdated == 1;
        }

        public async Task<UserDetails> GetUserByEmailAsync(string email)
        {
            var result = _dBContext.Users.AsNoTracking()
                .Where(w => w.Email == email)?.FirstOrDefault();
            return await Task.FromResult(result);
        }
        
        public async Task<bool> VerifyUserCredAsync(UserDetails userDetails)
        {
            var userExists = _dBContext.Users.Any(u => u.UserName == userDetails.UserName && u.Password == userDetails.Password);
            return userExists;
        }
    }
}