namespace UserPlatform.ApplicationCore.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellation);
    }
}