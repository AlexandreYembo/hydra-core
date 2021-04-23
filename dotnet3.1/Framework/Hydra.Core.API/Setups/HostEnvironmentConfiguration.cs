using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Hydra.Core.API.Setups
{
    public static class HostEnvironmentConfiguration
    {
        /// <summary>
        /// Set the host environment for the configuration
        /// DEV, TEST or PROD
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hostEnvironment"></param>
        public static IConfigurationRoot AddHostEnvironment(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(hostEnvironment.ContentRootPath)
                               .AddJsonFile("appsettings.json", true, true)
                               .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                               .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}