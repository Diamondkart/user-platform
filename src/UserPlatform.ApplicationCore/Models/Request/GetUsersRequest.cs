using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Queries;

namespace UserPlatform.ApplicationCore.Models.Request
{
    public class GetUsersRequest:IQuery<IEnumerable<GetUsersResponse>>
    {       
    }
}
