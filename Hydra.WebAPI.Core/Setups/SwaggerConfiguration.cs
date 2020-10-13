using System;
using Hydra.WebAPI.Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Hydra.WebAPI.Core.Setups
{
    public static class SwaggerConfiguration
    {
         public static void AddSwaggerConfiguration(this IServiceCollection services, SwaggerConfig config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(config.Version, new OpenApiInfo()
                {
                    Title =  config.Title,
                    Description = config.Description,
                    Contact = new OpenApiContact() { Name = "Alexandre Yembo"},
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT")}
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insert the JWT token using this format: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, SwaggerConfig config)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint($"/swagger/{config.Version}/swagger.json", config.Version);
                c.RoutePrefix = "";
            });
        }
    }
}