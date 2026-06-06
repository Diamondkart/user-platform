namespace UserPlatform.ApplicationCore.Ports.Out.IServices
{
    public interface ICacheEntryOptions
    {
        TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        TimeSpan? SlidingExpiration { get; set; }
    }
}