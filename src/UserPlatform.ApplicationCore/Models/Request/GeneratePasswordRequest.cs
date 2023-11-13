using UserPlatform.ApplicationCore.Commands;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class GeneratePasswordRequest : ICommand<bool>
    {
        public string TempPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}