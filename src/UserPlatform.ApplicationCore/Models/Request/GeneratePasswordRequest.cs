using UserPlatform.ApplicationCore.Commands;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class GeneratePasswordRequest : ICommand<bool>
    {
        public string? Token { get; set; }
        public string TempPassword { get; set; }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                var hashedPassword = Utils.Utils.GetSecurePassword(value);
                _password = hashedPassword.Item1;
                Salt = hashedPassword.Item2;
            }
        }

        public string? Salt { get; set; }
        private string _password;
    }
}