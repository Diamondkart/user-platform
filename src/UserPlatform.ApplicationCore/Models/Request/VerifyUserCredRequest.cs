using UserPlatform.ApplicationCore.Commands;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class VerifyUserCredRequest:ICommand<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}