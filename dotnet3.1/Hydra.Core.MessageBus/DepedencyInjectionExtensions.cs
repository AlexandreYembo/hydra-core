using System;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.MessageBus
{
    public static class DepedencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if(string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

            services.AddSingleton<IMessageBus>(new MessageBus(connection));
            return services;
        }
    }
} 