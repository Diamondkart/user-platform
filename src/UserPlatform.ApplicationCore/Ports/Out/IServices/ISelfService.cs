using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface ISelfService
    {
        Task<ChangePasswordResponse> RequestChangePasswordAsync(ChangePasswordRequest changePasswordRequest);

        Task<bool> GeneratePasswordAsync(GeneratePasswordRequest generatePasswordRequest);
        Task<bool> VerifyUserCredAsync(VerifyUserCredRequest verifyUserCredRequest);


    }
}