using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Queries;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class GetByUserNameRequest: IQuery<GetByUserNameResponse>
    {
        public string UserName { get; set; }
    }
}