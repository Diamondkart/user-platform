using MediatR;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class VerifyUserCredRequestHandler : IRequestHandler<VerifyUserCredRequest, bool>
    {
        private readonly ISelfService _selfService;

        public VerifyUserCredRequestHandler(ISelfService selfService) => _selfService = selfService;

        public async Task<bool> Handle(VerifyUserCredRequest request, CancellationToken cancellationToken)
        {
            return await _selfService.VerifyUserCredAsync(request);
        }
    }
}