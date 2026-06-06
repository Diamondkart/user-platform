using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Services.CacheServices
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
        {
            return _cache.TryGetValue(key, out bool exists);
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            return _cache.Get<T>(key);
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            _cache.Remove(key);
        }

        public async Task SetAsync<T>(string key, T value, ICacheEntryOptions? options = null, CancellationToken cancellationToken = default)
        {
            _cache.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = options?.AbsoluteExpirationRelativeToNow,
                SlidingExpiration = options?.SlidingExpiration,
                Priority = CacheItemPriority.Normal
            });
        }
    }
}
