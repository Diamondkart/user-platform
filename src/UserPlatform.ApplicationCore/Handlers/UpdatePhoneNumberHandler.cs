using MediatR;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class UpdatePhoneNumberHandler : IRequestHandler<UpdatePhoneNumberRequest, bool>
    {
        private readonly IUserService _userService;

        public UpdatePhoneNumberHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(UpdatePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            return await _userService.UpdatePhoneNumberAsync(request);
        }
    }
}