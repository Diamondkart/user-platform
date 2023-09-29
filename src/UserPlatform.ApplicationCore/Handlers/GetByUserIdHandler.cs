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
    public class GetByUserIdHandler : IRequestHandler<GetByUserIdRequest, GetByUserIdResponse>
    {
        private readonly IUserService _userService;

        public GetByUserIdHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<GetByUserIdResponse> Handle(GetByUserIdRequest request, CancellationToken cancellationToken)
        {
            var userResponse = _userService.GetByUserByUserIdAsync(request.UserId);
            return await userResponse;
        }
    }
}
