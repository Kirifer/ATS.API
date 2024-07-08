using Microsoft.Extensions.DependencyInjection;
using Ats.Core.Extensions;

namespace Ats.Core.ApiConfig
{
    public static class EntityServiceConfig
    {
        public static IServiceCollection AddCoreEntityServices<TService>(
            this IServiceCollection services,
            string assemblyName)
        {
            services.RegisterAssemblies<TService>(assemblyName, DependencyLifetime.Scoped);
            return services;
        }
    }
}
