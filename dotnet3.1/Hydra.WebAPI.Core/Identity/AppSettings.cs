namespace Hydra.WebAPI.Core.Identity
{
    public class AppSettings
    {
        
        public string Secret { get; set; }
        public double ExpirationTime { get; set; }
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
    }
}