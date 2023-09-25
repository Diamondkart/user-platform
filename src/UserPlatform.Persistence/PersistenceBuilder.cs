using Microsoft.Extensions.DependencyInjection;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.Persistence.Repositories;

namespace UserPlatform.Persistence
{
    public static class PersistenceBuilder
    {
        public static IServiceCollection AddPersistenceBuilderServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}