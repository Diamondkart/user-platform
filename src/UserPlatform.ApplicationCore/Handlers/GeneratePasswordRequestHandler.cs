using MediatR;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class GeneratePasswordRequestHandler : IRequestHandler<GeneratePasswordRequest, bool>
    {
        private readonly ISelfService _selfService;

        public GeneratePasswordRequestHandler(ISelfService selfService) => _selfService = selfService;

        public async Task<bool> Handle(GeneratePasswordRequest request, CancellationToken cancellationToken)
        {
            return await _selfService.GeneratePasswordAsync(request);
        }
    }
}