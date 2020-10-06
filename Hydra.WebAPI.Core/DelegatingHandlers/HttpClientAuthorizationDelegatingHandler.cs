using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Hydra.WebAPI.Core.User;

namespace Hydra.WebAPI.Core.DelegatingHandlers
{
    /// <summary>
    /// Override the SendAsync of the HttpClient
    /// This class avoid you use pass the token through the Header, by intercepting the request
    /// </summary>
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IAspNetUser _user;

        public HttpClientAuthorizationDelegatingHandler(IAspNetUser user)
        {
            _user = user;
        }

        /// <summary>
        /// SendAsync implements the authorization for the header and also get the token and set to the Authorization.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _user.GetHttpContext().Request.Headers["Authorization"];

            if(!string.IsNullOrEmpty(authorizationHeader))
                request.Headers.Add("Authorization", new List<string>(){authorizationHeader});
            
            var token = _user.GetUserToken();

            if(token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}