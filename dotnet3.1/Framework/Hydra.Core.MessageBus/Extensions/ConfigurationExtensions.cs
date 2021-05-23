using Microsoft.Extensions.Configuration;

namespace Hydra.Core.MessageBus.Extensions
{
    public static class ConfigurationExtensions
    {
         public static string GetMessageQueueConnection(this IConfiguration configuration, string name) => 
            configuration?.GetSection("MessageQueueConnection")?[name];
    }
}