using Microsoft.Extensions.DependencyInjection;
using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Ports.Out.IServices;
using UserPlatform.ApplicationCore.Queries;
using UserPlatform.ApplicationCore.Services;

namespace UserPlatform.ApplicationCore
{
    public static class ApplicationCoreBuilder
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationCoreBuilder).Assembly));
            services.AddAutoMapper(typeof(ApplicationCoreBuilder));
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISelfService, SelfService>();
            
            return services;
        }
    }
}