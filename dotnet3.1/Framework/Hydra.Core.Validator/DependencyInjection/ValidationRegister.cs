using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Core.Validator.DependencyInjection
{
    public static class ValidationRegister
    {
        public static void RegisterValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidationResult, ValidationResultAdapter>();
        }
    }
}