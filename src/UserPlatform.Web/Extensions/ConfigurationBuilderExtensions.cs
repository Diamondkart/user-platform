namespace UserPlatform.Web.Extensions
{
	public static class ConfigurationBuilderExtensions
	{
		public static IConfigurationRoot BuildConfiguration(this IConfigurationBuilder builder, string[] args)
		{
			return builder
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables() // optional, might be used in build/deployment pipeline
				.AddCommandLine(args)
				.Build();
		}
	}
}
