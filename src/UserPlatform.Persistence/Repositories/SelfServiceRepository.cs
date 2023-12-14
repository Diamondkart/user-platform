using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.Domain.Entities;
using UserPlatform.Persistence.DBStorage;
using UserPlatform.Domain.Entities.SP;

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

        public async Task<bool> UpdatePasswordAndPasswordTokenValidityAsync(UserDetails user, ChangePassword changePassword)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@password", user.Password),
                new SqlParameter("@salt", user.Salt),
                new SqlParameter("@userId", user.UserId),
                new SqlParameter("@isValid", changePassword.IsValid),
                new SqlParameter("@changePasswordId", changePassword.Id)
            };
            var result = await _dBContext.Database.ExecuteSqlRawAsync(SP.Sp_UpdatePasswordAndPasswordTokenValidity, parameters);
            return result > 0;
        }
    }
}