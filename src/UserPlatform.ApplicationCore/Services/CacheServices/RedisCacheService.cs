using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Services.CacheServices
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
        {
            return false;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            var bytes = await _cache.GetAsync(key);

            if (bytes is not null)
            {
                var cacheValue = JsonSerializer.Deserialize<T>(bytes);
                return cacheValue;
            }
            return default(T?);
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task SetAsync<T>(string key, T value, ICacheEntryOptions? options = null, CancellationToken cancellationToken = default)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value);

            await _cache.SetAsync(key, bytes, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = options?.AbsoluteExpirationRelativeToNow,
                SlidingExpiration = options?.SlidingExpiration,
            });
        }
    }
}