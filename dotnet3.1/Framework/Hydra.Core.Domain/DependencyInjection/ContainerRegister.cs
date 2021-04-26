using Hydra.Core.Domain.Abstractions.Mediator;
using Hydra.Core.Domain.Communication;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Example.Domain.DependencyInjection
{
    public static class ContainerRegister
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            return services;
        }
    }
}