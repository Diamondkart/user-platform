namespace UserPlatform.ApplicationCore.Commands
{
    public interface ICommandDispatcher
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellation);
    }
}