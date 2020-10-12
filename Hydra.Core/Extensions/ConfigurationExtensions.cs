using Microsoft.Extensions.Configuration;

namespace Hydra.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetMessageQueueConnection(this IConfiguration configuration, string name) => 
            configuration?.GetSection("MessasgeQueueConnection")?[name];
    }
}