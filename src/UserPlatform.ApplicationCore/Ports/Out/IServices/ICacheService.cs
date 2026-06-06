using Microsoft.Extensions.Caching.Memory;
namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface ICacheService
    {
        Task SetAsync<T>(
            string key,
            T value,
            ICacheEntryOptions? options = null,
            CancellationToken cancellationToken = default);

        Task<T?> GetAsync<T>(
            string key,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(
            string key,
            CancellationToken cancellationToken = default);

        Task RemoveAsync(
            string key,
            CancellationToken cancellationToken = default);
    }
}