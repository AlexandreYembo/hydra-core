using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Mediator.Configuration
{
    public static class MediatorRegister
    {
        public static IServiceCollection AddMediator<T>(this IServiceCollection services)
        {
           services.AddMediatR(typeof(T));

           return services;
        }   
    }
}