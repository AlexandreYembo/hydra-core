using Hydra.Core.Example.Domain.Commands;
using Hydra.Core.Mediator.Abstractions.Mediator;
using Hydra.Core.Mediator.Communication;
using Hydra.Core.Mediator.Messages;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Example.Mediator.App
{
  public static class Startup
    {
        public static IConfigurationRoot configuration;

        public static void Main(IServiceCollection services)
        {
           // Build configuration
        // configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
        //     .AddJsonFile("appsettings.json", false)
        //     .Build();

        //     services.AddSingleton<IConfiguration>(provider => configuration);
            
           services.AddScoped<IMediatorHandler, MediatorHandler>();
           services.AddScoped<IRequestHandler<TestCommand, CommandResult<TestCommandResult>>, TestCommandHandler>();
            
            services.AddMediatR(typeof(Startup));
        }
    }
}