using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserPlatform.ApplicationCore.Ports.Out.IRepositories;
using UserPlatform.Domain.Constant;
using UserPlatform.Persistence.DBStorage;
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

        public static IServiceCollection AddConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserPlatformDBContex>(options => options.UseSqlServer(configuration.GetConnectionString(Constant.ConnectionStringName)));
            return services;
        }
    }
}