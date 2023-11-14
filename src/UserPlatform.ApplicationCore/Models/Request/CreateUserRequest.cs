using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Response;
using static UserPlatform.ApplicationCore.Utils.Utils;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class CreateUserRequest : ICommand<CreateUserResponse>
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                var hashedPassword = GetSecurePassword(value);
                SecurePassword = hashedPassword.Password;
                Salt = hashedPassword.Salt;
            }
        }

        private string _password;

        public long MobileNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsLocked { get; set; }

        public string SecurePassword { get; set; }

        public string Salt { get; set; }
    }
}