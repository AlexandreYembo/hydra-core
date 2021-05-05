using Hydra.Core.Abstractions.Data.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Data.Query.DependencyInjection
{
   public static class ContainerRegister
    {
        public static IServiceCollection RegisterQueryRepository(this IServiceCollection services)
        {
            services.AddScoped<IQueryRepository, QueryRepository>();
            return services;
        }
    }
}