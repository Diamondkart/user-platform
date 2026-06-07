using Microsoft.Extensions.Caching.Hybrid;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.ApplicationCore.Services.CacheServices;

namespace UserPlatform.Web.Extensions
{
    public static class CacheServiceExtensions
    {
        public static IServiceCollection AddCacheService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var opts = configuration.GetSection(CacheOptions.Section).Get<CacheOptions>()
                       ?? new CacheOptions();

            services.Configure<CacheOptions>(configuration.GetSection(CacheOptions.Section));

            // Register L2 based on provider
            switch (opts.Provider.ToLowerInvariant())
            {
                case "redis":
                    services.AddStackExchangeRedisCache(o =>
                    {
                        o.Configuration = configuration.GetConnectionString("Redis");
                        o.InstanceName = opts.Redis.InstanceName;
                    });
                    break;

                case "inmemory":
                    services.AddDistributedMemoryCache(o =>
                    {
                        if (opts.InMemory.SizeLimit.HasValue)
                            o.SizeLimit = opts.InMemory.SizeLimit;
                    });
                    break;

                case "none":
                default:
                    break;
            }

            // HybridCache always registered — adapts to whatever L2 is present
            services.AddHybridCache(o =>
            {
                o.DefaultEntryOptions = new HybridCacheEntryOptions
                {
                    Expiration = opts.DefaultExpiry,
                    LocalCacheExpiration = opts.LocalExpiry
                };
            });

            services.AddSingleton<ICacheService, HybridCacheService>();
            return services;
        }
    }
}