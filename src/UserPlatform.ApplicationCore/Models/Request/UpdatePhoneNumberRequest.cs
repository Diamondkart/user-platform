using System.Text.Json.Serialization;
using UserPlatform.ApplicationCore.Commands;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class UpdatePhoneNumberRequest : ICommand<bool>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        public long PhoneNumber { get; set; }
    }
}