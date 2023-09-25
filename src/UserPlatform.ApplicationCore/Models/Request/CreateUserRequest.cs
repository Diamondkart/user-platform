using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class CreateUserRequest : ICommand<CreateUserResponse>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}