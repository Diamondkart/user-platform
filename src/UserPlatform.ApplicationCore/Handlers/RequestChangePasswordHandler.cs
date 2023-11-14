using MediatR;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Models.Response;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class RequestChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
    {
        private readonly ISelfService _selfService;

        public RequestChangePasswordHandler(ISelfService selfService) => _selfService = selfService;

        public async Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var response=await _selfService.RequestChangePasswordAsync(request);
            return response;
        }
    }
}