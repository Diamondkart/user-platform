using Microsoft.Extensions.Caching.Memory;
namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T>> factory,
        TimeSpan? expiry = null,
        TimeSpan? localExpiry = null,
        IEnumerable<string>? tags = null,
        CancellationToken ct = default);

        Task RemoveAsync(string key, CancellationToken ct = default);
        Task RemoveByTagAsync(string tag, CancellationToken ct = default);
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default);
    }
}