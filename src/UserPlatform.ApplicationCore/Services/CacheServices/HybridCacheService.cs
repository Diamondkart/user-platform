using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Options;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Services.CacheServices
{
    public class HybridCacheService(HybridCache cache, IOptions<CacheOptions> opts) : ICacheService
    {
        private readonly CacheOptions _opts = opts.Value;

        public Task<T> GetOrCreateAsync<T>(
            string key,
            Func<CancellationToken, ValueTask<T>> factory,
            TimeSpan? expiry = null,
            TimeSpan? localExpiry = null,
            IEnumerable<string>? tags = null,
            CancellationToken ct = default)
        {
            var entryOpts = new HybridCacheEntryOptions
            {
                Expiration = expiry ?? _opts.DefaultExpiry,
                LocalCacheExpiration = localExpiry ?? _opts.LocalExpiry
            };

            return cache.GetOrCreateAsync(key, factory, entryOpts, tags, ct).AsTask();
        }

        public Task RemoveAsync(string key, CancellationToken ct = default)
            => cache.RemoveAsync(key, ct).AsTask();

        public Task RemoveByTagAsync(string tag, CancellationToken ct = default)
            => cache.RemoveByTagAsync(tag, ct).AsTask();

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken ct = default)
        {
            await cache.GetOrCreateAsync(
                key,
                _ => ValueTask.FromResult(value),
                new HybridCacheEntryOptions { Expiration = expiry ?? _opts.DefaultExpiry },
                cancellationToken: ct);
        }
    }
}