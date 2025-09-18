
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;


namespace TeledocTestTask.Application.DI
{
    public static class FluentValidationRegistration
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
