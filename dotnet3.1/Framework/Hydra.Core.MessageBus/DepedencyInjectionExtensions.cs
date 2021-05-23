using System;
using Hydra.Core.Mediator.Integration;
using Hydra.Core.MessageBus.Extensions;
using Hydra.Core.MessageBus.LogEventsIntegrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.MessageBus
{
    public static class DepedencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if(string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

            services.AddSingleton<IMessageBus>(new MessageBus(connection));
            services.AddScoped<IDispatchLogEventToBus, DispatchLogEventToBus>();
            return services;
        }

        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
} 