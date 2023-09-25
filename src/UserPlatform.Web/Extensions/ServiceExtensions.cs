using UserPlatform.ApplicationCore;

namespace UserPlatform.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            return services;
        }
		public static bool IsLocal(this IHostEnvironment hostEnvironment)
		{
			return hostEnvironment.EnvironmentName.Equals("Local", StringComparison.OrdinalIgnoreCase);
		}
	}
}
