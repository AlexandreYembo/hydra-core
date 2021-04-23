using Hydra.Core.gRPC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.gRPC.Config
{
    public static class GrpcInterceptorConfig
    {
        /// <summary>
        /// Register interceptors for gRPC
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddgGRPCInterceptor(this IHttpClientBuilder builder)
        {
            builder.AddInterceptor<GRPCServiceInterceptor>();
            return builder;
        }

         /// <summary>
        /// Register interceptors for gRPC
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static void RegisterInterceptor(this IServiceCollection services)
        {
            services.AddSingleton<GRPCServiceInterceptor>();

        }
    }
}