using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public static IServiceCollection UseFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Program>();
            return services;
        }

        public static IMvcBuilder UseApiBehaviorOptions(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.ConfigureApiBehaviorOptions(options =>
             {
                 options.InvalidModelStateResponseFactory = context =>
                 {
                     // Key is the model property name
                     var fieldErrors = new List<KeyValuePair<string, string[]>>();
                     foreach (var modelStateKey in context.ModelState.Keys)
                     {
                         var modelStateVal = context.ModelState[modelStateKey];
                         if (modelStateVal?.ValidationState == ModelValidationState.Invalid)
                         {
                             var errors = modelStateVal.Errors.Select(x => x.ErrorMessage).ToArray();
                             fieldErrors.Add(KeyValuePair.Create(modelStateKey, errors));
                         }
                     }

                     var errorResult = new
                     {
                         Errors = fieldErrors.ToDictionary(x => x.Key, x => x.Value)
                     };

                     return new BadRequestObjectResult(errorResult)
                     {
                         ContentTypes = { "application/problem+json", "application/problem+xml" }
                     };
                 };
             });
            return mvcBuilder;
        }
    }
}