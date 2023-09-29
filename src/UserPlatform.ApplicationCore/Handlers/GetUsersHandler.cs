using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.ApplicationCore.Services;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IEnumerable<GetUsersResponse>>
    {
        private readonly IUserService _userService;

        public GetUsersHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var userResponse = await _userService.GetUsersAsync();
            return await Task.FromResult(userResponse);
        }
    }
}
