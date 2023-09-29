using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class GetByUserNameHandler : IRequestHandler<GetByUserNameRequest, GetByUserNameResponse>
    {
        private readonly IUserService _userService;

        public GetByUserNameHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetByUserNameResponse> Handle(GetByUserNameRequest request, CancellationToken cancellationToken)
        {
            var userResponse = _userService.GetByUserNameAsync(request.UserName);
            return await userResponse;
        }
    }
}
