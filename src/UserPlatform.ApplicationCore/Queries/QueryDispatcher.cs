using MediatR;

namespace UserPlatform.ApplicationCore.Queries
{
    /// <summary>
    /// This is a wrapper around IMediaTr which is called in Controller.
    /// Used for Query operations: Get
    /// </summary>
    public class QueryDispatcher : IQueryDispatcher
    {
        private IMediator _mediator;

        public QueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellation)
        {
            return await _mediator.Send(request, cancellation);
        }
    }
}