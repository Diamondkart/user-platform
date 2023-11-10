using MediatR;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class UpdateNameRequestHandler : IRequestHandler<UpdateNameRequest, bool>
    {
        private readonly IUserService _userService;

        public UpdateNameRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(UpdateNameRequest request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateNameAsync(request);
        }
    }
}