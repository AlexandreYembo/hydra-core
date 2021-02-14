using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Hydra.Core.gRPC.Services
{
    /// <summary>
    /// Will work on the scope of singleton
    /// It does not inject AspNetUser because it is injected in the scope, It will need to use
    /// IHttpContextorAccessor to replace the AspNetUser library.
    /// </summary>
    public class GRPCServiceInterceptor : Interceptor
    {
        private readonly ILogger<GRPCServiceInterceptor> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GRPCServiceInterceptor(ILogger<GRPCServiceInterceptor> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// This is how I will call my grpc service from the server.
        /// This method override to provide the token via header to call the GRPC server.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <param name="continuation"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
                        TRequest request, 
                        ClientInterceptorContext<TRequest, TResponse> context, 
                        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            var headers = new Metadata
            {
                {"Authorization", token}
            };

            //It will take my request context that I intercepted and I will add headers
            var options = context.Options.WithHeaders(headers);

            //It will create a new context to understand that there is a new header
            context = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, options);

            return base.AsyncUnaryCall(request, context, continuation);
        }
    }
}