namespace Hydra.WebAPI.Core.Identity
{
    public class AppSettings
    {
        
        /// <summary>
        /// it will read the public key from the endpoint
        /// example: localhost/jwks
        /// </summary>
        /// <value></value>
        public string AuthenticationJwksUrl { get; set; }
    }
}