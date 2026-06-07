namespace UserPlatform.ApplicationCore.Services.CacheServices
{
    public class CacheOptions
    {
        public const string Section = "Cache";

        public string Provider { get; set; } = "None";
        public TimeSpan DefaultExpiry { get; set; } = TimeSpan.FromMinutes(5);
        public TimeSpan LocalExpiry { get; set; } = TimeSpan.FromMinutes(1);

        public InMemoryOptions InMemory { get; set; } = new();
        public RedisOptions Redis { get; set; } = new();
    }
}