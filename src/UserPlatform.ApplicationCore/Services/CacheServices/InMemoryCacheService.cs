using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.Domain.Attributes;

namespace UserPlatform.ApplicationCore.Services.CacheServices
{
    [ExcludeFromScan]
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, ValueTask<T>> factory, TimeSpan? expiry = null, TimeSpan? localExpiry = null, IEnumerable<string>? tags = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByTagAsync(string tag, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
