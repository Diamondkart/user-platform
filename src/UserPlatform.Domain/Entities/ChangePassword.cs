using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPlatform.Domain.Entities
{
    [Table(name: "ChangePassword")]
    public class ChangePassword
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public string TempPassword { get; set; }

        public string Token { get; set; }
        public DateTime ExpireOn { get; set; }
        public bool IsValid { get; set; }
    }
}