using System.Text.Json.Serialization;
using UserPlatform.ApplicationCore.Commands;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class UpdateNameRequest : ICommand<bool>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}