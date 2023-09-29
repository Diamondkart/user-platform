using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Queries;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class GetByUserIdRequest:IQuery<GetByUserIdResponse>
    {
        public Guid UserId { get; set; }
    }
}