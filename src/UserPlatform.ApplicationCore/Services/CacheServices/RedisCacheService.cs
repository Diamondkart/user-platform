using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.Domain.Attributes;

namespace UserPlatform.ApplicationCore.Services.CacheServices
{
    [ExcludeFromScan]
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, ValueTask<T>> factory, TimeSpan? expiry = null, TimeSpan? localExpiry = null, IEnumerable<string>? tags = null, CancellationToken ct = default)
        {
            var bytes = await _cache.GetAsync(key, ct);

            if (bytes is not null)
                return JsonSerializer.Deserialize<T>(bytes)!;

            var value = await factory(ct);

            await _cache.SetAsync(key, JsonSerializer.SerializeToUtf8Bytes(value),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromMinutes(5)
                }, ct);

            return value;
        }

        public Task RemoveAsync(string key, CancellationToken ct = default)
            => _cache.RemoveAsync(key, ct);

        public Task RemoveByTagAsync(string tag, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default)
        {
            await _cache.SetAsync(key, JsonSerializer.SerializeToUtf8Bytes(value),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromMinutes(5)
                }, ct);
        }
    }
}