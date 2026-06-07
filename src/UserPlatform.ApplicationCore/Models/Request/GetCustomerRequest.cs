using System.Text.Json.Serialization;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class GetCustomerRequest
    {
        [JsonIgnore]
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}