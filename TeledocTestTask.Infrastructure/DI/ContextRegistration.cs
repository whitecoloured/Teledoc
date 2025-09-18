using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TeledocTestTask.Infrastructure.Context;

namespace TeledocTestTask.Infrastructure.DI
{
    public static class ContextRegistration
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<TeledocContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
