using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class ChangePasswordRequest : ICommand<ChangePasswordResponse>
    {
        public string UserIdentifier { get; set; }
    }
}

/*
 * PasswordChangeId, UserId, TempPassword, ExpireOn, Token, IP, MacAddress, Client
 * 
 * 
 */