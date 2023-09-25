namespace UserPlatform.ApplicationCore.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellation);
    }
}