using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TeledocTestTask.Application.DI
{
    public static class MediatRRegistration
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
