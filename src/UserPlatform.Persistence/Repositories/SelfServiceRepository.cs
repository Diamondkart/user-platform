using Microsoft.EntityFrameworkCore;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.Domain.Entities;
using UserPlatform.Persistence.DBStorage;

namespace UserPlatform.Persistence.Repositories
{
    public class SelfServiceRepository : ISelfServiceRepository
    {
        private readonly UserPlatformDBContex _dBContext;

        public SelfServiceRepository(UserPlatformDBContex context)
        {
            _dBContext = context;
        }

        public async Task<ChangePassword> RequestChangePasswordAsync(ChangePassword changePassword)
        {
            _dBContext.ChangePassword.Add(changePassword);
            await _dBContext.SaveChangesAsync();
            return changePassword;
        }

        public Task<bool> GeneratePasswordAsync(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<ChangePassword> GetChangePasswordByTokenPasswordAsync(ChangePassword changePassword)
        {
            var changePasswordDb = _dBContext.ChangePassword.AsNoTracking()
                .Where(x => x.TempPassword == changePassword.TempPassword && x.Token == changePassword.Token)
                ?.FirstOrDefault();
            return await Task.FromResult(changePasswordDb);
        }

        public async Task<bool> UpdateIsValidChangePasswordAsync(ChangePassword changePassword)
        {
            _dBContext.ChangePassword.Attach(changePassword);
            _dBContext.Entry(changePassword).Property(x => x.IsValid).IsModified = true;
            var isUpdated = await _dBContext.SaveChangesAsync();
            return isUpdated == 1;
        }
    }
}