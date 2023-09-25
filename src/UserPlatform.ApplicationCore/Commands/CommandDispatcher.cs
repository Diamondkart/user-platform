using MediatR;

namespace UserPlatform.ApplicationCore.Commands
{
    /// <summary>
    /// This is a wrapper around IMediaTr which is called in Controller.
    /// Used for Command operations: Create, Update, Delete, Execute.
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private IMediator _mediator;

        public CommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}