using UserPlatform.Domain.Entities;

namespace UserPlatform.ApplicationCore.Ports.Out.IRepositories
{
    public interface ISelfServiceRepository
    {
        Task<ChangePassword> RequestChangePasswordAsync(ChangePassword changePassword);

        Task<bool> GeneratePasswordAsync(UserDetails userDetails);

        Task<ChangePassword> GetChangePasswordByTokenPasswordAsync(ChangePassword changePassword);

        Task<bool> UpdatePasswordAndPasswordTokenValidityAsync(UserDetails user, ChangePassword changePassword);
    }
}