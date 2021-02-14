using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.API.Extensions
{
    /// <summary>
    /// Class used to validate the SSL Certificate
    /// </summary>
    public static class HttpExtensions
    {
        public static IHttpClientBuilder AllowSelfSignedCertificate(this IHttpClientBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.ConfigureHttpMessageHandlerBuilder(b =>
            {
                b.PrimaryHandler = 
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
            });
        }
    }
}