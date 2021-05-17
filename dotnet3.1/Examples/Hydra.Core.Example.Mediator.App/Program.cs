using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using Hydra.Core.Example.Domain.Commands;
using Hydra.Core.Mediator.Abstractions.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Example.Mediator.App
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = RegisterStartup();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediatorHandler>();

            var result = await mediator.SendCommand<TestCommand, ValidationResult>(new TestCommand("Test Sending command"));
        }

        private static ServiceCollection RegisterStartup()
        {
            var serviceCollection = new ServiceCollection();
            Startup.Main(serviceCollection);

            return serviceCollection;
        }
    }
}
