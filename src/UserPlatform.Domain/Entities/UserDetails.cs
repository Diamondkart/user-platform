using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPlatform.Domain.Entities
{
    [Table("UserDetails")]
    public class UserDetails
    {
        [Key]
        public Guid UserId { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long MobileNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsLocked { get; set; }
        public string Salt { get; set; }
        
    }
}