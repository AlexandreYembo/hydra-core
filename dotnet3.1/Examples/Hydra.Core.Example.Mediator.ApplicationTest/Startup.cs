using System;
using System.IO;
using FluentValidation.Results;
using Hydra.Core.Example.Domain.Commands;
using Hydra.Core.Example.Domain.Events.ExampleEvents;
using Hydra.Core.Mediator.Abstractions.Mediator;
using Hydra.Core.Mediator.Communication;
using Hydra.Core.Mediator.Configuration;
using Hydra.Core.Mediator.Messages;
using Hydra.Core.MessageBus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Example.Mediator.ApplicationTest
{
  public class Startup
    {
        public IConfigurationRoot configuration;

        public void Main(IServiceCollection services)
        {
          // Build configuration
          configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

          services.AddSingleton<IConfiguration>(provider => configuration);
            
          services.AddScoped<IMediatorHandler, MediatorHandler>();
          services.AddScoped<IRequestHandler<TestCommand, CommandResult<ValidationResult>>, TestCommandHandler>();
          services.AddScoped<IRequestHandler<TestCommand2, bool>, TestCommandHandler>();

          services.AddScoped<INotificationHandler<ExampleEvent>, ExampleEventHandler>();
          services.AddScoped<INotificationHandler<ExampleEvent2>, ExampleEventHandler>();
            
          services.AddMediator<Startup>();
          services.AddMessageBusConfiguration(configuration);
        }
    }
}