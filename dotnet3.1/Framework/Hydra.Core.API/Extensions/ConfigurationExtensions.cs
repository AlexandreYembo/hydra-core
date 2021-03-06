using Microsoft.Extensions.Configuration;

namespace Hydra.Core.API.Extensions
{
    public static class ConfigurationExtensions
    {
         public static string GetRedisConnection(this IConfiguration configuration, string name) => 
            configuration?.GetSection("RedisCache")?[name];
    }
}