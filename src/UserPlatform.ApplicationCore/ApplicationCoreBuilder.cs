using Microsoft.Extensions.DependencyInjection;
using UserPlatform.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore
{
    public static class ApplicationCoreBuilder
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationCoreBuilder).Assembly));
            services.AddAutoMapper(typeof(ApplicationCoreBuilder));
            //services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            //services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ISelfService, SelfService>();
            //services.AddScoped<ICustomerService, CustomerService>();
            services.Scan(scan => scan
            .FromAssemblyOf<IUserService>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}